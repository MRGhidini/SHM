using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

public class SetConfigRegistry
{
    const string userRoot = "HKEY_CURRENT_USER\\SOFTWARE";
    const string subkey = "SHM";
    const string keyName = userRoot + "\\" + subkey;

    public static RegistryKey RegistryKeyOpen = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\SHM\");
    public static RegistryKey registrykeyCreate = Registry.CurrentUser.CreateSubKey(keyName);

    public static void VerifyRegistry()
    {
        if (RegistryKeyOpen == null)
        {
            Registry.SetValue(keyName, "PathPsvita", "");
            Registry.SetValue(keyName, "PathPS3", "");
            Registry.SetValue(keyName, "PathPS4", "");
            Registry.SetValue(keyName, "PathDownload", "");
            registrykeyCreate.Close();

            MessageBox.Show("Configuration settings created successfully, the program will be closed, this process happens only once to create the configuration settings", "Setting", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Application.Exit();

        }
    }

    public static string ReadRegistry(string Regs)
    {
        var Server = RegistryKeyOpen.GetValue(Regs).ToString();
        return Server;
    }

    public static void RecordRegistry(string Regs, string valor)
    {
        Registry.SetValue(keyName, Regs, valor);
        registrykeyCreate.Close();
    }
}