using Syroot.Windows.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHM.Utilities
{
    public class SHMRegistryHelper : RegistryHelper
    {
        static Lazy<SHMRegistryHelper> instance = new Lazy<SHMRegistryHelper>();
        public static SHMRegistryHelper Instance => instance.Value;

        public const string LegacyPSVKey = "PathPsvita";
        public const string LegacyPS3Key = "PathPS3";
        public const string LegacyPS4Key = "PathPS4";
        public const string LegacyDownloadPathKey = "PathDownload";
        public const string LegacyUseVitaDBKey = "OptionVitaDB";
        public SHMRegistryHelper() : base(RegistryRoot.User, "SHM") { }

        string ProvideString(string[] keys, Func<string> valueProvider = null) => Provide(keys, () => valueProvider?.Invoke() ?? string.Empty)?.ToString();
        bool ProvideBool(string[] keys, Func<bool> valueProvider = null) => Provide(keys, () => valueProvider?.Invoke() ?? false)?.ToString() == bool.TrueString;

        public string PSV { get { return ProvideString(new[] { nameof(PSV), LegacyPSVKey }); } set { Set(nameof(PSV), value); } }
        public string PS3 { get { return ProvideString(new[] { nameof(PS3), LegacyPS3Key }); } set { Set(nameof(PS3), value); } }
        public string PS4 { get { return ProvideString(new[] { nameof(PS4), LegacyPS4Key }); } set { Set(nameof(PS4), value); } }
        public string DownloadPath { get { return ProvideString(new[] { nameof(DownloadPath), LegacyDownloadPathKey }, () => new KnownFolder(KnownFolderType.Downloads).Path); } set { Set(nameof(DownloadPath), value); } }
        public bool UseVitaDB { get { return ProvideBool(new[] { nameof(UseVitaDB), LegacyUseVitaDBKey }, () => true); } set { Set(nameof(UseVitaDB), value); } }
    }
}
