using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using TicketSystem.Classes.Enums;
using TicketSystem.Classes.Items;

namespace TicketSystem.Classes.ViewModels
{
    public class RegisterViewModel: INotifyPropertyChanged
    {
        #region Properties
        private TicketItem _selectedTicket;
        private TicketGroupItem _selectedGroup;
        private Visibility _noTicketsWarningVisibility = Visibility.Collapsed;
        private Visibility _registerMinutesVisibility = Visibility.Collapsed;
        private Visibility _registerIntervalVisibility = Visibility.Collapsed;
        private Visibility _registerNoLimitVisibility = Visibility.Collapsed;
        public ObservableCollection<TicketGroupItem> GroupsList { get; set; }
        public ICommand AcceptCommand { get; set; }
        public ICommand CancelCommand { get; set; }
        public MonitoringItem Item { get; set; } = new MonitoringItem();

        public Visibility RegisterMinutesVisibility
        {
            get => _registerMinutesVisibility;
            set { _registerMinutesVisibility = value; OnPropertyChanged(); }
        }

        public Visibility RegisterIntervalVisibility
        {
            get => _registerIntervalVisibility;
            set { _registerIntervalVisibility = value; OnPropertyChanged(); }
        }

        public Visibility RegisterNoLimitVisibility
        {
            get => _registerNoLimitVisibility;
            set { _registerNoLimitVisibility = value; OnPropertyChanged(); }
        }

        public Visibility NoTicketsWarningVisibility
        {
            get => _noTicketsWarningVisibility;
            set { _noTicketsWarningVisibility = value; OnPropertyChanged();}
        }

        public TicketGroupItem SelectedGroup
        {
            get => _selectedGroup;
            set { _selectedGroup = value; OnPropertyChanged(); TicketsFilteredCollection.Refresh();
                if(SelectedGroup != null)
                    SelectedTicket = TicketsList.FirstOrDefault(a=> a.GroupID == _selectedGroup.ID);
            }
        }

        public ObservableCollection<TicketItem> TicketsList { get; set; }
        public ICollectionView TicketsFilteredCollection
        {
            get
            {      
                var source = CollectionViewSource.GetDefaultView(TicketsList);
                source.Filter = p => ((TicketItem) p).GroupID == (SelectedGroup?.ID ?? 0);
                return source;
            }
        }

        public TicketItem SelectedTicket
        {
            get => _selectedTicket;
            set
            {
                _selectedTicket = value;
                OnPropertyChanged();
                Item.TicketItem = _selectedTicket;
                Item.TicketItemID = _selectedTicket?.ID ?? 0;
                UpdateInfoVisibility();
            }
        }

        public List<KeyValuePair<string,int>> PaymentMethodsList { get; set; } = new List<KeyValuePair<string, int>>
        {
            new KeyValuePair<string, int>("Credit card", 1),
            new KeyValuePair<string, int>("Cash", 2),
            new KeyValuePair<string, int>("Credit card or cash", 3)
        };

        public ObservableCollection<ItemItem> ItemsList { get; set; }

        #endregion

        public RegisterViewModel(ObservableCollection<TicketGroupItem> groupsList, ObservableCollection<TicketItem> ticketsList, ObservableCollection<ItemItem> itemsList, UserItem user)
        {
            var today = DateTime.Today;
            TicketsList = new ObservableCollection<TicketItem>(ticketsList.Where(a=> a.IsValidForToday(today)));
            GroupsList = new ObservableCollection<TicketGroupItem>(groupsList.Where(b=> TicketsList.Any(a=> a.GroupID == b.ID)));
            ItemsList = itemsList;
            if (TicketsList.Count == 0)
                NoTicketsWarningVisibility = Visibility.Visible;
            var defTicket = ticketsList.FirstOrDefault(a => a.IsDefault);
            if (defTicket != null)
            {
                SelectedGroup = GroupsList.FirstOrDefault(a => a.ID == defTicket.GroupID);
                SelectedTicket = TicketsList.FirstOrDefault(a => a.ID == defTicket.ID);
            }
            else
            {
                SelectedGroup = GroupsList.FirstOrDefault();
                SelectedTicket = TicketsList.FirstOrDefault(a => a.GroupID == (SelectedGroup?.ID ?? 0));
            }

            //UpdateInfoVisibility();

            Item.TerminalID = SettingsManager.TerminalID;
            Item.UserItemID = user.ID;
            Item.UserItem = user;
            Item.EntryID = Guid.NewGuid().ToString();
            Item.PaymentMethod = PaymentMethodsList.FirstOrDefault().Value;

            AcceptCommand = new SimpleCommand(o=> Item.IsValid(),o =>
            {
                Item.EntryTime = DateTime.Now;                
                OnClosed(Item);
            });
            CancelCommand = new SimpleCommand(o => OnClosed(null));
        }

        private void UpdateInfoVisibility()
        {
            if (SelectedTicket == null)
            {
                RegisterMinutesVisibility = Visibility.Collapsed;
                RegisterIntervalVisibility = Visibility.Collapsed;
                RegisterNoLimitVisibility = Visibility.Collapsed;
                return;
            }
            switch (SelectedTicket.TimeType)
            {
                case (int)TimerTypeEnum.Minute:
                    RegisterMinutesVisibility = Visibility.Visible;
                    RegisterIntervalVisibility = Visibility.Collapsed;
                    RegisterNoLimitVisibility = Visibility.Collapsed;
                    break;
                case (int)TimerTypeEnum.Interval:
                    RegisterMinutesVisibility = Visibility.Collapsed;
                    RegisterIntervalVisibility = Visibility.Visible;
                    RegisterNoLimitVisibility = Visibility.Collapsed;
                    break;
                case (int)TimerTypeEnum.NoLimit:
                    RegisterMinutesVisibility = Visibility.Collapsed;
                    RegisterIntervalVisibility = Visibility.Collapsed;
                    RegisterNoLimitVisibility = Visibility.Visible;
                    break;
            }
        }

        public event Action<object, MonitoringItem> Closed;

        protected void OnClosed(MonitoringItem item)
        {
            Closed?.Invoke(this, item);
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
