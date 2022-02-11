namespace TicketSystemCmd
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MagazineProduct")]
    public partial class MagazineProduct
    {
        public int Id { get; set; }

        public int MagazineId { get; set; }

        public int ProductId { get; set; }

        public virtual Magazine Magazine { get; set; }

        public virtual Product Product { get; set; }
    }
}
