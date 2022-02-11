using System.Windows.Input;

namespace TicketSystem.Controls
{
    /// <summary>
    /// Interaction logic for TicketGroupsView.xaml
    /// </summary>
    public partial class WorkTimesView
    {
        public WorkTimesView()
        {
            InitializeComponent();
            Loaded += (sender, args) => idComboBox.Focus();
        }
    }
}
