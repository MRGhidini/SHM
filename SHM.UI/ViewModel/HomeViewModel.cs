using GalaSoft.MvvmLight.Command;
using SHM.Extensions;
using SHM.Models;
using SHM.UI.Pages;
using SHM.Utilities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHM.UI.ViewModel
{
    public class HomeViewModel : ViewModel
    {
        public HomeViewModel(ViewModelLocator locator) : base(locator)
        {
            GoToDetailCommand = new RelayCommand<string>(async p => await GoToDetailAsync(p), true);
            GoToSettingsCommand = new RelayCommand(GoToSettings);
            CheckForUpdatesCommmand = new RelayCommand(async () => await CheckForUpdatesAsync(), true);
            CheckForUpdatesCommmand.Execute(null);
        }

        public RelayCommand<string> GoToDetailCommand { get; set; }
        public async Task GoToDetailAsync(string parameter)
        {
            if(!BrewProvider.Instance.IsKindRetrievable(parameter.ToEnum<BrewKind>()))
            {
                await Locator.Main.Dialog.ShowMessageAsync(Locator.Main, "Information", $"There is no provided path configuration for {parameter} homebrews. You have to provide it first in the settings.", MahApps.Metro.Controls.Dialogs.MessageDialogStyle.Affirmative);
                Locator.Main.GoTo<Settings>();
                return;
            }
            Locator.Main.GoTo<Homebrews>();
            await Locator.Homebrews.RefillBrewsAsync(parameter.ToEnum<BrewKind>());
        }

        public RelayCommand GoToSettingsCommand { get; set; }
        public void GoToSettings() => Locator.Main.GoTo<Settings>();

        public RelayCommand CheckForUpdatesCommmand { get; set; }
        public async Task CheckForUpdatesAsync()
        {
            await Locator.Update.Bootstrap();
            if (Locator.Update.IsUpdateAvailable)
            {
                if ((await Locator.Main.Dialog.ShowMessageAsync(Locator.Main, "Information", $"New update is available. Would you like to update to version {Locator.Update.LatestRelease.Version.ToString()}?", MahApps.Metro.Controls.Dialogs.MessageDialogStyle.AffirmativeAndNegative)) == MahApps.Metro.Controls.Dialogs.MessageDialogResult.Affirmative)
                {
                    Locator.Main.GoTo<Update>();
                    await Locator.Update.UpdateAppAsync();
                }
            }
        }
    }
}
