namespace TicketSystem.Controls.Dialogs
{
    /// <summary>
    /// Interaction logic for CreateTicketGroup.xaml
    /// </summary>
    public partial class CreateTicketGroupView
    {
        public CreateTicketGroupView()
        {
            InitializeComponent();
            Loaded += (sender, args) => textBox.Focus();
        }
    }
}
