using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace TicketSystem.Classes.MagazineProducts
{
    [Table("Magazine"), Serializable]
    public class MagazineItem
    {
        public int Id { get; set; }

        public short DocumentTypeId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual MagazineDocumentType DocumentType { get; set; }

        public virtual ICollection<MagazineProduct> MagazineProducts { get; set; }

        /// <summary>
        /// This should be set automatically
        /// </summary>
        public MagazineItem()
        {
            MagazineProducts = new HashSet<MagazineProduct>();
        }
    }
}
