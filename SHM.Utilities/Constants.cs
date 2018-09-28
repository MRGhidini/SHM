using Flurl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHM.Utilities
{
    public static class Constants
    {
        public const string VitaDbBaseUri = "https://rinnegatamante.it/vitadb";
        public const string VitaDbIconsPathSegment = "icons";
        public const string VitaDBBrewListPathSegment = "list_hbs_json.php";
        public static string VitaDBIconsUri => VitaDbBaseUri.AppendPathSegment(VitaDbIconsPathSegment);
        public static string VitaDBBrewsListUri => VitaDbBaseUri.AppendPathSegment(VitaDBBrewListPathSegment);
    }
}
