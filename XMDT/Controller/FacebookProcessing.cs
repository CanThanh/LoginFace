using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OtpNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using xNet;
using XMDT.Model;

namespace XMDT.Controller
{
    public  class FacebookProcessing : CommonFunction
    {
        public ChromeDriver InitChromeDriver()
        {
            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("no-sandbox");
            //chromeOptions.AddArguments("incognito");
            //chromeOptions.AddArgument("--start-maximized");
            //chromeOptions.AddArgument("--ignore-certificate-errors");
            //chromeOptions.AddArgument("--disable-popup-blocking");
            //chromeOptions.AddArgument("--disable-web-security");
            //chromeOptions.AddExtension("");

            ChromeDriverService chromeDriverService = ChromeDriverService.CreateDefaultService();
            chromeDriverService.HideCommandPromptWindow = true;
            //chromeDriverService.SuppressInitialDiagnosticInformation = true;

            //options.AddArgument("--proxy-server=http://" + proxy);
            //var proxyQA = new Proxy();
            //proxyQA.HttpProxy = proxy;
            //options.Proxy = proxyQA;
            //options.AddArgument("--user-agent=" + userAgent);

            ChromeDriver driver = new ChromeDriver(chromeDriverService, chromeOptions);
            return driver;
        }        

        public void GetFaceInfo(ChromeDriver driver, string url, List<FaceInfo> faceInfos, string userId, bool isUpdate = false)
        {
            FaceInfo result = new FaceInfo();
            driver.Url = url;
            driver.Navigate().GoToUrl(url);
            Thread.Sleep(1000);
            var html = driver.FindElement(By.XPath("html")).GetInnerHTML();
            HtmlAgilityPack.HtmlDocument document = new HtmlAgilityPack.HtmlDocument();
            document.LoadHtml(html);
            result.Id = userId;
            var existUser = faceInfos.FirstOrDefault(x => x.Id == userId);
            if (existUser != null && !isUpdate)
            {
                return;
            }

            var works = document.DocumentNode.SelectNodes("//div[@id='work']//div[@class='_c3u']//span");
            if (works != null)
            {
                foreach (var item in works)
                {
                    result.Works.Add(item.InnerText);
                }
            }

            var educations = document.DocumentNode.SelectNodes("//div[@id='education']//div[@class='_c3u']//span");
            if (educations != null)
            {
                foreach (var item in educations)
                {
                    result.Educations.Add(item.InnerText);
                }
            }

            var places = document.DocumentNode.SelectNodes("//div[@id='education']//div[@class='_c3u']//span");
            if (places != null)
            {
                foreach (var item in places)
                {
                    result.Places.Add(item.InnerText);
                }
            }

            var basicInfo = document.DocumentNode.SelectNodes("//div[@id='basic-info']//div[@class='_5cdv r']");
            if (basicInfo != null)
            {
                result.DateOfBirth = basicInfo[0].InnerText;
                result.Gender = basicInfo[1].InnerText;
            }

            var nicknames = document.DocumentNode.SelectNodes("//div[@id='nicknames']//h3[@class='_52jg']");
            if (nicknames != null)
            {
                foreach (var item in nicknames)
                {
                    result.OtherNames.Add(item.InnerText);
                }
            }

            var relationShip = document.DocumentNode.SelectSingleNode("//div[@id='relationship']//div[@class='_52ja _5cds _5cdt']");
            if (relationShip != null)
            {
                result.RelationShip = relationShip.InnerText;

            }

            var familyMembers = document.DocumentNode.SelectNodes("//div[@id='family']//div[@class='title mfsm fcb']");
            if (familyMembers != null)
            {
                foreach (var item in familyMembers)
                {
                    result.FamilyMember.Add(item.InnerText);
                }
            }

            var about = document.DocumentNode.SelectSingleNode("//div[@id='bio']//div[@class='_5cds _2lcw _5cdt']");
            if (about != null)
            {
                result.About = about.InnerText;
            }

            var favourite = document.DocumentNode.SelectSingleNode("//div[@id='quote']//div[@class='_5cds _2lcw _5cdt']");
            if (favourite != null)
            {
                result.Favourite = favourite.InnerText;
            }

            var friends = document.DocumentNode.SelectNodes("//div[@id='profile-card']//div[@class='title mfsm fcb']");
            if (friends != null)
            {
                foreach (var item in friends)
                {
                    result.Friends.Add(item.InnerText);
                }
            }
            if (existUser != null)
            {
                if (isUpdate)
                {
                    existUser.Works = result.Works;
                    existUser.Educations = result.Educations;
                    existUser.Places = result.Places;
                    existUser.Email = result.Email;
                    existUser.DateOfBirth = result.DateOfBirth;
                    existUser.Gender = result.Gender;

                    existUser.About = result.About;
                    existUser.OtherNames = result.OtherNames;
                    existUser.RelationShip = result.RelationShip;
                    existUser.Favourite = result.Favourite;
                    existUser.FamilyMember = result.FamilyMember;
                    existUser.Friends = result.Friends;
                }
            }
            else
            {
                faceInfos.Add(result);
            }
            //return result;
        }

