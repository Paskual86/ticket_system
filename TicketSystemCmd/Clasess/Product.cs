namespace TicketSystemCmd
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Product")]
    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
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

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MagazineProduct> MagazineProducts { get; set; }

        public virtual ProductCategory ProductCategory { get; set; }

        public virtual Vat Vat { get; set; }
    }
}
