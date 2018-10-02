using ByteSizeLib;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SHM.Models
{
    public class Downloadable<T> : ObservableObject
    {
        public Downloadable(T value, DownloadState state = DownloadState.WaitingToDownload)
        {
            Value = value;
            State = state;
            CancelDownloadCommand = new RelayCommand(CancelDownload);
        }
        DownloadState state;
        public DownloadState State
        {
            get { return state; }
            set
            {
                Set(ref state, value);
                RaisePropertyChanged(nameof(IsWaitingToDownload));
                RaisePropertyChanged(nameof(IsDownloaded));
                RaisePropertyChanged(nameof(IsDownloading));
                RaisePropertyChanged(nameof(IsDownloadFailed));
            }
        }

        public T Value { get; set; }
        public bool IsWaitingToDownload => state == DownloadState.WaitingToDownload;
        public bool IsDownloaded => state == DownloadState.Downloaded;
        public bool IsDownloading => state == DownloadState.Downloading;
        public bool IsDownloadFailed => state == DownloadState.DownloadFailed;

        public CancellationTokenSource CancellationTokenSource { get; set; }

        ByteSize totalSize, downloadedSize;
        public ByteSize TotalSize { get { return totalSize; } set { Set(ref totalSize, value); RaisePropertyChanged(nameof(DownloadingStatus)); } }
        public ByteSize DownloadedSize { get { return downloadedSize; } set { Set(ref downloadedSize, value); RaisePropertyChanged(nameof(DownloadingStatus)); } }

        public string DownloadingStatus => $"{DownloadedSize.ToString()}/{TotalSize.ToString()}";

        int percentage = 0;
        public int Percentage { get { return percentage; } set { Set(ref percentage, value); } }

        public RelayCommand CancelDownloadCommand { get; set; }
        public void CancelDownload()
        {
            if (IsDownloading && CancellationTokenSource != null)
                CancellationTokenSource.Cancel();
        }

        public void Clear()
        {
            CancellationTokenSource = null;
            TotalSize = new ByteSize();
            DownloadedSize = new ByteSize();
            Percentage = 0;
        }
    }

    public enum DownloadState
    {
        None,
        WaitingToDownload,
        Downloading,
        Downloaded,
        DownloadFailed
    }
}
