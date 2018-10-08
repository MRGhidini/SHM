using GalaSoft.MvvmLight.Command;
using Microsoft.Win32;
using Microsoft.WindowsAPICodePack.Dialogs;
using SHM.UI.Pages;
using SHM.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHM.UI.ViewModel
{
    public class SettingsViewModel : ViewModel
    {
        public const string SelectDialogTitleFormat = "Select a {0} for {1}";
        public SHMRegistryHelper Registry { get; set; }
        public SettingsViewModel(ViewModelLocator locator) : base(locator)
        {
            Registry = SHMRegistryHelper.Instance;
            Populate();
            SaveCommand = new RelayCommand(async () => await SaveAsync(), true);
            CancelCommand = new RelayCommand(async () => await CancelAsync(), true);
            SelectCommand = new RelayCommand<string>(async p => await SelectAsync(p), true);
        }

        bool useVitaDB;
        string psv, ps3, ps4, downloadPath, theme;
        public bool UseVitaDB { get { return useVitaDB; } set { Set(ref useVitaDB, value); } }
        public string PSV { get { return psv; } set { Set(ref psv, value); } }
        public string PS3 { get { return ps3; } set { Set(ref ps3, value); } }
        public string PS4 { get { return ps4; } set { Set(ref ps4, value); } }
        public string DownloadPath { get { return downloadPath; } set { Set(ref downloadPath, value); } }
        public string Theme { get { return theme; } set { Set(ref theme, value); App.ChangeTheme(theme); } }

        public ObservableCollection<string> Themes { get; set; } = new ObservableCollection<string>();


        void Populate()
        {
            UseVitaDB = Registry.UseVitaDB;
            PSV = Registry.PSV;
            PS3 = Registry.PS3;
            PS4 = Registry.PS4;
            DownloadPath = Registry.DownloadPath;
            Theme = Registry.Theme;
            if (!Themes.Any())
                foreach (var theme in App.SupportedThemes()) Themes.Add(theme);
        }

        public RelayCommand<string> SelectCommand { get; protected set; }
        async Task SelectAsync(string parameter)
        {
            await Task.Yield();
            var select = new CommonOpenFileDialog();
            switch (parameter)
            {
                case nameof(PSV):
                case nameof(PS3):
                case nameof(PS4):
                    select.Filters.Add(new CommonFileDialogFilter("TSV Files", "*.tsv"));
                    select.IsFolderPicker = false;
                    select.Title = string.Format(SelectDialogTitleFormat, "file", parameter);
                    break;
                case nameof(DownloadPath):
                    select.IsFolderPicker = true;
                    select.Title = string.Format(SelectDialogTitleFormat, "folder", "download path");
                    break;
                default: return;
            }

            if (select.ShowDialog() == CommonFileDialogResult.Ok)
            {
                switch (parameter)
                {
                    case nameof(PSV): PSV = select.FileName; break;
                    case nameof(PS3): PS3 = select.FileName; break;
                    case nameof(PS4): PS4 = select.FileName; break;
                    case nameof(DownloadPath): DownloadPath = select.FileName; break;
                }
            }
        }

        public RelayCommand SaveCommand { get; protected set; }
        async Task SaveAsync()
        {
            if (await Locator.Main.Dialog.ShowMessageAsync(Locator.Main, "Confirmation", "Do you want to save your changes?", MahApps.Metro.Controls.Dialogs.MessageDialogStyle.AffirmativeAndNegative)
                == MahApps.Metro.Controls.Dialogs.MessageDialogResult.Affirmative)
            {
                Registry.UseVitaDB = UseVitaDB;
                Registry.PSV = UseVitaDB ? string.Empty : PSV;
                Registry.PS3 = PS3;
                Registry.PS4 = PS4;
                Registry.DownloadPath = DownloadPath;
                Registry.Theme = Theme;
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
                App.ChangeTheme();
                Locator.Main.GoTo<Home>();
            }
        }
    }
}
