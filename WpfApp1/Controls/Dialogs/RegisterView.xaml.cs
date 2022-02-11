using System.Windows.Controls;

namespace TicketSystem.Controls.Dialogs
{
    /// <summary>
    /// Interaction logic for RegisterView.xaml
    /// </summary>
    public partial class RegisterView : UserControl
    {
        public RegisterView()
        {
            InitializeComponent();
            Loaded += (sender, args) => listBox.Focus();
        }
    }
}
