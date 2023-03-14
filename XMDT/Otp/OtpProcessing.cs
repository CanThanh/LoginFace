using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMDT.Otp
{
    internal interface OtpProcessing
    {
        int GetBalanceAccount(string apiKey);
        string GetIdApplicationByName(string apiKey, string appName);
        string GetNumberByAppId(string apiKey, string appId, out string idNumber);
        string GetCodeByIdService(string apiKey, string idNumber);
        bool CancelByAppId(string apiKey, string idNumber);
    }
}
