using GalaSoft.MvvmLight.Command;
using SHM.Extensions;
using SHM.Models;
using SHM.Models.Extensions;
using SHM.UI.Extensions;
using SHM.UI.Pages;
using SHM.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHM.UI.ViewModel
{
    public class HomebrewsViewModel : ViewModel
    {
        public HomebrewsViewModel(ViewModelLocator locator) : base(locator)
        {
            Brews = new ObservableCollection<Downloadable<Brew>>();
            DownloadCommand = new RelayCommand<Downloadable<Brew>>(async p => await DownloadAsync(p), true);
            GoToCommand = new RelayCommand<Downloadable<Brew>>(GoTo);
            SetDownloadStateFilterCommand = new RelayCommand<string>(SetDownloadStateFilter);
            GoToSettingsCommand = new RelayCommand(GoToSettings);
            GoToDetailsCommand = new RelayCommand<Downloadable<Brew>>(GoToDetails);
        }

        public string Title => $"{BrewDownloadStateFilter.AsDisplay()} Homebrews for {CurrentBrewKind.AsDisplay()} {(CurrentBrewKind == BrewKind.All ? "Platforms" : "Platform")}";

        BrewKind currentBrewKind;
        public BrewKind CurrentBrewKind { get { return currentBrewKind; } set { Set(ref currentBrewKind, value); RaisePropertyChanged(nameof(Title)); } }

        bool isLoading = false;
        public bool IsLoading { get { return isLoading; } set { Set(ref isLoading, value); RaisePropertyChanged(nameof(IsNoBrewErrorHidden)); } }

        public ObservableCollection<Downloadable<Brew>> Brews { get; set; }

        public bool HasBrews => Brews.Any();

        string brewFilter = string.Empty;
        public string BrewFilter { get { return brewFilter; } set { Set(ref brewFilter, value); RaisePropertyChanged(nameof(FilteredBrews)); } }

        public DownloadState brewDownloadStateFilter;
        public DownloadState BrewDownloadStateFilter { get { return brewDownloadStateFilter; } set { Set(ref brewDownloadStateFilter, value); RaisePropertyChanged(nameof(FilteredBrews)); RaisePropertyChanged(nameof(Title)); } }

        public IEnumerable<Downloadable<Brew>> FilteredBrews =>
            Brews
                .As(brews => BrewDownloadStateFilter == DownloadState.None ? brews : brews.Where(x => x.State == BrewDownloadStateFilter))
                .As(brews => string.IsNullOrEmpty(BrewFilter) ? brews : brews.Where(x => x.Value.Name.ToLower().Contains(BrewFilter.ToLower()) || x.Value.Author.ToLower().Contains(BrewFilter.ToLower())));

        public bool IsNoBrewErrorHidden => IsLoading || HasBrews;

        public async Task RefillBrewsAsync(BrewKind? kind = null)
        {
            CurrentBrewKind = kind ?? CurrentBrewKind;
            IsLoading = true;
            Brews.Clear();
            RaisePropertyChanged(nameof(HasBrews));
            (await BrewProvider.Instance.RetrieveDownloadableAsync(CurrentBrewKind)).ForEach(b => Brews.Add(b));
            RaisePropertyChanged(nameof(FilteredBrews));
            RaisePropertyChanged(nameof(HasBrews));
            IsLoading = false;
        }

        public RelayCommand<Downloadable<Brew>> DownloadCommand { get; protected set; }
        public async Task DownloadAsync(Downloadable<Brew> downloadable) => await BrewDownloader.Instance.Download(downloadable);

        public RelayCommand<Downloadable<Brew>> GoToCommand { get; protected set; }
        public void GoTo(Downloadable<Brew> downloadable)
        {
            if (BrewDownloader.Instance.IsDownloaded(downloadable.Value))
                Process.Start(BrewDownloader.Instance.BrewPath(downloadable.Value));
            else
                downloadable.State = DownloadState.WaitingToDownload;
        }

        public RelayCommand<string> SetDownloadStateFilterCommand { get; protected set; }
        public void SetDownloadStateFilter(string parameter) => BrewDownloadStateFilter = parameter.ToEnum<DownloadState>();

        public RelayCommand GoToSettingsCommand { get; set; }
        public void GoToSettings() => Locator.Main.GoTo<Settings>();

        public RelayCommand<Downloadable<Brew>> GoToDetailsCommand { get; protected set; }
        public void GoToDetails(Downloadable<Brew> parameter)
        {
            if (parameter.Value.HasDetails)
            {
                Locator.Details.Brew = parameter;
                Locator.Main.GoTo<Details>();
            }
        }
    }

}
