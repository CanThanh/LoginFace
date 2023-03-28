using Facebook.Model;
using Facebook.Otp;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V85.IndexedDB;
using OpenQA.Selenium.Interactions;
using OtpNet;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Keys = OpenQA.Selenium.Keys;

namespace Facebook.Core.AccountQuality
{
    internal class FacebookAccountQuality
    {
        public bool Proccess(AccountInfo account, int rowIndex, string idFile, string idConfigIndentity, string resolveCaptchaKey, bool loginCookie = false)
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
                }
                else
                {
                    facebookProcessing.LoginFace(driver, url, account.Id, account.Pass, account.TwoFA);
                    account.Cookie = CommonFunction.GetCookie(driver);
                }

                if (string.IsNullOrEmpty(account.Info))
                {
                    driver.Navigate().GoToUrl("https://business.facebook.com/business_locations/");
                    Thread.Sleep(TimeSpan.FromSeconds(3));

                    string faCode = new Totp(Base32Encoding.ToBytes(account.TwoFA)).ComputeTotp();
                    var inputCode = driver.FindElement(By.XPath("//div[@id='globalContainer']//input"));
                    CommonFunction.SendKeyByXPath(driver, "//div[@id='globalContainer']//input", faCode);
                    Actions builder = new Actions(driver);
                    builder.MoveByOffset(inputCode.Location.X + inputCode.Size.Width / 2, inputCode.Location.Y + inputCode.Size.Height / 2).Click().Perform();
                    Thread.Sleep(500);
                    builder.KeyDown(Keys.Enter).Perform();
                    Thread.Sleep(3000);
                    string token = "EAAG";
                    source = driver.PageSource;
                    if (source.Contains("EAAG"))
                    {
                        token += source.Split(new[] { "EAAG" }, StringSplitOptions.None)[1].Split('"')[0];
                    }
                    if (token.Length > 4)
                    {
                        account.EAAG = token;
                        string infor = facebookProcessing.GetUserInfoSecond(token, account.Cookie);
                        account.Info = infor;
                    }
                }

                //Change get config
                SQLiteProcessing sqLiteProcessing = new SQLiteProcessing();
                var configIdentityDbModel = sqLiteProcessing.GetConfigIndentityById(idConfigIndentity);
                ImageProcessing imageProcessing = new ImageProcessing();
                var faceInfo = JsonConvert.DeserializeObject<FaceInfo>(account.Info);
                var birthdaySplit = faceInfo.birthday.Split("/");
                string dayOfBirthday = birthdaySplit[1];
                string monthOfBirthday = birthdaySplit[0];
                string yearOfBirthday = birthdaySplit[2];
                faceInfo.birthday = dayOfBirthday + "." + monthOfBirthday + "." + yearOfBirthday.Substring(2, 2);
                var bitmap = (Bitmap)Image.FromFile(configIdentityDbModel.imageUrl);
                string imgFaceFakePath = CommonFunction.CreatDirectory(Environment.CurrentDirectory + "\\File\\Image\\Face") + "\\" + faceInfo.id + ".jpg";
                var imageFaceUrl = CommonFunction.GetLinkFaceImage(DateTime.Now.Year - Convert.ToInt32(yearOfBirthday), faceInfo.gender);
                imageProcessing.getImageFromUrl(imageFaceUrl.Substring(30), imageFaceUrl, imgFaceFakePath);
                imageProcessing.ProcessImage(faceInfo, bitmap, configIdentityDbModel.configIdentityModel, Image.FromFile(imgFaceFakePath));
                string imgIdentityPath = CommonFunction.CreatDirectory(Environment.CurrentDirectory + "\\File\\Image\\Identity") + "\\" + faceInfo.id + ".jpg";
                bitmap.Save(imgIdentityPath);

                url = "https://www.facebook.com/accountquality/" + account.Id;
                driver.Navigate().GoToUrl(url);
                Thread.Sleep(2000);

                driver.FindElement(By.XPath("//div[@class='xeuugli x2lwn1j x1cy8zhl x78zum5 x1q0g3np x1yztbdb']//div[@class='x3nfvp2 x193iq5w xxymvpz']")).Click();
                Thread.Sleep(2000);

                driver.FindElement(By.XPath("//div[@class='x6s0dn4 x78zum5 xl56j7k x1608yet xljgi0e x1e0frkt']")).Click();
                Thread.Sleep(2000);
                url = driver.Url;
                url = url.Replace("www", "mbasic");
                driver.Navigate().GoToUrl(url);
                Thread.Sleep(random.Next(1000, 2000));
                source = driver.PageSource;

                if (source.Contains("captcha_persist_data"))
                {
                    var dtsg = driver.FindElement(By.XPath("//input[@name='fb_dtsg']")).GetValue();
                    account.DTSG = dtsg;
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
                        driver.Navigate().GoToUrl(url);
                        Thread.Sleep(2000);
                        source = driver.PageSource;
                    }
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
                    var mobile_image_data = driver.FindElement(By.XPath("//input[@name='mobile_image_data']"));
                    mobile_image_data.SendKeys(imgIdentityPath);
                    Thread.Sleep(200);
                    driver.FindElement(By.XPath("//input[@name='action_upload_image']")).Click();
                }
                sqLiteProcessing.InsertOrUpdateAccount(account, idFile);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                driver.Close();
            }
            return result;
        }
    }
}
