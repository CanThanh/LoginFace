using Newtonsoft.Json;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools;
using OpenQA.Selenium.DevTools.V85.IndexedDB;
using OpenQA.Selenium.Support.UI;
using OtpNet;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using xNet;
using static XMDT.Model.CommonConstant;

namespace XMDT
{
    public partial class ConfigUserAgent_Proxy : Form
    {
        public int typeForm;
        public ConfigUserAgent_Proxy()
        {
            InitializeComponent();            
        }     

        private void InitForm()
        {
            if(typeForm == (int)TypeForm.UserAgent)
            {
                lblList.Text = "Danh sách User Agent:";
                lblAccount.Text = "Số tài khoản/User Agent";
                lblInfo.Text = "(Mỗi User Agent 1 dòng)";
                lblRadio.Text = "Tuỳ chọn nhập User Agent";
                ckExistAccount.Text = "Không nhập với các tài khoản có User Agent";
            }
            else if (typeForm == (int)TypeForm.Proxy)
            {
                lblList.Text = "Danh sách Proxy:";
                lblAccount.Text = "Số tài khoản/Proxy";
                lblInfo.Text = "(Mỗi Proxy 1 dòng)";
                lblRadio.Text = "Tuỳ chọn nhập Proxy";
                ckExistAccount.Text = "Không nhập với các tài khoản có Proxy";
            }
        }

        private void ConfigUserAgent_Proxy_Load(object sender, EventArgs e)
        {
            InitForm();
        }
    }
}
