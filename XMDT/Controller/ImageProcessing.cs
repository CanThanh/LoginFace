using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using XMDT.Model;
using System.Drawing.Text;

namespace XMDT.Controller
{
    internal class ImageProcessing
    {
        public Image getImageFromUrl(string fileName, string url)
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

        public void ProcessImage(FaceInfo faceInfo,Bitmap bitmap, ConfigIdentity configIdentity, Image img)
        {
            try
            {
                PointF pName = new PointF(configIdentity.nUDFirstNameX, configIdentity.nUDFirstNameY);
                PointF pNameDiff = new PointF(configIdentity.nUDFirstNameX, configIdentity.nUDFirstNameY);
                PointF pBirthday = new PointF(configIdentity.nUDBirthdayX, configIdentity.nUDBirthdayY);
                PointF pImage = new PointF(configIdentity.nUDImgFirstLocationX, configIdentity.nUDImgFirstLocationY);
                PointF pGender = new PointF(configIdentity.nUDGenderX, configIdentity.nUDGenderY);
                PointF pAddress = new PointF(configIdentity.nUDAddressX, configIdentity.nUDAddressY);

                var fontName = configIdentity.cbFont;
                InstalledFontCollection col = new InstalledFontCollection();
                var fontFamily = col.Families.First(x => x.Name == fontName);
                Font font = new Font(fontFamily, configIdentity.nUDFontSize, (FontStyle)configIdentity.cbFontStyle);
                Brush brush = new SolidBrush(ColorTranslator.FromHtml(configIdentity.cbFontColor));

                using (Graphics graphics = Graphics.FromImage(bitmap))
                {
                    graphics.RotateTransform(configIdentity.nUDFirstNameRotate, MatrixOrder.Append);
                    graphics.DrawString(faceInfo.LastName + " " + faceInfo.FirtName, font, brush, pName);
                    graphics.DrawString(faceInfo.LastName + " " + faceInfo.FirtName, font, brush, pNameDiff);

                    graphics.ResetTransform();
                    graphics.RotateTransform(configIdentity.nUDBirthdayRotate, MatrixOrder.Append);
                    graphics.DrawString(faceInfo.DateOfBirth, font, brush, pBirthday);
                    //graphics.DrawString("KINH", font, Brushes.Black, pEthnic);
                    if (!(faceInfo.Gender == "Male"))
                    {
                        graphics.ResetTransform();
                        graphics.RotateTransform(configIdentity.nUDGenderRotate, MatrixOrder.Append);
                        graphics.DrawString("Nam", font, brush, pGender);
                    }
                    else
                    {
                        graphics.ResetTransform();
                        graphics.RotateTransform(configIdentity.nUDGenderRotate, MatrixOrder.Append);
                        graphics.DrawString("Nữ", font, brush, pGender);
                    }

                    graphics.ResetTransform();
                    graphics.RotateTransform(configIdentity.nUDAddressRotate, MatrixOrder.Append);
                    graphics.DrawString(faceInfo.Address, font, brush, pAddress);

                    //graphics.DrawString(faceInfo.Address, font, brush, pDomicile);
                    //graphics.DrawString(string.Format("0{0}/0{1}/{2}", Rand.Next(1, 9), Rand.Next(2, 9), Rand.Next(2025, 2029)), font, brush, pExpires);

                    graphics.ResetTransform();
                    graphics.RotateTransform(configIdentity.nUDImgFirstLocationRotate, MatrixOrder.Append);
                    graphics.DrawImage(new Bitmap(img, new Size(configIdentity.nUDImgFirstWidth, configIdentity.nUDImgFirstHeight)), pImage);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
