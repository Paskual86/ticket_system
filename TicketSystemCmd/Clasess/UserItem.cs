namespace TicketSystemCmd
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class UserItem
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public UserItem()
        {
            MonitoringItems = new HashSet<MonitoringItem>();
            WorkTimeItems = new HashSet<WorkTimeItem>();
        }

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

        public DateTime? Session_LoginTime { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MonitoringItem> MonitoringItems { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WorkTimeItem> WorkTimeItems { get; set; }
    }
}
