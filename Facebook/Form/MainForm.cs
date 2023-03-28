using Facebook.Core;
using Facebook.Core.AccountQuality;
using Facebook.Core.FacebookError;
using Facebook.Model;
using xNet;
using static Facebook.Model.CommonConstant;
using static Facebook.Model.FaceInfo;

namespace Facebook
{
    public partial class MainForm : Form
    {
        public static MainForm Self;
        //ConfigUserAgent_Proxy configUserAgent_Proxy;
        SQLiteProcessing sqLiteProcessing = new SQLiteProcessing();
        List<AccountInfo> lstAccountInfo = new List<AccountInfo>();
        string KeyResovelCatcha;
        int countThread = 3;
        List<int> lstRowDataRun = new List<int>();
        public MainForm()
        {
            InitializeComponent();
            Self = this;
            //configUserAgent_Proxy = new ConfigUserAgent_Proxy();
            //SQLiteProcessing sQLiteProcessing = new SQLiteProcessing();
            //sQLiteProcessing.createTable();
            InitComboBoxFile();
            LoadDataGridView();
            KeyResovelCatcha = "90b9de403cd4c42f45a4f9048760dec0";
        }

        #region InitData when Form Load
        private void InitComboBoxFile()
        {
            cbFile.Items.Clear();
            var lstFile = sqLiteProcessing.getAllFile();
            foreach (var item in lstFile)
            {
                cbFile.Items.Add(item);
            }
            if (lstFile.Count > 0)
            {
                cbFile.SelectedIndex = 0;
            }
        }
        #endregion

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

            facebookProcessing.LoginFace(driver, urlFace, account.Id, account.Pass, account.TwoFA);
            string eaab = facebookProcessing.GetEAABToken(driver);
            string dtsg = facebookProcessing.GetDTSGToken(driver);
            string cookie = CommonFunction.GetCookie(driver);
            facebookProcessing.CallAuthenTwoFa(account.Id, account.TwoFA, dtsg, cookie);
            Thread.Sleep(2000);
            string eaag = facebookProcessing.GetEAAGTokenApi(account.Id, cookie);

            //var urlInfo = "https://graph.facebook.com/v15.0/me?access_token="+ eaag +"&fields=id%2Cname%2Cfirst_name%2Cgender%2Chometown%2Crelationship_status%2Creligion%2Cfriends%2Cbirthday%2Clast_name";
            //cookie = facebookProcessing.GetCookie(driver);

            //var kq = facebookProcessing.GetUserInfo(inf.Id);

            var kq = facebookProcessing.GetUserInfoSecond(eaag, cookie);

            var x = CommonFunction.UnicodeToUTF8(kq);

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

        public void LoadDataGridView()
        {
            dgViewInput.Rows.Clear();
            var itemSelected = (ComboboxItem)cbFile.SelectedItem;
            lstAccountInfo = sqLiteProcessing.getAllAccount(itemSelected.Value);
            foreach (var item in lstAccountInfo)
            {
                dgViewInput.Rows.Add(false, lstAccountInfo.IndexOf(item) + 1, item.Id, item.Pass, item.TwoFA, item.Cookie,
                                    item.Email, item.PassMail, "", item.Proxy, item.UserAgent, "", "");
            }
        }

        #region Context Menu GridView
        private void SetCheckColUIdGridView()
        {
            dgViewInput.ContextMenuStrip.Close();
            if (dgViewInput.SelectedRows.Count > 0)
            {
                dgViewInput.CurrentCell = dgViewInput.SelectedRows[0].Cells["colID"];
            }
        }
        private void cmsUnselectedAll_Click(object sender, EventArgs e)
        {
            SetCheckColUIdGridView();
            foreach (DataGridViewRow item in dgViewInput.Rows)
            {
                item.Cells["colCheck"].Value = 0;
            }
        }

        private void cmsSelectAll_Click(object sender, EventArgs e)
        {
            SetCheckColUIdGridView();
            foreach (DataGridViewRow item in dgViewInput.Rows)
            {
                item.Cells["colCheck"].Value = true;
            }
        }

        private void cmsSelectHightlight_Click(object sender, EventArgs e)
        {
            SetCheckColUIdGridView();
            foreach (DataGridViewRow item in dgViewInput.SelectedRows)
            {
                item.Cells["colCheck"].Value = true;
            }
        }
        #endregion

        #region Process 282 Facebook in contextmenu DatagridView
        private AccountInfo ConvertRowGridViewToAccountInfo(int rowIndex)
        {
            var accountInfo = new AccountInfo();
            try
            {
                accountInfo.Id = Convert.ToString(dgViewInput.Rows[rowIndex].Cells["colID"].Value);
                accountInfo.Pass = Convert.ToString(dgViewInput.Rows[rowIndex].Cells["colPass"].Value);
                accountInfo.TwoFA = Convert.ToString(dgViewInput.Rows[rowIndex].Cells["colTwoFA"].Value);
                accountInfo.Cookie = Convert.ToString(dgViewInput.Rows[rowIndex].Cells["colCookie"].Value);
                accountInfo.Email = Convert.ToString(dgViewInput.Rows[rowIndex].Cells["colEmail"].Value);
                accountInfo.Pass = Convert.ToString(dgViewInput.Rows[rowIndex].Cells["colPassMail"].Value);
                accountInfo.Proxy = Convert.ToString(dgViewInput.Rows[rowIndex].Cells["colProxy"].Value);
                accountInfo.UserAgent = Convert.ToString(dgViewInput.Rows[rowIndex].Cells["colUserAgent"].Value);
                accountInfo.Status = Convert.ToString(dgViewInput.Rows[rowIndex].Cells["colStatus"].Value);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                accountInfo = new AccountInfo();
            }
            return accountInfo;
        }

