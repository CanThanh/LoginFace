using System;
using System.Diagnostics;
using System.IO;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using XMDT.Controller;
using XMDT.Facebook;
using XMDT.Model;
using xNet;

namespace XMDT
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }  

        //100007557514409  snowkvt123  B6R546Q2K26FCFOTLU2MUKT3ANYWLRYY   micshidevon@hotmail.com     @thainguyenteam@@1022020    micshidevon2022 @getnada.com
        //100009306396626  snowkvt1234  76IZ6TLE4XTKIWFRIKCVQSWYSRMZRWQN	alishauemargie@hotmail.com  @thainguyenteam@@1022020    alishauemargie2022@getnada.com
        private void btnProgess_Click()
        {
            string currentDirectory = Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(Environment.CurrentDirectory)));
            FileHelper fileHelper = new FileHelper();
            var pathUserAgent = currentDirectory + "\\File\\ua.txt";
            var userAgent = fileHelper.ReadLine(pathUserAgent)[Rand.Next(0, fileHelper.ReadLine(pathUserAgent).Count)];
            AccountInfo account = new AccountInfo();

            var pathProxy = currentDirectory + "\\File\\proxy.txt";
            var proxy = fileHelper.ReadLine(pathProxy)[Rand.Next(0, fileHelper.ReadLine(pathProxy).Count)];

            var pathAccount = currentDirectory + "\\File\\account.txt";
            var accountLst = fileHelper.ReadLine(pathAccount)[Rand.Next(0, fileHelper.ReadLine(pathAccount).Count)];

            var pathSecondaryEmail = currentDirectory + "\\File\\secondaryemail.txt";
            var strSecondaryEmail = fileHelper.ReadLine(pathSecondaryEmail)[Rand.Next(0, fileHelper.ReadLine(pathSecondaryEmail).Count)];
            var secondaryEmail = new SecondaryEmail();
            var infSecondaryEmail = strSecondaryEmail.Split('|');
            secondaryEmail.Email = infSecondaryEmail[0];
            secondaryEmail.Pass = infSecondaryEmail[1];

            var infAccount = accountLst.Split(' ');
            account.Id = infAccount[0];
            account.Pass = infAccount[1];
            account.TwoFA = infAccount[2];
            account.Email = infAccount[3];
            account.PassMail = infAccount[4];
            //inf.EmailRecover = infAccount[5];

            //MailProcessing mail = new MailProcessing();
            //var code = mail.GetCode(inf.Email, inf.PassMail, "outlook.office365.com", 993, @"\d+");
            
            FacebookProcessing facebookProcessing = new FacebookProcessing();
            //var kq = facebookProcessing.GetLinkFaceImage(30, "male");

            var driver = facebookProcessing.InitChromeDriver(account);

            string urlMail = "https://login.live.com/login.srf?wa=wsignin1.0&rpsnv=13&ct=1656739386&rver=7.0.6737.0&wp=MBI_SSL&wreply=https%3a%2f%2foutlook.live.com%2fowa%2f%3fnlp%3d1%26RpsCsrfState%3d7426e649-3fef-467b-6e2b-6026c58ea03b&id=292841&aadredir=1&CBCXT=out&lw=1&fl=dob%2cflname%2cwld&cobrandid=90015";
            string urlFace = "https://m.facebook.com/login/?ref=dbl&fl";
            string urlAddMailFace = "https://m.facebook.com/ntdelegatescreen/?params=%7B%22entry-point%22%3A%22settings%22%7D&path=%2Fcontacts%2Fmanagement%2F";
            string urlFaceInfo = "https://m.facebook.com/profile.php?v=info&_rdr";

            //string cookie = "presence=EDvF3EtimeF1675742421EuserFA21B03574129834A2EstateFDutF0CEchF_7bCC;cppo=1;m_page_voice=100003574129834;xs=10%3AAA9MUI7T-hnOGg%3A2%3A1675742409%3A-1%3A11945;c_user=100003574129834;locale=vi_VN;wd=929x879;m_pixel_ratio=1;fr=05YnzmcTSx7a2u5xz.AWUqjLht6jYAmSiSj46xHsf97qg.Bj4cy5.7Q.AAA.0.0.Bj4czH.AWVw7EQ79Wg;usida=eyJ2ZXIiOjEsImlkIjoiQXJwb3o0aDQwdno4MyIsInRpbWUiOjE2NzU3NDI0MTd9;sb=uczhYxqd-jNUJ7QzKES0Nu_B;datr=uczhY2GY8sB6sc4tUfXL3Lgj";

            //string cookie2 = "datr=1LvhY1pGpki2WZzFaXc-8f_v; sb=1LvhY8qSzVz63ESQJCNrjd0F; m_pixel_ratio=1; locale=vi_VN; fr=0Pgf72nltOesLADqP.AWVXDWEUwUp1p8bY1yjfnz6a6UU.Bj4bvU.5z.AAA.0.0.Bj4bvi.AWWjB2-UB7Q; c_user=100003574129834; xs=44%3ATITPFBpdERQNnA%3A2%3A1675738084%3A-1%3A11945; m_page_voice=100003574129834; cppo=1; usida=eyJ2ZXIiOjEsImlkIjoiQXJwb3hyaTE2ZXJ3MWYiLCJ0aW1lIjoxNjc1NzQwNzM1fQ%3D%3D; presence=EDvF3EtimeF1675740790EuserFA21B03574129834A2EstateFDutF0CEchF_7bCC; wd=1920x372";

            //facebookProcessing.LoginCookie(driver, cookie);

            facebookProcessing.LoginFace(driver, urlFace, account.Id, account.Pass, account.TwoFA );
            string eaab = facebookProcessing.GetEAABToken(driver);
            string dtsg = facebookProcessing.GetDTSGToken(driver);
            string cookie = facebookProcessing.GetCookie(driver);
            facebookProcessing.CallAuthenTwoFa(account.Id, account.TwoFA, dtsg, cookie);
            Thread.Sleep(2000);
            string eaag = facebookProcessing.GetEAAGTokenApi(account.Id, cookie);

            //var urlInfo = "https://graph.facebook.com/v15.0/me?access_token="+ eaag +"&fields=id%2Cname%2Cfirst_name%2Cgender%2Chometown%2Crelationship_status%2Creligion%2Cfriends%2Cbirthday%2Clast_name";
            //cookie = facebookProcessing.GetCookie(driver);

            //var kq = facebookProcessing.GetUserInfo(inf.Id);

            var kq = facebookProcessing.GetUserInfoSecond(eaag, cookie);

            var x = facebookProcessing.UnicodeToUTF8(kq);

            //GetFaceInfo(driver, urlFaceInfo, inf.Id);
            //WriteFile(currentDirectory + "\\File\\userInfo.json");
            //ReadFile(currentDirectory + "\\File\\userInfo.json");

            //GetCodeHotMail(driver, urlMail, inf.Email, inf.PassMail);

            var hoangnv1 = "hoangnv1";
        }

        private void configXMDT_Click(object sender, EventArgs e)
        {
            ConfigImage configImage = new ConfigImage();
            configImage.Show();
        }

        private void facebookerr282_Click(object sender, EventArgs e)
        {
            FacebookError282 facebookError282 = new FacebookError282();
            string currentDirectory = Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(Environment.CurrentDirectory)));
            var pathData = currentDirectory + "\\File\\accountQuality.txt";
            var lstAccount = facebookError282.GetAllAccount(pathData);
            ////Đa luồng cần proxy đa luồng
            //for (int i = 0; i < 3; i++)
            //{
            //    var account = lstAccount[i];
            //    account.UserAgent = "Mozilla/5.0 (Linux; Android 10; SCV47 Build/QP1A.190711.020; wv) AppleWebKit/537.36 (KHTML, like Gecko) Version/4.0 Chrome/84.0.4147.111 Mobile Safari/537.36";
            //    account.TypeProxy = (int) CommonConstant.TypeProxy.HttpProxy;
            //    account.Proxy = "170.210.121.190:8080";
            //    Task t = new Task(() => { 
            //        facebookError282.ProcessMBasicFacebook(account, "90b9de403cd4c42f45a4f9048760dec0");
            //    });
            //    t.Start();
            //}

            var account = lstAccount[2];
            //account.UserAgent = "Mozilla/5.0 (Linux; Android 10; SCV47 Build/QP1A.190711.020; wv) AppleWebKit/537.36 (KHTML, like Gecko) Version/4.0 Chrome/84.0.4147.111 Mobile Safari/537.36";
            account.UserAgent = "Mozilla/5.0 (Linux; Android 9; SAMSUNG SM-G960U) AppleWebKit/537.36 (KHTML, like Gecko) SamsungBrowser/10.1 Chrome/71.0.3578.99 Mobile Safari/537.36";
            account.TypeProxy = (int) CommonConstant.TypeProxy.HttpProxy;
            //account.Proxy = "95.85.24.83:8118";
            account.Proxy = "154.236.189.5:8080";
            facebookError282.ProcessMBasicFacebook(account, "90b9de403cd4c42f45a4f9048760dec0");
        }
    }
}
