using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using xNet;
using Facebook.Model;
using static Facebook.Model.CommonConstant;
using Facebook.Core;
using OtpNet;
using OpenQA.Selenium.Chromium;
using OpenQA.Selenium.Chrome.ChromeDriverExtensions;
using Facebook.Otp;
using System.Drawing.Imaging;
using System.Security.Policy;
using System.Security.Principal;
using System;
using Newtonsoft.Json;

namespace Facebook.Core
{
    public  class FacebookProcessing
    {
        public ChromeDriver InitChromeDriver(AccountInfo account)
        {
            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("no-sandbox");
            //chromeOptions.AddArgument("--auto-open-devtools-for-tabs");
            //chromeOptions.AddArguments("incognito");
            //chromeOptions.AddArgument("--start-maximized");
            //chromeOptions.AddArgument("--ignore-certificate-errors");
            //chromeOptions.AddArgument("--disable-popup-blocking");
            //chromeOptions.AddArgument("--disable-web-security");
            //chromeOptions.AddExtension("");

            if (!string.IsNullOrEmpty(account.Proxy))
            {
                if (account.TypeProxy == (int)TypeProxy.HttpProxy)
                {
                    if (account.Proxy.Contains("@"))
                    {
                        var proxysplit = account.Proxy.Split('@');
                        chromeOptions.AddHttpProxy(proxysplit[1].Split(':')[0], Convert.ToInt32(proxysplit[1].Split(':')[1]), proxysplit[0].Split(':')[0], proxysplit[0].Split(':')[1]);
                    }
                    else
                    {
                        chromeOptions.AddArgument("--proxy-server=http://" + account.Proxy);
                    }
                }
                else
                {
                    chromeOptions.AddArgument("--proxy-server=socks5://" + account.Proxy);
                }
            }

            if (!string.IsNullOrEmpty(account.UserAgent))
            {
                chromeOptions.AddArgument("--user-agent=" + account.UserAgent);
            }

            ChromeDriverService chromeDriverService = ChromeDriverService.CreateDefaultService();
            chromeDriverService.HideCommandPromptWindow = true;
            //chromeDriverService.SuppressInitialDiagnosticInformation = true;

            ChromeDriver driver = new ChromeDriver(chromeDriverService, chromeOptions);
            driver.Manage().Window.Size = new Size(945, 1024);
 
            return driver;
        }        

        //public void GetFaceInfo(ChromeDriver driver, string url, List<FaceInfo> faceInfos, string userId, bool isUpdate = false)
        //{
        //    FaceInfo result = new FaceInfo();
        //    driver.Url = url;
        //    driver.Navigate().GoToUrl(url);
        //    Thread.Sleep(1000);
        //    var html = driver.FindElement(By.XPath("html")).GetInnerHTML();
        //    HtmlAgilityPack.HtmlDocument document = new HtmlAgilityPack.HtmlDocument();
        //    document.LoadHtml(html);
        //    result.Id = userId;
        //    var existUser = faceInfos.FirstOrDefault(x => x.Id == userId);
        //    if (existUser != null && !isUpdate)
        //    {
        //        return;
        //    }

        //    var works = document.DocumentNode.SelectNodes("//div[@id='work']//div[@class='_c3u']//span");
        //    if (works != null)
        //    {
        //        foreach (var item in works)
        //        {
        //            result.Works.Add(item.InnerText);
        //        }
        //    }

        //    var educations = document.DocumentNode.SelectNodes("//div[@id='education']//div[@class='_c3u']//span");
        //    if (educations != null)
        //    {
        //        foreach (var item in educations)
        //        {
        //            result.Educations.Add(item.InnerText);
        //        }
        //    }

        //    var places = document.DocumentNode.SelectNodes("//div[@id='education']//div[@class='_c3u']//span");
        //    if (places != null)
        //    {
        //        foreach (var item in places)
        //        {
        //            result.Places.Add(item.InnerText);
        //        }
        //    }

        //    var basicInfo = document.DocumentNode.SelectNodes("//div[@id='basic-info']//div[@class='_5cdv r']");
        //    if (basicInfo != null)
        //    {
        //        result.DateOfBirth = basicInfo[0].InnerText;
        //        result.Gender = basicInfo[1].InnerText;
        //    }

        //    var nicknames = document.DocumentNode.SelectNodes("//div[@id='nicknames']//h3[@class='_52jg']");
        //    if (nicknames != null)
        //    {
        //        foreach (var item in nicknames)
        //        {
        //            result.OtherNames.Add(item.InnerText);
        //        }
        //    }

