using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facebook.Model
{
    internal class CommonConstant
    {
        public enum AccountStatus
        {
            Ok,
            Error282,
        }
        public enum TypeProxy
        {
            HttpProxy = 0,
            Socks5Proxy
        }

        public enum TypeForm
        {
            UserAgent,
            Proxy
        }
    }
    internal class FacebookLinkUrl
    {
        public const string MBasicFacebook = "https://mbasic.facebook.com/";
        public const string MFacebook = "https://m.facebook.com/";
        public const string Facebook = "https://www.facebook.com/";
        public const string FacebookAccountQuality = "https://www.facebook.com/accountquality/";
        public const string FacebookBusinessLocations = "https://business.facebook.com/business_locations/";
        public const string FacebookContentManagement = "https://business.facebook.com/content_management/";
        public const string FacebookAdsmanager = "https://www.facebook.com/pe";
        public const string FacebookReauth = "https://business.facebook.com/security/twofactor/reauth/enter/";
        public const string FacebookMProfile = "https://m.facebook.com/profile.php?v=info&_rdr";
        public const string FacebookGetAccountInfo = "https://graph.facebook.com/me?fields=first_name,last_name,middle_name,name,birthday,gender&access_token=";
    }

}
