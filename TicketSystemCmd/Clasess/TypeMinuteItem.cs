namespace TicketSystemCmd
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TypeMinuteItem
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
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

        public virtual TicketItem TicketItem { get; set; }
    }
}
