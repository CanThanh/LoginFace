using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facebook.Model
{
    internal class ConfigOtpModel
    {
        public string ApiKey;
        public int LinkGetOtp;
        public int HomeNetwork;
        public int LinkGetOtpSelectedIndex;
        public int HomeNetworkSelectedIndex;
    }

    public enum EnumLinkGetOtp
    {
        [Description("Sell")]
        Sell = 0,
        [Description("Chothuesimcode")]
        Chothuesimcode = 1,
    }

    public enum EnumHomeNetwork
    {
        [Description("Tất cả")]
        All = 0,
        [Description("Vinaphone")]
        Vinaphone = 1,
        [Description("Viettel")]
        Viettel = 2,
        [Description("Mobifone")]
        Mobifone = 3,
        [Description("Vietnamobile")]
        Vietnamobile = 4,
        [Description("Gmobile")]
        Gmobile = 5,
        [Description("I-Telecom")]
        ITelecom = 6,
        [Description("Reddi")]
        Reddi = 7
    }
}
