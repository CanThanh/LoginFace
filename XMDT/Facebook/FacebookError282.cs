using OpenQA.Selenium;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using XMDT.Controller;
using XMDT.Model;

namespace XMDT.Facebook
{
    internal class FacebookError282
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

        public bool Process(int i)
        {
            bool result = false;
            FacebookProcessing facebookProcessing = new FacebookProcessing();
            var driver = facebookProcessing.InitChromeDriver();
            //driver.Navigate().GoToUrl("https://m.facebook.com/");
            facebookProcessing.LoginCookie(driver, lstAccount[i].Cookie);
            var options = new RestClientOptions("https://www.fbsbx.com")
            {
                MaxTimeout = -1,
            };
            var client = new RestClient(options);
            var request = new RestRequest("/captcha/recaptcha/iframe/", Method.Get);
            RestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);
            Thread.Sleep(3000);
            ResolveCaptcha resolveCaptcha  = new ResolveCaptcha();
            resolveCaptcha.APIKey = "8893da60ce756a9ad13321321cf028f2";
            string output = "";
            resolveCaptcha.SolveRecaptchaV2("6Lc9qjcUAAAAADTnJq5kJMjN9aD1lxpRLMnCS2TR", "https://www.google.com/recaptcha/api2/anchor?ar=1&k=6Lc9qjcUAAAAADTnJq5kJMjN9aD1lxpRLMnCS2TR&co=aHR0cHM6Ly93d3cuZmJzYnguY29tOjQ0Mw..&hl=vi&v=tNAc29ZZrpcOCErva2nr4BS9&theme=light&size=normal&cb=8pver0ijdn37/", out output);
            //var googlecaptcha = driver.FindElement(By.XPath("//div[@class='g-recaptcha']"));
            return result;
        }
    }
}
