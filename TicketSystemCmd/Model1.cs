namespace TicketSystemCmd
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<ItemItem> ItemItems { get; set; }
        public virtual DbSet<Magazine> Magazines { get; set; }
        public virtual DbSet<MagazineProduct> MagazineProducts { get; set; }
        public virtual DbSet<MonitoringItem> MonitoringItems { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductCategory> ProductCategories { get; set; }
        public virtual DbSet<TerminalItem> TerminalItems { get; set; }
        public virtual DbSet<TicketGroupItem> TicketGroupItems { get; set; }
        public virtual DbSet<TicketItem> TicketItems { get; set; }
        public virtual DbSet<TypeIntervalItem> TypeIntervalItems { get; set; }
        public virtual DbSet<TypeMinuteItem> TypeMinuteItems { get; set; }
        public virtual DbSet<TypeNoLimitItem> TypeNoLimitItems { get; set; }
        public virtual DbSet<UserItem> UserItems { get; set; }
        public virtual DbSet<Vat> Vats { get; set; }
        public virtual DbSet<WorkTimeItem> WorkTimeItems { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Magazine>()
                .HasMany(e => e.MagazineProducts)
                .WithRequired(e => e.Magazine)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.NetPrice)
                .HasPrecision(18, 3);

            modelBuilder.Entity<Product>()
                .Property(e => e.GrossPrice)
                .HasPrecision(18, 3);

            modelBuilder.Entity<Product>()
                .Property(e => e.NetPurchasePrice)
                .HasPrecision(18, 3);

            modelBuilder.Entity<Product>()
                .Property(e => e.Comision)
                .HasPrecision(18, 3);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.MagazineProducts)
                .WithRequired(e => e.Product)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ProductCategory>()
                .HasMany(e => e.Products)
                .WithOptional(e => e.ProductCategory)
                .HasForeignKey(e => e.CategoryId);

            modelBuilder.Entity<TerminalItem>()
                .HasMany(e => e.MonitoringItems)
                .WithRequired(e => e.TerminalItem)
                .HasForeignKey(e => e.TerminalID);

            modelBuilder.Entity<TicketGroupItem>()
                .HasMany(e => e.TicketItems)
                .WithRequired(e => e.TicketGroupItem)
                .HasForeignKey(e => e.GroupID);

            modelBuilder.Entity<TicketItem>()
                .HasOptional(e => e.TypeIntervalItem)
                .WithRequired(e => e.TicketItem);

            modelBuilder.Entity<TicketItem>()
                .HasOptional(e => e.TypeMinuteItem)
                .WithRequired(e => e.TicketItem);

            modelBuilder.Entity<TicketItem>()
                .HasOptional(e => e.TypeNoLimitItem)
                .WithRequired(e => e.TicketItem);

            modelBuilder.Entity<Vat>()
                .Property(e => e.Value)
                .HasPrecision(18, 3);

            modelBuilder.Entity<Vat>()
                .HasMany(e => e.Products)
                .WithRequired(e => e.Vat)
                .WillCascadeOnDelete(false);
        }
    }
}
