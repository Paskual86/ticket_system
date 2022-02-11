using System;
using System.Windows.Input;
using TicketSystem.Classes.Items;

namespace TicketSystem.Classes.ViewModels
{
    public class TicketGroupViewModel
    {
        public TicketGroupItem GroupData { get; set; }
        public ICommand AcceptCommand { get; set; }
        public ICommand CancelCommand { get; set; }

        public event EventHandler<TicketGroupItem> Closed;

        public TicketGroupViewModel(TicketGroupItem group)
        {
            GroupData = group;
            AcceptCommand = new SimpleCommand(o=> !string.IsNullOrEmpty(GroupData.Name) && !string.IsNullOrEmpty(GroupData.Description),o => OnClosed(GroupData));
            CancelCommand = new SimpleCommand(o => OnClosed(null));
        }

        protected void OnClosed(TicketGroupItem group)
        {
            Closed?.Invoke(this, group);
        }
    }
}
