using Facebook.Model;
using Facebook.Otp;
using OpenQA.Selenium;
using System.Drawing.Imaging;

namespace Facebook.Core.FacebookError
{
    internal class FacebookError282
    {
        //List<AccountInfo> lstAccount;

        public List<AccountInfo> GetAllAccount(string path)
        {
            var lstAccount = new List<AccountInfo>();
            try
            {
                FileHelper fileHelper = new FileHelper();
                var lstData = fileHelper.ReadLine(path);
                for (int i = 0; i < lstData.Count(); i++)
                {
                    var data = lstData[i].Split('|');
                    lstAccount.Add(new AccountInfo
                    {
                        Id = data[0],
                        Pass = data[1],
                        Cookie = data[2],
                        EAAAAAY = data[3],
                    });
                }
            }
            catch (Exception ex)
            {
                return new List<AccountInfo>();
            }
            return lstAccount;
        }

        #region Process facebook
        public bool ProcessFacbook(AccountInfo account, string resolveCaptchaKey, bool loginCookie = false)
        {
            bool result = false;
            Random random = new Random();
            string source = "";
            string url = FacebookLinkUrl.Facebook;
            FacebookProcessing facebookProcessing = new FacebookProcessing();
            var driver = facebookProcessing.InitChromeDriver(account);
            try
            {
                if (loginCookie)
                {
                    facebookProcessing.LoginCookie(driver, url, account.Cookie);
                }
                else
                {
                    facebookProcessing.LoginFace(driver, url, account.Id, account.Pass, account.TwoFA);
                }

                Thread.Sleep(random.Next(1000, 2000));

                //ResolveCaptcha resolveCaptcha = new ResolveCaptcha();
                //var divGoogleKey = driver.FindElement(By.XPath("//div[@class='g-recaptcha']"));
                //string googleKey = "";
                //resolveCaptcha.APIKey = resolveCaptchaKey;
                //string outputCapcha = "";
                //resolveCaptcha.SolveRecaptchaV2(googleKey, driver.Url, out outputCapcha);
                result = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                result = false;
            }
            finally
            {
                driver.Close();
            }

            return result;
        }
        #endregion Process facebook

        #region Process Mfacebook
        public bool ProcessMFacbook(AccountInfo account, int rowIndex, string resolveCaptchaKey, bool loginCookie = false, int age = 0, string gender = "male")
        {
            bool result = false;
            Random random = new Random();
            string source = "";
            string url = FacebookLinkUrl.MFacebook;
            FacebookProcessing facebookProcessing = new FacebookProcessing();
            var driver = facebookProcessing.InitChromeDriver(account);
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
                }
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
                    driver.Navigate().GoToUrl(url);
                    Thread.Sleep(2000);
                    source = driver.PageSource;
                }
                if (source.Contains("action_set_contact_point"))
                {
                    MainForm.Self.SetColNoteGridViewByRow(rowIndex, "OTP");
                    IOtp otpProcessing = new OtpSell();
                    //string apiKey = "90e2b1f8fa419d46", appName = "Facebook";
                    string apiKey = "172c280613d44fc194b2143054690b7e", appName = "Facebook";
                    string appId = otpProcessing.GetIdApplicationByName(apiKey, appName);
                    string number = "", idNumber = "", code = "";
                    int count = 0;
                    while (count < 5 && string.IsNullOrEmpty(number))
                    {
                        number = otpProcessing.GetNumberByAppId(apiKey, appId, out idNumber);
                        CommonFunction.SendKeyByXPath(driver, "//input[@name='contact_point']", number);
                        driver.FindElement(By.XPath("//input[@name='action_set_contact_point']")).Click();
                        Thread.Sleep(random.Next(1000));
                        source = driver.PageSource;
                        if (source.Contains("This number has been used to verify too many accounts on Facebook. Please try a different number."))
                        {
                            number = "";
                            otpProcessing.CancelByAppId(apiKey, idNumber);
                        }
                        count++;
                    }
                    count = 0;
                    if (!string.IsNullOrEmpty(number))
                    {
                        while (count < 5 && string.IsNullOrEmpty(code))
                        {
                            Thread.Sleep(60000);
                            code = otpProcessing.GetCodeByIdService(apiKey, idNumber);
                            count++;
                        }
                    }
                    if (string.IsNullOrEmpty(code))
                    {
                        otpProcessing.CancelByAppId(apiKey, idNumber);
                        MainForm.Self.SetColNoteGridViewByRow(rowIndex, "Lỗi nhận OTP");
                    }
                    else
                    {
                        CommonFunction.SendKeyByXPath(driver, "//input[@name='code']", code);
                        driver.FindElement(By.XPath("//div[@class='ba']//input[@name='action_submit_code']")).Click();
                        Thread.Sleep(random.Next(500, 1000));
                        source = driver.PageSource;
                    }
                }

                if (source.Contains("mobile_image_data"))
                {
                    MainForm.Self.SetColNoteGridViewByRow(rowIndex, "Upload ảnh");
                    if (age == 0)
                    {
                        age = random.Next(18, 60);
                        var randomGender = random.NextDouble();
                        gender = randomGender > 0.5 ? "male" : "female";
                    }

                    ImageProcessing imageProcessing = new ImageProcessing();
                    string faceFakeUrl = CommonFunction.GetLinkFaceImage(age, gender);
                    string imgFaceFakePath = CommonFunction.CreatDirectory(Environment.CurrentDirectory + "\\File\\Image\\Face") + "\\" + account.Id + ".jpg";
                    imageProcessing.getImageFromUrl(faceFakeUrl.Substring(30), faceFakeUrl, imgFaceFakePath);
                    account.ImgFacePath = imgFaceFakePath;
                    var mobile_image_data = driver.FindElement(By.XPath("//input[@name='mobile_image_data']"));
                    mobile_image_data.SendKeys(imgFaceFakePath);
                    Thread.Sleep(200);
                    driver.FindElement(By.XPath("//input[@name='action_upload_image']")).Click();
                    driver.Navigate().GoToUrl(url);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                result = false;
            }
            finally
            {
                driver.Close();
            }

            return result;
        }
        #endregion Process Mfacebook

        #region Process MbasicFacebook
        public bool ProcessMBasicFacebook(AccountInfo account, int rowIndex, string imgFacePath, string resolveCaptchaKey, string apiKey, bool loginCookie = false)
        {
            var result = true;
            Random random = new Random();
            FacebookProcessing facebookProcessing = new FacebookProcessing();
            var driver = facebookProcessing.InitChromeDriver(account);
            string url = FacebookLinkUrl.MBasicFacebook;
            try
            {
                //Login by cookie
                MainForm.Self.SetColNoteGridViewByRow(rowIndex, "Đăng nhập");
                if (loginCookie)
                {
                    facebookProcessing.LoginCookie(driver, url, account.Cookie);
                    driver.Navigate().GoToUrl(url);
                }
                else
                {
                    facebookProcessing.LoginFace(driver, url, account.Id, account.Pass, account.TwoFA);
                }

                Thread.Sleep(random.Next(1000, 2000));

                facebookProcessing.FacebookError282MBasic(driver, account, rowIndex, resolveCaptchaKey, apiKey,  imgFacePath, true);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MainForm.Self.SetColNoteGridViewByRow(rowIndex, "Exception: " + ex.Message);
                result = false;
            }
            finally
            {
                driver.Close();
            }
            return result;
        }        
        #endregion Process MbasicFacebook
    }
}
