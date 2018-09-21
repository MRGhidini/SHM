using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SHM
{
    public class Utilitary
    {

        public static Item GetHomeBrewSelec(List<string> HomeBrewOption, string TypePS)
        {
            var exploit = new FormGetHomebrew(HomeBrewOption);
            exploit.TypeConsole = TypePS;
            var exploit2 = exploit.ShowDialog();
            return exploit.Opgave;
        }

        public static void CreateFolder(string Pasta)
        {
            if (!Directory.Exists(Pasta))
                Directory.CreateDirectory(Pasta);
        }

        public static void CreateFileWriteHistoric(string path, string text)
        {
            if (!File.Exists(path))
            {
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine(text);
                }
            }
            else
            {
                string FindHist = "";
                FindHist = ReadFileHistoric(path, text);
                if (FindHist == "N")
                {
                    using (StreamWriter sw = File.AppendText(path))
                    {
                        sw.WriteLine(text);
                    }
                }
            }

        }

        public static string ReadFileHistoric(string path, string text)
        {
            string RetText = "N";
            if (File.Exists(path))
            {
                using (StreamReader sr = File.OpenText(path))
                {
                    string input = sr.ReadToEnd();

                    if (input.IndexOf(text) > -1)
                        RetText = "Y";
                    else
                        RetText = "N";

                    sr.Close();
                }
            }
            return RetText;
        }

        public static bool Verifythers(string pstype)
        {
            string Ps = SetConfigRegistry.ReadRegistry(pstype);

            if (string.IsNullOrWhiteSpace(Ps))
            {
                MessageBox.Show("04-First set the PS3/PS4 tsv path in the Setting option", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            return true;
        }

        public static bool Verifythersvita(string pstype)
        {
            string Ps = SetConfigRegistry.ReadRegistry(pstype);
            string psvitadb = SetConfigRegistry.ReadRegistry("OptionVitaDB");

            if (string.IsNullOrWhiteSpace(Ps) && string.IsNullOrWhiteSpace(psvitadb))
            {
                MessageBox.Show("05-First set the Psvita tsv path in the Setting option or use vitadb by ticking the setting option for list homebrews", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            return true;
        }

        public static bool VerifyPath()
        {
            var registryKey = Registry.CurrentUser.OpenSubKey(@"Software\SHM\", true);
            if (registryKey == null)
            {
                MessageBox.Show("01 - First set the path to download and set the tsv path in option Setting", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            string PathDown = SetConfigRegistry.ReadRegistry("PathDownload");

            if (string.IsNullOrWhiteSpace(PathDown))
            {
                MessageBox.Show("02 - First set the path to download in option Setting", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (PathDown != "" && !Directory.Exists(PathDown))
            {
                MessageBox.Show("03 - First set the path to download in option Setting", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            return true;
        }
    }
}
