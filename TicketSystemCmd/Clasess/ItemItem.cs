namespace TicketSystemCmd
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ItemItem
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ItemItem()
        {
            MonitoringItems = new HashSet<MonitoringItem>();
        }

        [Key]
        public string EntryID { get; set; }

        public string Firstname { get; set; }

        public string Surname { get; set; }

        public string Address { get; set; }

        public long PostalCode { get; set; }

        public string City { get; set; }

        public string Region { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public string CompanyName { get; set; }

        public long NIP { get; set; }

        public long REGON { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MonitoringItem> MonitoringItems { get; set; }
    }
}
