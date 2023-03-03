﻿using System;
using System.IO;
using System.Windows.Forms;
using XMDT.Model;
using System.Linq;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace XMDT
{
    public partial class ConfigInput : Form
    {
        string currentDirectory = Path.GetDirectoryName(Path.GetDirectoryName(Environment.CurrentDirectory));
        string pathFile =  "\\File\\setting\\inputformat.json";
        private bool lvInput_mDown, lvConfig_mDown;
        public ConfigInputModel configInputModel;
        public List<ConfigInputModel> lstConfigInputModel = new List<ConfigInputModel>();
        public ConfigInput()
        {
            InitializeComponent();
            //InitListView();
            SetConfigInputModel();
            InitComboBoxInput();
        }

        private void InitListView()
        {
            lvInput.Items.Add("EmailRecover");
            lvInput.Items.Add("UserAgent");
            lvInput.Items.Add("TypeProxy");
            lvInput.Items.Add("Proxy");
            lvInput.Items.Add("ImgFacePath");
            lvInput.Items.Add("Status");
            lvInput.Items.Add("EAAG");
            lvInput.Items.Add("EAAB");
            lvInput.Items.Add("EAAAAAY");
            lvInput.Items.Add("DTSG");

            lvConfig.Items.Add("Id");
            lvConfig.Items.Add("Pass");
            lvConfig.Items.Add("TwoFA");
            lvConfig.Items.Add("Email");
            lvConfig.Items.Add("PassMail");
            lvConfig.Items.Add("Cookie");
        }

        private void InitComboBoxInput()
        {
            FileHelper fileHelper = new FileHelper();
            var content = fileHelper.Read(currentDirectory + pathFile);
            lstConfigInputModel.Clear();
            cbInput.Items.Clear();
            var lst = JsonConvert.DeserializeObject<List<ConfigInputModel>>(content);
            if(lst != null && lst.Count > 0)
            {
                lstConfigInputModel.AddRange(lst);
            }
            foreach (var item in lstConfigInputModel)
            {
                var cbInputItem = string.Join(item.SplitCharacter, item.lstInput.Keys);
                cbInput.Items.Add($"{cbInputItem}");
            }
        }

        private void SetConfigInputModel()
        {
            configInputModel = new ConfigInputModel();
            foreach (ListViewItem item in lvConfig.Items)
            {
                configInputModel.lstInput.Add(item.Text, lvConfig.Items.IndexOf(item));
            }
            configInputModel.SplitCharacter = txtSplitCharacter.Text;
        }

        #region Drag and Drop 2 ListView
        private void lvInput_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
                e.Effect = DragDropEffects.Move;
            else
                e.Effect = DragDropEffects.None;
        }

        private void lvInput_DragDrop(object sender, DragEventArgs e)
        {
            var data = e.Data.GetData(DataFormats.Text).ToString();
            if (!string.IsNullOrEmpty(data))
            {
                if (lvConfig_mDown)
                {
                    lvConfig.Items.RemoveAt(lvConfig.SelectedIndices[0]);
                    lvInput.Items.Add(data);
                }
                if (lvInput_mDown)
                {
                    lvInput.Items.RemoveAt(lvInput.SelectedIndices[0]);
                    lvInput.Items.Add(data);
                }
            }
            lvInput_mDown = false;
            lvConfig_mDown = false;
        }

        private void lvInput_MouseDown(object sender, MouseEventArgs e)
        {
            lvInput_mDown = true;
        }

        private void lvInput_MouseUp(object sender, MouseEventArgs e)
        {
            lvInput_mDown = false;
        }

        private void lvInput_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right) return;
            if (lvInput_mDown && lvInput.SelectedItems.Count > 0)
            {
                lvInput.DoDragDrop(lvInput.SelectedItems[0].Text, DragDropEffects.Move);
            }
        }

        private void lvConfig_MouseDown(object sender, MouseEventArgs e)
        {
            lvConfig_mDown = true;
        }

        private void lvConfig_MouseUp(object sender, MouseEventArgs e)
        {
            lvConfig_mDown = false;
        }
        private void lvConfig_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right) return;
            if (lvConfig_mDown && lvConfig.SelectedItems.Count > 0)
            {
                lvConfig.DoDragDrop(lvConfig.SelectedItems[0].Text, DragDropEffects.Move);
            }
        }

        private void lvConfig_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
                e.Effect = DragDropEffects.Move;
            else
                e.Effect = DragDropEffects.None;
        }

        private void lvConfig_DragDrop(object sender, DragEventArgs e)
        {
            var data = e.Data.GetData(DataFormats.Text).ToString();
            if (!string.IsNullOrEmpty(data))
            {
                if (lvConfig_mDown)
                {
                    lvConfig.Items.RemoveAt(lvConfig.SelectedIndices[0]);
                    lvConfig.Items.Add(data);
                }
                if (lvInput_mDown)
                {
                    lvInput.Items.RemoveAt(lvInput.SelectedIndices[0]);
                    lvConfig.Items.Add(data);
                }
            }
            lvInput_mDown = false;
            lvConfig_mDown = false;
        }
        #endregion 

        private void SaveFileInputFomat()
        {
            FileHelper fileHelper = new FileHelper();
            string content = JsonConvert.SerializeObject(lstConfigInputModel);
            fileHelper.Write(currentDirectory + pathFile, content);
        }

        private void btnAddDirection_Click(object sender, EventArgs e)
        {

        }

        private void btnAddOtherInput_Click(object sender, EventArgs e)
        {
            configInputModel = new ConfigInputModel();
            foreach (ListViewItem item in lvConfig.Items)
            {
                configInputModel.lstInput.Add(item.Text, lvConfig.Items.IndexOf(item));
            }
            configInputModel.SplitCharacter = txtSplitCharacter.Text;
            lstConfigInputModel.Add(configInputModel);
            SaveFileInputFomat();
            InitComboBoxInput();
        }

        private void ckOtherFormat_CheckedChanged(object sender, EventArgs e)
        {
            if (ckOtherFormat.Checked)
            {
                InitListView();
            }
            else
            {
                lvConfig.Items.Clear();
                lvInput.Items.Clear();
            }
        }

        private void btnRemoveItemInput_Click(object sender, EventArgs e)
        {
            var index = cbInput.SelectedIndex;
            if (index >= 0 && cbInput.Items.Count > 0)
            {
                cbInput.Items.RemoveAt(index);
                lstConfigInputModel.RemoveAt(index);
            }
            SaveFileInputFomat();
        }

        private void btnAddAccount_Click(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSplitCharacter.Text) || txtSplitCharacter.Text.Length > 2)
            {
                MessageBox.Show("Vui lòng nhập 1 ký tụ phân cách giữa các dữ liệu");
            } else if(lvInput.Items.Count == 0) 
            {
                MessageBox.Show("Vui lòng chọn dữ liệu đầu vào");
            } else {
                SetConfigInputModel();
                this.Close();
            }
        }
    }
}