        //    var relationShip = document.DocumentNode.SelectSingleNode("//div[@id='relationship']//div[@class='_52ja _5cds _5cdt']");
        //    if (relationShip != null)
        //    {
        //        result.RelationShip = relationShip.InnerText;

        //    }

        //    var familyMembers = document.DocumentNode.SelectNodes("//div[@id='family']//div[@class='title mfsm fcb']");
        //    if (familyMembers != null)
        //    {
        //        foreach (var item in familyMembers)
        //        {
        //            result.FamilyMember.Add(item.InnerText);
        //        }
        //    }

        //    var about = document.DocumentNode.SelectSingleNode("//div[@id='bio']//div[@class='_5cds _2lcw _5cdt']");
        //    if (about != null)
        //    {
        //        result.About = about.InnerText;
        //    }

        //    var favourite = document.DocumentNode.SelectSingleNode("//div[@id='quote']//div[@class='_5cds _2lcw _5cdt']");
        //    if (favourite != null)
        //    {
        //        result.Favourite = favourite.InnerText;
        //    }

        //    var friends = document.DocumentNode.SelectNodes("//div[@id='profile-card']//div[@class='title mfsm fcb']");
        //    if (friends != null)
        //    {
        //        foreach (var item in friends)
        //        {
        //            result.Friends.Add(item.InnerText);
        //        }
        //    }
        //    if (existUser != null)
        //    {
        //        if (isUpdate)
        //        {
        //            existUser.Works = result.Works;
        //            existUser.Educations = result.Educations;
        //            existUser.Places = result.Places;
        //            existUser.Email = result.Email;
        //            existUser.DateOfBirth = result.DateOfBirth;
        //            existUser.Gender = result.Gender;

        //            existUser.About = result.About;
        //            existUser.OtherNames = result.OtherNames;
        //            existUser.RelationShip = result.RelationShip;
        //            existUser.Favourite = result.Favourite;
        //            existUser.FamilyMember = result.FamilyMember;
        //            existUser.Friends = result.Friends;
        //        }
        //    }
        //    else
        //    {
        //        faceInfos.Add(result);
        //    }
        //    //return result;
        //}

        #region Login
        public void LoginFace(ChromeDriver driver, string url, string user, string pass, string twoFA)
        {
            Random random = new Random();
            string source = "";
            string idButtonSubmit = (url.Contains("mbasic") || url.Contains("m.facebook.com")) ? "checkpointSubmitButton-actual-button" : "checkpointSubmitButton";
            driver.Navigate().GoToUrl(url);
            Thread.Sleep(random.Next(500, 1000));
            CommonFunction.SendKeyByXPath(driver, "//input[@name='email']", user);
            CommonFunction.SendKeyByXPath(driver, "//input[@name='pass']", pass);
            string elementXpath = url.Contains("mbasic") ? "//input" : "//button";
            Thread.Sleep(random.Next(500, 1000));
            driver.FindElement(By.XPath(elementXpath + "[@name='login']")).Click();
            Thread.Sleep(random.Next(2000, 3000));
            string faCode = new Totp(Base32Encoding.ToBytes(twoFA)).ComputeTotp();
            CommonFunction.SendKeyByXPath(driver, "//input[@name='approvals_code']", faCode);
            Thread.Sleep(random.Next(2000, 3000));
            driver.FindElement(By.XPath(elementXpath + "[@type='submit']")).Click();
            Thread.Sleep(random.Next(1000, 1500));
            var radioBtn = driver.FindElements(By.Name("name_action_selected"));
            for (int i = 0; i < radioBtn.Count; i++)
            {
                string val = radioBtn[i].GetAttribute("value");
                if (val.ToLower() == "dont_save")
                {
                    radioBtn[i].Click();
                    driver.FindElement(By.XPath(elementXpath + "[@type='submit']")).Click();
                    Thread.Sleep(random.Next(500, 1000));
                }
            }

            source = driver.PageSource;           
            if (source.Contains(idButtonSubmit))
            {
                driver.FindElement(By.XPath(elementXpath + "[@id='" + idButtonSubmit + "']")).Click();
                Thread.Sleep(random.Next(500, 1000));
                source = driver.PageSource;
            }
            if (source.Contains(idButtonSubmit))
            {
                driver.FindElement(By.XPath(elementXpath + "[@id='" + idButtonSubmit + "']")).Click();
                Thread.Sleep(random.Next(500, 1000));
                source = driver.PageSource;
            }
            if (source.Contains("name_action_selected"))
            {
                radioBtn = driver.FindElements(By.Name("name_action_selected"));
                for (int i = 0; i < radioBtn.Count; i++)
                {
                    string val = radioBtn[i].GetAttribute("value");
                    if (val.ToLower() == "dont_save")
                    {
                        radioBtn[i].Click();
                        driver.FindElement(By.XPath(elementXpath + "[@id='" + idButtonSubmit + "']")).Click();
                        Thread.Sleep(random.Next(500, 1000));
                        source = driver.PageSource;
                    }
                }
            }
            if (source.Contains("action_proceed"))
            {
                driver.FindElement(By.XPath(elementXpath + "[@name='action_proceed']")).Click();
                Thread.Sleep(random.Next(500, 1000));
            }
            Thread.Sleep(random.Next(500, 1000));
        }

