using AutoMapper;
using Flurl;
using SHM.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHM.Utilities
{
    public static class BrewMapper
    {
        public const string ScreenshotUrisDelimeter = ";";
        public static void Configure(IMapperConfigurationExpression config = null)
        {
            if (config == null)
            {
                Mapper.Initialize(Configure);
                return;
            }

            config.CreateMap<RawBrew, Brew>()
                  .ForMember(t => t.DownloadUri, c => c.ResolveUsing(f => f.LastDirectLink))
                  .ForMember(t => t.ReleasePageUri, c => c.ResolveUsing(f => f.ReadmeLink));

            config.CreateMap<RawVitaDbBrew, Brew>()
                  .ForMember(t => t.Kind, o => o.ResolveUsing(f => BrewKind.PSV))
                  .ForMember(t => t.Date, o => o.ResolveUsing(f => string.IsNullOrEmpty(f.Date) ? new DateTimeOffset?() : DateTimeOffset.ParseExact(f.Date, "yyyy-MM-dd", null)))
                  .ForMember(t => t.IconUri, o => o.ResolveUsing(f => Constants.VitaDBIconsUri.AppendPathSegment(f.IconUri)))
                  .ForMember(t => t.ScreenshotUris, o => o.ResolveUsing(f => new ObservableCollection<string>(f.ScreenshotUris.Split(new[] { ScreenshotUrisDelimeter }, StringSplitOptions.RemoveEmptyEntries).Select(ss => Constants.VitaDbBaseUri.AppendPathSegment(ss).ToString()).ToList())));
        }
    }
}
