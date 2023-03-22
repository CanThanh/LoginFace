using OpenQA.Selenium;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using XMDT.Controller;
using XMDT.Model;
using xNet;
using System.Drawing;
using System.IO;
using XMDT.Otp;
using System.Drawing.Imaging;

namespace XMDT.Facebook
{
    internal class FacebookError282 : CommonFunction
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
            string url = "https://www.facebook.com/";
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

        private string ApiSubmit(RestClient client, string url, string user, string dtsg, string variables)
        {
            var request = new RestRequest("/api/graphql/", Method.Post);
            client.Options.BaseUrl = new Uri(url);
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
            //request.AddFile("abcd.png", "path", "multipart/form-data");
            RestResponse response = client.Execute(request);
            return response.Content;
        }
        #endregion Process facebook

        #region Process Mfacebook
        public bool ProcessMFacbook(AccountInfo account, string resolveCaptchaKey, bool loginCookie = false)
        {
            bool result = false;
            //Random random = new Random();
            //string source = "";
            //string url = "https://m.facebook.com/";
            string url = "https://mbasic.facebook.com/";
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
                screenShot.Save("D:\\Code\\XMDT\\Image\\Captcha\\"+ account.Id + "_captcha.png", ImageFormat.Png);
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
        public bool ProcessMBasicFacebook(AccountInfo account, int rowIndex, string resolveCaptchaKey, bool loginCookie = false, int age = 0, string gender = "male")
        {
            var result = true;
            Random random = new Random();
            string source = "";
            FacebookProcessing facebookProcessing = new FacebookProcessing();
            var driver = facebookProcessing.InitChromeDriver(account);
            string url = "https://mbasic.facebook.com/";
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
                if (driver.Url.Contains("282")) //1501092823525282
                {
                    //InitHttpRequest(account);
                    //if (loginCookie)
                    //{
                    //    AddCookie(httpRequest, account.Cookie);
                    //}
                    //else
                    //{
                    //    var cookie = driver.GetCookie();
                    //    AddCookie(httpRequest, account.Cookie);
                    //}

                    var dtsg = driver.FindElement(By.XPath("//input[@name='fb_dtsg']")).GetValue();
                    account.DTSG = dtsg;
                    ////Get base64 captcha
                    source = driver.PageSource;
                    if (source.Contains("captcha_persist_data"))
                    {
                        MainForm.Self.SetColNoteGridViewByRow(rowIndex, "Captcha");
                        var containName = source.Contains("you're now interacting as");
                        var captcha_persist_data = driver.FindElement(By.XPath("//input[@name='captcha_persist_data']")).GetValue();
                        ITakesScreenshot screenshotDriver = driver as ITakesScreenshot;
                        Screenshot screenshot = screenshotDriver.GetScreenshot();
                        string imgPath = CreatDirectory(Path.GetDirectoryName(Path.GetDirectoryName(Environment.CurrentDirectory)) + "\\Image\\Screenshot") + "\\" + account.Id + "SS.png";
                        screenshot.SaveAsFile(imgPath);
                        var img = Image.FromFile(imgPath);
                        //Diffrence crop mobile/win
                        int xLocation = (!string.IsNullOrEmpty(account.UserAgent) && account.UserAgent.Contains("Android")) ? 10 : 136;
                        Rectangle cropArea = new Rectangle(180, containName ? 135: 105, 250, 66);
                        var imgCaptcha = cropImage(img, cropArea);
                        string imgCaptchaPath = CreatDirectory(Path.GetDirectoryName(Path.GetDirectoryName(Environment.CurrentDirectory)) + "\\Image\\Captcha") + "\\" + account.Id + "_captcha.png";
                        imgCaptcha.Save(imgCaptchaPath);
                        string base64Img = ConvertImageToBase64String(Image.FromFile(imgCaptchaPath));
                        //Resolve captcha
                        ResolveCaptcha resolveCaptcha = new ResolveCaptcha();
                        resolveCaptcha.APIKey = resolveCaptchaKey;
                        string outputCapcha = "";
                        resolveCaptcha.SolveNormalCapcha(base64Img, out outputCapcha);
                        //Get data pass captcha and upload img
                        //var data = "fb_dtsg=" + dtsg + "&jazoest=25200&captcha_persist_data=" + captcha_persist_data + "&captcha_response=" + outputCapcha + "&action_submit_bot_captcha_response=Ti%E1%BA%BFp+t%E1%BB%A5c";
                        //var response = httpRequest.Post("https://mbasic.facebook.com/checkpoint/1501092823525282/submit/", data, "application/x-www-form-urlencoded; charset=UTF-8").ToString();
                        //Load page to up img

                        if(string.IsNullOrEmpty(outputCapcha) || outputCapcha.Length > 6)
                        {
                            MainForm.Self.SetColNoteGridViewByRow(rowIndex, "Lỗi giả mã captcha");
                        }
                        else
                        {
                            facebookProcessing.SendKeyByXPath(driver, "//input[@name='captcha_response']", outputCapcha);
                            Thread.Sleep(300);
                            driver.FindElement(By.XPath("//input[@name='action_submit_bot_captcha_response']")).Click();
                            driver.Navigate().GoToUrl(url);
                            Thread.Sleep(2000);
                            source = driver.PageSource;
                        }
                    }

                    if (source.Contains("action_set_contact_point"))
                    {
                        MainForm.Self.SetColNoteGridViewByRow(rowIndex, "OTP");
                        OtpProcessing otpProcessing = new OtpSell();
                        //string apiKey = "90e2b1f8fa419d46", appName = "Facebook";
                        string apiKey = "172c280613d44fc194b2143054690b7e", appName = "Facebook";
                        string appId = otpProcessing.GetIdApplicationByName(apiKey, appName);
                        string number =  "", idNumber = "", code = "";
                        int count = 0;
                        while(count < 5 && string.IsNullOrEmpty(number))
                        {
                            number = otpProcessing.GetNumberByAppId(apiKey, appId, out idNumber);
                            SendKeyByXPath(driver, "//input[@name='contact_point']", number);
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
                            SendKeyByXPath(driver, "//input[@name='code']", code);                           
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
                        string faceFakeUrl = facebookProcessing.GetLinkFaceImage(age, gender);
                        string imgFaceFakePath = CreatDirectory(Path.GetDirectoryName(Path.GetDirectoryName(Environment.CurrentDirectory)) + "\\Image\\Face") +"\\" + account.Id + ".jpg";
                        imageProcessing.getImageFromUrl(faceFakeUrl.Substring(30), faceFakeUrl, imgFaceFakePath);
                        account.ImgFacePath = imgFaceFakePath;
                        var mobile_image_data = driver.FindElement(By.XPath("//input[@name='mobile_image_data']"));
                        mobile_image_data.SendKeys(imgFaceFakePath);
                        Thread.Sleep(200);
                        driver.FindElement(By.XPath("//input[@name='action_upload_image']")).Click();
                        driver.Navigate().GoToUrl(url);
                    }
                }                
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

        private Image cropImage(Image img, Rectangle cropArea)
        {
            Bitmap bmpImage = new Bitmap(img);
            return bmpImage.Clone(cropArea, bmpImage.PixelFormat);
        }
        private string ConvertImageToBase64String(Image image)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, image.RawFormat);
                return Convert.ToBase64String(ms.ToArray());
            }
        }
        #endregion Process MbasicFacebook

        string Reslove2CaptchaCaptcha(string captchaKey, string ggKey, string url, string cookie = "")
        {
            string capt = "";
            ResolveCaptcha resolveCaptcha = new ResolveCaptcha();
            resolveCaptcha.APIKey = captchaKey;

            bool isSuccess = resolveCaptcha.SolveRecaptchaV2(ggKey, url, out capt);
            int count = 0;
            while (!isSuccess && count < 5)
            {
                count++;
                isSuccess = resolveCaptcha.SolveRecaptchaV2(ggKey, url, out capt);
                Thread.Sleep(TimeSpan.FromSeconds(2));
            }
            return capt;
        }
    }
}
