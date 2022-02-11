using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TicketSystem.Classes.Items
{
    [Serializable]
    public class TicketGroupItem
    {
        [Key]
        public long ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        [InverseProperty("Group")]
        public virtual ICollection<TicketItem> TicketItems { get; set; }
    }
}