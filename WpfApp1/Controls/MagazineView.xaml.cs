using System.Windows;
using System.Windows.Controls;

namespace TicketSystem.Controls
{
    /// <summary>
    /// Interaction logic for MagazineView.xaml
    /// </summary>
    public partial class MagazineView : UserControl
    {
        public MagazineView()
        {
            InitializeComponent();
        }

        private void Grid_OnGotFocus(object sender, RoutedEventArgs e)
        {
            /*if (!(e.OriginalSource is DataGridCell cell) || !(cell.Column is DataGridCheckBoxColumn)) return;
            ((DataGrid)sender).BeginEdit();
            if (cell.Content is CheckBox chkBox)
                chkBox.IsChecked = !chkBox.IsChecked;*/
        }
    }
}
