using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace TicketSystem.Classes.MagazineProducts
{
    [Serializable]
    [Table("SaleProduct")]
    public class SaleProduct
    {
        public int Id { get; set; }

        public virtual ICollection<ProductItem> Products { get; set; }
    }
}
