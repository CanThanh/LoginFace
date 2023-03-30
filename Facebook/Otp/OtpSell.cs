using Newtonsoft.Json.Linq;
using xNet;

namespace Facebook.Otp
{
    internal class OtpSell : IOtp
    {
        public int GetBalanceAccount(string apiKey)
        {
            string url = "https://api.sellotp.com/users/balance?token=" + apiKey;
            HttpRequest httpRequest = new HttpRequest();
            var response = httpRequest.Get(url).ToString();
            JObject obj = JObject.Parse(response);
            return (int)obj["data"]["balance"];
        }
        public string GetIdApplicationByName(string apiKey, string appName)
        {
            string url = "https://api.sellotp.com/service/get?token=" + apiKey;
            HttpRequest httpRequest = new HttpRequest();
            var response = httpRequest.Get(url).ToString();
            JObject obj = JObject.Parse(response);
            foreach (var item in obj["data"])
            {
                if (item["name"].ToString().ToLower() == appName.ToLower())
                {
                    return (string)item["id"].ToString();
                }
            }
            return "";
        }

        public string GetNumberByAppId(string apiKey, string appId, out string idNumber)
        {
            string url = "https://api.sellotp.com/request/get?token=" + apiKey + "&serviceId=";// + appId + "&network=MOBIFONE|VINAPHONE|VIETNAMOBILE|ITELECOM";
            idNumber = "";
            try
            {
                HttpRequest httpRequest = new HttpRequest();
                var response = httpRequest.Get(url).ToString();
                JObject obj = JObject.Parse(response);
                idNumber = (string)obj["data"]["request_id"];
                string number = (string)obj["data"]["phone_number"];
                string contrycode = (string)obj["data"]["countryCode"];
                return number.Replace(contrycode, "");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return "";
            }            
        }
        public string GetCodeByIdService(string apiKey, string idNumber)
        {
            var url = "https://api.sellotp.com/session/get?token=" + apiKey + "&requestId=" + idNumber;
            try
            {
                HttpRequest httpRequest = new HttpRequest();
                var response = httpRequest.Get(url).ToString();
                JObject obj = JObject.Parse(response);
                return (string)obj["data"]["Code"];
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return "";
            }           
        }
        public bool CancelByAppId(string apiKey, string idNumber)
        {
            return false;
        }

    }
}
