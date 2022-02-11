using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Media;
using MahApps.Metro;

namespace TicketSystem.Classes
{
    public class AccentColorMenuData
    {
        private const string DEFAULT_ACCENT_NAME = "Blue";
        private const string DEFAULT_THEME_NAME = "BaseLight";

        public string Name { get; set; }
        public Brush BorderColorBrush { get; set; }
        public Brush ColorBrush { get; set; }

        public virtual void DoChangeTheme()
        {
            var theme = ThemeManager.DetectAppStyle(Application.Current);
            var accent = ThemeManager.GetAccent(Name);
            ThemeManager.ChangeAppStyle(Application.Current, accent, theme.Item1);
        }

        public static AccentColorMenuData GetDefaultAccent(IEnumerable<AccentColorMenuData> accents)
        {
            return accents.FirstOrDefault(a => a.Name == DEFAULT_ACCENT_NAME);
        }

        public static AppThemeMenuData GetDefaultTheme(List<AppThemeMenuData> appThemes)
        {
            return appThemes.FirstOrDefault(a => a.Name == DEFAULT_THEME_NAME);
        }
    }

    public class AppThemeMenuData : AccentColorMenuData
    {
        public override void DoChangeTheme()
        {
            var theme = ThemeManager.DetectAppStyle(Application.Current);
            var appTheme = ThemeManager.GetAppTheme(Name);
            ThemeManager.ChangeAppStyle(Application.Current, theme.Item2, appTheme);
        }
    }
}
