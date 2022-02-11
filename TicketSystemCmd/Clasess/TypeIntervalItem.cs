namespace TicketSystemCmd
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TypeIntervalItem
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
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

        public bool ThingA { get; set; }

        public bool ThingB { get; set; }

        public bool ThingC { get; set; }

        public bool ThingD { get; set; }

        public decimal VAT { get; set; }

        public decimal Discount { get; set; }

        public virtual TicketItem TicketItem { get; set; }
    }
}
