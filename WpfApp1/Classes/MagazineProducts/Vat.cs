using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace TicketSystem.Classes.MagazineProducts
{
    [Serializable]
    [Table("Vat")]
    public class Vat
    {
        public Vat()
        {
            Products = new HashSet<ProductItem>();
        }

        public int Id { get; set; }

        public decimal Value { get; set; }

        public virtual ICollection<ProductItem> Products { get; set; }
    }
}
