using Facebook.Core;
using Facebook.Core.AccountQuality;
using Facebook.Core.FacebookError;
using Facebook.Model;
using Newtonsoft.Json;
using OpenQA.Selenium;
using RestSharp;
using System.Security.Policy;
using System;
using System.Security.Principal;
using System.Text;
using xNet;
using static Facebook.Model.CommonConstant;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Facebook.Otp;

namespace Facebook
{
    public partial class MainForm : Form
    {
        public static MainForm Self;
        //ConfigUserAgent_Proxy configUserAgent_Proxy;
        SQLiteProcessing sqLiteProcessing = new SQLiteProcessing();
        List<AccountInfo> lstAccountInfo = new List<AccountInfo>();
        string KeyResovelCatcha, apiKey;
        int countThread = 3;
        List<int> lstRowDataRun = new List<int>();
        ComboboxItem itemSelected;
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
            //apiKey = "172c280613d44fc194b2143054690b7e"; //otp sell
            apiKey = "46398264a7d207e3"; //doi sang chothuesimcode
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
                itemSelected = (ComboboxItem)cbFile.SelectedItem;
            }
        }
        #endregion

        private void configXMDT_Click(object sender, EventArgs e)
        {
            //Chỉnh lại cấu hình phôi chỗ này có thể cho load từ db
            ConfigImage configImage = new ConfigImage("1");
            configImage.Show();
        }

        public void LoadDataGridView()
        {
            dgViewInput.Rows.Clear();

            lstAccountInfo = sqLiteProcessing.getAllAccount(itemSelected.Value);
            foreach (var item in lstAccountInfo)
            {
                dgViewInput.Rows.Add(false, lstAccountInfo.IndexOf(item) + 1, item.Id, item.Pass, item.TwoFA, item.Cookie,
                                    item.Email, item.PassMail, "", item.Proxy, item.UserAgent, "", "");
            }
        }

        #region MainForm
        private void dgViewInput_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                var oldValue = Convert.ToBoolean(dgViewInput.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);
                dgViewInput.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = !oldValue;
            }
        }

        private void cbFile_SelectedValueChanged(object sender, EventArgs e)
        {
            itemSelected = (ComboboxItem)cbFile.SelectedItem;
            LoadDataGridView();
        }
        #endregion MainForm

        #region Context Menu GridView
        //private void SetCheckColUIdGridView()
        //{
        //    dgViewInput.ContextMenuStrip.Close();
        //    if (dgViewInput.SelectedRows.Count > 0)
        //    {
        //        dgViewInput.CurrentCell = dgViewInput.SelectedRows[0].Cells["colID"];
        //    }
        //}
        private void cmsUnselectedAll_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in dgViewInput.Rows)
            {
                item.Cells["colCheck"].Value = 0;
            }
        }

        private void cmsSelectAll_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in dgViewInput.Rows)
            {
                item.Cells["colCheck"].Value = true;
            }
        }

        private void cmsSelectHightlight_Click(object sender, EventArgs e)
        {
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
            dgViewInput.Rows[rowIndex].Cells["colStatus"].Value = "";
            FacebookError282 facebookError282 = new FacebookError282();
            var account = lstAccountInfo[rowIndex];

            var result = facebookError282.ProcessMBasicFacebook(account, rowIndex, "", KeyResovelCatcha, apiKey, rbLoginCookie.Checked);
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
                            if (configUserAgentProxyModel.TypeForm == (int)TypeForm.Proxy)
                            {
                                lstAccountInfo[dgViewInput.Rows.IndexOf(item)].Proxy = configUserAgentProxyModel.LstData[count];
                            }
                            else
                            {
                                lstAccountInfo[dgViewInput.Rows.IndexOf(item)].UserAgent = configUserAgentProxyModel.LstData[count];
                            }
                            item.Cells[colName].Value = configUserAgentProxyModel.LstData[count];
                            count++;
                        }
                        else if (!string.IsNullOrEmpty(Convert.ToString(item.Cells[colName].Value)))
                        {
                            if (configUserAgentProxyModel.TypeForm == (int)TypeForm.Proxy)
                            {
                                lstAccountInfo[dgViewInput.Rows.IndexOf(item)].Proxy = configUserAgentProxyModel.LstData[count];
                            }
                            else
                            {
                                lstAccountInfo[dgViewInput.Rows.IndexOf(item)].UserAgent = configUserAgentProxyModel.LstData[count];
                            }
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
            dgViewInput.Rows[rowIndex].Cells["colStatus"].Value = "";
            FacebookProcessing facebookProcessing = new FacebookProcessing();
            string url = "https://mbasic.facebook.com/";
            var result = facebookProcessing.CheckStatusAccount(lstAccountInfo[rowIndex], url, rowIndex, rbLoginCookie.Checked);
            dgViewInput.Rows[rowIndex].Cells["colStatus"].Value = result ? "Sống" : "Checkpoint";
        }

        #region AccountQuality
        private void cmsAccountQuality_Click(object sender, EventArgs e)
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
            RunMultiThread(FacebookAccountQuality);
        }
        private void FacebookAccountQuality(int rowIndex)
        {
            dgViewInput.Rows[rowIndex].Cells["colStatus"].Value = "";
            FacebookAccountQuality facebookAccountQuality = new FacebookAccountQuality();
            var account = lstAccountInfo[rowIndex];
            //Set mau phoi o dau so 1
            var result = facebookAccountQuality.Proccess(account, rowIndex, itemSelected.Value, "1", KeyResovelCatcha, apiKey, rbLoginCookie.Checked);
            dgViewInput.Rows[rowIndex].Cells["colStatus"].Value = result ? "Thành công" : "Lỗi";
        }
        #endregion

        #region Login
        private void cmsLogin_Click(object sender, EventArgs e)
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
            RunMultiThread(FacebookLogin);
        }
        private void FacebookLogin(int rowIndex)
        {
            dgViewInput.Rows[rowIndex].Cells["colStatus"].Value = "";
            FacebookProcessing facebookProcessing = new FacebookProcessing();
            var account = lstAccountInfo[rowIndex];
            var result = false;
            var driver = facebookProcessing.InitChromeDriver(account);



            if (rbLoginCookie.Checked)
            {
                facebookProcessing.LoginCookie(driver, FacebookLinkUrl.MFacebook, account.Cookie);
            }
            else if (rbLoginUP.Checked)
            {
                if (string.IsNullOrEmpty(account.TwoFA))
                {
                    facebookProcessing.LoginFace(driver, FacebookLinkUrl.MFacebook, account.Id, account.Pass);
                }
                else
                {
                    facebookProcessing.LoginFace(driver, FacebookLinkUrl.MFacebook, account.Id, account.Pass, account.TwoFA);
                }
            }

            dgViewInput.Rows[rowIndex].Cells["colStatus"].Value = result ? "Thành công" : "Lỗi";
        }
        #endregion

        private void oTPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfigOtp configOtp = new ConfigOtp();
            configOtp.Show();
        }
    }
}
