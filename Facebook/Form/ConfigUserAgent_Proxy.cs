using Facebook.Model;
using static Facebook.Model.CommonConstant;

namespace Facebook
{
    public partial class ConfigUserAgent_Proxy : Form
    {
        private int typeForm;
        public ConfigUserAgent_Proxy(int typeForm)
        {
            this.typeForm = typeForm;
            InitializeComponent();            
        }     

        private void InitForm()
        {
            if(typeForm == (int)TypeForm.UserAgent)
            {
                lblList.Text = "Danh sách User Agent:";
                lblAccount.Text = "Số tài khoản/User Agent";
                lblInfo.Text = "(Mỗi User Agent 1 dòng)";
                lblRadio.Text = "Tuỳ chọn nhập User Agent";
                ckExistAccount.Text = "Không nhập với các tài khoản có User Agent";
            }
            else if (typeForm == (int)TypeForm.Proxy)
            {
                lblList.Text = "Danh sách Proxy:";
                lblAccount.Text = "Số tài khoản/Proxy";
                lblInfo.Text = "(Mỗi Proxy 1 dòng)";
                lblRadio.Text = "Tuỳ chọn nhập Proxy";
                ckExistAccount.Text = "Không nhập với các tài khoản có Proxy";
            }
        }

        private void ConfigUserAgent_Proxy_Load(object sender, EventArgs e)
        {
            InitForm();
        }

        private void SetConfigUserAgentProxyModel()
        {
            var result = new List<string>();
            var lstData = rtbInput.Text.Split('\n');
            List<string> temp = new List<string>();
            Random random = new Random();
            foreach (var item in lstData)
            {
                for (int i = 0; i < (int)nUDAccount.Value; i++)
                {
                    temp.Add(item);
                }
            }
            if (!rbRandom.Checked)
            {
                result.AddRange(temp);
            }
            else
            {
                while (temp.Count > 0)
                {
                    var index = random.Next(temp.Count);
                    result.Add(temp[index]);
                    temp.RemoveAt(index);
                }
            }
            var configUserAgentProxyModel = new ConfigUserAgentProxyModel
            {   
                TypeForm = typeForm,
                LstData = result,
                CheckExistData = ckExistAccount.Checked
            };
            MainForm.Self.SetUserAgentOrProxyForAccount(configUserAgentProxyModel);
        }

        private void btnConfirn_Click(object sender, EventArgs e)
        {
            SetConfigUserAgentProxyModel();
            this.Close();
        }
    }
}
