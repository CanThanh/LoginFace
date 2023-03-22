namespace Facebook.Otp
{
    internal interface IOtp
    {
        int GetBalanceAccount(string apiKey);
        string GetIdApplicationByName(string apiKey, string appName);
        string GetNumberByAppId(string apiKey, string appId, out string idNumber);
        string GetCodeByIdService(string apiKey, string idNumber);
        bool CancelByAppId(string apiKey, string idNumber);
    }
}
