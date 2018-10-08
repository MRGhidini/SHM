using ByteSizeLib;
using SHM.Models;
using SHM.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SHM.Utilities
{
    public class BrewDownloader
    {
        static Lazy<BrewDownloader> instance = new Lazy<BrewDownloader>(() => new BrewDownloader());
        public static BrewDownloader Instance => instance.Value;

        const string TempFileExtension = "shmdownload";
        const string DefaultAppendPath = "SHM";
        public string DownloadPath { get; set; }
        public string AppendPath { get; set; }
        public BrewDownloader(string downloadPath = null, string appendPath = DefaultAppendPath)
        {
            DownloadPath = downloadPath ?? SHMRegistryHelper.Instance.DownloadPath;
            AppendPath = string.IsNullOrEmpty(appendPath) ? DefaultAppendPath : appendPath;
        }

        public void ClearUnfinishedDownloads(string path)
        {
            if (Directory.Exists(path))
                foreach (var file in Directory.GetFiles(path, $"*.{TempFileExtension}"))
                    File.Delete(file);
        }

        public async Task Download(Downloadable<Brew> downloadable)
        {
            string brewPath = BrewPath(downloadable.Value);
            ClearUnfinishedDownloads(brewPath);
            if (IsDownloaded(downloadable.Value))
            {
                downloadable.State = DownloadState.Downloaded;
                return;
            }
            Directory.CreateDirectory(BrewPath(downloadable.Value));
            string fileName = $"{Guid.NewGuid().ToString("N")}.{TempFileExtension}";
            string filePath = Path.Combine(brewPath, fileName);
            WebClient client = new WebClient();
            client.DownloadProgressChanged += (_, e) =>
            {
                downloadable.TotalSize = ByteSize.FromBytes(e.TotalBytesToReceive);
                downloadable.DownloadedSize = ByteSize.FromBytes(e.BytesReceived);
                if (!downloadable.IsTotalSizeUnknown)
                    downloadable.Percentage = e.ProgressPercentage;
            };
            client.DownloadFileCompleted += (_, e) =>
            {
                if (e.Cancelled || e.Error != null)
                {
                    downloadable.State = e.Cancelled ? DownloadState.WaitingToDownload : DownloadState.DownloadFailed;
                    ClearUnfinishedDownloads(brewPath);
                }
                else
                {
                    downloadable.State = DownloadState.Downloaded;
                    var contentDisposition = client.ResponseHeaders["content-disposition"];
                    string realFileName = ClearInvalidFileNameChars(contentDisposition?.Split(';')?.Last()?.Split('=')?.Last() ?? Path.GetFileName(new Uri(downloadable.Value.DownloadUri).LocalPath), string.Empty);
                    string realFilePath = Path.Combine(brewPath, realFileName);
                    File.Move(filePath, realFilePath);
                }
                downloadable.Clear();
            };
            downloadable.State = DownloadState.Downloading;
            downloadable.CancellationTokenSource = new CancellationTokenSource();
            await Try.ItAsync(async () => await client.DownloadFileTaskAsync(downloadable.Value.DownloadUri, filePath, downloadable.CancellationTokenSource.Token));
        }

        public string ClearInvalidFileNameChars(string fileName, string joinWith = "_") => string.Join(joinWith, fileName.Split(Path.GetInvalidFileNameChars()));
        public string BrewPath(Brew brew) => Path.Combine(DownloadPath, AppendPath, brew.Kind.ToString(), ClearInvalidFileNameChars(brew.Name));
        public bool IsDownloaded(Brew brew) => Directory.Exists(BrewPath(brew)) && Directory.GetFiles(BrewPath(brew)).Where(x => !x.Contains(TempFileExtension)).Any();
    }
}
