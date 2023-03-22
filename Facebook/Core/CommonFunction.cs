using Facebook.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using RestSharp;
using System.Text.RegularExpressions;
using xNet;

namespace Facebook.Core
{
    public static class CommonFunction
    {
        public static HttpRequest httpRequest;
        public static RestClient restClient;
        public static string GetData(string url, string userArgent = "", string cookie = null)
        {
            if (httpRequest == null)
            {
                httpRequest = new HttpRequest();
                httpRequest.Cookies = new CookieDictionary();
            }

            if (!string.IsNullOrEmpty(cookie))
            {
                AddCookie(httpRequest, cookie);
            }

            if (!string.IsNullOrEmpty(userArgent))
            {
                httpRequest.UserAgent = userArgent;
            }
            string html = httpRequest.Get(url).ToString();
            return html;
        }
        
        #region Cookie
        public static string GetCookie(ChromeDriver driver)
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

        public static void AddCookie(HttpRequest http, string cookie)
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
        public static void ReadFile(List<FaceInfo> faceInfos, string filePath)
        {
            faceInfos.Clear();
            FileHelper fileHelper = new FileHelper();
            var strData = fileHelper.Read(filePath);
            faceInfos = JsonConvert.DeserializeObject<List<FaceInfo>>(strData);
        }

        public static void WriteFile(List<FaceInfo> faceInfos, string filePath)
        {
            FileHelper fileHelper = new FileHelper();
            var strData = JsonConvert.SerializeObject(faceInfos);
            fileHelper.Write(filePath, strData);
        }

        public static byte[] FileToByteArray(string fileName)
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
        public static void SendKeyByXPath(ChromeDriver driver, string xPath, string key)
        {
            Random random = new Random();
            var randomValue = random.NextDouble();
            if (randomValue < 0.9)
            {
                foreach (var item in key)
                {
                    driver.FindElement(By.XPath(xPath)).SendKeys(item.ToString());
                    Thread.Sleep(random.Next(100));
                }
            }
            else
            {
                var randomIndex = random.Next(key.Length - 1);
                for (int i = 0; i < randomIndex; i++)
                {
                    driver.FindElement(By.XPath(xPath)).SendKeys(key[i].ToString());
                    Thread.Sleep(random.Next(random.Next(200)));
                }
                //Ghi 1 chữ cái sai rồi xóa bỏ
                var character = 65 + random.Next(26);
                driver.FindElement(By.XPath(xPath)).SendKeys(Convert.ToChar(character).ToString());
                Thread.Sleep(random.Next(200));
                driver.FindElement(By.XPath(xPath)).SendKeys(Convert.ToChar(8).ToString());
                Thread.Sleep(random.Next(200));
                driver.FindElement(By.XPath(xPath)).SendKeys(key[randomIndex].ToString());
                //
                for (int i = randomIndex + 1; i < key.Length; i++)
                {
                    Thread.Sleep(random.Next(200));
                    driver.FindElement(By.XPath(xPath)).SendKeys(key[i].ToString());
                }
            }
        }
        #endregion Input value for input html

        #region FunctionCommon
        public static string GetLinkFaceImage(int age, string gender)
        {
            string result = "";
            string url = "https://fakeface.rest/face/json?maximum_age=" + (age + 2) + "&minimum_age=" + (age - 2) + "&gender=" + gender;
            HttpRequest httprequest = new HttpRequest();
            var response = httprequest.Get(url).ToString();
            JObject obj = JObject.Parse(response);
            result = (string)obj["image_url"];
            return result;
        }

        public static string UnicodeToUTF8(string from)
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

        public static void InitHttpRequest(AccountInfo account)
        {
            if (httpRequest == null)
            {
                httpRequest = new HttpRequest();
            }
            if (!string.IsNullOrEmpty(account.UserAgent))
            {
                httpRequest.UserAgent = account.UserAgent;
            }
            if (!string.IsNullOrEmpty(account.Proxy))
            {
                if (account.TypeProxy == (int)CommonConstant.TypeProxy.HttpProxy)
                {
                    httpRequest.Proxy = HttpProxyClient.Parse(account.Proxy);
                }
                else if (account.TypeProxy == (int)CommonConstant.TypeProxy.Socks5Proxy)
                {
                    httpRequest.Proxy = Socks5ProxyClient.Parse(account.Proxy);
                }
            }
        }

        public static void InitRestClientOption(AccountInfo account)
        {
            var options = new RestClientOptions()
            {
                MaxTimeout = -1,
                UserAgent = account.UserAgent,
                //Proxy = new WebProxy("", Int32.Parse("")){
                //Credentials = new NetworkCredential(proxySettings.Username, proxySettings.Password, proxySettings.Domain)
                //};,

            };
            var client = new RestClient(options);
            if (!string.IsNullOrEmpty(account.Cookie))
            {
                var lstCookie = account.Cookie.Split(';');
                foreach (var item in lstCookie)
                {
                    var nameValue = item.Split('=');
                    if (nameValue.Count() > 1)
                    {
                        client.CookieContainer.Add(new System.Net.Cookie(nameValue[0], nameValue[1], "/", "www.facebook.com"));
                    }
                }
            }
        }
        #endregion FunctionCommon

        #region Load Accout Info
        public static List<AccountInfo> GetAccountInfosByFilePath(string filePath, ConfigInputModel configInput)
        {
            var lstAccountInfo = new List<AccountInfo>();
            try
            {

                var listOfFieldNames = typeof(AccountInfo).GetProperties().Select(f => f.Name).ToList();
                FileHelper fileHelper = new FileHelper();
                var allData = fileHelper.Read(filePath);
                var lstLineData = allData.Split('\n');
                foreach (var lineData in lstLineData)
                {
                    var accountInfo = new AccountInfo();
                    var data = lineData.Split(configInput.SplitCharacter.ToCharArray());
                    foreach (var input in configInput.lstInput.Keys)
                    {
                        accountInfo.GetType().GetProperty(input).SetValue(accountInfo, data[configInput.lstInput[input]]);
                    }
                    lstAccountInfo.Add(accountInfo);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                lstAccountInfo = new List<AccountInfo>();
            }

            return lstAccountInfo;
        }
        public static List<AccountInfo> GetAccountInfos(string strAccounts, ConfigInputModel configInput)
        {
            var lstAccountInfo = new List<AccountInfo>();
            try
            {

                var listOfFieldNames = typeof(AccountInfo).GetProperties().Select(f => f.Name).ToList();
                FileHelper fileHelper = new FileHelper();
                var lstLineData = strAccounts.Split('\n');
                foreach (var lineData in lstLineData)
                {
                    var accountInfo = new AccountInfo();
                    var data = lineData.Split(configInput.SplitCharacter.ToCharArray());
                    foreach (var input in configInput.lstInput.Keys)
                    {
                        accountInfo.GetType().GetProperty(input).SetValue(accountInfo, data[configInput.lstInput[input]]);
                    }
                    lstAccountInfo.Add(accountInfo);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                lstAccountInfo = new List<AccountInfo>();
            }

            return lstAccountInfo;
        }

        public static string CreatDirectory(string path)
        {
            bool exists = Directory.Exists(path);
            if (!exists)
                Directory.CreateDirectory(path);
            return path;
        }
        #endregion
    }
}
