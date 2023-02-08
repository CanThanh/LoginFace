using Newtonsoft.Json;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools;
using OpenQA.Selenium.DevTools.V85.IndexedDB;
using OpenQA.Selenium.Support.UI;
using OtpNet;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using xNet;

namespace XMDT
{
    public partial class Form1 : Form
    {
        private List<FaceInfo> faceInfos;
        public Form1()
        {
            InitializeComponent();
            faceInfos = new List<FaceInfo>();
        }
        //100007557514409  snowkvt123  B6R546Q2K26FCFOTLU2MUKT3ANYWLRYY   micshidevon@hotmail.com     @thainguyenteam@@1022020    micshidevon2022 @getnada.com
        //100009306396626  snowkvt1234  76IZ6TLE4XTKIWFRIKCVQSWYSRMZRWQN	alishauemargie@hotmail.com  @thainguyenteam@@1022020    alishauemargie2022@getnada.com
        private void btnProgess_Click(object sender, EventArgs e)
        {
            string currentDirectory = Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(Environment.CurrentDirectory)));
            FileHelper fileHelper = new FileHelper();
            var pathUserAgent = currentDirectory + "\\File\\ua.txt";
            var userAgent = fileHelper.ReadLine(pathUserAgent)[Rand.Next(0, fileHelper.ReadLine(pathUserAgent).Count)];
            Information inf = new Information();

            var pathProxy = currentDirectory + "\\File\\proxy.txt";
            var proxy = fileHelper.ReadLine(pathProxy)[Rand.Next(0, fileHelper.ReadLine(pathProxy).Count)];

            var pathAccount = currentDirectory + "\\File\\account.txt";
            var account = fileHelper.ReadLine(pathAccount)[Rand.Next(0, fileHelper.ReadLine(pathAccount).Count)];

            var pathSecondaryEmail = currentDirectory + "\\File\\secondaryemail.txt";
            var strSecondaryEmail = fileHelper.ReadLine(pathSecondaryEmail)[Rand.Next(0, fileHelper.ReadLine(pathSecondaryEmail).Count)];
            var secondaryEmail = new SecondaryEmail();
            var infSecondaryEmail = strSecondaryEmail.Split('|');
            secondaryEmail.Email = infSecondaryEmail[0];
            secondaryEmail.Pass = infSecondaryEmail[1];

            //var infAccount = Regex.Replace(account, @"[\s]", "!@#$%^&*").Split(new string[] { "!@#$%^&*" }, StringSplitOptions.None);
            var infAccount = account.Split(' ');
            inf.Id = infAccount[0];
            inf.Pass = infAccount[1];
            inf.TwoFA = infAccount[2];
            inf.Email = infAccount[3];
            inf.PassMail = infAccount[4];
            //inf.EmailRecover = infAccount[5];

            Mail mail = new Mail();
            var code = mail.GetCode(inf.Email, inf.PassMail, "outlook.office365.com", 993, @"\d+");

            var driver = InitChromeDriver();

            string urlMail = "https://login.live.com/login.srf?wa=wsignin1.0&rpsnv=13&ct=1656739386&rver=7.0.6737.0&wp=MBI_SSL&wreply=https%3a%2f%2foutlook.live.com%2fowa%2f%3fnlp%3d1%26RpsCsrfState%3d7426e649-3fef-467b-6e2b-6026c58ea03b&id=292841&aadredir=1&CBCXT=out&lw=1&fl=dob%2cflname%2cwld&cobrandid=90015";
            string urlFace = "https://m.facebook.com/login/?ref=dbl&fl";
            string urlAddMailFace = "https://m.facebook.com/ntdelegatescreen/?params=%7B%22entry-point%22%3A%22settings%22%7D&path=%2Fcontacts%2Fmanagement%2F";
            string urlFaceInfo = "https://m.facebook.com/profile.php?v=info&_rdr";

