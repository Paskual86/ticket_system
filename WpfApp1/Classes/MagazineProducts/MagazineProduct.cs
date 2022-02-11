using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TicketSystem.Classes.MagazineProducts
{
    [Table("MagazineProduct"), Serializable]
    public partial class MagazineProduct
    {
        public int Id { get; set; }

        public int MagazineId { get; set; }

        public int ProductId { get; set; }

        [Required]
        [StringLength(150)]
        public string Description { get; set; }

        public int Quantity { get; set; }

        public virtual MagazineItem Magazine { get; set; }

        public virtual ProductItem Product { get; set; }
    }
}
