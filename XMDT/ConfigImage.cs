using Newtonsoft.Json;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools;
using OpenQA.Selenium.DevTools.V85.IndexedDB;
using OpenQA.Selenium.Support.UI;
using OtpNet;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using XMDT.Controller;
using xNet;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace XMDT
{
    public partial class ConfigImage : Form
    {
        string imgPath = "";
        Bitmap bitmap= null;

        public ConfigImage()
        {
            InitializeComponent();
            InitComboBox();
            InitConfigPoint();
        }

        private void InitConfigPoint()
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
            //PointF pEthnic = new PointF(750f, 455f); //Dân tộc
            //PointF pDomicile = new PointF(530f, 567f); //Tôn giáo
            //PointF pExpires = new PointF(230f, 610f); //Ngày hết hạn
        }

        private void InitComboBox()
        {
            //Khởi tạo font
            cbFont.Items.Add("Times New Roman");
            cbFont.Items.Add("Arial");
            cbFont.Items.Add("Roboto");
            cbFont.Items.Add("Monospace");
            cbFont.SelectedIndex = 0;
            //Khởi tạo kiểu chữ
            cbFontWeight.Items.Add("Thường");
            cbFontWeight.Items.Add("In đậm");
            cbFontWeight.Items.Add("In nghiêng");
            cbFontWeight.SelectedIndex = 0;
            //Khởi tạo màu sắc
            cbFontColor.Items.Add("Đen");
            cbFontColor.Items.Add("Đỏ");
            cbFontColor.Items.Add("Xanh");
            cbFontColor.Items.Add("Vàng");
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
                Font font = new Font("Arial", 14f);
                FaceInfo faceInfo = new FaceInfo
                {
                    FirtName = "Nguyen Tien",
                    LastName = "Long",
                    DateOfBirth = "19/05/1981",
                    Gender = "Male",
                    Address = "Thien Hien, My Dinh, Tu Liem, Ha Noi",
                    ImageUrl = "https://content.fakeface.rest/female_32_0d3d9bedb2171ff4b3a0f111d6dd756a681fe395.jpg",
                };
                var img = getImageFromUrl("female_32_0d3d9bedb2171ff4b3a0f111d6dd756a681fe395.jpg", faceInfo.ImageUrl);
                ProcessImage(faceInfo, font, Brushes.Black, img);
                ptBoxEdit.Image = (Image)bitmap;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public Image getImageFromUrl(string fileName,string url)
        {
            try
            {
                byte[] content;
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                WebResponse response = request.GetResponse();
                Stream stream = response.GetResponseStream();
                using (BinaryReader br = new BinaryReader(stream))
                {
                    content = br.ReadBytes(500000);
                    br.Close();
                }
                response.Close();

                FileStream fs = new FileStream(fileName, FileMode.Create);
                BinaryWriter bw = new BinaryWriter(fs);
                try
                {
                    bw.Write(content);
                }
                finally
                {
                    fs.Close();
                    bw.Close();
                }
                using (MemoryStream memstr = new MemoryStream(content))
                {
                    Image img = Image.FromStream(memstr);
                    return img;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }        

        private void ProcessImage(FaceInfo faceInfo, Font font, Brush brush, Image img)
        {
            try
            {
                PointF pName = new PointF((float)nUDFirstNameX.Value, (float)nUDFirstNameY.Value);
                PointF pNameDiff = new PointF((float)nUDFirstNameX.Value, (float)nUDFirstNameY.Value);
                PointF pBirthday = new PointF((float)nUDBirthdayX.Value, (float)nUDBirthdayY.Value);
                PointF pImage = new PointF((float)nUDImgFirstLocationX.Value, (float)nUDImgFirstLocationY.Value);
                PointF pGender = new PointF((float)nUDGenderX.Value, (float)nUDGenderY.Value);
                PointF pAddress = new PointF((float)nUDAddressX.Value, (float)nUDAddressY.Value);

                using (Graphics graphics = Graphics.FromImage(bitmap))
                {
                    graphics.RotateTransform((float)nUDFirstNameRotate.Value, MatrixOrder.Append);
                    graphics.DrawString(faceInfo.LastName + " " + faceInfo.FirtName, font, brush, pName);
                    graphics.DrawString(faceInfo.LastName + " " + faceInfo.FirtName, font, brush, pNameDiff);

                    graphics.ResetTransform();
                    graphics.RotateTransform((float)nUDBirthdayRotate.Value, MatrixOrder.Append);
                    graphics.DrawString(faceInfo.DateOfBirth, font, brush, pBirthday);
                    //graphics.DrawString("KINH", font, Brushes.Black, pEthnic);
                    if (!(faceInfo.Gender == "Male"))
                    {
                        graphics.ResetTransform();
                        graphics.RotateTransform((float)nUDGenderRotate.Value, MatrixOrder.Append);
                        graphics.DrawString("Nam", font, brush, pGender);
                    }
                    else
                    {
                        graphics.ResetTransform();
                        graphics.RotateTransform((float)nUDGenderRotate.Value, MatrixOrder.Append);
                        graphics.DrawString("Nữ", font, brush, pGender);
                    }

                    graphics.ResetTransform();
                    graphics.RotateTransform((float)nUDAddressRotate.Value, MatrixOrder.Append);
                    graphics.DrawString(faceInfo.Address, font, brush, pAddress);

                    //graphics.DrawString(faceInfo.Address, font, brush, pDomicile);
                    //graphics.DrawString(string.Format("0{0}/0{1}/{2}", Rand.Next(1, 9), Rand.Next(2, 9), Rand.Next(2025, 2029)), font, brush, pExpires);

                    graphics.ResetTransform();
                    graphics.RotateTransform((float)nUDImgFirstLocationRotate.Value, MatrixOrder.Append);
                    graphics.DrawImage(new Bitmap(img, new Size((int)nUDImgFirstWidth.Value, (int)nUDImgFirstHeight.Value)), pImage);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
