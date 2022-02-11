namespace TicketSystemCmd
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class WorkTimeItem
    {
        public long ID { get; set; }

        [StringLength(128)]
        public string UserItemID { get; set; }

        public DateTime Date { get; set; }

        public TimeSpan StartHour { get; set; }

        public TimeSpan? EndHour { get; set; }

        public virtual UserItem UserItem { get; set; }
    }
}
