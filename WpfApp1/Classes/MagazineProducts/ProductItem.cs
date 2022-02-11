using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TicketSystem.Classes.MagazineProducts
{
    [Serializable]
    [Table("Product")]
    public class ProductItem
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ProductItem()
        {
            MagazineProducts = new HashSet<MagazineProduct>();            
        }

        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Code { get; set; }

        [Required]
        [StringLength(150)]
        public string Name { get; set; }

        public decimal NetPrice { get; set; }

        public int VatId { get; set; }

        public decimal? GrossPrice { get; set; }

        public int? CategoryId { get; set; }

        public decimal? NetPurchasePrice { get; set; }

        public decimal? Comision { get; set; }

        public virtual ICollection<MagazineProduct> MagazineProducts { get; set; }

        public virtual ProductCategory ProductCategory { get; set; }

        public virtual Vat Vat { get; set; }

        /// <summary>
        /// Clear
        /// </summary>
        public void ClearIdentificators()
        {
            Id = 0;            
        }
    }
}
