using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using TicketSystem.Classes.Enums;

namespace TicketSystem.Classes.Items
{
    [Serializable]
    public class TicketItem: INotifyPropertyChanged
    {
        private bool _monday;
        private bool _tuesday;
        private bool _wednesday;
        private bool _thursday;
        private bool _friday;
        private bool _saturday;
        private bool _sunday;
        private bool _isDefault;
        private string _name;

        [Key]
        public long ID { get; set; }

        public string Name
        {
            get => _name;
            set { _name = value; OnPropertyChanged();}
        }

        [ForeignKey("Group")]
        public long GroupID { get; set; }

        public bool IsDefault
        {
            get => _isDefault;
            set { _isDefault = value; OnPropertyChanged();}
        }

        public int TimeType { get; set; }

        [InverseProperty("TicketItems")]
        public virtual TicketGroupItem Group { get; set; }

        public TypeNoLimitItem TypeNoLimitItem { get; set; }
        public TypeIntervalItem TypeIntervalItem { get; set; }
        public TypeMinuteItem TypeMinuteItem { get; set; }

        [InverseProperty("TicketItem")]
        [field: NonSerialized]
        public virtual ICollection<MonitoringItem> MonitoringItems { get; set; } = new List<MonitoringItem>();

        #region Days
        public bool Monday
        {
            get => _monday;
            set { _monday = value; OnPropertyChanged(); OnPropertyChanged(nameof(AllDays));OnPropertyChanged(nameof(ValidOnDays));}
        }

        public bool Tuesday
        {
            get => _tuesday;
            set { _tuesday = value; OnPropertyChanged(); OnPropertyChanged(nameof(AllDays));OnPropertyChanged(nameof(ValidOnDays));}
        }

        public bool Wednesday
        {
            get => _wednesday;
            set { _wednesday = value; OnPropertyChanged(); OnPropertyChanged(nameof(AllDays));OnPropertyChanged(nameof(ValidOnDays));}
        }

        public bool Thursday
        {
            get => _thursday;
            set { _thursday = value; OnPropertyChanged(); OnPropertyChanged(nameof(AllDays));OnPropertyChanged(nameof(ValidOnDays));}
        }

        public bool Friday
        {
            get => _friday;
            set { _friday = value; OnPropertyChanged(); OnPropertyChanged(nameof(AllDays));OnPropertyChanged(nameof(ValidOnDays));}
        }

        public bool Saturday
        {
            get => _saturday;
            set { _saturday = value; OnPropertyChanged(); OnPropertyChanged(nameof(AllDays));OnPropertyChanged(nameof(ValidOnDays));}
        }

        public bool Sunday
        {
            get => _sunday;
            set { _sunday = value; OnPropertyChanged(); OnPropertyChanged(nameof(AllDays)); OnPropertyChanged(nameof(ValidOnDays));}
        }
        #endregion

        #region NotMapped

        [NotMapped]
        public decimal VAT
        {
            get
            {
                switch ((TimerTypeEnum)TimeType)
                {
                    case TimerTypeEnum.Interval:
                        return TypeIntervalItem?.VAT ?? 0;
                    case TimerTypeEnum.Minute:
                        return TypeMinuteItem?.VAT ?? 0;
                    case TimerTypeEnum.NoLimit:
                        return TypeNoLimitItem?.VAT ?? 0;
                }

                return 0;
            }
        }

        [NotMapped]
        public string ValidOnDays {
            get
            {
                if (AllDays) return "All Days";
                var sb = new StringBuilder();
                if (Monday)
                {
                    sb.Append("Monday");
                    sb.Append(",");
                }
                if (Tuesday)
                {
                    sb.Append("Tuesday");
                    sb.Append(",");
                }
                if (Wednesday)
                {
                    sb.Append("Wednesday");
                    sb.Append(",");
                }
                if (Thursday)
                {
                    sb.Append("Thursday");
                    sb.Append(",");
                }
                if (Friday)
                {
                    sb.Append("Friday");
                    sb.Append(",");
                }
                if (Saturday)
                {
                    sb.Append("Saturday");
                    sb.Append(",");
                }
                if (Sunday)
                {
                    sb.Append("Sunday");
                    sb.Append(",");
                }

                sb.Remove(sb.Length - 1, 1);
                return sb.ToString();
            }
        }


