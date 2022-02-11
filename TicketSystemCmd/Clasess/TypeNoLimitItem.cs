namespace TicketSystemCmd
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TypeNoLimitItem
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long ID { get; set; }

        public decimal GrossPrice { get; set; }

        public decimal VAT { get; set; }

        public decimal Discount { get; set; }

        public virtual TicketItem TicketItem { get; set; }
    }
}
