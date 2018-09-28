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
        public const string DefaultThemeName = "SHM";
        public static string AssemblyName => Assembly.GetExecutingAssembly().GetName().Name;

        protected override void OnStartup(StartupEventArgs e)
        {
            BrewMapper.Configure();
            ThemeManager.AddAccent(DefaultThemeName, new Uri($"pack://application:,,,/{AssemblyName};component/Themes/{DefaultThemeName}.xaml"));

            // get the current app style (theme and accent) from the application
            Tuple<AppTheme, Accent> theme = ThemeManager.DetectAppStyle(Current);

            // now change app style to the custom accent and current theme
            ThemeManager.ChangeAppStyle(Current,
                                        ThemeManager.GetAccent(DefaultThemeName),
                                        theme.Item1);
            base.OnStartup(e);
        }
    }
}
