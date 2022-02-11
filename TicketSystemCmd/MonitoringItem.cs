namespace TicketSystemCmd
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MonitoringItem
    {
        public long ID { get; set; }

        public DateTime? EntryTime { get; set; }

        public DateTime? ExitTime { get; set; }

        [Required]
        [StringLength(128)]
        public string EntryID { get; set; }

        public decimal Deposit { get; set; }

        public decimal ActualPrice { get; set; }

        public long TicketItemID { get; set; }

        public int PaymentMethod { get; set; }

        public long TerminalID { get; set; }

        [Required]
        [StringLength(128)]
        public string UserItemID { get; set; }

        public int NumberOfTickets { get; set; }

        public bool PermForChildDrinks { get; set; }

        public bool PermForChildFood { get; set; }

        public virtual ItemItem ItemItem { get; set; }

        public virtual TerminalItem TerminalItem { get; set; }

        public virtual TicketItem TicketItem { get; set; }

        public virtual UserItem UserItem { get; set; }
    }
}
