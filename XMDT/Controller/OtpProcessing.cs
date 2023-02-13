using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xNet;

namespace XMDT.Controller
{
    internal class OtpProcessing
    {
        #region Chothuesimcode
        public int GetBalanceAccount(string apiKey)
        {  
            string url = "https://chothuesimcode.com/api?act=account&apik=" + apiKey;
            HttpRequest httpRequest = new HttpRequest();
            var response = httpRequest.Get(url).ToString();            
            JObject obj = JObject.Parse(response);
            return (int) obj["Result"]["Balance"];
        }

        public string GetIdApplicationByName(string apiKey, string appName)
        {
            string url = "https://chothuesimcode.com/api?act=app&apik=" + apiKey;
            HttpRequest httpRequest = new HttpRequest();
            var response = httpRequest.Get(url).ToString();
            JObject obj = JObject.Parse(response);
            if ((int) obj["ResponseCode"] == 0)
            {
                foreach (var item in obj["Result"])
                {
                    if (item["Name"].ToString().ToLower() == appName.ToLower())
                    {
                        return (string)item["Id"].ToString();
                    }
                }
            }
            return "abcd";
        }

        public string GetNumberByAppId(string apiKey, string appId)
        {
            string url = "https://chothuesimcode.com/api?act=number&apik="+ apiKey +"&appId=" + appId;
            HttpRequest httpRequest = new HttpRequest();
            var response = httpRequest.Get(url).ToString();
            JObject obj = JObject.Parse(response);
            var responseCode = (int)obj["ResponseCode"];
            if (responseCode == 0)
            {
                return (string)obj["Result"]["Number"];
            }
            return "";
        }

        public string GetCodeNumberByNumber(string apiKey, string number)
        {
            string url = "https://chothuesimcode.com/api?act=code&apik=" + apiKey+ "&id=" + number;
            HttpRequest httpRequest = new HttpRequest();
            var response = httpRequest.Get(url).ToString();
            JObject obj = JObject.Parse(response);
            var responseCode = (int)obj["ResponseCode"];
            if (responseCode == 0)
            {
                return (string)obj["Result"]["Code"];
            }
            return "";
        }

        public bool CancelByAppId(string apiKey, string appId)
        {
            string url = "https://chothuesimcode.com/api?act=expired&apik="+ apiKey + "&id=" + appId;
            HttpRequest httpRequest = new HttpRequest();
            var response = httpRequest.Get(url).ToString();
            JObject obj = JObject.Parse(response);
            var responseCode = (int)obj["ResponseCode"];
            if (responseCode == 0)
            {
                return true;
            }
            return false;
        }

        //OtpProcessing otpProcessing = new OtpProcessing();
        //string apiKey = "90e2b1f8fa419d46";
        //string appId = otpProcessing.GetIdApplicationByName(apiKey, "Facebook");
        //otpProcessing.CancelByAppId(apiKey, appId);
        //    var number = otpProcessing.GetNumberByAppId(apiKey, appId);
        //int count = 0;
        //var code = "";
        //    while (string.IsNullOrEmpty(code) && count< 10)
        //    {
        //        Thread.Sleep(5000);
        //        code = otpProcessing.GetCodeNumberByNumber(apiKey, number);
        //        count ++;
        //    }
        //MessageBox.Show(code + " ,count:" + count);
        #endregion Chothuesimcode
    }
}
