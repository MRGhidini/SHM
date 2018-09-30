using GalaSoft.MvvmLight.Command;
using SHM.Models;
using SHM.Utilities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHM.UI.ViewModel
{
    public class DetailsViewModel : ViewModel
    {
        public DetailsViewModel(ViewModelLocator locator) : base(locator)
        {
            DownloadCommand = new RelayCommand<Downloadable<Brew>>(async p => await DownloadAsync(p), true);
            GoToCommand = new RelayCommand<Downloadable<Brew>>(GoTo);
        }

        Downloadable<Brew> brew;
        public Downloadable<Brew> Brew { get { return brew; } set { Set(ref brew, value); } }

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
    }
}
