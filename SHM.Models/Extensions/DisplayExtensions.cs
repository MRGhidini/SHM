using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHM.Models.Extensions
{
    public static class DisplayExtensions
    {
        public static string AsDisplay(this BrewKind self)
        {
            switch (self)
            {
                case BrewKind.None: return "All";
                case BrewKind.PSV: return "PS Vita";
                default: return self.ToString();
            }
        }

        public static string AsDisplay(this DownloadState self)
        {
            switch (self)
            {
                case DownloadState.None: return "All";
                case DownloadState.WaitingToDownload: return "Available";
                case DownloadState.DownloadFailed: return "Download failed";
                default: return self.ToString();
            }
        }
    }
}