        public void LoginFace(ChromeDriver driver, string url, string user, string pass)
        {
            //driver.Url = url;
            driver.Navigate().GoToUrl(url);
            Thread.Sleep(1000);
            CommonFunction.SendKeyByXPath(driver, "//input[@name='email']", user);
            CommonFunction.SendKeyByXPath(driver, "//input[@name='pass']", pass);
            Thread.Sleep(1000);
            driver.FindElement(By.XPath("//button[@name='login']")).Click();
            Thread.Sleep(3000);
        }

        public bool LoginCookieGetEAAB(ChromeDriver driver, string cookie)
        {
            bool result = false;
            driver.Navigate().GoToUrl(FacebookLinkUrl.Facebook); 
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
            driver.Navigate().GoToUrl(FacebookLinkUrl.Facebook);
            if (!string.IsNullOrEmpty(GetEAABToken(driver)))
            {
                result = true;
            }
            return result;
        }

        public void LoginCookie(ChromeDriver driver,string url, string cookie)
        {
            driver.Navigate().GoToUrl(url);
            driver.Manage().Cookies.DeleteAllCookies();
            var lstCookie = cookie.Split(';');
            for (int i = 0; i < lstCookie.Length; i++)
            {
                if (!string.IsNullOrEmpty(lstCookie[i]))
                {
                    string key = lstCookie[i].Split('=')[0].Trim();
                    string value = lstCookie[i].Split('=')[1].Trim();
                    //OpenQA.Selenium.Cookie osCookie = new Cookie(key,value,".facebook.com","/", DateTime.Now.AddDays(10));
                    OpenQA.Selenium.Cookie osCookie = new Cookie(key, value);
                    driver.Manage().Cookies.AddCookie(osCookie);
                }
            }
        }
        #endregion Login

        #region GetToken
        public string GetEAAGToken(ChromeDriver driver, string user, string twoFA, string dtsg, string cookie)
        {
            string token = "EAAG";
            //Vào trang business lấy token
            driver.Url = FacebookLinkUrl.FacebookBusinessLocations;;
            Thread.Sleep(3000);
            var respone = CallAuthenTwoFa(user, twoFA, dtsg, cookie);
            Thread.Sleep(5000);
            if (respone.Contains("codeConfirmed\":true"))
            {
                string source = driver.PageSource;

                if (source.Contains("EAAG"))
                {
                    token += source.Split(new[] { "EAAG" }, StringSplitOptions.None)[1].Split('"')[0];
                }
            }
            var kq = GetEAAGTokenApi(user, cookie);
            return token;
        }

