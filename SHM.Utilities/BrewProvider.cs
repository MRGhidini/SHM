using AutoMapper;
using Flurl;
using Flurl.Http;
using HandyUtil.Text.Xsv;
using SHM.Extensions;
using SHM.Models;
using SHM.Models.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHM.Utilities
{
    public class BrewProvider
    {
        static Lazy<BrewProvider> instance = new Lazy<BrewProvider>();
        public static BrewProvider Instance => instance.Value;

        public const string TsvDelimeter = "	";

        public async Task<IEnumerable<Downloadable<Brew>>> RetrieveDownloadableAsync(BrewKind kind) => (await RetrieveAsync(kind)).Select(x => x.ToDownloadable(BrewDownloader.Instance.IsDownloaded(x) ? DownloadState.Downloaded : DownloadState.WaitingToDownload));
        public async Task<IEnumerable<Brew>> RetrieveAsync(BrewKind kind)
        {
            List<Brew> brews = new List<Brew>();
            foreach (var k in kind.GetFlags())
            {
                string uri = string.Empty;
                switch (k)
                {
                    case BrewKind.PSV: uri = SHMRegistryHelper.Instance.UseVitaDB ? null : SHMRegistryHelper.Instance.PSV; break;
                    case BrewKind.PS3: uri = SHMRegistryHelper.Instance.PS3; break;
                    case BrewKind.PS4: uri = SHMRegistryHelper.Instance.PS4; break;
                    default: continue;
                }
                brews.AddRange((k == BrewKind.PSV && SHMRegistryHelper.Instance.UseVitaDB ? Mapper.Map<IEnumerable<Brew>>(await RetrieveRawFromVitaDbAsync()) : Mapper.Map<IEnumerable<Brew>>(await RetrieveRawAsync(uri))).Select(x => x.With(y => y.Kind = k)));
            }
            return brews;
        }
        
        public async Task<IEnumerable<RawBrew>> RetrieveRawAsync(string source)
        {
            if (string.IsNullOrEmpty(source)) return Enumerable.Empty<RawBrew>();
            var xsv = new XsvData<RawBrew>(new[] { TsvDelimeter });
            var content = (await Try.ItAsync(async () => await source.GetStringAsync())) ?? string.Empty;
            using (var reader = new XsvReader(new StringReader(content))) await xsv.ReadAsync(reader, headerExists: true);
            return xsv.Rows.ToList();
        }

        public async Task<IEnumerable<RawVitaDbBrew>> RetrieveRawFromVitaDbAsync(string source = null)
        {
            source = source ?? Constants.VitaDBBrewsListUri;
            return await Try.ItAsync(async () => await source.GetJsonAsync<List<RawVitaDbBrew>>()) ?? new List<RawVitaDbBrew>();
        }

        public bool IsKindRetrievable(BrewKind kind)
        {
            switch (kind)
            {
                case BrewKind.PSV: return SHMRegistryHelper.Instance.UseVitaDB || !string.IsNullOrEmpty(SHMRegistryHelper.Instance.PSV);
                case BrewKind.PS3: return !string.IsNullOrEmpty(SHMRegistryHelper.Instance.PS3);
                case BrewKind.PS4: return !string.IsNullOrEmpty(SHMRegistryHelper.Instance.PS4);
                case BrewKind.All: return kind.GetFlags().Where(x => x != BrewKind.All && x != BrewKind.None).Any(x => IsKindRetrievable(x));
                default: return false;
            }
        }
    }
}
