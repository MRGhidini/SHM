using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace SHM
{
    [System.Serializable]
    public class Item : IEquatable<Item>
    {
        public string TitleId, TitleName, Author, Version, LastDirectLink, ReadmeLink;
        public System.DateTime lastModifyDate = System.DateTime.MinValue;
        public int DLCs { get { return DlcItm.Count; } }
        public List<Item> DlcItm = new List<Item>();
        public bool IsDLC = false, ItsPsx = false, ItsPsp = false, ItsPS3;
        public string ParentGameTitle = string.Empty;
        public string ContentId = null;
        public string contentType = "";
        public string DownloadFileName
        {
            get
            {
                string res = "";

                if (this.ItsPS3) res = TitleName;
                else if (string.IsNullOrEmpty(ContentId)) res = TitleId;
                else res = ContentId;

                string regexSearch = new string(Path.GetInvalidFileNameChars()) + new string(Path.GetInvalidPathChars());
                Regex r = new Regex(string.Format("[{0}]", Regex.Escape(regexSearch)));
                return r.Replace(res, "");
            }
        }

        public Item() { }



        //public void CalculateDlCs(Item[] dlcDbs)
        //{
        //    foreach (Item i in dlcDbs)
        //    {
        //        if (i.Region == this.Region && i.TitleId.Contains(this.TitleId))
        //        {
        //            this.DlcItm.Add(i);
        //        }
        //    }
        //}

        public bool CompareName(string name)
        {
            name = name.ToLower();

            if (this.TitleId.ToLower().Contains(name)) return true;
            if (this.TitleName.ToLower().Contains(name)) return true;
            return false;
        }

        public bool Equals(Item other)
        {
            if (other == null) return false;

            return this.TitleId == other.TitleId && this.TitleName == other.TitleName && this.Author == other.Author && this.Version == other.Version &&  this.LastDirectLink == other.LastDirectLink && this.ReadmeLink == other.ReadmeLink;
        }
    }


}
