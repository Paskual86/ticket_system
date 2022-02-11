using System.Windows.Controls;
using TicketSystem.Classes.ViewModels;

namespace TicketSystem.Controls.Dialogs
{
    /// <summary>
    /// Interaction logic for CreateTicketGroup.xaml
    /// </summary>
    public partial class CreateUserView
    {
        protected UserViewModel ViewModel => (UserViewModel) DataContext;

        public CreateUserView()
        {
            InitializeComponent();
            passwordBox.PasswordChanged += (sender, args) => { ViewModel.UserData.Password = passwordBox.Password; };
            Loaded += (sender, args) =>
            {
                passwordBox.Password = ViewModel.UserData.Password;
                textBox.Focus();
            };
        }

        private void Email_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            
        }
    }
}
