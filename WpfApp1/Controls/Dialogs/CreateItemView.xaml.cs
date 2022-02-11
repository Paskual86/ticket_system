using System.Windows.Controls;
using TicketSystem.Classes.ViewModels;

namespace TicketSystem.Controls.Dialogs
{
    /// <summary>
    /// Interaction logic for CreateTicketGroup.xaml
    /// </summary>
    public partial class CreateItemView
    {
        protected UserViewModel ViewModel => (UserViewModel) DataContext;

        public CreateItemView()
        {
            InitializeComponent();
            Loaded += (sender, args) =>
            {
                textBox.Focus();
            };
        }

        private void Email_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            
        }
    }
}