        private void cmsCheckPoint282_Click(object sender, EventArgs e)
        {
            dgViewInput.ContextMenuStrip.Close();
            lstRowDataRun.Clear();
            foreach (DataGridViewRow item in dgViewInput.Rows)
            {
                if (Convert.ToBoolean(item.Cells["colCheck"].Value))
                {
                    lstRowDataRun.Add(dgViewInput.Rows.IndexOf(item));
                }
            }
            RunMultiThread(CheckPointMBasic282);
        }

        private void CheckPointMBasic282(int rowIndex)
        {
            FacebookError282 facebookError282 = new FacebookError282();
            var result = facebookError282.ProcessMBasicFacebook(lstAccountInfo[rowIndex], rowIndex, KeyResovelCatcha, rbLoginCookie.Checked);
            dgViewInput.Rows[rowIndex].Cells["colStatus"].Value = result ? "Hoàn thành" : "Có lỗi";
        }
        #endregion

        #region Data Input      
        private void addAccount_Click(object sender, EventArgs e)
        {
            ConfigInput configInput = new ConfigInput();
            configInput.Show();
        }
        private void addUserAgent_Click(object sender, EventArgs e)
        {
            ConfigUserAgent_Proxy configUserAgent_Proxy = new ConfigUserAgent_Proxy((int)TypeForm.UserAgent);
            configUserAgent_Proxy.Show();
        }

        private void addProxy_Click(object sender, EventArgs e)
        {
            ConfigUserAgent_Proxy configUserAgent_Proxy = new ConfigUserAgent_Proxy((int)TypeForm.Proxy);
            configUserAgent_Proxy.Show();
        }

        public void SetUserAgentOrProxyForAccount(ConfigUserAgentProxyModel configUserAgentProxyModel)
        {
            try
            {
                string colName = configUserAgentProxyModel.TypeForm == (int)TypeForm.Proxy ? "colProxy" : "colUserAgent";
                var countData = configUserAgentProxyModel.LstData.Count;
                int count = 0;
                foreach (DataGridViewRow item in dgViewInput.Rows)
                {
                    if (count < countData && Convert.ToBoolean(item.Cells["colCheck"].Value))
                    {
                        if (!configUserAgentProxyModel.CheckExistData)
                        {
                            item.Cells[colName].Value = configUserAgentProxyModel.LstData[count];
                            count++;
                        }
                        else if (!string.IsNullOrEmpty(Convert.ToString(item.Cells[colName].Value)))
                        {
                            item.Cells[colName].Value = configUserAgentProxyModel.LstData[count];
                            count++;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show("Dữ liệu cấu hình chưa đúng. Vui lòng kiểm tra lại");
            }
        }
        #endregion

        #region MultiThread
        private void RunMultiThread(Action<int> actionName)
        {
            //ThreadPool.SetMaxThreads(countThread, countThread);
            ParallelOptions parallelOptions = new ParallelOptions();
            parallelOptions.MaxDegreeOfParallelism = countThread;
            Parallel.ForEach(lstRowDataRun, parallelOptions, itemRow =>
            {
                lock ((object)itemRow) { actionName(itemRow); }
            });
        }

        public void SetColNoteGridViewByRow(int rowIndex, string value)
        {
            dgViewInput.Rows[rowIndex].Cells["colNote"].Value = value;
        }
        #endregion

        private void btnRemoveAccount_Click(object sender, EventArgs e)
        {
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show("Bạn chắc chắn muốn xoá danh sách tài khoản này?", "Xoá", buttons);
            if (result == DialogResult.Yes)
            {
                List<string> lstUserId = new List<string>();
                var itemSelected = (ComboboxItem)cbFile.SelectedItem;
                foreach (DataGridViewRow item in dgViewInput.Rows)
                {
                    if (Convert.ToBoolean(item.Cells["colCheck"].Value))
                    {
                        lstUserId.Add(item.Cells["colID"].Value.ToString());
                    }
                }
                sqLiteProcessing.DeleteListAccount(lstUserId, itemSelected.Value);
                LoadDataGridView();
            }
        }

        private void checkStatusAccount_Click(object sender, EventArgs e)
        {
            dgViewInput.ContextMenuStrip.Close();
            lstRowDataRun.Clear();
            foreach (DataGridViewRow item in dgViewInput.Rows)
            {
                if (Convert.ToBoolean(item.Cells["colCheck"].Value))
                {
                    lstRowDataRun.Add(dgViewInput.Rows.IndexOf(item));
                }
            }
            RunMultiThread(CheckStatusAccount);
        }
        private void CheckStatusAccount(int rowIndex)
        {
            FacebookProcessing facebookProcessing = new FacebookProcessing();
            string url = "https://mbasic.facebook.com/";
            var result = facebookProcessing.CheckStatusAccount(lstAccountInfo[rowIndex], url, rowIndex, rbLoginCookie.Checked);
            dgViewInput.Rows[rowIndex].Cells["colStatus"].Value = result ? "Sống" : "Checkpoint";
        }

        private void cmsAccountQuality_Click(object sender, EventArgs e)
        {
            dgViewInput.ContextMenuStrip.Close();
            FacebookAccountQuality facebookAccountQuality = new FacebookAccountQuality();
            int rowIndex = 9;
            var result = facebookAccountQuality.Proccess(lstAccountInfo[rowIndex], rowIndex, KeyResovelCatcha, rbLoginCookie.Checked);
            dgViewInput.Rows[rowIndex].Cells["colStatus"].Value = result ? "Thành công" : "Lỗi";
        }
    }
}
