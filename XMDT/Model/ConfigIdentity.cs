using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMDT.Model
{
    internal class ConfigIdentityModel
    {
        public int nUDFirstNameRotate {get; set;}
        public int nUDFirstNameY {get; set;}
        public int nUDFirstNameX {get; set;}
        public int nUDImgFirstHeight {get; set;}
        public int nUDImgFirstWidth {get; set;}
        public int nUDImgSecondHeight {get; set;}
        public int nUDImgSecondWidth {get; set;}
        public int nUDImgFirstLocationRotate {get; set;}
        public int nUDImgFirstLocationY {get; set;}
        public int nUDImgFirstLocationX {get; set;}
        public int nUDAddressRotate {get; set;}
        public int nUDAddressY {get; set;}
        public int nUDAddressX {get; set;}
        public int nUDGenderRotate {get; set;}
        public int nUDGenderY {get; set;}
        public int nUDGenderX {get; set;}
        public int nUDBirthdayRotate {get; set;}
        public int nUDBirthdayY {get; set;}
        public int nUDBirthdayX {get; set;}
        public int nUDLastNameRotate {get; set;}
        public int nUDLastNameY {get; set;}
        public int nUDLastNameX {get; set;}
        public int nUDImgSecondLocationRotate {get; set;}
        public int nUDImgSecondLocationY {get; set;}
        public int nUDImgSecondLocationX {get; set;}
        public int nUDFontSize {get; set;}
        public string cbFontColor {get; set;}
        public int cbFontStyle {get; set;}
        public string cbFont { get; set;}
    }

    public class ConfigInputModel
    {
        public string SplitCharacter { get; set; }
        public Dictionary<string, int> lstInput { get; set; } = new Dictionary<string, int>();
    }

    public class ConfigUserAgentProxyModel
    {
        public List<string> LstData { get; set; } = new List<string>();
        public bool CkeckExistData { get; set; }
    }
}