        [NotMapped]
        public bool AllDays
        {
            get => Monday && Tuesday && Wednesday && Thursday && Friday && Saturday && Sunday;
            set
            {
                Monday = Tuesday = Wednesday = Thursday = Friday = Saturday = Sunday = value; 
                OnPropertyChanged(nameof(Monday));
                OnPropertyChanged(nameof(Tuesday));
                OnPropertyChanged(nameof(Wednesday));
                OnPropertyChanged(nameof(Thursday));
                OnPropertyChanged(nameof(Friday));
                OnPropertyChanged(nameof(Saturday));
                OnPropertyChanged(nameof(Sunday));
            }
        }

        [NotMapped]
        public bool AnyDay => Monday || Tuesday || Wednesday || Thursday || Friday || Saturday || Sunday;        

        [NotMapped]
        public string TimeTypeText 
        {
            get
            {
                switch ((TimerTypeEnum)TimeType)
                {
                    case TimerTypeEnum.Interval:
                        return "Intervals";
                    case TimerTypeEnum.Minute:
                        return "Minutes";
                    case TimerTypeEnum.NoLimit:
                        return "No Limits";
                }

                return null;
            }
        }

        [NotMapped]
        public decimal GrossPrice 
        {
            get
            {
                switch ((TimerTypeEnum)TimeType)
                {
                    case TimerTypeEnum.Interval:
                        return TypeIntervalItem.GrossPriceAbove;
                    case TimerTypeEnum.Minute:
                        return TypeMinuteItem.GrossPrice;
                    case TimerTypeEnum.NoLimit:
                        return TypeNoLimitItem.GrossPrice;
                }

                return 0;
            }
        }

        [NotMapped]
        public decimal Discount 
        {
            get
            {
                switch ((TimerTypeEnum)TimeType)
                {
                    case TimerTypeEnum.Interval:
                        return TypeIntervalItem.Discount;
                    case TimerTypeEnum.Minute:
                        return TypeMinuteItem.Discount;
                    case TimerTypeEnum.NoLimit:
                        return TypeNoLimitItem.Discount;
                }

                return 0;
            }
        }

        [NotMapped]
        public int ForMinutes
        {
            get
            {
                switch ((TimerTypeEnum)TimeType)
                {
                    case TimerTypeEnum.Interval:
                        return TypeIntervalItem.FromMinutesAbove;
                    case TimerTypeEnum.Minute:
                        return TypeMinuteItem.ForMinutes;
                    case TimerTypeEnum.NoLimit:
                        return 0;
                }

                return 0;
            }
        }

        [NotMapped]
        public decimal ExtraPay
        {
            get
            {
                switch ((TimerTypeEnum)TimeType)
                {
                    case TimerTypeEnum.Interval:
                        return 0;
                    case TimerTypeEnum.Minute:
                        return TypeMinuteItem.ExtraPay;
                    case TimerTypeEnum.NoLimit:
                        return 0;
                }

                return 0;
            }
        }

        [NotMapped]
        public int ForNext
        {
            get
            {
                switch ((TimerTypeEnum)TimeType)
                {
                    case TimerTypeEnum.Interval:
                        return 0;
                    case TimerTypeEnum.Minute:
                        return TypeMinuteItem.ForNextMinutes;
                    case TimerTypeEnum.NoLimit:
                        return 0;
                }

                return 0;
            }
        }


        #endregion

        #region INotifyPropertyChanged
        [field: NonSerialized] 
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        public bool IsValid()
        {
            return AnyDay && !string.IsNullOrEmpty(Name) && GroupID > 0 && (TimeType != 2 || TypeNoLimitItem.IsValid()) && (TimeType != 1 || TypeIntervalItem.IsValid()) && (TimeType != 0 || TypeMinuteItem.IsValid());
        }

