using Facebook.Core;
using Facebook.Model;
using Newtonsoft.Json;
using Org.BouncyCastle.Asn1.Cms;

namespace Facebook
{
    public partial class ConfigOtp : Form
    {
        string filePath = Environment.CurrentDirectory + FilePath.ConfigOtp;
        ConfigOtpModel configOtpModel = new ConfigOtpModel();
        public ConfigOtp()
        {
            InitializeComponent();
            InitComboBoxLink();
            InitComboBoxHomeNetWork();
            SetValueConfig();
        }

        private void InitComboBoxLink()
        {
            foreach (var member in typeof(EnumLinkGetOtp).GetEnumValues())
            {
                ComboboxItem item = new ComboboxItem();
                item.Text = CommonFunction.GetDesciptionEnum((Enum)member);
                item.Value = ((int)member).ToString();
                cbLink.Items.Add(item);
            }
        }

        private void InitComboBoxHomeNetWork()
        {
            foreach (var member in typeof(EnumHomeNetwork).GetEnumValues())
            {
                ComboboxItem item = new ComboboxItem();
                item.Text = CommonFunction.GetDesciptionEnum((Enum)member);
                item.Value = ((int)member).ToString();
                cbHomeNetwork.Items.Add(item);
            }
        }

        private void SetValueConfig()
        {
            var configOtp = "";
            cbLink.SelectedIndex = -1;
            cbHomeNetwork.SelectedIndex = -1;
            if (File.Exists(filePath))
            {
                FileHelper fileHelper = new FileHelper();
                configOtp = fileHelper.Read(filePath);
            }

            if (!string.IsNullOrEmpty(configOtp))
            {
                configOtpModel = JsonConvert.DeserializeObject<ConfigOtpModel>(configOtp);
                if (configOtpModel != null)
                {
                    txtApiKey.Text = configOtpModel.ApiKey;
                    cbLink.SelectedIndex = configOtpModel.LinkGetOtpSelectedIndex;
                    cbHomeNetwork.SelectedIndex = configOtpModel.HomeNetworkSelectedIndex;
                }
            }
            else
            {
                cbLink.SelectedIndex = cbLink.Items.Count > 0 ? 0 : -1;
                cbHomeNetwork.SelectedIndex = cbHomeNetwork.Items.Count > 0 ? 0 : -1;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            configOtpModel.ApiKey = txtApiKey.Text;
            FileHelper fileHelper = new FileHelper();
            fileHelper.Write(filePath, JsonConvert.SerializeObject(configOtpModel));
            this.Close();
        }

        private void cbLink_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbLink.SelectedItem != null)
            {
                configOtpModel.LinkGetOtpSelectedIndex = cbLink.SelectedIndex;
                configOtpModel.LinkGetOtp = Convert.ToInt32(((ComboboxItem)cbLink.SelectedItem).Value);
            }
        }

        private void cbHomeNetwork_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbHomeNetwork.SelectedItem != null)
            {
                configOtpModel.HomeNetworkSelectedIndex = cbHomeNetwork.SelectedIndex;
                configOtpModel.HomeNetwork = Convert.ToInt32(((ComboboxItem)cbHomeNetwork.SelectedItem).Value);
            }
        }
    }
}