using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SHM
{
    public partial class Main : Form
    {

        public Main()
        {
            InitializeComponent();
        }
        enum TypeRege { PathPsvita, PathPS3, PathPS4, PathDownload };

        private void Donate_Click(object sender, EventArgs e)
        {
            string url = "https://goo.gl/sXsvDg";
            System.Diagnostics.Process.Start(url);
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string url = "https://github.com/MRGhidini/SHM#special-thanks";
            System.Diagnostics.Process.Start(url);
        }

        private void Main_Load(object sender, EventArgs e)
        {
            return;
        }

        private void settingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OptionsSet o = new OptionsSet();
            o.ShowDialog();
        }

        private void rootToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!Utilitary.VerifyPath())
            {
                OptionsSet o = new OptionsSet();
                o.ShowDialog();
                return;
            }
            System.Diagnostics.Process.Start(SetConfigRegistry.ReadRegistry(TypeRege.PathDownload.ToString()));

        }

        private void Psvita_CheckedChanged(object sender, EventArgs e)
        {
            if (Psvita.Checked)
            {
                if (!Utilitary.VerifyPath())
                {
                    OptionsSet o = new OptionsSet();
                    o.ShowDialog();
                    Psvita.Checked = false;
                    return;
                }
                if (!Utilitary.Verifythers(TypeRege.PathPsvita.ToString()))
                {
                    OptionsSet o = new OptionsSet();
                    o.ShowDialog();
                    Psvita.Checked = false;
                    return;
                }

                Utilitary.CreateFolder(SetConfigRegistry.ReadRegistry(TypeRege.PathDownload.ToString()) + "\\HomeBrewDonwload");
                Utilitary.CreateFolder(SetConfigRegistry.ReadRegistry(TypeRege.PathDownload.ToString()) + "\\HomeBrewDonwload\\"+"Psvita");

                var HomeBrewList = new List<string>();
                var HomeBrewSelec = Utilitary.GetHomeBrewSelec(HomeBrewList, TypeRege.PathPsvita.ToString()); 

                if (string.IsNullOrEmpty(HomeBrewSelec.TitleId))
                {
                    Psvita.Checked = false;
                    return;
                }

                if (HomeBrewSelec.TitleId == "--Exit--")
                {
                    Psvita.Checked = false;
                    return;
                }

                Utilitary.CreateFolder(SetConfigRegistry.ReadRegistry(TypeRege.PathDownload.ToString()) + "\\HomeBrewDonwload\\" + "Psvita\\" + HomeBrewSelec.TitleId);

                string Ex = HomeBrewSelec.LastDirectLink;
                string Extension = Ex.Substring(Ex.Length - 4, 4);
                string patharc = SetConfigRegistry.ReadRegistry(TypeRege.PathDownload.ToString()) + "\\HomeBrewDonwload\\" + "Psvita\\" + HomeBrewSelec.TitleId + "\\"+HomeBrewSelec.TitleName+ Extension;
                DownloadFile(HomeBrewSelec.LastDirectLink,patharc);
                progressBar1.Visible = true;
                label6.Visible = true;
                Psvita.Enabled = false;
                PS3.Enabled = false;
                PS4.Enabled = false;
                Psvita.Checked = false;

                string NameArtTxt = SetConfigRegistry.ReadRegistry(TypeRege.PathDownload.ToString()) + "\\HomeBrewDonwload\\" + @"\historic.txt";
                Utilitary.CreateFileWriteHistoric(NameArtTxt, HomeBrewSelec.TitleId);

            }
        }

        private void PS3_CheckedChanged(object sender, EventArgs e)
        {
            if (PS3.Checked)
            {
                if (!Utilitary.VerifyPath())
                {
                    OptionsSet o = new OptionsSet();
                    o.ShowDialog();
                    PS3.Checked = false;
                    return;
                }
                if (!Utilitary.Verifythers(TypeRege.PathPS3.ToString()))
                {
                    OptionsSet o = new OptionsSet();
                    o.ShowDialog();
                    PS3.Checked = false;
                    return;
                }

                Utilitary.CreateFolder(SetConfigRegistry.ReadRegistry(TypeRege.PathDownload.ToString()) + "\\HomeBrewDonwload");
                Utilitary.CreateFolder(SetConfigRegistry.ReadRegistry(TypeRege.PathDownload.ToString()) + "\\HomeBrewDonwload\\" + "PS3");

                var HomeBrewList = new List<string>();
                var HomeBrewSelec = Utilitary.GetHomeBrewSelec(HomeBrewList, TypeRege.PathPS3.ToString());

                if (string.IsNullOrEmpty(HomeBrewSelec.TitleId))
                {
                    PS3.Checked = false;
                    return;
                }

                if (HomeBrewSelec.TitleId == "--Exit--")
                {
                    PS3.Checked = false;
                    return;
                }

                Utilitary.CreateFolder(SetConfigRegistry.ReadRegistry(TypeRege.PathDownload.ToString()) + "\\HomeBrewDonwload\\" + "PS3\\" + HomeBrewSelec.TitleId);

                string Ex = HomeBrewSelec.LastDirectLink;
                string Extension = Ex.Substring(Ex.Length - 4, 4);
                string patharc = SetConfigRegistry.ReadRegistry(TypeRege.PathDownload.ToString()) + "\\HomeBrewDonwload\\" + "PS3\\" + HomeBrewSelec.TitleId + "\\" + HomeBrewSelec.TitleName + Extension;
                DownloadFile(HomeBrewSelec.LastDirectLink, patharc);
                progressBar1.Visible = true;
                label6.Visible = true;
                Psvita.Enabled = false;
                PS3.Enabled = false;
                PS4.Enabled = false;
                PS3.Checked = false;

                string NameArtTxt = SetConfigRegistry.ReadRegistry(TypeRege.PathDownload.ToString()) + "\\HomeBrewDonwload\\" + @"\historic.txt";
                Utilitary.CreateFileWriteHistoric(NameArtTxt, HomeBrewSelec.TitleId);
            }            
        }

        private void PS4_CheckedChanged(object sender, EventArgs e)
        {
            if (PS4.Checked)
            {
                if (!Utilitary.VerifyPath())
                {
                    OptionsSet o = new OptionsSet();
                    o.ShowDialog();
                    PS4.Checked = false;
                    return;
                }
                if (!Utilitary.Verifythers(TypeRege.PathPS4.ToString()))
                {
                    OptionsSet o = new OptionsSet();
                    o.ShowDialog();
                    PS4.Checked = false;
                    return;
                }

                Utilitary.CreateFolder(SetConfigRegistry.ReadRegistry(TypeRege.PathDownload.ToString()) + "\\HomeBrewDonwload");
                Utilitary.CreateFolder(SetConfigRegistry.ReadRegistry(TypeRege.PathDownload.ToString()) + "\\HomeBrewDonwload\\" + "PS4");

                var HomeBrewList = new List<string>();
                var HomeBrewSelec = Utilitary.GetHomeBrewSelec(HomeBrewList, TypeRege.PathPS4.ToString());

                if (string.IsNullOrEmpty(HomeBrewSelec.TitleId))
                {
                    PS4.Checked = false;
                    return;
                }

                if (HomeBrewSelec.TitleId == "--Exit--")
                {
                    PS4.Checked = false;
                    return;
                }

                Utilitary.CreateFolder(SetConfigRegistry.ReadRegistry(TypeRege.PathDownload.ToString()) + "\\HomeBrewDonwload\\" + "PS4\\" + HomeBrewSelec.TitleId);

                string Ex = HomeBrewSelec.LastDirectLink;
                string Extension = Ex.Substring(Ex.Length - 4, 4);
                string patharc = SetConfigRegistry.ReadRegistry(TypeRege.PathDownload.ToString()) + "\\HomeBrewDonwload\\" + "PS4\\" + HomeBrewSelec.TitleId + "\\" + HomeBrewSelec.TitleName + Extension;
                DownloadFile(HomeBrewSelec.LastDirectLink, patharc);
                progressBar1.Visible = true;
                label6.Visible = true;
                Psvita.Enabled = false;
                PS3.Enabled = false;
                PS4.Enabled = false;
                PS4.Checked = false;

                string NameArtTxt = SetConfigRegistry.ReadRegistry(TypeRege.PathDownload.ToString()) + "\\HomeBrewDonwload\\" + @"\historic.txt";
                Utilitary.CreateFileWriteHistoric(NameArtTxt, HomeBrewSelec.TitleId);
            }
        }

        private static WebClient web = new WebClient();
        public void DownloadFile(string url, string output)
        {
            WebClient web = new WebClient();

            web.DownloadProgressChanged += new DownloadProgressChangedEventHandler(Web_DownloadProgressChanged);
            web.DownloadFileCompleted += new System.ComponentModel.AsyncCompletedEventHandler(Web_DownloadFileCompleted);
            web.DownloadFileAsync(new Uri(url), output);
        }

        public void Web_DownloadFileCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            //throw new NotImplementedException();
            if (e.Cancelled == true)
            {
                //FileSystem.DeleteFile(path + "PKG-h-encore\\xGMrXOkORxWRyqzLMihZPqsXAbAXLzvAdJFqtPJLAZTgOcqJobxQAhLNbgiFydVlcmVOrpZKklOYxizQCRpiLfjeROuWivGXfwgkq.pkg");
                MessageBox.Show("Download canceled.", "Download canceled", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else if (e.Error != null) // We have an error! Retry a few times, then abort.
            {
                //FileSystem.DeleteFile(path + "PKG-h-encore\\xGMrXOkORxWRyqzLMihZPqsXAbAXLzvAdJFqtPJLAZTgOcqJobxQAhLNbgiFydVlcmVOrpZKklOYxizQCRpiLfjeROuWivGXfwgkq.pkg");
                MessageBox.Show("An error ocurred while trying to download file: " + e.Error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                MessageBox.Show("Downloaded the Homebrew successful", "Sucessfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            ((WebClient)sender).Dispose();

            progressBar1.Visible = false;
            label6.Visible = false;
            Psvita.Enabled = true;
            PS3.Enabled = true;
            PS4.Enabled = true;
        }

        public void Web_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            progressBar1.Maximum = (int)e.TotalBytesToReceive / 100;
            progressBar1.Value = (int)e.BytesReceived / 100;
            label6.Text = "Download is in progress." + string.Format("{0} MB's / {1} MB's", (e.BytesReceived / 1024d / 1024d).ToString("0.00"), (e.TotalBytesToReceive / 1024d / 1024d).ToString("0.00"));
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string url = "https://twitter.com/GuidoGhidini";
            System.Diagnostics.Process.Start(url);
        }
    }
    
}