        #region Login
        public void LoginFace(ChromeDriver driver, string url, string user, string pass, string twoFA)
        {
            driver.Url = url;
            driver.Navigate().GoToUrl(url);
            Thread.Sleep(1000);
            SendKeyByXPath(driver, "//input[@name='email']", user);
            SendKeyByXPath(driver, "//input[@name='pass']", pass);
            Thread.Sleep(1000);
            driver.FindElement(By.XPath("//button[@name='login']")).Click();
            Thread.Sleep(3000);
            var html = driver.FindElement(By.XPath("html")).GetInnerHTML();
            var nodeCode = driver.FindElement(By.XPath("//input[@name='approvals_code']"));
            //https://m.facebook.com/checkpoint/?__req=4
            if (nodeCode != null)
            {
                string faCode = new Totp(Base32Encoding.ToBytes(twoFA)).ComputeTotp();
                SendKeyByXPath(driver, "//input[@name='approvals_code']", faCode);
                Thread.Sleep(1000);
                driver.FindElement(By.XPath("//button[@type='submit']")).Click();
                Thread.Sleep(2000);
                var radioBtn = driver.FindElements(By.Name("name_action_selected"));
                for (int i = 0; i < radioBtn.Count; i++)
                {
                    string val = radioBtn[i].GetAttribute("value");
                    if (val.ToLower() == "dont_save")
                    {
                        radioBtn[i].Click();
                    }
                }
                Thread.Sleep(1000);
                driver.FindElement(By.XPath("//button[@type='submit']")).Click();
            }
        }

        public bool LoginCookie(ChromeDriver driver, string cookie)
        {
            bool result = false;
            driver.Navigate().GoToUrl("https://www.facebook.com");
            driver.Manage().Cookies.DeleteAllCookies();
            var lstCookie = cookie.Split(';');
            for (int i = 0; i < lstCookie.Length; i++)
            {
                string key = lstCookie[i].Split('=')[0].Trim();
                string value = lstCookie[i].Split('=')[1].Trim();
                //OpenQA.Selenium.Cookie osCookie = new Cookie(key,value,".facebook.com","/", DateTime.Now.AddDays(1));
                OpenQA.Selenium.Cookie osCookie = new Cookie(key, value);
                driver.Manage().Cookies.AddCookie(osCookie);
            }
            driver.Navigate().GoToUrl("https://www.facebook.com");
            if (!string.IsNullOrEmpty(GetEAABToken(driver)))
            {
                result = true;
            }
            return result;
        }
        #endregion Login

        #region GetToken
        public string GetEAAGToken(ChromeDriver driver, string user, string twoFA, string dtsg, string cookie)
        {
            //Vào trang business lấy token
            driver.Url = "https://business.facebook.com/content_management/";
            Thread.Sleep(3000);
            var respone = CallAuthenTwoFa(user, twoFA, dtsg, cookie);
            Thread.Sleep(5000);
            driver.Url = "https://business.facebook.com/content_management/";
            Thread.Sleep(10000);
            string source = driver.PageSource;
            string token = "EAAG";
            if (source.Contains("EAAG"))
            {
                token += source.Split(new[] { "EAAG" }, StringSplitOptions.None)[1].Split('"')[0];
            }
            return token;
        }

        public string CallAuthenTwoFa(string user, string twoFA, string dtsg, string cookie)
        {
            string faCode = new Totp(Base32Encoding.ToBytes(twoFA)).ComputeTotp();
            HttpRequest httprequest = new HttpRequest();
            AddCookie(httprequest, cookie);
            var data = "approvals_code=" + faCode + "&save_device=false&__user=" + user + "&__a=1&__dyn=7xeUmF3EfXpUS2q3mbwyyVuC2-m2q3Kq2i5Uf9E6C7UW3q5UgDxW4E8U6ydwJwCwmUO0BoiyEqx68w9q15wfO1YCwjHwuk9wgovyolwuEsxe687C2m3K2y1nUS0jG12KdwnU5W0IU9kbxR12ewi85W1bxq1uG3G48W2a5Ey19zUcE28wdq1iwKwHxa1XwnFU2DxiaBw4kxa4UCfwSyES2e0UE2ZwiU8U6C0yEco5C&__csr=&__req=8&__hs=19395.BP%3ADEFAULT.2.0.0.0.0&dpr=1.5&__ccg=GOOD&__rev=1006920906&__s=6hjwrm%3A3vhtq1%3Aspfsji&__hsi=7197324973317924624&__comet_req=0&fb_dtsg=" + dtsg + "&jazoest=25525&lsd=Q7Feqpz-TcfK27ydcQVNhN&__aaid=191881262750333&__spin_r=1006920906&__spin_b=trunk&__spin_t=1675757806&__jssesw=1";
            var response = httprequest.Post("https://business.facebook.com/security/twofactor/reauth/enter/", data, "application/x-www-form-urlencoded; charset=UTF-8").ToString();
            return response;
        }

        public string GetEAAGTokenApi(string user, string cookie)
        {
            HttpRequest request = new HttpRequest();
            AddCookie(request, cookie);
            var respone = request.Get("https://business.facebook.com/content_management/").ToString();
            string token = "EAAG";
            if (respone.Contains("EAAG"))
            {
                token += respone.Split(new[] { "EAAG" }, StringSplitOptions.None)[1].Split('"')[0];
            }
            return token;
        }
        public string GetEAABToken(ChromeDriver driver)
        {
            //Vào trang quảng cáo pe lấy token
            driver.Url = "https://www.facebook.com/pe";
            Thread.Sleep(2000);
            string source = driver.PageSource;
            string token = "EAAB" + source.Split(new[] { "EAAB" }, StringSplitOptions.None)[1].Split('"')[0];
            return token;
        }

        public string GetDTSGToken(ChromeDriver driver)
        {
            string source = driver.PageSource;
            string token = source.Split(new[] { "\"token\":\"" }, StringSplitOptions.None)[1].Split('"')[0];
            return token;
        }
        #endregion
    }
}
