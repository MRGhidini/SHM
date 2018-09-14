using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Net;
using Microsoft.Win32;
using System.Runtime.Serialization.Formatters.Binary;

namespace SHM
{
    public partial class OptionsSet : Form
    {
        public OptionsSet()
        {
            InitializeComponent();
        }

        private void Options_Load(object sender, EventArgs e)
        {
            LoadSettings();
        }

        void LoadSettings()
        {
            try
            {   //CreateRegistry
                SetConfigRegistry.VerifyRegistry();
                textPSV.Text = SetConfigRegistry.ReadRegistry("PathPsvita");
                textPS3.Text = SetConfigRegistry.ReadRegistry("PathPS3");
                textPS4.Text = SetConfigRegistry.ReadRegistry("PathPS4");
                textDownload.Text = SetConfigRegistry.ReadRegistry("PathDownload");
            }
            catch (Exception ex)
            {
                return;
            }
        }

        private void Options_FormClosing(object sender, FormClosingEventArgs e)
        {
            UpdateSettings(true);
        }

        void UpdateSettings(bool withStoring)
        {
            SetConfigRegistry.RecordRegistry("PathPsvita", textPSV.Text);
            SetConfigRegistry.RecordRegistry("PathPS3", textPS3.Text);
            SetConfigRegistry.RecordRegistry("PathPS4", textPS4.Text);
            SetConfigRegistry.RecordRegistry("PathDownload", textDownload.Text);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ShowOpenFileWindow(textPSV);
        }


        private void button5_Click(object sender, EventArgs e)
        {
            ShowOpenFileWindow(textPS3);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ShowOpenFileWindow(textPS4);
        }


        void ShowOpenFileWindow(TextBox tb)
        {

            using (var fbd = new OpenFileDialog())
            {
                fbd.Filter = "|*.tsv";

                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.FileName))
                {
                    tb.Text = fbd.FileName;
                }
            }

        }

        void ShowOpenPathWindow(TextBox tb)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    tb.Text = fbd.SelectedPath;
                }
            }

        }

        private void button9_Click(object sender, EventArgs e)
        {
            ShowOpenPathWindow(textDownload);
        }
    }
}
