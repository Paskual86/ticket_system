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
    public class ItemItem: INotifyPropertyChanged, IDataErrorInfo
    {
        private string _entryID;
        private string _firstname;
        private string _surname;
        private string _address;
        private string _companyName;
        private long _postalCode;
        private string _city;
        private long _nip;
        private long _regon;
        private string _email;
        private string _region;
        private string _phone;

        // public long ID { get; set; }
        [Key]
        public string EntryID
        {
            get => _entryID;
            set { _entryID = value; OnPropertyChanged(); }
        }

        public string Firstname
        {
            get => _firstname;
            set { _firstname = value; OnPropertyChanged();}
        }

        public string Surname
        {
            get => _surname;
            set { _surname = value; OnPropertyChanged(); }
        }

        public string Address
        {
            get => _address;
            set { _address = value; OnPropertyChanged(); }
        }

        public long PostalCode
        {
            get => _postalCode;
            set { _postalCode = value; OnPropertyChanged(); }
        }

        public string City
        {
            get => _city;
            set { _city = value; OnPropertyChanged(); }
        }

        public string Region
        {
            get => _region;
            set { _region = value; OnPropertyChanged(); }
        }

        public string Phone
        {
            get => _phone;
            set { _phone = value; OnPropertyChanged(); }
        }

        public string Email
        {
            get => _email;
            set { _email = value; OnPropertyChanged(); }
        }

        public string CompanyName
        {
            get => _companyName;
            set { _companyName = value; OnPropertyChanged(); }
        }

        public long NIP
        {
            get => _nip;
            set { _nip = value; OnPropertyChanged(); }
        }

        public long REGON
        {
            get => _regon;
            set { _regon = value; OnPropertyChanged(); }
        }

        [field:NonSerialized]
        [InverseProperty("ItemItem")]
        public virtual List<MonitoringItem> MonitoringItems { get; set; }

        [NotMapped]
        public string OldEntryId { get; set; }

        #region INotifyPropertyChanged
        [field:NonSerialized]
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        private const string MSG_ERROR_NOVALUE = "Value must be set!";

        public string this[string columnName]
        {
            get
            {
                switch (columnName)
                {
                    case nameof(EntryID):
                        return !string.IsNullOrEmpty(EntryID) ? null : MSG_ERROR_NOVALUE;
                    case nameof(PostalCode):
                        return PostalCode > 0 ? null : MSG_ERROR_NOVALUE;
                    case nameof(NIP):
                        return NIP > 0 ? null : MSG_ERROR_NOVALUE;
                    case nameof(REGON):
                        return REGON > 0 ? null : MSG_ERROR_NOVALUE;
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
                    case nameof(CompanyName):
                        return !string.IsNullOrEmpty(CompanyName) ? null : MSG_ERROR_NOVALUE;
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

        public void UnknownFields()
        {
            Surname = Firstname = CompanyName = Region = City = Address = "Unknown";
        }

        public void ClearIdentifiers()
        {
            EntryID = Guid.NewGuid().ToString("D");
        }
    }
}
