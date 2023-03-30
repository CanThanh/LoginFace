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
        public bool Proccess(AccountInfo account, int rowIndex, string idFile, string idConfigIndentity, string resolveCaptchaKey, string apiKey, bool loginCookie = false)
        {
            MainForm.Self.SetColNoteGridViewByRow(rowIndex, "Bắt đầu");
            bool result = true;
            Random random = new Random();
            string source = "";
            FacebookProcessing facebookProcessing = new FacebookProcessing();
            SQLiteProcessing sqLiteProcessing = new SQLiteProcessing();
            var driver = facebookProcessing.InitChromeDriver(account);
            string url = FacebookLinkUrl.MFacebook;
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
                    driver.Navigate().GoToUrl(FacebookLinkUrl.FacebookBusinessLocations);
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
                        driver.NewTab();
                        driver.SwitchTo().Window(driver.WindowHandles.Last());
                        driver.Navigate().GoToUrl(FacebookLinkUrl.FacebookGetAccountInfo + token);
                        Thread.Sleep(random.Next(1000, 2000));
                        account.Info = driver.FindElement(By.XPath("//html//body//pre")).GetInnerHTML();
                    }                                    
                }

                if (string.IsNullOrEmpty(account.ImgIdentityQuanlityPath))
                {
                    //Change get config
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
                    account.ImgIdentityQuanlityPath = imgIdentityPath;
                    bitmap.Dispose();
                }

                //driver.NewTab();
                //driver.SwitchTo().Window(driver.WindowHandles.Last());
                url = FacebookLinkUrl.FacebookAccountQuality + account.Id;
                driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(600);
                driver.Navigate().GoToUrl(url);
                Thread.Sleep(2000);
                source = driver.PageSource;

                if (source.Contains("xeuugli x2lwn1j x1cy8zhl x78zum5 x1q0g3np x1yztbdb"))
                {
                    driver.FindElement(By.XPath("//div[@class='xeuugli x2lwn1j x1cy8zhl x78zum5 x1q0g3np x1yztbdb']//div[@class='x3nfvp2 x193iq5w xxymvpz']")).Click();
                    Thread.Sleep(2000);
                    source = driver.PageSource;
                }

                if(source.Contains("x6s0dn4 x78zum5 xl56j7k x1608yet xljgi0e x1e0frkt"))
                {
                    driver.FindElement(By.XPath("//div[@class='x6s0dn4 x78zum5 xl56j7k x1608yet xljgi0e x1e0frkt']")).Click();
                    Thread.Sleep(2000);
                }
 
   
                url = driver.Url;
                url = url.Replace("www", "mbasic");
                driver.NewTab();
                driver.SwitchTo().Window(driver.WindowHandles.Last());
                driver.Navigate().GoToUrl(url);
                Thread.Sleep(random.Next(1000, 2000));

                facebookProcessing.FacebookError282MBasic(driver, account, rowIndex, resolveCaptchaKey, apiKey, account.ImgIdentityQuanlityPath, false);

                sqLiteProcessing.InsertOrUpdateAccount(account, idFile);
            }
            catch (Exception ex)
            {
                result = false;
                MainForm.Self.SetColNoteGridViewByRow(rowIndex, ex.Message);
            }
            finally
            {
                //driver.Close();
            }
            return result;
        }
    }
}
