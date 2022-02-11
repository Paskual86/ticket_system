using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Input;
using TicketSystem.Classes.Database;
using TicketSystem.Classes.Items;

namespace TicketSystem.Classes.ViewModels
{
    public class UserViewModel
    {
        public UserItem UserData { get; set; }
        public ICommand AcceptCommand { get; set; }
        public ICommand CancelCommand { get; set; }
        public ICommand DashboardCommand { get; set; }


        public event EventHandler<UserItem> Closed;
        public event EventHandler<string> WarningMessage;

        public bool IsIDFieldEnabled { get; set; }

        public List<string> RegionsList { get; set; } = new List<string>
        {
            "Region 1",
            "Region 2",
            "Region 3",
            "Region 4"
        };

        public UserViewModel(UserItem user, bool isNew)
        {
            IsIDFieldEnabled = isNew;

            if (!isNew)
            {
                if(!RegionsList.Contains(user.Region) && !string.IsNullOrEmpty(user.Region))
                    RegionsList.Insert(0, user.Region);
            }

            UserData = user;
            AcceptCommand = new SimpleCommand(o=> user.IsValid(),o =>
            {
                if (isNew && DbHelper.UserHasEntries(UserData.ID))
                {
                    OnWarningMessage("Selected user ID already exists, please select another one!");
                    return;
                }
                OnClosed(UserData);
            });
            CancelCommand = new SimpleCommand(o => OnClosed(null));
            DashboardCommand = new SimpleCommand(o => Process.Start("http://www.google.com"));
        }

        protected void OnClosed(UserItem user)
        {
            Closed?.Invoke(this, user);
        }

        protected void OnWarningMessage(string value)
        {
            WarningMessage?.Invoke(this, value);
        }
    }
}
