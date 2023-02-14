using OpenQA.Selenium;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using XMDT.Controller;
using XMDT.Model;
using xNet;

namespace XMDT.Facebook
{
    internal class FacebookError282 : CommonFunction
    {
        List<Information> lstAccount;

        public void GetAllAccount(string path)
        {
            lstAccount = new List<Information>();
            FileHelper fileHelper = new FileHelper();
            var lstData = fileHelper.ReadLine(path);
            for (int i = 0; i < lstData.Count() - 1; i++)
            {
                var data = lstData[i].Split('|');
                lstAccount.Add(new Information
                {
                    Id= data[0],
                    Pass= data[1],
                    Cookie= data[2],
                    EAAAAAY= data[3],
                }); 
            }
        }

        public bool ProcessFacbook(int i)
        {
            bool result = false;
            var client = InitRestClientOption(lstAccount[i].Cookie);
            FacebookProcessing facebookProcessing = new FacebookProcessing();
            string url = "https://m.facebook.com/";
            var driver = facebookProcessing.InitChromeDriver();
            facebookProcessing.LoginCookie(driver, url, lstAccount[i].Cookie);
            driver.Navigate().GoToUrl("https://m.facebook.com/");
            Thread.Sleep(5000);
            var dtsg = driver.FindElement(By.XPath("//input[@name='fb_dtsg']")).GetValue();
            lstAccount[i].DTSG = dtsg;

            ////https://facebook.com/
            var variables = "{\"input\":{\"client_mutation_id\":\"1\",\"actor_id\":\"" + lstAccount[i].Id + "\",\"action\":\"PROCEED\",\"enrollment_id\":null},\"scale\":1}";
            var captcha_persist_data1 = "";
            var response = ApiSubmit(client, lstAccount[i].Id, dtsg, variables);
            if (response.Contains("captcha_persist_data"))
            {
                captcha_persist_data1 = response.Split(new[] { "\"captcha_persist_data\":\"" }, StringSplitOptions.None)[1].Split('"')[0];
            }
            driver.Navigate().GoToUrl(url);
            var captcha_persist_data = driver.FindElement(By.XPath("//input[@name='captcha_persist_data']")).GetValue();

            var request = new RestRequest("/captcha/recaptcha/iframe/", Method.Get);
            var options = new RestClientOptions("https://www.fbsbx.com")
            {
                MaxTimeout = -1,
            };
            client = new RestClient(options);
            request.AddHeader("referer", url);
            RestResponse responseResolveCaptcha = client.Execute(request);
            string googleKey = "";
            if (responseResolveCaptcha.Content.Contains("data-sitekey=\"")){
                googleKey = responseResolveCaptcha.Content.Split(new[] { "data-sitekey=\"" },StringSplitOptions.None)[1].Split('"')[0];
            }

            ResolveCaptcha resolveCaptcha  = new ResolveCaptcha();
            resolveCaptcha.APIKey = "90b9de403cd4c42f45a4f9048760dec0";
            string outputCapcha = "";
            resolveCaptcha.SolveRecaptchaV2(googleKey, "https://m.facebook.com/checkpoint/1501092823525282/", out outputCapcha);

            client = InitRestClientOption(lstAccount[i].Cookie);
            var variablesResolveCaptcha = "{\"input\":{\"client_mutation_id\":\"1\",\"actor_id\":\"" + lstAccount[i].Id + "\",\"action\":\"SUBMIT_BOT_CAPTCHA_RESPONSE\",\"bot_captcha_persist_data\":\"" + captcha_persist_data + "\",\"bot_captcha_response\":\"" + outputCapcha + "\",\"enrollment_id\":null},\"scale\":1}";
            var temp = ApiSubmit(client, lstAccount[i].Id, dtsg, variablesResolveCaptcha);
            return result;
        }

        public bool ProcessMBasicFacbook(int i)
        {
            bool result = false;
            var client = InitRestClientOption(lstAccount[i].Cookie);
            FacebookProcessing facebookProcessing = new FacebookProcessing();
            var driver = facebookProcessing.InitChromeDriver();
            string url = "https://mbasic.facebook.com/";
            facebookProcessing.LoginCookie(driver, url,lstAccount[i].Cookie);
            driver.Navigate().GoToUrl(url);
            var dtsg = driver.FindElement(By.XPath("//input[@name='fb_dtsg']")).GetValue();
            var lstImg = driver.FindElements(By.XPath("//img"));
            string base64Img = "";
            foreach (var item in lstImg)
            {
                var productSrc = item.GetDomAttribute("src");
                if (!string.IsNullOrEmpty(productSrc) && productSrc.Contains("captcha"))
                {
                    HttpRequest http = new HttpRequest();
                    AddCookie(http, lstAccount[i].Cookie);
                    var byteImg = http.Get(productSrc);
                    //base64Img = Convert.ToBase64String(byteImg);
                    base64Img = byteImg.ToString();
                }     
            }
            lstAccount[i].DTSG = dtsg;
            var variables = "{\"input\":{\"client_mutation_id\":\"1\",\"actor_id\":\"" + lstAccount[i].Id + "\",\"action\":\"PROCEED\",\"enrollment_id\":null},\"scale\":1}";
            var captcha_persist_data1 = "";
            var response = ApiSubmit(client, lstAccount[i].Id, dtsg, variables);
            if (response.Contains("captcha_persist_data"))
            {
                captcha_persist_data1 = response.Split(new[] { "\"captcha_persist_data\":\"" }, StringSplitOptions.None)[1].Split('"')[0];
            }
            ResolveCaptcha resolveCaptcha = new ResolveCaptcha();
            resolveCaptcha.APIKey = "90b9de403cd4c42f45a4f9048760dec0";
            string outputCapcha = "";

            resolveCaptcha.SolveNormalCapcha(base64Img, out outputCapcha);
            Thread.Sleep(2000);
            return result;
        }

