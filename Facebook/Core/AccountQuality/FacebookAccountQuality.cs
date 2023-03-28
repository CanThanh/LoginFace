using Facebook.Model;
using Newtonsoft.Json.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V85.IndexedDB;
using OpenQA.Selenium.Interactions;
using OtpNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Keys = OpenQA.Selenium.Keys;

namespace Facebook.Core.AccountQuality
{
    internal class FacebookAccountQuality
    {
        public bool Proccess(AccountInfo account, int rowIndex, string resolveCaptchaKey, bool loginCookie = false)
        {
            bool result = true;
            Random random = new Random();
            string source = "";
            FacebookProcessing facebookProcessing = new FacebookProcessing();
            var driver = facebookProcessing.InitChromeDriver(account);
            string url = "https://m.facebook.com/";
            try
            {
                if (loginCookie)
                {
                    facebookProcessing.LoginCookie(driver, url, account.Cookie);
                    driver.Navigate().GoToUrl(url);
                    Thread.Sleep(2000);
                }
                else
                {
                    facebookProcessing.LoginFace(driver, url, account.Id, account.Pass, account.TwoFA);
                    account.Cookie = CommonFunction.GetCookie(driver);
                }

                string infor = "";
                //driver.Navigate().GoToUrl("https://business.facebook.com/business_locations/");
                //Thread.Sleep(TimeSpan.FromSeconds(3));

                //string faCode = new Totp(Base32Encoding.ToBytes(account.TwoFA)).ComputeTotp();
                //Actions builder = new Actions(driver);
                //builder.MoveByOffset(310, 250).Click().Perform();
                //Thread.Sleep(500);
                //builder.SendKeys(faCode).Perform();
                //builder.KeyDown(Keys.Enter).Perform();

                //Thread.Sleep(3000);
                //string token = "EAAG";
                //source = driver.PageSource;
                //if (source.Contains("EAAG"))
                //{
                //    token += source.Split(new[] { "EAAG" }, StringSplitOptions.None)[1].Split('"')[0];
                //}
                //if(token.Length > 4)
                //{
                //    infor = facebookProcessing.GetUserInfoSecond(token, account.Cookie);
                //}                

                infor = "{\r\n   \"first_name\": \"Chuan\",\r\n   \"last_name\": \"Ah\",\r\n   \"name\": \"Chuan Ah\",\r\n   \"birthday\": \"08/31/1991\",\r\n   \"gender\": \"male\",\r\n   \"id\": \"100002536610524\"\r\n}";


                //url = "https://www.facebook.com/accountquality/100001633161446";
                //driver.Navigate().GoToUrl(url);                
                var abcd = 1;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return result;
        }
    }
}
