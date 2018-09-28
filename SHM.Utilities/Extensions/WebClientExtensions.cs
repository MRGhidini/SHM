using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SHM.Utilities.Extensions
{
    public static class WebClientExtensions
    {
        public static async Task DownloadFileTaskAsync(this WebClient webClient, string address, string fileName, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            using (cancellationToken.Register(webClient.CancelAsync))
                await webClient.DownloadFileTaskAsync(address, fileName);
        }
    }
}