        public string CallAuthenTwoFa(string user, string twoFA, string dtsg, string cookie)
        {
            string faCode = new Totp(Base32Encoding.ToBytes(twoFA)).ComputeTotp();
            HttpRequest httprequest = new HttpRequest();
            CommonFunction.AddCookie(httprequest, cookie);
            var data = "approvals_code=" + faCode + "&save_device=false&__user=" + user + "&__a=1&__dyn=7xeUmF3EfXpUS2q3mbwyyVuC2-m2q3Kq2i5U4e1Fx-ewSxu68uxa2e1Ezobo9E5KcwayaxG4o2vwho3Ywv9E4WUc417mu11x-9xm1WxO4Uowuo9oeUa85vzo1eE4aUS1vwnE2PwBgK7k48W18wnE4K5E5WEeEgzE8Emy84CfwOw8y0RE5a2W2K4E7K1uDwau58Gm0hi4Ejyo-3qazo8U3ywbS1bwzwqo2awNwmo&__csr=&__req=6&__hs=19443.BP%3ADEFAULT.2.0..0.0&dpr=1&__ccg=GOOD&__rev=1007183526&__s=jj5qaf%3A46u6l7%3Aamtubg&__hsi=7215233148342221029&__comet_req=0&fb_dtsg=" + dtsg + "&jazoest=25390&lsd=x122Doj0kkTQe8TdeLWoDJ&__aaid=158820340401185&__spin_r=1007183526&__spin_b=trunk&__spin_t=1679927378&__jssesw=1";
            //var data = "approvals_code=" + faCode + "&save_device=false&__user=" + user + "&__a=1&__dyn=7xeUmF3EfXpUS2q3mbwyyVuC2-m2q3Kq2i5Uf9E6C7UW3q5UgDxW4E8U6ydwJwCwmUO0BoiyEqx68w9q15wfO1YCwjHwuk9wgovyolwuEsxe687C2m3K2y1nUS0jG12KdwnU5W0IU9kbxR12ewi85W1bxq1uG3G48W2a5Ey19zUcE28wdq1iwKwHxa1XwnFU2DxiaBw4kxa4UCfwSyES2e0UE2ZwiU8U6C0yEco5C&__csr=&__req=8&__hs=19395.BP%3ADEFAULT.2.0.0.0.0&dpr=1.5&__ccg=GOOD&__rev=1006920906&__s=6hjwrm%3A3vhtq1%3Aspfsji&__hsi=7197324973317924624&__comet_req=0&fb_dtsg=" + dtsg + "&jazoest=25525&lsd=Q7Feqpz-TcfK27ydcQVNhN&__aaid=191881262750333&__spin_r=1006920906&__spin_b=trunk&__spin_t=1675757806&__jssesw=1";
            var response = httprequest.Post(FacebookLinkUrl.FacebookReauth, data, "application/x-www-form-urlencoded; charset=UTF-8").ToString();
            return response;
        }

        public string GetEAAGTokenApi(string user, string cookie)
        {
            HttpRequest request = new HttpRequest();
            CommonFunction.AddCookie(request, cookie);
            var respone = request.Get(FacebookLinkUrl.FacebookContentManagement).ToString();
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
            driver.Url = FacebookLinkUrl.FacebookAdsmanager;
            Thread.Sleep(2000);
            string source = driver.PageSource;
            string token = "EAAB";
            if (source.Contains("EAAB"))
            {
                token += source.Split(new[] { "EAAB" }, StringSplitOptions.None)[1].Split('"')[0];
            }             
            return token;
        }

        public string GetDTSGToken(ChromeDriver driver)
        {
            string source = driver.PageSource;
            string token = source.Split(new[] { "dtsg\":{\"token\":\"" }, StringSplitOptions.None)[1].Split('"')[0];
            return token;
        }
        #endregion

        #region
        public string GetUserInfo(string userId)
        {
            var url = "https://graph.facebook.com/v15.0/"+ userId + "?access_token=EAAGNO4a7r2wBANai5HBi6zfk4jZBzyF3O2JhYJZBb7QK6KrGBoGjWLdE9ZCsX6blS59Rhz13sL0dAl7TapypeLaPaGPmcCZB4Yzrlxsq7IaKtxaZCSTplxtPdf3LqeZACnYqCHipYZAmawWDC2gaAULcahXBqz9xL9EtQjrStzyDahpQMuatWKZB&fields=id%2Cname%2Cfirst_name%2Cgender%2Chometown%2Crelationship_status%2Creligion%2Cfriends%2Cbirthday%2Clast_name";
            var cookie = "sb=canhY_SrURrp1sEhshmYmsu8; datr=dqnhYwHHCGAWc_mws1UdDc1W;c_user=100011930435548; fr=001y8RytbFcYQdabf.AWW0ySaWufAIZAo4OkhzixbaY58.Bj5eSK.wk.AAA.0.0.Bj5eec.AWUQi77ufRI; usida=eyJ2ZXIiOjEsImlkIjoiQXJwdXFtanNxd3N6OSIsInRpbWUiOjE2NzYwMTE2ODR9;xs=24%3AGpqfzUv-2uYy7Q%3A2%3A1676011390%3A-1%3A13781;";
            HttpRequest httprequest = new HttpRequest();
            CommonFunction.AddCookie(httprequest, cookie);
            var response = httprequest.Get(url).ToString();
            return response;
        }

