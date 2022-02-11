using System;
using System.ComponentModel.DataAnnotations.Schema;
using TicketSystem.Classes.Enums;

namespace TicketSystem.Classes.MagazineProducts
{
    [Table("MagazineDocumentType"), Serializable]
    public class MagazineDocumentType
    {
        public short Id { get; set; }
        public string Description { get; set; }

        [NotMapped]
        // Internal, not mapped. 
        public virtual MagazineDocumentTypeEnum MagazineType { get; set; }
    }
}
