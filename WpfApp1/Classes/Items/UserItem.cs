using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;

namespace TicketSystem.Classes.Items
{
    [Serializable]
    public class UserItem: IDataErrorInfo
    {
        [Key]
        public string ID { get; set; }
        public string Firstname { get; set; }
        public string Surname { get; set; }

        public string Address { get; set; }
        public long PostalCode { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Email2 { get; set; }

        [NotMapped]
        public string SecureString => $"{Firstname}{Surname}{Login}".ToLower();

        [field: NonSerialized] 
        public UserSessionItem Session { get; set; } = new UserSessionItem();
        public string Login { get; set; }
        public string Password { get; set; }

        [InverseProperty("UserItem")]
        [field: NonSerialized] 
        public virtual ICollection<MonitoringItem> MonitoringItems { get; set; } = new List<MonitoringItem>();

        [InverseProperty("UserItem")]
        [field: NonSerialized] 
        public virtual ICollection<WorkTimeItem> WorkItems { get; set; } = new List<WorkTimeItem>();

        private const string MSG_ERROR_NOVALUE = "Value must be set!";

        public string this[string columnName]
        {
            get
            {
                switch (columnName)
                {
                    case nameof(ID):
                        return !string.IsNullOrEmpty(ID)? null : MSG_ERROR_NOVALUE;
                    case nameof(PostalCode):
                        return PostalCode > 0 ? null : MSG_ERROR_NOVALUE;
                    case nameof(Firstname):
                        return !string.IsNullOrEmpty(Firstname) ? null : MSG_ERROR_NOVALUE;
                    case nameof(Surname):
                        return !string.IsNullOrEmpty(Surname) ? null : MSG_ERROR_NOVALUE;
                    case nameof(Address):
                        return !string.IsNullOrEmpty(Address) ? null : MSG_ERROR_NOVALUE;
                    case nameof(City):
                        return !string.IsNullOrEmpty(City) ? null : MSG_ERROR_NOVALUE;
                    case nameof(Region):
                        return !string.IsNullOrEmpty(Region) ? null : MSG_ERROR_NOVALUE;
                    case nameof(Phone):
                        return !string.IsNullOrEmpty(Phone) ? null : MSG_ERROR_NOVALUE;
                    case nameof(Login):
                        return !string.IsNullOrEmpty(Login) ? null : MSG_ERROR_NOVALUE;
                    case nameof(Password):
                        return !string.IsNullOrEmpty(Password) ? null : MSG_ERROR_NOVALUE;
                    case nameof(Email):
                        return TextBoxHelper.IsValidEmail(Email) ? null : "Invalid email!";
                    default:
                        return null;
                }
            }
        }

        public string Error => null;

        public bool IsValid()
        {
            return GetType().GetProperties().All(a=> this[a.Name] == null);
        }

        public void ClearIdentificators()
        {
            ID = Guid.NewGuid().ToString("D");
            MonitoringItems = new List<MonitoringItem>();
            WorkItems = new List<WorkTimeItem>();
            Session = new UserSessionItem();
        }
    }

    public class UserSessionItem: INotifyPropertyChanged
    {
        public DateTime? LoginTime { get; set; } = DateTime.Now;

        [NotMapped]
        public string LoginTimeText => LoginTime?.ToString("HH:mm");

        [NotMapped]
        public TimeSpan WorkTime => LoginTime.HasValue ? TimeSpan.FromSeconds((int)(DateTime.Now - LoginTime.Value).TotalSeconds) : TimeSpan.Zero;
        
        #region INotifyPropertyChanged

        [field: NonSerialized] 
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        public void RefreshTime()
        {
            OnPropertyChanged(nameof(WorkTime));
        }

        public void ResetStats()
        {
            LoginTime = DateTime.Now;
        }
    }
}