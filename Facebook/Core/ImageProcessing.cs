using System.Drawing.Drawing2D;
using System.Net;
using System.Drawing.Text;
using Facebook.Model;

namespace Facebook.Core
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

        public void getImageFromUrl(string fileName, string url, string pathImg)
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
                    img.Save(pathImg);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void ProcessImage(FaceInfo faceInfo,Bitmap bitmap, ConfigIdentityModel configIdentity, Image img)
        {
            try
            {
                PointF pName = new PointF(configIdentity.nUDFirstNameX, configIdentity.nUDFirstNameY);
                PointF pNameDiff = new PointF(configIdentity.nUDLastNameX, configIdentity.nUDLastNameY);
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
                    if (configIdentity.nUDFirstNameX > 0 && configIdentity.nUDFirstNameY > 0)
                    {
                        graphics.DrawString(faceInfo.FirtName, font, brush, pName);
                    }

                    if (configIdentity.nUDLastNameX > 0 && configIdentity.nUDLastNameY > 0)
                    {
                        graphics.DrawString(faceInfo.LastName, font, brush, pNameDiff);
                    }

                    if(configIdentity.nUDBirthdayX > 0 && configIdentity.nUDBirthdayY >0)
                    {
                        graphics.ResetTransform();
                        graphics.RotateTransform(configIdentity.nUDBirthdayRotate, MatrixOrder.Append);
                        graphics.DrawString(faceInfo.DateOfBirth, font, brush, pBirthday);
                    }

                    if (configIdentity.nUDGenderX > 0 && configIdentity.nUDGenderY > 0)
                    {
                        graphics.ResetTransform();
                        graphics.RotateTransform(configIdentity.nUDGenderRotate, MatrixOrder.Append);
                        graphics.DrawString(faceInfo.Gender, font, brush, pGender);
                    }

                    if (configIdentity.nUDAddressX > 0 && configIdentity.nUDAddressY > 0)
                    {
                        graphics.ResetTransform();
                        graphics.RotateTransform(configIdentity.nUDAddressRotate, MatrixOrder.Append);
                        graphics.DrawString(faceInfo.Address, font, brush, pAddress);
                    }


                    //graphics.DrawString(faceInfo.Address, font, brush, pDomicile);
                    //graphics.DrawString(string.Format("0{0}/0{1}/{2}", Rand.Next(1, 9), Rand.Next(2, 9), Rand.Next(2025, 2029)), font, brush, pExpires);

                    if (configIdentity.nUDImgFirstWidth > 0 && configIdentity.nUDImgFirstHeight > 0)
                    {
                        graphics.ResetTransform();
                        graphics.RotateTransform(configIdentity.nUDImgFirstLocationRotate, MatrixOrder.Append);
                        graphics.DrawImage(new Bitmap(img, new Size(configIdentity.nUDImgFirstWidth, configIdentity.nUDImgFirstHeight)), pImage);
                    }


                    if (configIdentity.nUDImgSecondWidth > 0 && configIdentity.nUDImgSecondHeight > 0)
                    {
                        graphics.ResetTransform();
                        graphics.RotateTransform(configIdentity.nUDImgSecondLocationRotate, MatrixOrder.Append);
                        PointF pImageSecond = new PointF(configIdentity.nUDImgSecondLocationX, configIdentity.nUDImgSecondLocationY);
                        graphics.DrawImage(new Bitmap(img, new Size(configIdentity.nUDImgSecondWidth, configIdentity.nUDImgSecondHeight)), pImageSecond);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
