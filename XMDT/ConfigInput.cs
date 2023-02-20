﻿using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace XMDT
{
    public partial class ConfigInput : Form
    {
        private bool lvInput_mDown, lvConfig_mDown;
        public ConfigInput()
        {
            InitializeComponent();
            InitListView();
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
        private void button1_Click(object sender, EventArgs e)
        {

        }

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
    }
}
