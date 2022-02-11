using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TicketSystem.Classes.MagazineProducts
{
    [Table("ProductCategory"), Serializable]
    public partial class ProductCategory
    {
        public ProductCategory()
        {
            Products = new HashSet<ProductItem>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(150)]
        public string Description { get; set; }

        public bool Active { get; set; }
        public virtual ICollection<ProductItem> Products { get; set; }
    }
}
