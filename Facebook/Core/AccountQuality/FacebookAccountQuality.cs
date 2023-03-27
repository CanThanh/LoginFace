using Facebook.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                }
                else
                {
                    facebookProcessing.LoginFace(driver, url, account.Id, account.Pass, account.TwoFA);
                    account.Cookie = CommonFunction.GetCookie(driver);
                }

                var dtsg = facebookProcessing.GetDTSGToken(driver);
                var eaag = facebookProcessing.GetEAAGToken(driver, account.Id, account.TwoFA, dtsg, account.Cookie);
                //string eaab = facebookProcessing.GetEAABToken(driver);
                var kq = facebookProcessing.GetUserInfoSecond(eaag, account.Cookie);
                url = "https://www.facebook.com/accountquality/100001633161446";
                driver.Navigate().GoToUrl(url);
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