        public string GetUserInfoSecond(string eaag, string cookie)
        {
            var url = "https://graph.facebook.com/me?fields=first_name,last_name,middle_name,name,birthday,gender&access_token=" + eaag;
            HttpRequest httprequest = new HttpRequest();
            CommonFunction.AddCookie(httprequest, cookie);
            var response = httprequest.Get(url).ToString();
            return response;
        }

        public string GetFullUserInfoSecond(string eaag, string cookie)
        {
            var url = "https://graph.facebook.com/v14.0/me/adaccounts?summary=1&limit=50&fields=account_id,name,adtrust_dsl,account_status,users{id,+role},currency,+funding_source,all_payment_methods{pm_credit_card{display_string,exp_month,exp_year,is_verified},payment_method_direct_debits{address,can_verify,display_string,is_awaiting,is_pending,status},payment_method_paypal{email_address},payment_method_tokens{current_balance,original_balance,time_expire,type}}&locale=en_US&access_token=" + eaag;
            HttpRequest httprequest = new HttpRequest();
            CommonFunction.AddCookie(httprequest, cookie);
            var response = httprequest.Get(url).ToString();
            return response;
        }
        #endregion

        public bool CheckStatusAccount(AccountInfo accountInfo, string url, int rowIndex, bool isLoginCookie)
        {
            var result = false;
            var driver = InitChromeDriver(accountInfo);
            try
            {
                if (isLoginCookie)
                {
                    LoginCookie(driver, url, accountInfo.Cookie);
                }
                else
                {
                    if(string.IsNullOrEmpty(accountInfo.TwoFA))
                    {
                        LoginFace(driver, url, accountInfo.Id, accountInfo.Pass);
                    }
                    else
                    {
                        LoginFace(driver, url, accountInfo.Id, accountInfo.Pass, accountInfo.TwoFA);
                    }
                }
                
                if (!driver.Url.Contains("checkpoint"))
                {
                    result = true;
                }
                else
                {
                   // MainForm.Self.SetColNoteGridViewByRow(rowIndex, driver.Url);
                }
            }
            catch (Exception ex)
            {
                //MainForm.Self.SetColNoteGridViewByRow(rowIndex, "Exception: " + ex.Message);
                result = false;
            }
            finally
            {
                //driver.Close();
            }
            return result;
        }
        
