using GalaSoft.MvvmLight.Command;
using Microsoft.Win32;
using Microsoft.WindowsAPICodePack.Dialogs;
using SHM.UI.Pages;
using SHM.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHM.UI.ViewModel
{
    public class SettingsViewModel : ViewModel
    {
        public const string SelectDialogTitleFormat = "Select a {0} for {1}";
        public CommonOpenFileDialog SelectDialog { get; set; }
        public SHMRegistryHelper Registry { get; set; }
        public SettingsViewModel(ViewModelLocator locator) : base(locator)
        {
            SelectDialog = new CommonOpenFileDialog() {
                EnsureFileExists = true,
                EnsurePathExists = true
            };
            SelectDialog.Filters.Add(new CommonFileDialogFilter("TSV Files", "*.tsv"));
            Registry = SHMRegistryHelper.Instance;
            Populate();
            SaveCommand = new RelayCommand(async () => await SaveAsync(), true);
            CancelCommand = new RelayCommand(async () => await CancelAsync(), true);
            SelectCommand = new RelayCommand<string>(async p => await SelectAsync(p), true);
        }

        string psv, ps3, ps4, downloadPath;
        bool useVitaDB;
        public string PSV { get { return psv; } set { Set(ref psv, value); } }
        public string PS3 { get { return ps3; } set { Set(ref ps3, value); } }
        public string PS4 { get { return ps4; } set { Set(ref ps4, value); } }
        public string DownloadPath { get { return downloadPath; } set { Set(ref downloadPath, value); } }
        public bool UseVitaDB { get { return useVitaDB; } set { Set(ref useVitaDB, value); } }

        void Populate()
        {
            PSV = Registry.PSV;
            PS3 = Registry.PS3;
            PS4 = Registry.PS4;
            DownloadPath = Registry.DownloadPath;
            UseVitaDB = Registry.UseVitaDB;
        }

        public RelayCommand<string> SelectCommand { get; protected set; }
        async Task SelectAsync(string parameter)
        {
            await Task.Yield();
            switch (parameter)
            {
                case nameof(PSV):
                case nameof(PS3):
                case nameof(PS4):
                    SelectDialog.IsFolderPicker = false;
                    SelectDialog.Title = string.Format(SelectDialogTitleFormat, "file", parameter);
                    break;
                case nameof(DownloadPath):
                    SelectDialog.IsFolderPicker = true;
                    SelectDialog.Title = string.Format(SelectDialogTitleFormat, "folder", "download path");
                    break;
                default: return;
            }

            if(SelectDialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                switch (parameter)
                {
                    case nameof(PSV): PSV = SelectDialog.FileName; break;
                    case nameof(PS3): PS3 = SelectDialog.FileName; break;
                    case nameof(PS4): PS4 = SelectDialog.FileName; break;
                    case nameof(DownloadPath): DownloadPath = SelectDialog.FileName; break;
                }
            }
        }

        public RelayCommand SaveCommand { get; protected set; }
        async Task SaveAsync()
        {
            if (await Locator.Main.Dialog.ShowMessageAsync(Locator.Main, "Confirmation", "Do you want to save your changes?", MahApps.Metro.Controls.Dialogs.MessageDialogStyle.AffirmativeAndNegative)
                == MahApps.Metro.Controls.Dialogs.MessageDialogResult.Affirmative)
            {
                Registry.PSV = UseVitaDB ? string.Empty : PSV;
                Registry.PS3 = PS3;
                Registry.PS4 = PS4;
                Registry.DownloadPath = DownloadPath;
                Registry.UseVitaDB = UseVitaDB;
                Locator.Main.GoTo<Home>();
                await Locator.Main.Dialog.ShowMessageAsync(Locator.Main, "Information", "Saved changes successfully.");
            }
        }

        public RelayCommand CancelCommand { get; set; }
        async Task CancelAsync()
        {
            if (await Locator.Main.Dialog.ShowMessageAsync(Locator.Main, "Confirmation", "Do you want to discard your changes?", MahApps.Metro.Controls.Dialogs.MessageDialogStyle.AffirmativeAndNegative)
                == MahApps.Metro.Controls.Dialogs.MessageDialogResult.Affirmative)
            {
                Populate();
                Locator.Main.GoTo<Home>();
            }
        }
    }
}
