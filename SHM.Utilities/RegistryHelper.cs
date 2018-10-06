using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHM.Utilities
{
    public class RegistryHelper : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public RegistryHelper(RegistryRoot root, string path)
        {
            Root = root;
            Path = path;
        }
        public RegistryRoot Root { get; set; }
        public string Path { get; set; }

        public const string SoftwareKey = "Software";
        
        RegistryKey RootRegistryKey() => Root == RegistryRoot.User ? Registry.CurrentUser.OpenSubKey(SoftwareKey, writable: true) : Registry.LocalMachine.OpenSubKey(SoftwareKey.ToUpper(), writable: true);
        RegistryKey PathRegistryKey(string path = null) => Try.It(() => RootRegistryKey().CreateSubKey(path ?? Path));
        public object Get(params string[] names)
        {
            var key = PathRegistryKey();
            if (key == null) return null;
            object value = null;
            foreach (var alternative in names)
                if ((value = key.GetValue(alternative)) != null)
                    return value;
            return value;
        }
        public object Set(string name, object value)
        {
            PathRegistryKey()?.SetValue(name, value);
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
            return value;
        }

        public object Provide(string[] keys, Func<object> valueProvider) => Get(keys) ?? Set(keys.First(), valueProvider?.Invoke());
    }

    public enum RegistryRoot
    {
        User,
        Machine
    }
}
