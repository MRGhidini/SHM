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
            LaunchCommand = new RelayCommand<string>(Launch);
            GoToDetailCommand = new RelayCommand<string>(async p => await GoToDetailAsync(p), true);
            GoToSettingsCommand = new RelayCommand(GoToSettings);
        }

        public RelayCommand<string> LaunchCommand { get; protected set; }
        void Launch(string item) => Process.Start(item);

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
    }
}
