using System.Windows;
using System.Windows.Controls;

namespace TicketSystem.Controls
{
    /// <summary>
    /// Interaction logic for TicketsView.xaml
    /// </summary>
    public partial class TicketsView : UserControl
    {
        public TicketsView()
        {
            InitializeComponent();
            Loaded += (sender, args) => cb.Focus();
        }

        private void Grid_OnGotFocus(object sender, RoutedEventArgs e)
        {
            if (!(e.OriginalSource is DataGridCell cell) || !(cell.Column is DataGridCheckBoxColumn)) return;
            ((DataGrid)sender).BeginEdit();
            if (cell.Content is CheckBox chkBox)
                chkBox.IsChecked = !chkBox.IsChecked;
        }
    }
}
