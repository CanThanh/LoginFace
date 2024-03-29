﻿using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System.Text.RegularExpressions;
using xNet;
using MailKit.Net.Imap;
using MailKit.Search;
using MailKit;

namespace Facebook.Core
{
    internal class MailProcessing
    {
        /// <summary>
        /// Xác nhận đồng ý gửi vào tài khoản mail
        /// </summary>
        /// <param name="email">user đăng nhập</param>
        /// <param name="pass">pass đăng nhập</param>
        /// <param name="ipmap">ipmap</param>
        /// <param name="port">port</param>
        public void Verify(string email, string pass, string ipmap, int port)
        {
            string url = null;
            using (ImapClient client = new ImapClient())
            {
                client.Connect(ipmap, port);
                client.Authenticate(email, pass);
                client.Inbox.Open(FolderAccess.ReadOnly);
                var uids = client.Inbox.Search(SearchQuery.All);
                for (int i = 0; i < uids.Count; i++)
                {

                }
                //for (mailcount = client.GetMessageCount(); mailcount < 2; mailcount = client.GetMessageCount())
                //{
                //    MailProcessing.Delay(5);
                //    client.SelectMailbox("INBOX");
                //}
                //MailMessage[] mm = client.GetMessages(mailcount - 1, mailcount - 1, false, false);
                //MailMessage[] array = mm;
                //for (int j = 0; j < array.Length; j++)
                //{
                //    MailMessage i = array[j];
                //    {
                //        string sbody = i.Body;
                //        url = Regex.Match(i.Body, "abcd").Groups[1].Value;
                //        bool flag2 = string.IsNullOrEmpty(url);
                //        if (flag2)
                //        {
                //            url = Regex.Match(i.Body, "(http.*)").Groups[1].Value.Trim();
                //            url = url.Substring(0, url.IndexOf('"'));
                //        }
                //        break;
                //    }
                //}
                client.Dispose();
            }
            HttpRequest rq = new HttpRequest();
            rq.Cookies = new CookieDictionary(false);
            rq.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/69.0.3497.92 Safari/537.36";
            bool Load = false;
            while (!Load)
            {
                try
                {
                    rq.Get(url, null);
                    Load = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public string GetCode(string email, string pass, string ipmap, int port, string strRegex)
        {
            string result = null;
            using (ImapClient client = new ImapClient())
            {
                client.Connect(ipmap, port);
                client.Authenticate(email, pass);
                client.Inbox.Open(FolderAccess.ReadOnly);
                var uids = client.Inbox.Search(SearchQuery.All);
                for (int i = 0; i < uids.Count; i++)
                {

                }
                //client.Connect(ipmap, port, true, false);
                //client.Login(email, pass);
                //client.SelectMailbox("INBOX");
                //int mailcount;
                //for (mailcount = client.GetMessageCount(); mailcount < 2; mailcount = client.GetMessageCount())
                //{
                //    MailProcessing.Delay(5);
                //    client.SelectMailbox("INBOX");
                //}
                //MailMessage[] mm = client.GetMessages(mailcount - 50, mailcount -1, false, false);
                ////MailMessage[] mm = client.GetMessages(0, 20, false, false);
                //MailMessage[] array = mm;
                //for (int j = array.Length - 1; j > 0; j--)
                //{
                //    MailMessage i = array[j];
                //    {
                //        if (i.Subject.ToLower().Contains("facebook") && i.From.Address.ToLower().Contains("security"))
                //        {
                //            string sbody = i.Body;
                //            result = Regex.Match(i.Body, strRegex).Value;
                //            if(result.Length  >= 6)
                //            {
                //                return result;
                //            }
                //        }
                //    }
                //}
                client.Dispose();
            }
            return result;
        }

        private void Delay(int time)
        {
            for (int i = 0; i < time; i++)
            {
                Thread.Sleep(time);
            }
        }

        private List<string> GetCodeHotMail(ChromeDriver driver, string url, string user, string pass)
        {
            List<string> result = new List<string>();
            driver.Url = url;
            driver.Navigate().GoToUrl(url);
            CommonFunction.SendKeyByXPath(driver, "//input[@name='loginfmt']", user);
            driver.FindElement(By.XPath("//input[@id='idSIButton9']")).Click();
            Thread.Sleep(2000);
            CommonFunction.SendKeyByXPath(driver, "//input[@name='passwd']", pass);
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
    }
}
