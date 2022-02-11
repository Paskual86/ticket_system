using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using MahApps.Metro;
using MahApps.Metro.Controls.Dialogs;
using TicketSystem.Classes;
using TicketSystem.Classes.Database;
using TicketSystem.Classes.Enums;
using TicketSystem.Classes.ViewModels;

namespace TicketSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        protected MainViewModel ViewModel => (MainViewModel) DataContext;

        public MainWindow()
        {
            InitializeComponent();
            DbHelper.Seed();

            DataContext = new MainViewModel();
            ViewModel.RequestDashboardSelection += async (sender, o) => { await ControlsHelper.LoadControl(this, ViewModel, (ControlsEnum) o, null); };
            ViewModel.ShutDownMessage += async (sender, s) =>
            {                
                await this.ShowMessageAsync("Error", s);
                Application.Current.Shutdown();
            };
            ViewModel.WarningMessage += async (sender, s) => { await this.ShowMessageAsync("Error", s); };
            Loaded += async (sender, args) =>
            {
                GenerateThemes();
                await ControlsHelper.ProcessLoginControls(this, ViewModel);
            };

            Closed += (sender, args) =>
            {
                ViewModel.LogOutUser();
                Application.Current.Shutdown();
            };
           // DbHelper.CreateDatabase();
        }

        #region Theme
        public List<AccentColorMenuData> AccentColors { get; set; }
        public List<AppThemeMenuData> AppThemes { get; set; }
        
        private void ComboBoxAccentOnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ((AccentColorMenuData) comboBoxAccent.SelectedItem).DoChangeTheme();
        }

        private void ComboBoxThemeOnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ((AppThemeMenuData) comboBoxTheme.SelectedItem).DoChangeTheme();
        }

        private void GenerateThemes()
        {
            AccentColors = ThemeManager.Accents
                .Select(a => new AccentColorMenuData { Name = a.Name, ColorBrush = a.Resources["AccentColorBrush"] as Brush })
                .ToList();
            AppThemes = ThemeManager.AppThemes
                .Select(a => new AppThemeMenuData { Name = a.Name, BorderColorBrush = a.Resources["BlackColorBrush"] as Brush, ColorBrush = a.Resources["WhiteColorBrush"] as Brush })
                .ToList();

            comboBoxTheme.ItemsSource = AppThemes;
            comboBoxTheme.SelectedItem = AccentColorMenuData.GetDefaultTheme(AppThemes);
            comboBoxTheme.SelectionChanged+=ComboBoxThemeOnSelectionChanged;

            comboBoxAccent.ItemsSource = AccentColors;
            comboBoxAccent.SelectedItem = AccentColorMenuData.GetDefaultAccent(AccentColors);
            comboBoxAccent.SelectionChanged+=ComboBoxAccentOnSelectionChanged;
        }

        #endregion
    }
}
