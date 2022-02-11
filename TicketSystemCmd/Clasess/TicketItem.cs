namespace TicketSystemCmd
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TicketItem
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TicketItem()
        {
            MonitoringItems = new HashSet<MonitoringItem>();
        }

        public long ID { get; set; }

        public string Name { get; set; }

        public long GroupID { get; set; }

        public bool IsDefault { get; set; }

        public int TimeType { get; set; }

        public bool Monday { get; set; }

        public bool Tuesday { get; set; }

        public bool Wednesday { get; set; }

        public bool Thursday { get; set; }

        public bool Friday { get; set; }

        public bool Saturday { get; set; }

        public bool Sunday { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MonitoringItem> MonitoringItems { get; set; }

        public virtual TicketGroupItem TicketGroupItem { get; set; }

        public virtual TypeIntervalItem TypeIntervalItem { get; set; }

        public virtual TypeMinuteItem TypeMinuteItem { get; set; }

        public virtual TypeNoLimitItem TypeNoLimitItem { get; set; }
    }
}
