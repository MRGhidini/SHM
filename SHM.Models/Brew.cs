using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHM.Models
{
    public class Brew
    {
        public BrewKind Kind { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        public string IconUri { get; set; }
        public string Version { get; set; }
        public string Author { get; set; }
        public DateTimeOffset? Date { get; set; }
        public List<string> ScreenshotUris { get; set; }
        public string Description { get; set; }
        public string LongDescription { get; set; }
        public string SourceUri { get; set; }
        public string ReleasePageUri { get; set; }
        public string DownloadUri { get; set; }
    }
}
