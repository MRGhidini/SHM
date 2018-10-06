using MahApps.Metro;
using SHM.Utilities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows;

namespace SHM.UI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static string AssemblyName => Assembly.GetExecutingAssembly().GetName().Name;
        public static string ThemesPath => $"pack://application:,,,/{AssemblyName};component/Themes";

        protected override void OnStartup(StartupEventArgs e)
        {
            BrewMapper.Configure();
            ChangeTheme();
            SHMRegistryHelper.Instance.PropertyChanged += (_, pcea) => { if (pcea.PropertyName == "Theme") ChangeTheme(); };
            base.OnStartup(e);
        }

        public static IEnumerable<string> SupportedThemes()
        {
            yield return "SHM";
            yield return "Gray";
            yield return "Yellow";
            yield return "Aqua";
            yield return "Blue";
            yield return "Orange";
        }

        public static void ChangeTheme(string themeName = null)
        {
            themeName = themeName ?? SHMRegistryHelper.Instance.Theme;
            var accent = ThemeManager.GetAccent(themeName);
            if (accent == null && ThemeManager.AddAccent(themeName, new Uri($"{ThemesPath}/{themeName}.xaml")))
                accent = ThemeManager.GetAccent(themeName);

            if (accent == null) return;

            Tuple<AppTheme, Accent> theme = ThemeManager.DetectAppStyle(Current);
            ThemeManager.ChangeAppStyle(Current, accent, theme.Item1);

        }
    }
}
