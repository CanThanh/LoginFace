using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using XMDT.Model;
using xNet;

namespace XMDT.Controller
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

        #region FunctionCommon
        public string GetLinkFaceImage(int age, string gender)
        {
            string result = "";
            string url = "https://fakeface.rest/face/json?maximum_age=" + (age + 2) + "&minimum_age=" + (age - 2) + "&gender=" + gender;
            HttpRequest httprequest = new HttpRequest();
            var response = httprequest.Get(url).ToString();
            JObject obj = JObject.Parse(response);
            result = (string)obj["image_url"];
            return result;
        }

        public string UnicodeToUTF8(string from)
        {
            var splitted = Regex.Split(from, @"\\u([a-fA-F\d]{4})");
            string outString = "";
            foreach (var s in splitted)
            {
                try
                {
                    if (s.Length == 4)
                    {
                        var decoded = ((char)Convert.ToUInt16(s, 16)).ToString();
                        outString += decoded;
                    }
                    else
                    {
                        outString += s;
                    }
                }
                catch (Exception)
                {
                    outString += s;
                }
            }
            return outString;
        }

        public void InitHttpRequest(HttpRequest httpRequest,int typeProxy ,string proxy, string userAgent)
        {
            httpRequest.UserAgent = userAgent;
            if(typeProxy == (int) CommonConstant.TypeProxy.HttpProxy)
            {
                httpRequest.Proxy = HttpProxyClient.Parse(proxy);
            }
            else if(typeProxy == (int)CommonConstant.TypeProxy.Socks5Proxy)
            {
                httpRequest.Proxy = Socks5ProxyClient.Parse(proxy);
            }
        }
        #endregion FunctionCommon
    }
}