            //string cookie = "presence=EDvF3EtimeF1675742421EuserFA21B03574129834A2EstateFDutF0CEchF_7bCC;cppo=1;m_page_voice=100003574129834;xs=10%3AAA9MUI7T-hnOGg%3A2%3A1675742409%3A-1%3A11945;c_user=100003574129834;locale=vi_VN;wd=929x879;m_pixel_ratio=1;fr=05YnzmcTSx7a2u5xz.AWUqjLht6jYAmSiSj46xHsf97qg.Bj4cy5.7Q.AAA.0.0.Bj4czH.AWVw7EQ79Wg;usida=eyJ2ZXIiOjEsImlkIjoiQXJwb3o0aDQwdno4MyIsInRpbWUiOjE2NzU3NDI0MTd9;sb=uczhYxqd-jNUJ7QzKES0Nu_B;datr=uczhY2GY8sB6sc4tUfXL3Lgj";

            //string cookie2 = "datr=1LvhY1pGpki2WZzFaXc-8f_v; sb=1LvhY8qSzVz63ESQJCNrjd0F; m_pixel_ratio=1; locale=vi_VN; fr=0Pgf72nltOesLADqP.AWVXDWEUwUp1p8bY1yjfnz6a6UU.Bj4bvU.5z.AAA.0.0.Bj4bvi.AWWjB2-UB7Q; c_user=100003574129834; xs=44%3ATITPFBpdERQNnA%3A2%3A1675738084%3A-1%3A11945; m_page_voice=100003574129834; cppo=1; usida=eyJ2ZXIiOjEsImlkIjoiQXJwb3hyaTE2ZXJ3MWYiLCJ0aW1lIjoxNjc1NzQwNzM1fQ%3D%3D; presence=EDvF3EtimeF1675740790EuserFA21B03574129834A2EstateFDutF0CEchF_7bCC; wd=1920x372";

            //LoginFace(driver, urlFace, inf.Id, inf.Pass, inf.TwoFA );
            ////LoginCookie(driver, cookie2);
            //string eaab = GetEAABToken(driver);
            //string dtsg = GetDTSGToken(driver);

            //string cookie = GetCookie(driver);


            ////string eaag = GetEAAGToken(driver, inf.Id, inf.TwoFA, dtsg, cookie);
            //CallAuthenTwoFa(inf.Id, inf.TwoFA, dtsg, cookie);
            //string eaag = GetEAAGTokenApi(inf.Id, cookie);

            //GetFaceInfo(driver, urlFaceInfo, inf.Id);
            //WriteFile(currentDirectory + "\\File\\userInfo.json");
            //ReadFile(currentDirectory + "\\File\\userInfo.json");

            //GetCodeHotMail(driver, urlMail, inf.Email, inf.PassMail);

