using System.Windows.Input;

namespace TicketSystem.Controls
{
    /// <summary>
    /// Interaction logic for TicketGroupsView.xaml
    /// </summary>
    public partial class UsersView
    {
        public UsersView()
        {
            InitializeComponent();
            searchTextBox.KeyDown += (sender, e) =>
            {
                if (e.Key == Key.Enter)
                    searchButton.Command.Execute(null);
            };
            Loaded += (sender, args) => searchTextBox.Focus();
        }
    }
}
