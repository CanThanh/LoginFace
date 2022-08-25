using HtmlAgilityPack;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using xNet;

namespace XMDT
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
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
            inf.EmailRecover = infAccount[5];

            //Mail mail = new Mail();
            //mail.Verify(inf.Email, inf.PassMail, "outlook.office365.com", 993);

            string chromeDriverPath = currentDirectory + "\\Library";
            
            var options = new ChromeOptions();
            options.AddArgument("no-sandbox");
            //options.AddArgument("--proxy-server=http://" + proxy);
            var proxyQA = new Proxy();
            proxyQA.HttpProxy = proxy;
            options.Proxy = proxyQA;
            options.AddArgument("--user-agent=" + userAgent);
            ChromeDriver driver = new ChromeDriver(chromeDriverPath, options, TimeSpan.FromDays(20)); 


            string url = "https://login.live.com/login.srf?wa=wsignin1.0&rpsnv=13&ct=1656739386&rver=7.0.6737.0&wp=MBI_SSL&wreply=https%3a%2f%2foutlook.live.com%2fowa%2f%3fnlp%3d1%26RpsCsrfState%3d7426e649-3fef-467b-6e2b-6026c58ea03b&id=292841&aadredir=1&CBCXT=out&lw=1&fl=dob%2cflname%2cwld&cobrandid=90015";
            string urlFace = "https://m.facebook.com/login/?ref=dbl&fl";
            //string urlFace = "https://www.google.com";
            string urlAddMailFace = "https://m.facebook.com/ntdelegatescreen/?params=%7B%22entry-point%22%3A%22settings%22%7D&path=%2Fcontacts%2Fmanagement%2F";
            //div[@id='u_9_26_O0']       //div[contains(., "Add email address")]

            //string urlFaceInfo = "https://m.facebook.com/profile.php?v=info&_rdr";

            //LoginFace(driver, urlFace, inf.Id, inf.Pass, inf.TwoFA );
            //GetCodeHotMail(driver, url, inf.Email, inf.PassMail);
        }

        private FaceInfo GetFaceInfo(ChromeDriver driver, string url, string userId)
        {
            FaceInfo result = new FaceInfo();
            driver.Url = url;
            driver.Navigate().GoToUrl(url);
            Thread.Sleep(1000);
            var html = driver.FindElement(By.XPath("html")).GetInnerHTML();
            HtmlAgilityPack.HtmlDocument document = new HtmlAgilityPack.HtmlDocument();
            document.LoadHtml(html);
            //result.DateOfBirth = document.DocumentNode.SelectSingleNode("//div[contains(@class,'basic - info')]//div[@class='_5cdv r']").InnerText;
            result.Id = userId;
            var works = document.DocumentNode.SelectNodes("//div[@id='work']//div[@class='_c3u']//span");
            foreach (var item in works)
            {
                result.Works.Add(item.InnerText);
            }
            var educations = document.DocumentNode.SelectNodes("//div[@id='education']//div[@class='_c3u']//span");
            foreach (var item in educations)
            {
                result.Educations.Add(item.InnerText);
            }
            var places = document.DocumentNode.SelectNodes("//div[@id='education']//div[@class='_c3u']//span");
            foreach (var item in places)
            {
                result.Places.Add(item.InnerText);
            }
            var basicInfo = document.DocumentNode.SelectNodes("//div[@id='basic-info']//div[@class='_5cdv r']");
            result.DateOfBirth = basicInfo[0].InnerText;
            result.Gender = basicInfo[1].InnerText;
            return result;
        }

        private void LoginFace(ChromeDriver driver, string url, string user, string pass, string twoFA)
        {
            driver.Url = url;
            driver.Navigate().GoToUrl(url);
            Thread.Sleep(1000);
            driver.FindElement(By.XPath("//input[@name='email']")).SendKeys(user);
            Thread.Sleep(1000);
            driver.FindElement(By.XPath("//input[@name='pass']")).SendKeys(pass);
            Thread.Sleep(1000);
            driver.FindElement(By.XPath("//button[@name='login']")).Click();
            Thread.Sleep(3000);
            var html = driver.FindElement(By.XPath("html")).GetInnerHTML();
            var nodeCode = driver.FindElement(By.XPath("//input[@name='approvals_code']"));
            //https://m.facebook.com/checkpoint/?__req=4
            if (nodeCode != null)
            {
                string url2Fa = "https://2fa.live/tok/";
                var faCode = GetData(url2Fa + twoFA);
                string pattern = @"\d+";
                Regex rg = new Regex(pattern);
                string code = rg.Match(faCode).Value;
                driver.FindElement(By.XPath("//input[@name='approvals_code']")).SendKeys(code);
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

        private string GetCodeHotMail(ChromeDriver driver, string url, string user, string pass)
        {
            string result = "";
            driver.Url = url;
            driver.Navigate().GoToUrl(url);
            driver.FindElement(By.XPath("//input[@name='loginfmt']")).SendKeys(user);
            driver.FindElement(By.XPath("//input[@id='idSIButton9']")).Click();
            Thread.Sleep(1000);
            driver.FindElement(By.XPath("//input[@name='passwd']")).SendKeys(pass);
            driver.FindElement(By.XPath("//input[@id='idSIButton9']")).Click();
            Thread.Sleep(1000);
            driver.FindElement(By.XPath("//input[@id='idSIButton9']")).Click();
            Thread.Sleep(2000);

            var html = driver.FindElement(By.XPath("html")).GetInnerHTML();
            HtmlAgilityPack.HtmlDocument document = new HtmlAgilityPack.HtmlDocument();
            document.LoadHtml(html);
            var itemnodes = document.DocumentNode.SelectNodes("//div[@class='customScrollBar BW6l9']//div[@class='jA_gm']");
            foreach (var item in itemnodes)
            {
                HtmlAgilityPack.HtmlDocument documentItem = new HtmlAgilityPack.HtmlDocument();
                documentItem.LoadHtml(item.InnerHtml);
                var title = documentItem.DocumentNode.SelectSingleNode("//div[contains(@class,'Lf0qr')]//span").InnerText;
                var abcd2 = documentItem.DocumentNode.SelectSingleNode("//span[@class='JLM0t MtC_r jYIx5']").InnerText;
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

        void AddCookie(HttpRequest http, string cookie)
        {
            var temp = cookie.Split(';');
            foreach (var item in temp)
            {
                var temp2 = item.Split('=');
                if (temp2.Count() > 1)
                {
                    http.Cookies.Add(temp2[0], temp2[1]);
                }
            }
        }
    }
}
