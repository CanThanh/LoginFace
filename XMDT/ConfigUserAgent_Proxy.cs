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
using XMDT.Model;
using xNet;
using static XMDT.Model.CommonConstant;

namespace XMDT
{
    public partial class ConfigUserAgent_Proxy : Form
    {
        public int typeForm;
        public ConfigUserAgentProxyModel configUserAgentProxyModel;
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
            SetConfigUserAgentProxyModel();
        }

        //private void ConfigUserAgentProxyModel()
        //{
        //    configUserAgentProxyModel = new ConfigUserAgentProxyModel
        //    {
        //        Data = rtbInput.Text,
        //        AccountPerData = (int) nUDAccount.Value,
        //        IsRandom = rbRandom.Checked,
        //        CkeckExistData = ckExistAccount.Checked
        //    };            
        //}

        private void SetConfigUserAgentProxyModel()
        {
            var result = new List<string>();
            var lstData = rtbInput.Text.Split('\n');
            List<string> temp = new List<string>();
            Random random = new Random();
            foreach (var item in lstData)
            {
                for (int i = 0; i < (int)nUDAccount.Value; i++)
                {
                    temp.Add(item);
                }
            }
            if (!rbRandom.Checked)
            {
                result.AddRange(temp);
            }
            else
            {
                while (temp.Count > 0)
                {
                    var index = random.Next(temp.Count);
                    result.Add(temp[index]);
                    temp.RemoveAt(index);
                }
            }
            configUserAgentProxyModel = new ConfigUserAgentProxyModel
            {
                LstData = result,
                CkeckExistData = ckExistAccount.Checked
            };
        }

        private void btnConfirn_Click(object sender, EventArgs e)
        {
            SetConfigUserAgentProxyModel();
            this.Close();
        }
    }
}
