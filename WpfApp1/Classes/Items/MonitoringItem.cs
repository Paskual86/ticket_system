using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace TicketSystem.Classes.Items
{
    public class MonitoringItem: INotifyPropertyChanged
    {
        private int _numberOfTickets;
        private decimal _deposit;

        [Key]
        public long ID { get; set; }
        public DateTime? EntryTime { get; set; } 
        public DateTime? ExitTime { get; set; } 
        [Required]
        public string EntryID { get; set; }

        public decimal Deposit
        {
            get => _deposit;
            set { _deposit = value;
               // ActualPrice = value;
            }
        }

        public decimal ActualPrice
        {
            get => _actualPrice;
            set { _actualPrice = value; OnPropertyChanged(); }
        }

        [Required]
        public long TicketItemID { get; set; }
        public int PaymentMethod { get; set; }
        [Required]
        public long? TerminalID { get; set; }
        [Required]
        [ForeignKey("UserItem")]
        public string UserItemID { get; set; }

        public int NumberOfTickets
        {
            get => _numberOfTickets;
            set { _numberOfTickets = value; OnPropertyChanged(); }
        }

        public bool PermForChildDrinks { get; set; }
        public bool PermForChildFood { get; set; }

        [ForeignKey("EntryID")]
        [InverseProperty("MonitoringItems")]
        public virtual ItemItem ItemItem { get; set; }

        [ForeignKey("TicketItemID")]
        public virtual TicketItem TicketItem { get; set; }

        [InverseProperty("MonitoringItems")]
        public virtual UserItem UserItem { get; set; }

        [ForeignKey("TerminalID")]
        public virtual TerminalItem TerminalItem { get; set; }


        [NotMapped]
        public TimeSpan Time => EntryTime.HasValue ? TimeSpan.FromSeconds((int)(DateTime.Now - EntryTime.Value).TotalSeconds) : TimeSpan.Zero;
        [NotMapped]
        public string EntryTimeDisplay => EntryTime?.ToString("HH:mm");

        //[NotMapped]
       // public decimal TotalPrice => (TicketItem?.GrossPrice ?? 0) * NumberOfTickets;

        [NotMapped]
        public DateTime LastCheckTime = DateTime.Now;
        [NotMapped]
        public int LastIntervalPass = -1;

        private decimal _actualPrice;


        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        public void RefreshTime()
        {
            OnPropertyChanged(nameof(Time));
        }

        public bool IsValid()
        {
            return TicketItemID > 0 && !string.IsNullOrEmpty(EntryID) && Deposit > 0 && PaymentMethod > 0 && NumberOfTickets > 0;
        }
    }
}