        private string ApiSubmit(RestClient client, string user, string dtsg, string variables)
        {          
            var request = new RestRequest("/api/graphql/", Method.Post);
            request.AddHeader("authority", "www.facebook.com");
            request.AddHeader("accept", "*/*");
            request.AddHeader("accept-language", "en-US,en;q=0.9");
            request.AddHeader("origin", "https://www.facebook.com");
            request.AddHeader("referer", "https://www.facebook.com/checkpoint/1501092823525282/");
            request.AddHeader("sec-ch-prefers-color-scheme", "light");
            request.AddHeader("sec-ch-ua", "\"Chromium\";v=\"110\", \"Not A(Brand\";v=\"24\", \"Google Chrome\";v=\"110\"");
            request.AddHeader("sec-ch-ua-mobile", "?0");
            request.AddHeader("sec-ch-ua-platform", "\"Windows\"");
            request.AddHeader("sec-fetch-dest", "empty");
            request.AddHeader("sec-fetch-mode", "cors");
            request.AddHeader("sec-fetch-site", "same-origin");
            request.AddHeader("viewport-width", "1920");
            request.AddHeader("x-fb-friendly-name", "useUFACSubmitActionMutation");
            request.AddHeader("x-fb-lsd", "cF6xCQVEOeUZYLivLqxvU_");
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddParameter("av", user);
            request.AddParameter("__user", user);
            request.AddParameter("__a", "1");
            request.AddParameter("__dyn", "7xeUmwFwIxu1syUbFuC0BVU98nwgU29zEdEc8co2qwJwbS1DwUx60p-0LVE4W0om782Cw8G1nzUO0n2US1vw9m1YwBgao6C0Mo5W3S7Udo5qfK0zEkxe2Gew9O22362W5olw8Xwn82Lx-0iS2S3qazo720Bo2cwMwiU8U6C1pg661pw");
            request.AddParameter("__csr", "gLJb_kSimFkiaiyB-8y9kuUyKG8RGF4A8QEzh9pqxmmqqbHDGUW4UfXjxi3C12w-xu5UG1CwcC3e1twqo8odEW2mFo5S0oO0bEw05bJw0sdU074u");
            request.AddParameter("__req", "m");
            request.AddParameter("__hs", "19402.HYP:comet_pkg.2.1.0.2.1");
            request.AddParameter("dpr", "1");
            request.AddParameter("__ccg", "GOOD");
            request.AddParameter("__rev", "1006954403");
            request.AddParameter("__s", "xdrdop:l2s08s:mq72f3");
            request.AddParameter("__hsi", "7199828983379981054");
            request.AddParameter("__comet_req", "15");
            request.AddParameter("fb_dtsg", dtsg);
            request.AddParameter("jazoest", "25325");
            request.AddParameter("lsd", "cF6xCQVEOeUZYLivLqxvU_");
            request.AddParameter("__aaid", "3353109934941181");
            request.AddParameter("__spin_r", "1006954403");
            request.AddParameter("__spin_b", "trunk");
            request.AddParameter("__spin_t", "1676340816");
            request.AddParameter("fb_api_caller_class", "RelayModern");
            request.AddParameter("fb_api_req_friendly_name", "useUFACSubmitActionMutation");
            request.AddParameter("variables", variables);
            request.AddParameter("server_timestamps", "false");
            request.AddParameter("doc_id", "6055984694465012");
            RestResponse response = client.Execute(request);
            return response.Content;
        }
        private RestClient InitRestClientOption(string cookie)
        {
            var options = new RestClientOptions("https://www.facebook.com")
            {
                MaxTimeout = -1,
                UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/110.0.0.0 Safari/537.36",
                //Proxy = new WebProxy("", Int32.Parse("")){
                //Credentials = new NetworkCredential(proxySettings.Username, proxySettings.Password, proxySettings.Domain)
                //};,

            };
            var client = new RestClient(options);
            if (!string.IsNullOrEmpty(cookie))
            {
                var lstCookie = cookie.Split(';');
                foreach (var item in lstCookie)
                {
                    var nameValue = item.Split('=');
                    if (nameValue.Count() > 1)
                    {
                        client.CookieContainer.Add(new System.Net.Cookie(nameValue[0], nameValue[1], "/", "www.facebook.com"));
                    }
                }
            }
            return client;
        }
    }
}
