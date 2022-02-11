using System.Windows;
using System.Windows.Controls;
using TicketSystem.Classes.ViewModels;

namespace TicketSystem.Controls.Dialogs
{
    /// <summary>
    /// Interaction logic for CreateTicketView.xaml
    /// </summary>
    public partial class CreateTicketView : UserControl
    {
        private TicketViewModel ViewModel => (TicketViewModel) DataContext;

        public CreateTicketView()
        {
            InitializeComponent();
            Loaded += (sender, args) => textBox.Focus();
        }

        private void ToggleButton_OnChecked(object sender, RoutedEventArgs e)
        {
            ViewModel.UpdateTimerTypeSelection();
        }
    }
}
