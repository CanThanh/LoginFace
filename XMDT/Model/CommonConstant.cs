using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMDT.Model
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
            HttpProxy = 1,
            Socks5Proxy
        }

        public enum TypeForm
        {
            UserAgent,
            Proxy
        }
    }
}