        public void ClearIdentificators()
        {
            ID = 0;
            TypeIntervalItem.ID = 0;
            TypeMinuteItem.ID = 0;
            TypeNoLimitItem.ID = 0;
            IsDefault = false;
        }

        public bool IsValidForToday(DateTime today)
        {
            if (AllDays) return true;
            switch (today.DayOfWeek)
            {
                case DayOfWeek.Monday:
                    return Monday;
                case DayOfWeek.Tuesday:
                    return Tuesday;
                case DayOfWeek.Wednesday:
                    return Wednesday;
                case DayOfWeek.Thursday:
                    return Thursday;
                case DayOfWeek.Friday:
                    return Friday;
                case DayOfWeek.Saturday:
                    return Saturday;
                case DayOfWeek.Sunday:
                    return Sunday;
                default:
                    return false;
            }
        }
    }

    [Serializable]
    public class TypeMinuteItem
    {
        [Key]
        public long ID { get; set; }
        public decimal GrossPrice { get; set; }
        public int ForMinutes { get; set; }
        public decimal ExtraPay { get; set; }
        public int ForNextMinutes { get; set; }
        public bool IsFixedPrice { get; set; }
        public decimal VAT { get; set; }
        public decimal Discount { get; set; }
        public decimal GrossPriceAbove { get; set; }
        public int FromMinutesAbove { get; set; }

        public bool IsValid()
        {
            return !IsFixedPrice || (GrossPriceAbove >0  && FromMinutesAbove > 0);
        }
        [InverseProperty("TypeMinuteItem")]
        [Required]
        public virtual TicketItem TicketItem { get; set; }
    }

    [Serializable]
    public class TypeNoLimitItem
    {
        [Key]
        public long ID { get; set; }
        public decimal GrossPrice { get; set; }
        public decimal VAT { get; set; }
        public decimal Discount { get; set; }

        public bool IsValid()
        {
            return true;
        }
        [ForeignKey("ID")]
        [Required]
        public virtual TicketItem TicketItem { get; set; }

    }

    [Serializable]
    public class TypeIntervalItem: INotifyPropertyChanged
    {
        private bool _thingA = true;
        private bool _thingB = true;
        private bool _thingC = true;
        private bool _thingD = true;

        [Key]
        public long ID { get; set; }
        public decimal GrossPrice1 { get; set; }
        public int FromMinutes1 { get; set; }
        public decimal GrossPrice2 { get; set; }
        public int FromMinutes2 { get; set; }
        public decimal GrossPrice3 { get; set; }
        public int FromMinutes3 { get; set; }
        public decimal GrossPrice4 { get; set; }
        public int FromMinutes4 { get; set; }
        public decimal GrossPriceAbove { get; set; }
        public int FromMinutesAbove { get; set; }

        public bool ThingA
        {
            get => _thingA;
            set { _thingA = value; OnPropertyChanged(); }
        }

        public bool ThingB
        {
            get => _thingB;
            set { _thingB = value; OnPropertyChanged(); }
        }

        public bool ThingC
        {
            get => _thingC;
            set { _thingC = value; OnPropertyChanged(); }
        }

        public bool ThingD
        {
            get => _thingD;
            set { _thingD = value; OnPropertyChanged(); }
        }

        public decimal VAT { get; set; }
        public decimal Discount { get; set; }

        [ForeignKey("ID")]
        [Required]
        public virtual TicketItem TicketItem { get; set; }

        public bool IsValid()
        {
            return true;
        }

        [field: NonSerialized] 
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public Dictionary<int, decimal> GetIntervals()
        {
            var list = new Dictionary<int, decimal>();
            if(ThingA)
                list.Add(FromMinutes1, GrossPrice1);
            if(ThingB)
                list.Add(FromMinutes2, GrossPrice2);
            if(ThingC)
                list.Add(FromMinutes3, GrossPrice3);
            if(ThingD)
                list.Add(FromMinutes4, GrossPrice4);
            return list.OrderBy(a => a.Key).ToDictionary(pair => pair.Key, pair => pair.Value);
        }
    }
}