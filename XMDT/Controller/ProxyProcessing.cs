using Newtonsoft.Json.Linq;
using RestSharp;
using System.IO;
using xNet;

namespace XMDT.Controller
{
    internal class ProxyProcessing
    {
        #region TMProxy
        public string GetCurrentProxy(string apiKey)
        {
            var options = new RestClientOptions("https://tmproxy.com")
            {
                MaxTimeout = -1,
            };
            var client = new RestClient(options);
            var request = new RestRequest("/api/proxy/get-current-proxy", Method.Post);
            //request.AddHeader("Content-Type", "application/json");
            var body = "{\"api_key\":\"" + apiKey + "\"}";
            request.AddStringBody(body, DataFormat.Json);
            RestResponse response = client.Execute(request);
            JObject obj = JObject.Parse(response.Content);
            var responseCode = (int)obj["ResponseCode"];
            if (responseCode == 0)
            {
                return (string)obj["data"]["ip_allow"];
            }
            return "";
        }
        public string GetNewProxy(string apiKey)
        {
            var options = new RestClientOptions("https://tmproxy.com")
            {
                MaxTimeout = -1,
            };
            var client = new RestClient(options);
            var request = new RestRequest("/api/proxy/get-new-proxy", Method.Post);
            //request.AddHeader("accept", "application/json");
            //request.AddHeader("Content-Type", "application/json");
            var body = "{\"api_key\":\"" + apiKey + "\",\"sign\":\"\",\"id_location\":0}";
            request.AddStringBody(body, DataFormat.Json);
            RestResponse response = client.Execute(request);
            JObject obj = JObject.Parse(response.Content);
            var responseCode = (int)obj["code"];
            if (responseCode == 0)
            {
                return (string)obj["data"]["ip_allow"];
            }
            return "";

        }
        #endregion TMProxy
    }
}
