using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Input;
using TicketSystem.Classes.Items;

namespace TicketSystem.Classes.ViewModels
{
    public class ItemViewModel
    {
        public ItemItem ItemData { get; set; }
        public ICommand AcceptCommand { get; set; }
        public ICommand CancelCommand { get; set; }
        public ICommand DashboardCommand { get; set; }

        public event EventHandler<ItemItem> Closed;
        public event EventHandler<string> WarningMessage;

        public List<string> RegionsList { get; set; } = new List<string>
        {
            "Region 1",
            "Region 2",
            "Region 3",
            "Region 4"
        };

        private string _oldId;

        public ItemViewModel(ItemItem item, bool isNew)
        {
            if (!isNew)
            {
                _oldId = item.EntryID;
                if(!RegionsList.Contains(item.Region) && !string.IsNullOrEmpty(item.Region))
                    RegionsList.Insert(0, item.Region);
            }

            ItemData = item;
            AcceptCommand = new SimpleCommand(o=> item.IsValid(),o =>
            {
                if (!isNew && _oldId != ItemData.EntryID)
                    ItemData.OldEntryId = _oldId;
                OnClosed(ItemData);
            });
            CancelCommand = new SimpleCommand(o => OnClosed(null));
            DashboardCommand = new SimpleCommand(o => Process.Start("http://www.google.com"));
        }

        protected void OnClosed(ItemItem user)
        {
            Closed?.Invoke(this, user);
        }

        protected void OnWarningMessage(string value)
        {
            WarningMessage?.Invoke(this, value);
        }
    }
}
