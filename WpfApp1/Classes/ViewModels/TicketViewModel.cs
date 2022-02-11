using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using TicketSystem.Classes.Enums;
using TicketSystem.Classes.Items;

namespace TicketSystem.Classes.ViewModels
{
    public class TicketViewModel: INotifyPropertyChanged
    {
        public TicketItem TicketData { get; set; }
        public ICommand AcceptCommand { get; set; }
        public ICommand CancelCommand { get; set; }

        public TicketGroupItem SelectedGroup
        {
            get => _selectedGroup;
            set { _selectedGroup = value; OnPropertyChanged();
                TicketData.Group = _selectedGroup;
            }
        }

        private Visibility _timerTypeMinuteVisibility = Visibility.Collapsed;
        private Visibility _timerTypeIntervalVisibility = Visibility.Collapsed;
        private Visibility _timerTypeNoLimitVisibility = Visibility.Collapsed;
        private string _timeTypeHeaderText;
        private TicketGroupItem _selectedGroup;

        public List<decimal> VatList { get; set; } = new List<decimal>
        {
            0, 10,15,20,23,30
        };

        public List<decimal> DiscountList { get; set; } = new List<decimal>
        {
            0, 3, 5, 10,15,20,23,30
        };

        public Visibility TimerTypeMinuteVisibility
        {
            get => _timerTypeMinuteVisibility;
            set { _timerTypeMinuteVisibility = value; OnPropertyChanged();}
        }

        public Visibility TimerTypeIntervalVisibility
        {
            get => _timerTypeIntervalVisibility;
            set { _timerTypeIntervalVisibility = value; OnPropertyChanged();}
        }

        public Visibility TimerTypeNoLimitVisibility
        {
            get => _timerTypeNoLimitVisibility;
            set { _timerTypeNoLimitVisibility = value; OnPropertyChanged();}
        }

        public string TimeTypeHeaderText
        {
            get => _timeTypeHeaderText;
            set { _timeTypeHeaderText = value; OnPropertyChanged();}
        }

        public ObservableCollection<TicketGroupItem> GroupsList { get; set; }


        public TicketViewModel(TicketItem ticket, bool isNew, ObservableCollection<TicketGroupItem> groups)
        {
            TicketData = ticket;
            GroupsList = groups;
            if (isNew)
            {
                TicketData.TimeType = 0;
                SelectedGroup = GroupsList.FirstOrDefault();
                UpdateTimerTypeSelection();
                TicketData.TypeNoLimitItem = new TypeNoLimitItem();
                TicketData.TypeIntervalItem = new TypeIntervalItem();
                TicketData.TypeMinuteItem = new TypeMinuteItem();
            }
            else
            {
                SelectedGroup = GroupsList.FirstOrDefault(a=> a.ID == ticket.GroupID);
            }
            AcceptCommand = new SimpleCommand(o=> TicketData.IsValid(),o => OnClosed(TicketData));
            CancelCommand = new SimpleCommand(o => OnClosed(null));
        }

        public event Action<object, TicketItem> Closed;

        protected void OnClosed(TicketItem item)
        {
            Closed?.Invoke(this, item);
        }

        public void UpdateTimerTypeSelection()
        {
            TimeTypeHeaderText = TicketData.TimeTypeText;
            switch ((TimerTypeEnum)TicketData.TimeType)
            {
                case TimerTypeEnum.Minute:
                    TimerTypeMinuteVisibility = Visibility.Visible;
                    TimerTypeIntervalVisibility = Visibility.Collapsed;
                    TimerTypeNoLimitVisibility = Visibility.Collapsed;
                    return;
                case TimerTypeEnum.Interval:
                    TimerTypeMinuteVisibility = Visibility.Collapsed;
                    TimerTypeIntervalVisibility = Visibility.Visible;
                    TimerTypeNoLimitVisibility = Visibility.Collapsed;
                    return;
                case TimerTypeEnum.NoLimit:
                    TimerTypeMinuteVisibility = Visibility.Collapsed;
                    TimerTypeIntervalVisibility = Visibility.Collapsed;
                    TimerTypeNoLimitVisibility = Visibility.Visible;
                    return;
            }
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
