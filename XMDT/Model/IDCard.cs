using System;
using System.Drawing;
using xNet;

namespace XMDT
{
    internal class IDCard
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Birthday { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }

        public bool CreateIdVND(string filepath, string img, string savefile)
        {
			try
			{
				PointF pName= new PointF(580f, 276f);
				PointF pNameDiff = new PointF(575f, 346f);
				PointF pBirthday = new PointF(620f, 420f);
				PointF pEthnic = new PointF(750f, 455f);
				PointF pImage = new PointF(100f, 282f);
				PointF pGender = new PointF(470f, 458f);
				PointF pAddress = new PointF(485f, 495f);
				PointF pDomicile = new PointF(530f, 567f);
				PointF pExpires = new PointF(230f, 610f);
				Bitmap bitmap = (Bitmap)Image.FromFile(filepath);
				using (Graphics graphics = Graphics.FromImage(bitmap))
				{
					using (Font font = new Font("Arial", 14f))
					{
						graphics.DrawString(LastName + " " + FirstName, font, Brushes.Black, pName);
						graphics.DrawString(LastName + " " + FirstName, font, Brushes.Black, pNameDiff);
						graphics.DrawString(Birthday, font, Brushes.Black, pBirthday);
						graphics.DrawString("KINH", font, Brushes.Black, pEthnic);
						if (!(Gender == "Male"))
						{
							graphics.DrawString("Nam", font, Brushes.Black, pGender);
						}
						else
						{
							graphics.DrawString("Nữ", font, Brushes.Black, pGender);
						}
						graphics.DrawString(Address, font, Brushes.Black, pAddress);
						graphics.DrawString(Address, font, Brushes.Black, pDomicile);
						graphics.DrawString(string.Format("0{0}/0{1}/{2}", Rand.Next(1, 9), Rand.Next(2, 9), Rand.Next(2025, 2029)), font, Brushes.Black, pExpires);
						graphics.DrawImage(new Bitmap(Image.FromFile(img), new Size(200, 250)), pImage);
					}
				}
				bitmap.Save(savefile);
				return true;
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
			return false;
		}

        public bool CreateIdUSD(string filepath, string img, string savefile)
        {
			try
			{
				PointF pLastName = new PointF(380f, 290f);
				PointF pFirstName = new PointF(380f, 320f);
				PointF pAddress = new PointF(380f, 350f);
				PointF pBirthday = new PointF(400f, 410f);
				PointF pImage = new PointF(50f, 189f);
				PointF pGender = new PointF(516f, 490f);
				Bitmap bitmap = (Bitmap)Image.FromFile(filepath);
				using (Graphics graphics = Graphics.FromImage(bitmap))
				{
					using (Font font = new Font("Arial", 15f))
					{
						graphics.DrawString(LastName, font, Brushes.Black, pLastName);
						graphics.DrawString(FirstName, font, Brushes.Black, pFirstName);
						graphics.DrawString(Address, font, Brushes.Black, pAddress);
						graphics.DrawString(Birthday, font, Brushes.Black, pBirthday);
						graphics.DrawImage(new Bitmap(Image.FromFile(img), new Size(211, 262)), pImage);
					}
					using (Font font2 = new Font("Arial", 12f))
					{
						graphics.DrawString(Gender, font2, Brushes.Black, pGender);
					}
				}
				bitmap.Save(savefile);
				return true;
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
			return false;
		}

        public bool CreateIdCALI(string filepath, string img, string savefile)
        {
			try
			{
				PointF pDKI = new PointF(290f, 117f);
				PointF pExpires = new PointF(300f, 152f);
				PointF pLastName = new PointF(300f, 185f);
				PointF pFirstName = new PointF(300f, 212f);
				PointF pAddress = new PointF(315f, 287f);
				PointF pBirthday = new PointF(256f, 245f);
				PointF pImage = new PointF(32f, 80f);
				PointF pGender = new PointF(385f, 380f);
				Bitmap bitmap = (Bitmap)Image.FromFile(filepath);
				using (Graphics graphics = Graphics.FromImage(bitmap))
				{
					using (Font font = new Font("Arial", 14f))
					{
						graphics.DrawString(string.Format("DKI{0}", Rand.Next(1000000, 9999999)), font, Brushes.Black, pDKI);
						graphics.DrawString(string.Format("0{0}/0{1}/{2}", Rand.Next(1, 9), Rand.Next(1, 9), Rand.Next(2022, 2029)), font, Brushes.Black, pExpires);
						graphics.DrawString(LastName, font, Brushes.Black, pLastName);
						graphics.DrawString(FirstName, font, Brushes.Black, pFirstName);
						graphics.DrawString(Address, font, Brushes.Black, pAddress);
						graphics.DrawString(Birthday, font, Brushes.Black, pBirthday);
						graphics.DrawImage(new Bitmap(Image.FromFile(img), new Size(222, 300)), pImage);
					}
					using (Font font2 = new Font("Arial", 12f))
					{
						graphics.DrawString(Gender, font2, Brushes.Black, pGender);
					}
				}
				bitmap.Save(savefile);
				return true;
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
			return false;
		}
    }
}
