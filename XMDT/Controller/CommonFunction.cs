using Newtonsoft.Json;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using xNet;

namespace XMDT
{
    public class CommonFunction
    {
        public string GetData(string url, HttpRequest http = null, string userArgent = "", string cookie = null)
        {
            if (http == null)
            {
                http = new HttpRequest();
                http.Cookies = new CookieDictionary();
            }

            if (!string.IsNullOrEmpty(cookie))
            {
                AddCookie(http, cookie);
            }

            if (!string.IsNullOrEmpty(userArgent))
            {
                http.UserAgent = userArgent;
            }
            string html = http.Get(url).ToString();
            return html;
        }
        #region Cookie
        public string GetCookie(ChromeDriver driver)
        {
            string cookie = "";
            try
            {
                var lstCookie = driver.Manage().Cookies.AllCookies;
                for (int i = 0; i < lstCookie.Count; i++)
                {
                    string name = lstCookie.ElementAt(i).Name.ToString().Trim();
                    string value = lstCookie.ElementAt(i).Value.ToString().Trim();
                    if (!string.IsNullOrEmpty(name))
                    {
                        cookie += $"{name}={value};";
                    }
                }
            }
            catch (Exception)
            {
                return "";
            }
            return cookie;
        }

        public void AddCookie(HttpRequest http, string cookie)
        {
            var lstCookie = cookie.Split(';');
            foreach (var item in lstCookie)
            {
                var nameValue = item.Split('=');
                if (nameValue.Count() > 1)
                {
                    http.Cookies.Add(nameValue[0], nameValue[1]);
                }
            }
        }
        #endregion Cookie

        #region File
        public void ReadFile(List<FaceInfo> faceInfos, string filePath)
        {
            faceInfos.Clear();
            FileHelper fileHelper = new FileHelper();
            var strData = fileHelper.Read(filePath);
            faceInfos = JsonConvert.DeserializeObject<List<FaceInfo>>(strData);
        }

        public void WriteFile(List<FaceInfo> faceInfos, string filePath)
        {
            FileHelper fileHelper = new FileHelper();
            var strData = JsonConvert.SerializeObject(faceInfos);
            fileHelper.Write(filePath, strData);
        }

        public byte[] FileToByteArra(string fileName)
        {
            byte[] buff = null;
            FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
            long numBytes = new FileInfo(fileName).Length;
            buff = br.ReadBytes((int)numBytes);
            return buff;
        }
        #endregion File

        #region Input value for input html
        public void SendKeyByXPath(ChromeDriver driver, string xPath, string key)
        {
            Random random = new Random();
            var randomValue = random.NextDouble();
            if (randomValue < 0.9)
            {
                foreach (var item in key)
                {
                    driver.FindElement(By.XPath(xPath)).SendKeys(item.ToString());
                    Thread.Sleep(50);
                }
            }
            else
            {
                var randomIndex = random.Next(key.Length - 1);
                for (int i = 0; i < randomIndex; i++)
                {
                    driver.FindElement(By.XPath(xPath)).SendKeys(key[i].ToString());
                    Thread.Sleep(50);
                }
                //Ghi 1 chữ cái sai rồi xóa bỏ
                var character = 65 + random.Next(26);
                driver.FindElement(By.XPath(xPath)).SendKeys(Convert.ToChar(character).ToString());
                Thread.Sleep(100);
                driver.FindElement(By.XPath(xPath)).SendKeys(Convert.ToChar(8).ToString());
                Thread.Sleep(100);
                driver.FindElement(By.XPath(xPath)).SendKeys(key[randomIndex].ToString());
                //
                for (int i = randomIndex + 1; i < key.Length; i++)
                {
                    Thread.Sleep(50);
                    driver.FindElement(By.XPath(xPath)).SendKeys(key[i].ToString());
                }
            }
        }
        #endregion Input value for input html
    }
}
