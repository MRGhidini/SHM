using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHM.Models
{
    public class RawVitaDbBrew
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("icon")]
        public string IconUri { get; set; }
        [JsonProperty("version")]
        public string Version { get; set; }
        [JsonProperty("author")]
        public string Author { get; set; }
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("data")]
        public string Data { get; set; }
        [JsonProperty("date")]
        public string Date { get; set; }
        [JsonProperty("titleid")]
        public string TitleId { get; set; }
        [JsonProperty("screenshots")]
        public string ScreenshotUris { get; set; }
        [JsonProperty("long_description")]
        public string LongDescription { get; set; }
        [JsonProperty("downloads")]
        public string Downloads { get; set; }
        [JsonProperty("status")]
        public string Status { get; set; }
        [JsonProperty("source")]
        public string SourceUri { get; set; }
        [JsonProperty("release_page")]
        public string ReleasePageUri { get; set; }
        [JsonProperty("url")]
        public string DownloadUri { get; set; }
    }
}