        public bool FacebookError282MBasic2345(ChromeDriver driver, AccountInfo account, int rowIndex, string resolveCaptchaKey, string imgFacePath, bool isError282 = true)
        {
            var result = false;
            Random random = new Random();
            string source = "";
            if (driver.Url.Contains("1501092823525282")) //1501092823525282
            {
                var dtsg = driver.FindElement(By.XPath("//input[@name='fb_dtsg']")).GetValue();
                account.DTSG = dtsg;
                ////Get base64 captcha
                source = driver.PageSource;
                if (source.Contains("captcha_persist_data"))
                {
                    MainForm.Self.SetColNoteGridViewByRow(rowIndex, "Captcha");
                    var elementImage = driver.FindElement(By.XPath("//div[@id='captcha']//img"));
                    ITakesScreenshot screenshotDriver = driver as ITakesScreenshot;
                    byte[] byteArray = screenshotDriver.GetScreenshot().AsByteArray;
                    Bitmap screenShot = new Bitmap(new MemoryStream(byteArray));
                    Rectangle cropImage = new Rectangle(elementImage.Location.X, elementImage.Location.Y, elementImage.Size.Width, elementImage.Size.Height);
                    screenShot = screenShot.Clone(cropImage, screenShot.PixelFormat);
                    string imgPath = CommonFunction.CreatDirectory(Environment.CurrentDirectory + "\\File\\Image\\Captcha") + "\\" + account.Id + "_captcha.png";
                    screenShot.Save(imgPath, ImageFormat.Png);
                    ResolveCaptcha resolveCaptcha = new ResolveCaptcha();
                    resolveCaptcha.APIKey = resolveCaptchaKey;
                    string outputCapcha = "";
                    resolveCaptcha.SolveNormalCapcha(CommonFunction.ConvertImageToBase64String(imgPath), out outputCapcha);

                    if (string.IsNullOrEmpty(outputCapcha) || outputCapcha.Length > 6)
                    {
                        MainForm.Self.SetColNoteGridViewByRow(rowIndex, "Lỗi giả mã captcha");
                    }
                    else
                    {
                        CommonFunction.SendKeyByXPath(driver, "//input[@name='captcha_response']", outputCapcha);
                        Thread.Sleep(300);
                        driver.FindElement(By.XPath("//input[@name='action_submit_bot_captcha_response']")).Click();
                        //driver.Navigate().GoToUrl(url);
                        Thread.Sleep(2000);
                        source = driver.PageSource;
                    }
                }

                if (source.Contains("action_set_contact_point"))
                {
                    MainForm.Self.SetColNoteGridViewByRow(rowIndex, "OTP");
   
                    string filePath = Environment.CurrentDirectory + FilePath.ConfigOtp;
                    ConfigOtpModel configOtpModel = new ConfigOtpModel();
                    if (File.Exists(filePath))
                    {
                        FileHelper fileHelper = new FileHelper();
                        var configOtp = fileHelper.Read(filePath);
                        try
                        {
                            configOtpModel = JsonConvert.DeserializeObject<ConfigOtpModel>(configOtp);
                        }
                        catch (Exception)
                        {
                            configOtpModel = new ConfigOtpModel();
                        }
                    }
                    if (string.IsNullOrEmpty(configOtpModel.ApiKey))
                    {
                        MainForm.Self.SetColNoteGridViewByRow(rowIndex, "Cấu hình OTP lỗi");
                    }
                    else
                    {
                        string homenetwork = "";
                        IOtp otpProcessing = GetOtp(configOtpModel, out homenetwork);
                        string number = "", idNumber = "", code = "", appName = "Facebook";
                        string appId = otpProcessing.GetIdApplicationByName(configOtpModel.ApiKey, appName);
                        int count = 0;
                        while (count < 5 && string.IsNullOrEmpty(number))
                        {
                            number = otpProcessing.GetNumberByAppId(configOtpModel.ApiKey, appId, out idNumber, homenetwork);
                            Thread.Sleep(random.Next(2000, 3000));
                            if (!string.IsNullOrEmpty(number))
                            {
                                if (number.Length == 9)
                                {
                                    number = "+84" + number;
                                }
                                CommonFunction.SendKeyByXPath(driver, "//input[@name='contact_point']", number);
                                Thread.Sleep(random.Next(1000, 2000));
                                driver.FindElement(By.XPath("//input[@name='action_set_contact_point']")).Click();
                                Thread.Sleep(random.Next(1000, 2000));
                                source = driver.PageSource;
                                if (source.Contains("This number has been used to verify too many accounts on Facebook. Please try a different number."))
                                {
                                    number = "";
                                    otpProcessing.CancelByAppId(configOtpModel.ApiKey, idNumber);
                                }
                            }
                            count++;
                        }
                        count = 0;
                        if (!string.IsNullOrEmpty(number))
                        {
                            while (count < 30 && string.IsNullOrEmpty(code))
                            {
                                Thread.Sleep(10000);
                                code = otpProcessing.GetCodeByIdService(configOtpModel.ApiKey, idNumber);
                                count++;
                            }
                        }
                        if (string.IsNullOrEmpty(code))
                        {
                            otpProcessing.CancelByAppId(configOtpModel.ApiKey, idNumber);
                            MainForm.Self.SetColNoteGridViewByRow(rowIndex, "Lỗi nhận OTP");
                        }
                        else
                        {
                            CommonFunction.SendKeyByXPath(driver, "//input[@name='code']", code);
                            Thread.Sleep(random.Next(1000, 2000));
                            driver.FindElement(By.XPath("//div[@class='ba']//input[@name='action_submit_code']")).Click();
                            Thread.Sleep(random.Next(1000, 2000));
                            source = driver.PageSource;
                        }
                    }
                }

                if (source.Contains("mobile_image_data"))
                {
                    if (isError282)
                    {
                        ImageProcessing imageProcessing = new ImageProcessing();
                        string imgFaceFakePath = CommonFunction.CreatDirectory(Environment.CurrentDirectory + "\\File\\Image\\Face") + "\\" + account.Id + ".jpg";

                        if (string.IsNullOrEmpty(account.Info))
                        {
                            var age = random.Next(18, 60);
                            //fix gender or random o day male or female
                            string faceFakeUrl = CommonFunction.GetLinkFaceImage(age, "male");
                            imageProcessing.getImageFromUrl(faceFakeUrl.Substring(30), faceFakeUrl, imgFaceFakePath);
                            account.ImgFacePath = imgFaceFakePath;
                        }
                        else
                        {
                            var faceInfo = JsonConvert.DeserializeObject<FaceInfo>(account.Info);
                            var birthdaySplit = faceInfo.birthday.Split("/");
                            string yearOfBirthday = birthdaySplit[2];
                            var faceFakeUrl = CommonFunction.GetLinkFaceImage(DateTime.Now.Year - Convert.ToInt32(yearOfBirthday), faceInfo.gender);
                            imageProcessing.getImageFromUrl(faceFakeUrl.Substring(30), faceFakeUrl, imgFaceFakePath);
                        }
                        if (!string.IsNullOrEmpty(imgFaceFakePath))
                        {
                            MainForm.Self.SetColNoteGridViewByRow(rowIndex, "Upload ảnh");
                            var mobile_image_data = driver.FindElement(By.XPath("//input[@name='mobile_image_data']"));
                            mobile_image_data.SendKeys(imgFaceFakePath);
                            Thread.Sleep(500);
                            driver.FindElement(By.XPath("//input[@name='action_upload_image']")).Click();
                        }

                    }
                    else if(!string.IsNullOrEmpty(imgFacePath))
                    {
                        MainForm.Self.SetColNoteGridViewByRow(rowIndex, "Upload ảnh");
                        var mobile_image_data = driver.FindElement(By.XPath("//input[@name='mobile_image_data']"));
                        mobile_image_data.SendKeys(imgFacePath);
                        Thread.Sleep(500);
                        driver.FindElement(By.XPath("//input[@name='action_upload_image']")).Click();
                    }
                }
            }
            return result;
        }