            var hoangnv1 = "hoangnv1";
        }

        private ChromeDriver InitChromeDriver()
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

        private void SendKeyByXPath(ChromeDriver driver, string xPath, string key)
        {
            Random random = new Random();
            var randomValue = random.NextDouble();
            if (randomValue < 0.9)
            {
                foreach (var item in key)
                {
                    driver.FindElement(By.XPath(xPath)).SendKeys(item.ToString());
                    Thread.Sleep(50);
                }
            }
            else
            {
                var randomIndex = random.Next(key.Length - 1);
                for (int i = 0; i < randomIndex; i++)
                {
                    driver.FindElement(By.XPath(xPath)).SendKeys(key[i].ToString());
                    Thread.Sleep(50);
                }
                //Ghi 1 chữ cái sai rồi xóa bỏ
                var character = 65 + random.Next(26);
                driver.FindElement(By.XPath(xPath)).SendKeys(Convert.ToChar(character).ToString());
                Thread.Sleep(100);
                driver.FindElement(By.XPath(xPath)).SendKeys(Convert.ToChar(8).ToString());
                Thread.Sleep(100);
                driver.FindElement(By.XPath(xPath)).SendKeys(key[randomIndex].ToString());
                //
                for (int i = randomIndex + 1; i < key.Length; i++)
                {
                    Thread.Sleep(50);
                    driver.FindElement(By.XPath(xPath)).SendKeys(key[i].ToString());
                }
            }
        }

        private void GetFaceInfo(ChromeDriver driver, string url, string userId, bool isUpdate = false)
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

        private void LoginFace(ChromeDriver driver, string url, string user, string pass, string twoFA)
        {
            driver.Url = url;
            driver.Navigate().GoToUrl(url);
            Thread.Sleep(1000);
            SendKeyByXPath(driver, "//input[@name='email']", user);
            driver.FindElement(By.XPath("//input[@name='pass']")).SendKeys(pass);
            Thread.Sleep(1000);
            driver.FindElement(By.XPath("//button[@name='login']")).Click();
            Thread.Sleep(3000);
            var html = driver.FindElement(By.XPath("html")).GetInnerHTML();
            var nodeCode = driver.FindElement(By.XPath("//input[@name='approvals_code']"));
            //https://m.facebook.com/checkpoint/?__req=4
            if (nodeCode != null)
            {
                string faCode = new Totp(Base32Encoding.ToBytes(twoFA)).ComputeTotp();
                driver.FindElement(By.XPath("//input[@name='approvals_code']")).SendKeys(faCode);
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

        private bool LoginCookie(ChromeDriver driver, string cookie)
        {
            bool result = false;
            driver.Navigate().GoToUrl("https://www.facebook.com");
            driver.Manage().Cookies.DeleteAllCookies();
            var lstCookie = cookie.Split(';');
            for (int i = 0; i < lstCookie.Length; i++)
            {
                string key = lstCookie[i].Split('=')[0].Trim();
                string value = lstCookie[i].Split('=')[1].Trim();
                //OpenQA.Selenium.Cookie osCookie = new Cookie(key,value,"facebook.com","/", DateTime.Now.AddDays(1));
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

        #region GetToken
        private string GetEAAGToken(ChromeDriver driver, string user, string twoFA, string dtsg, string cookie)
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

        private string CallAuthenTwoFa(string user, string twoFA, string dtsg, string cookie)
        {
            string faCode = new Totp(Base32Encoding.ToBytes(twoFA)).ComputeTotp();
            HttpRequest httprequest = new HttpRequest();
            AddCookie(httprequest, cookie);
            var data = "approvals_code=" + faCode + "&save_device=false&__user=" + user + "&__a=1&__dyn=7xeUmF3EfXpUS2q3mbwyyVuC2-m2q3Kq2i5Uf9E6C7UW3q5UgDxW4E8U6ydwJwCwmUO0BoiyEqx68w9q15wfO1YCwjHwuk9wgovyolwuEsxe687C2m3K2y1nUS0jG12KdwnU5W0IU9kbxR12ewi85W1bxq1uG3G48W2a5Ey19zUcE28wdq1iwKwHxa1XwnFU2DxiaBw4kxa4UCfwSyES2e0UE2ZwiU8U6C0yEco5C&__csr=&__req=8&__hs=19395.BP%3ADEFAULT.2.0.0.0.0&dpr=1.5&__ccg=GOOD&__rev=1006920906&__s=6hjwrm%3A3vhtq1%3Aspfsji&__hsi=7197324973317924624&__comet_req=0&fb_dtsg=" + dtsg + "&jazoest=25525&lsd=Q7Feqpz-TcfK27ydcQVNhN&__aaid=191881262750333&__spin_r=1006920906&__spin_b=trunk&__spin_t=1675757806&__jssesw=1";
            var response = httprequest.Post("https://business.facebook.com/security/twofactor/reauth/enter/", data, "application/x-www-form-urlencoded; charset=UTF-8").ToString();
            return response;
        }

        private string GetEAAGTokenApi(string user, string cookie)
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
        private string GetEAABToken(ChromeDriver driver)
        {
            //Vào trang quảng cáo pe lấy token
            driver.Url = "https://www.facebook.com/pe";
            Thread.Sleep(2000);
            string source = driver.PageSource;
            string token = "EAAB" + source.Split(new[] { "EAAB" }, StringSplitOptions.None)[1].Split('"')[0];
            return token;
        }

        private string GetDTSGToken(ChromeDriver driver)
        {
            string source = driver.PageSource;
            string token = source.Split(new[] { "\"token\":\"" }, StringSplitOptions.None)[1].Split('"')[0];
            return token;
        }
        #endregion

        private List<string> GetCodeHotMail(ChromeDriver driver, string url, string user, string pass)
        {
            List<string> result = new List<string>();
            driver.Url = url;
            driver.Navigate().GoToUrl(url);
            driver.FindElement(By.XPath("//input[@name='loginfmt']")).SendKeys(user);
            driver.FindElement(By.XPath("//input[@id='idSIButton9']")).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//input[@name='passwd']")).SendKeys(pass);
            driver.FindElement(By.XPath("//input[@id='idSIButton9']")).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//input[@id='idSIButton9']")).Click();
            Thread.Sleep(3000);

            var buttons = driver.FindElements(By.XPath("//button[contains(@class,'ms-Pivot-link')]"));
            foreach (var button in buttons)
            {
                button.Click();
                Thread.Sleep(2000);
                driver.ExecuteScript("window.scrollTo(0, 10);");
                Thread.Sleep(1000);
                var itemnodes = driver.FindElements(By.XPath("//div[contains(@class,'hcptT gDC9O')]"));
                foreach (var item in itemnodes)
                {
                    var temp = item.GetInnerHTML();
                    var text = item.Text;
                    if (text.ToLower().Contains("facebook"))
                    {
                        var code = Regex.Match(text, @"\d{6,8}").Value;
                        if (code.Length >= 6)
                        {
                            result.Add(code);
                        }
                    }
                }
            }

            return result;
        }



        private string GetData(string url, HttpRequest http = null, string userArgent = "", string cookie = null)
        {
            if (http == null)
            {
                http = new HttpRequest();
                http.Cookies = new CookieDictionary();
            }

            if (!string.IsNullOrEmpty(cookie))
            {
                AddCookie(http, cookie);
            }

            if (!string.IsNullOrEmpty(userArgent))
            {
                http.UserAgent = userArgent;
            }
            string html = http.Get(url).ToString();
            return html;
        }

        private string GetCookie(ChromeDriver driver)
        {
            string cookie = "";
            try
            {
                var lstCookie = driver.Manage().Cookies.AllCookies;
                for (int i = 0; i < lstCookie.Count; i++)
                {
                    string name = lstCookie.ElementAt(i).Name.ToString().Trim();
                    string value = lstCookie.ElementAt(i).Value.ToString().Trim();
                    if (!string.IsNullOrEmpty(name))
                    {
                        cookie += $"{name}={value};";
                    }
                }
            }
            catch (Exception)
            {
                return "";
            }
            return cookie;
        }

        private void AddCookie(HttpRequest http, string cookie)
        {
            var lstCookie = cookie.Split(';');
            foreach (var item in lstCookie)
            {
                var nameValue = item.Split('=');
                if (nameValue.Count() > 1)
                {
                    http.Cookies.Add(nameValue[0], nameValue[1]);
                }
            }
        }

        private void ReadFile(string filePath)
        {
            faceInfos.Clear();
            FileHelper fileHelper = new FileHelper();
            var strData = fileHelper.Read(filePath);
            faceInfos = JsonConvert.DeserializeObject<List<FaceInfo>>(strData);
        }

        private void WriteFile(string filePath)
        {
            FileHelper fileHelper = new FileHelper();
            var strData = JsonConvert.SerializeObject(faceInfos);
            fileHelper.Write(filePath, strData);
        }

        public byte[] FileToByteArra(string fileName)
        {
            byte[] buff = null;
            FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
            long numBytes = new FileInfo(fileName).Length;
            buff = br.ReadBytes((int)numBytes);
            return buff;
        }
    }
}
