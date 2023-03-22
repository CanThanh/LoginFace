using Newtonsoft.Json.Linq;
using xNet;

namespace Facebook.Otp
{
    internal class OtpChoThueSimCode : IOtp
    {       
        public int GetBalanceAccount(string apiKey)
        {  
            string url = "https://chothuesimcode.com/api?act=account&apik=" + apiKey;
            var httpClient = new HttpClient();
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
            return "";
        }

        public string GetNumberByAppId(string apiKey, string appId, out string idNumber)
        {
            string url = "https://chothuesimcode.com/api?act=number&apik="+ apiKey +"&appId=" + appId;
            idNumber = "";
            HttpRequest httpRequest = new HttpRequest();
            var response = httpRequest.Get(url).ToString();
            JObject obj = JObject.Parse(response);
            var responseCode = (int)obj["ResponseCode"];
            if (responseCode == 0)
            {
                idNumber = (string)obj["Result"]["Id"];
                return (string)obj["Result"]["Number"];
            }
            return "";
        }

        public string GetCodeByIdService(string apiKey, string idNumber)
        {
            string url = "https://chothuesimcode.com/api?act=code&apik=" + apiKey+ "&id=" + idNumber;
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

        public bool CancelByAppId(string apiKey, string idNumber)
        {
            string url = "https://chothuesimcode.com/api?act=expired&apik="+ apiKey + "&id=" + idNumber;
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
    }
}