        private IOtp GetOtp(ConfigOtpModel configOtpModel, out string homenetwork)
        {
            IOtp otpProcessing;
            homenetwork = "";
            //Cấu hình link get OTP
            if (configOtpModel.LinkGetOtp == (int)EnumLinkGetOtp.Sell)
            {
                otpProcessing = new OtpSell();
                //Cấu hình nhà mạng
                if (configOtpModel.HomeNetwork == (int)EnumHomeNetwork.Vinaphone)
                {
                    homenetwork = "VINAPHONE";
                }
                else if (configOtpModel.HomeNetwork == (int)EnumHomeNetwork.Viettel)
                {
                    homenetwork = "VIETTEL";
                }
                else if (configOtpModel.HomeNetwork == (int)EnumHomeNetwork.Mobifone)
                {
                    homenetwork = "MOBIFONE";
                }
                else if (configOtpModel.HomeNetwork == (int)EnumHomeNetwork.Vietnamobile)
                {
                    homenetwork = "VIETNAMOBILE";
                }
                else if (configOtpModel.HomeNetwork == (int)EnumHomeNetwork.Gmobile)
                {
                    homenetwork = "";
                }
                else if (configOtpModel.HomeNetwork == (int)EnumHomeNetwork.ITelecom)
                {
                    homenetwork = "ITELECOM";
                }
                else if (configOtpModel.HomeNetwork == (int)EnumHomeNetwork.Reddi)
                {
                    homenetwork = "";
                }
            }
            else
            {
                otpProcessing = new OtpChoThueSimCode();
                //Cấu hình nhà mạng
                if (configOtpModel.HomeNetwork == (int)EnumHomeNetwork.Vinaphone)
                {
                    homenetwork = "Vina";
                }
                else if (configOtpModel.HomeNetwork == (int)EnumHomeNetwork.Viettel)
                {
                    homenetwork = "Viettel";
                }
                else if (configOtpModel.HomeNetwork == (int)EnumHomeNetwork.Mobifone)
                {
                    homenetwork = "Mobi";
                }
                else if (configOtpModel.HomeNetwork == (int)EnumHomeNetwork.Vietnamobile)
                {
                    homenetwork = "VNMB";
                }
                else if (configOtpModel.HomeNetwork == (int)EnumHomeNetwork.Gmobile)
                {
                    homenetwork = "";
                }
                else if (configOtpModel.HomeNetwork == (int)EnumHomeNetwork.ITelecom)
                {
                    homenetwork = "ITelecom";
                }
                else if (configOtpModel.HomeNetwork == (int)EnumHomeNetwork.Reddi)
                {
                    homenetwork = "";
                }
            }
            return otpProcessing;
        }
    }
}
