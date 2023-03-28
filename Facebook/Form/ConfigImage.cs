using Facebook.Core;
using Facebook.Model;
using System.Drawing.Text;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace Facebook
{
    public partial class ConfigImage : Form
    {
        string imgPath = "";
        Bitmap bitmap = null;
        string idConfigIdentity;

        public ConfigImage()
        {
            InitializeComponent();
            InitComboBox();
            InitConfigPoint("");
        }

        public ConfigImage(string idConfigIdentity)
        {
            InitializeComponent();
            InitComboBox();
            InitConfigPoint(idConfigIdentity);
        }

        private void InitConfigPoint(string idConfigIdentity)
        {
            if (string.IsNullOrEmpty(idConfigIdentity))
            {
                nUDFirstNameX.Value = 580;
                nUDFirstNameY.Value = 276;
                nUDLastNameX.Value = 575;
                nUDLastNameY.Value = 346;
                nUDBirthdayX.Value = 620;
                nUDBirthdayY.Value = 420;
                nUDImgFirstLocationX.Value = 100;
                nUDImgFirstLocationY.Value = 282;
                nUDGenderX.Value = 470;
                nUDGenderY.Value = 458;
                nUDAddressX.Value = 485;
                nUDAddressY.Value = 495;
                nUDImgFirstWidth.Value = 200;
                nUDImgFirstHeight.Value = 250;
                nUDFontSize.Value = 16;
            }
            else
            {
                SQLiteProcessing sqLiteProcessing = new SQLiteProcessing();
                var configIdentityDbModel = sqLiteProcessing.GetConfigIndentityById(idConfigIdentity);
                nUDFirstNameX.Value = configIdentityDbModel.configIdentityModel.nUDFirstNameX;
                nUDFirstNameY.Value = configIdentityDbModel.configIdentityModel.nUDFirstNameY;
                nUDFirstNameRotate.Value = configIdentityDbModel.configIdentityModel.nUDFirstNameRotate;
                nUDLastNameX.Value = configIdentityDbModel.configIdentityModel.nUDLastNameX;
                nUDLastNameY.Value = configIdentityDbModel.configIdentityModel.nUDLastNameY;
                nUDLastNameRotate.Value = configIdentityDbModel.configIdentityModel.nUDLastNameRotate;
                nUDBirthdayX.Value = configIdentityDbModel.configIdentityModel.nUDBirthdayX;
                nUDBirthdayY.Value = configIdentityDbModel.configIdentityModel.nUDBirthdayY;
                nUDBirthdayRotate.Value = configIdentityDbModel.configIdentityModel.nUDBirthdayRotate;
                nUDImgFirstLocationX.Value = configIdentityDbModel.configIdentityModel.nUDImgFirstLocationX;
                nUDImgFirstLocationY.Value = configIdentityDbModel.configIdentityModel.nUDImgFirstLocationY;
                nUDImgFirstWidth.Value = configIdentityDbModel.configIdentityModel.nUDImgFirstWidth;
                nUDImgFirstHeight.Value = configIdentityDbModel.configIdentityModel.nUDImgFirstHeight;
                nUDImgFirstLocationRotate.Value = configIdentityDbModel.configIdentityModel.nUDImgFirstLocationRotate;
                nUDGenderX.Value = configIdentityDbModel.configIdentityModel.nUDGenderX;
                nUDGenderY.Value = configIdentityDbModel.configIdentityModel.nUDGenderY;
                nUDGenderRotate.Value = configIdentityDbModel.configIdentityModel.nUDGenderRotate;
                nUDAddressX.Value = configIdentityDbModel.configIdentityModel.nUDAddressX;
                nUDAddressY.Value = configIdentityDbModel.configIdentityModel.nUDAddressY;
                nUDAddressRotate.Value = configIdentityDbModel.configIdentityModel.nUDAddressRotate;
                nUDImgSecondLocationX.Value = configIdentityDbModel.configIdentityModel.nUDImgSecondLocationX;
                nUDImgSecondLocationY.Value = configIdentityDbModel.configIdentityModel.nUDImgSecondLocationY;
                nUDImgSecondWidth.Value = configIdentityDbModel.configIdentityModel.nUDImgSecondWidth;
                nUDImgSecondHeight.Value = configIdentityDbModel.configIdentityModel.nUDImgSecondHeight;
                nUDImgSecondLocationRotate.Value = configIdentityDbModel.configIdentityModel.nUDImgSecondLocationRotate;

                nUDFontSize.Value = configIdentityDbModel.configIdentityModel.nUDFontSize;
                txtName.ReadOnly = true;
                txtName.Text = configIdentityDbModel.name;
                if (File.Exists(configIdentityDbModel.imageUrl))
                {
                    imgPath = configIdentityDbModel.imageUrl;
                    ptBoxEdit.Image = Image.FromFile(configIdentityDbModel.imageUrl);
                    ptBoxOriginal.Image = Image.FromFile(configIdentityDbModel.imageUrl);
                }
            }
        }

        private void InitComboBox()
        {
            //Khởi tạo font
            using (InstalledFontCollection col = new InstalledFontCollection())
            {
                foreach (FontFamily fa in col.Families)
                {
                    cbFont.Items.Add(fa.Name);
                }
            }
            cbFont.SelectedIndex = 0;
            //Khởi tạo kiểu chữ
            cbFontStyle.Items.Add(new { Text = "Thường", Value = 0 });
            cbFontStyle.Items.Add(new { Text = "Đậm", Value = 1 });
            cbFontStyle.Items.Add(new { Text = "In nghiêng", Value = 2 });
            cbFontStyle.Items.Add(new { Text = "Gạch dưới", Value = 4 });
            cbFontStyle.Items.Add(new { Text = "Gạch ngang", Value = 8 });
            cbFontStyle.DisplayMember = "Text";
            cbFontStyle.ValueMember = "Value";
            cbFontStyle.SelectedIndex = 0;
            //Khởi tạo màu sắc
            cbFontColor.Items.Add(new { Text = "Đỏ", Value = "#ff0000" });
            cbFontColor.Items.Add(new { Text = "Vàng", Value = "#ffff00" });
            cbFontColor.Items.Add(new { Text = "Xanh", Value = "#00ff00" });
            cbFontColor.Items.Add(new { Text = "Đen", Value = "#000000" });
            cbFontColor.Items.Add(new { Text = "Trắng", Value = "#ffffff" });
            cbFontColor.DisplayMember = "Text";
            cbFontColor.ValueMember = "Value";
            cbFontColor.SelectedIndex = 0;
        }

        private void btnLoadImg_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.tif;...";
            dialog.InitialDirectory = @"D:\ABCD\XMDT\XMDT\LoginFace\File\form";
            dialog.Title = "Vui lòng chọn ảnh";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                imgPath = dialog.FileName;
                ptBoxOriginal.Image = Image.FromFile(dialog.FileName);
                ptBoxEdit.Image = Image.FromFile(dialog.FileName);
            }
        }

        private void btnPreviewImg_Click(object sender, EventArgs e)
        {
            try
            {
                bitmap = (Bitmap)Image.FromFile(imgPath);

                FaceInfo faceInfo = new FaceInfo
                {
                    first_name = "Nguyen Tien",
                    last_name = "Long",
                    birthday = "19.05.81",
                    gender = "Male",
                    address = "Thien Hien, My Dinh, Tu Liem, Ha Noi",
                };
                ImageProcessing imageProcessing = new ImageProcessing();
                var imageUrl = "https://content.fakeface.rest/female_32_0d3d9bedb2171ff4b3a0f111d6dd756a681fe395.jpg";
                var img = imageProcessing.getImageFromUrl(imageUrl.Substring(30), imageUrl);
                imageProcessing.ProcessImage(faceInfo, bitmap, GetConfigIdentityForm(), img);
                ptBoxEdit.Image = (Image)bitmap;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private ConfigIdentityModel GetConfigIdentityForm()
        {
            var configIdentity = new ConfigIdentityModel
            {
                nUDFirstNameRotate = (int)nUDFirstNameRotate.Value,
                nUDFirstNameY = (int)nUDFirstNameY.Value,
                nUDFirstNameX = (int)nUDFirstNameX.Value,
                nUDImgFirstHeight = (int)nUDImgFirstHeight.Value,
                nUDImgFirstWidth = (int)nUDImgFirstWidth.Value,
                nUDImgSecondHeight = (int)nUDImgSecondHeight.Value,
                nUDImgSecondWidth = (int)nUDImgSecondWidth.Value,
                nUDImgFirstLocationRotate = (int)nUDImgFirstLocationRotate.Value,
                nUDImgFirstLocationY = (int)nUDImgFirstLocationY.Value,
                nUDImgFirstLocationX = (int)nUDImgFirstLocationX.Value,
                nUDAddressRotate = (int)nUDAddressRotate.Value,
                nUDAddressY = (int)nUDAddressY.Value,
                nUDAddressX = (int)nUDAddressX.Value,
                nUDGenderRotate = (int)nUDGenderRotate.Value,
                nUDGenderY = (int)nUDGenderY.Value,
                nUDGenderX = (int)nUDGenderX.Value,
                nUDBirthdayRotate = (int)nUDBirthdayRotate.Value,
                nUDBirthdayY = (int)nUDBirthdayY.Value,
                nUDBirthdayX = (int)nUDBirthdayX.Value,
                nUDLastNameRotate = ckFullName.Checked ? 0 : (int)nUDLastNameRotate.Value,
                nUDLastNameY = ckFullName.Checked ? 0 : (int)nUDLastNameY.Value,
                nUDLastNameX = ckFullName.Checked ? 0 : (int)nUDLastNameX.Value,
                nUDImgSecondLocationRotate = (int)nUDImgSecondLocationRotate.Value,
                nUDImgSecondLocationY = (int)nUDImgSecondLocationY.Value,
                nUDImgSecondLocationX = (int)nUDImgSecondLocationX.Value,
                nUDFontSize = (int)nUDFontSize.Value,
                cbFontColor = (cbFontColor.SelectedItem as dynamic).Value,
                cbFontStyle = (cbFontStyle.SelectedItem as dynamic).Value,
                cbFont = cbFont.Text,
            };
            return configIdentity;
        }

        private void btnSaveConfig_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtName.Text))
            {
                MessageBox.Show("Vui lòng nhập tên phôi muốn lưu");
            }
            else
            {
                SQLiteProcessing sqLiteProcessing = new SQLiteProcessing();
                sqLiteProcessing.InsertOrUpdateConfigIndentity(txtName.Text, GetConfigIdentityForm(), imgPath);
                this.Close();
            }
        }

        private void ckFullName_CheckedChanged(object sender, EventArgs e)
        {
            if (ckFullName.Checked)
            {
                lblFistName.Text = "Họ và tên";
                nUDLastNameX.Visible = false;
                nUDLastNameY.Visible = false;
                nUDLastNameRotate.Visible = false;
                lblLastName.Visible = false;
            }
            else
            {
                lblFistName.Text = "Họ";
                lblLastName.Visible = true;
                nUDLastNameX.Visible = true;
                nUDLastNameY.Visible = true;
                nUDLastNameRotate.Visible = true;
            }

        }
    }
}
