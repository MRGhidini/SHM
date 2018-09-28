using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHM.Models.Extensions
{
    public static class DownloadableExtensions
    {
        public static Downloadable<T> ToDownloadable<T>(this T self, DownloadState state = DownloadState.WaitingToDownload) => new Downloadable<T>(self, state);
        public static IEnumerable<Downloadable<T>> AsDownloadable<T>(this IEnumerable<T> self, DownloadState state = DownloadState.WaitingToDownload) => self.Select(x => x.ToDownloadable(state));
    }
}
