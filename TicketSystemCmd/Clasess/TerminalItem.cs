namespace TicketSystemCmd
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TerminalItem
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TerminalItem()
        {
            MonitoringItems = new HashSet<MonitoringItem>();
        }

        public long ID { get; set; }

        public string Name { get; set; }

        public decimal TotalIncome { get; set; }

        public long AverageLengthOfStayTicks { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MonitoringItem> MonitoringItems { get; set; }
    }
}
