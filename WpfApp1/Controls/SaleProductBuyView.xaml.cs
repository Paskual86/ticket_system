using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TicketSystem.Controls
{
    /// <summary>
    /// Interaction logic for SaleProductBuyView.xaml
    /// </summary>
    public partial class SaleProductBuyView : UserControl
    {
        public SaleProductBuyView()
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
