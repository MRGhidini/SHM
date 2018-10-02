using HandyUtil.Text.Xsv;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHM.Models
{
    public class RawBrew : XsvDataRow
    {
        public string TitleId { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public string Version { get; set; }
        public string LastDirectLink { get; set; }
        public string ReadmeLink { get; set; }

        protected override void AttachFields()
        {
            this.TitleId = this["Title ID"].AsString();
            this.Name = this["Name"].AsString();
            this.Author = this["Author"].AsString();
            this.Version = this["Version"].AsString();
            this.LastDirectLink = this["Last direct link"].AsString();
            this.ReadmeLink = this["Readme Link"].AsString();
        }

        protected override void UpdateFields()
        {
            this["Title ID"] = new XsvField(TitleId);
            this["Name"] = new XsvField(Name);
            this["Author"] = new XsvField(Author);
            this["Version"] = new XsvField(Version);
            this["Last direct link"] = new XsvField(LastDirectLink);
            this["Readme Link"] = new XsvField(ReadmeLink);

        }
    }
}
