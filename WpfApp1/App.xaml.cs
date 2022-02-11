using System;
using System.Windows;
using TicketSystem.Classes;

namespace TicketSystem
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        public App()
        {
            FrameworkCompatibilityPreferences.KeepTextBoxDisplaySynchronizedWithTextProperty = false;
            DispatcherUnhandledException += async (sender, e) =>
            {
                MessageBox.Show($"We've got unhandled exception: {e.Exception.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                e.Handled = true;
                await LogHelper.LogEx("UNHANDLED", e.Exception);
                Application.Current.Shutdown();
            };
        }
    }
}
