using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace TicketSystem.Classes.Items
{
    public class TerminalItem: INotifyPropertyChanged
    {
        [Key]
        public long ID { get; set; }
        public string Name { get; set; }

        private decimal _totalIncome;
        public decimal TotalIncome
        {
            get => _totalIncome;
            set { _totalIncome = value; OnPropertyChanged(); }
        }

        [NotMapped]
        private int _peoplesCount;

        [NotMapped]
        public int PeoplesCount
        {
            get => _peoplesCount;
            set { _peoplesCount = value; OnPropertyChanged();}
        }

        public long AverageLengthOfStayTicks{ get; set; }     
        
        [NotMapped]
        public TimeSpan AverageLengthOfStay
        {
            get => TimeSpan.FromTicks(AverageLengthOfStayTicks);
            set { AverageLengthOfStayTicks = value.Ticks; OnPropertyChanged();}
        }

        public string AverageLengthOfStayText => $"{AverageLengthOfStay.Hours:00}:{AverageLengthOfStay.Minutes:00}:{AverageLengthOfStay.Seconds:00}";

        #region INotifyPropertyChanged
        [field: NonSerialized] 
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
