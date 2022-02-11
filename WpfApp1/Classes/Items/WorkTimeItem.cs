using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace TicketSystem.Classes.Items
{
    public class WorkTimeItem: INotifyPropertyChanged
    {
        private TimeSpan? _endHour;

        [Key]
        public long ID { get; set; }
        
        [ForeignKey("UserItem")]
        public string UserItemID { get; set; }
        public DateTime Date { get; set; } = DateTime.Today;
        public TimeSpan StartHour { get; set; }

        [NotMapped]
        public string DateDisplay => Date.ToShortDateString();
        [NotMapped]
        public string StartHourDisplay => $"{StartHour.Hours:00}:{StartHour.Minutes:00}";
        [NotMapped]
        public string EndHourDisplay => !EndHour.HasValue ? null : $"{EndHour.Value.Hours:00}:{EndHour.Value.Minutes:00}";

        public TimeSpan? EndHour
        {
            get => _endHour;
            set { _endHour = value; OnPropertyChanged(); OnPropertyChanged(nameof(TotalHours)); }
        }

        [NotMapped]
        public int TotalHours => !EndHour.HasValue ? 0 : (int) (EndHour.Value.TotalHours - StartHour.TotalHours);

        [InverseProperty("WorkItems")]
        public virtual UserItem UserItem { get; set; }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
