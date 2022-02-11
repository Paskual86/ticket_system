using SQLite.CodeFirst;
using System.Data.Entity;
using System.Data.SQLite;
using TicketSystem.Classes.Items;
using TicketSystem.Classes.MagazineProducts;

namespace TicketSystem.Classes.Database
{
    internal class TicketSystemContext : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            if (SettingsManager.DbProvider == DbProviderEnum.Sqlite)
            {
                var sqliteConnectionInitializer = new SqliteDropCreateDatabaseWhenModelChanges<TicketSystemContext>(modelBuilder);
                System.Data.Entity.Database.SetInitializer(sqliteConnectionInitializer);
            }
            else { base.OnModelCreating(modelBuilder);

                modelBuilder.Entity<MagazineItem>()
               .HasMany(e => e.MagazineProducts)
               .WithRequired(e => e.Magazine)
               .WillCascadeOnDelete(false);

                modelBuilder.Entity<ProductItem>()
                    .Property(e => e.NetPrice)
                    .HasPrecision(18, 3);

                modelBuilder.Entity<ProductItem>()
                    .Property(e => e.GrossPrice)
                    .HasPrecision(18, 3);

                modelBuilder.Entity<ProductItem>()
                    .Property(e => e.NetPurchasePrice)
                    .HasPrecision(18, 3);

                modelBuilder.Entity<ProductItem>()
                    .Property(e => e.Comision)
                    .HasPrecision(18, 3);

                modelBuilder.Entity<ProductItem>()
                    .HasMany(e => e.MagazineProducts)
                    .WithRequired(e => e.Product)
                    .WillCascadeOnDelete(false);

                modelBuilder.Entity<ProductCategory>()
                    .HasMany(e => e.Products)
                    .WithOptional(e => e.ProductCategory)
                    .HasForeignKey(e => e.CategoryId);

                modelBuilder.Entity<Vat>()
                .Property(e => e.Value)
                .HasPrecision(18, 3);

                modelBuilder.Entity<Vat>()
                    .HasMany(e => e.Products)
                    .WithRequired(e => e.Vat)
                    .WillCascadeOnDelete(false);
            }
        }


        public DbSet<TicketGroupItem> TicketGroups { get; set; }
        public DbSet<UserItem> Users { get; set; }
        public DbSet<TerminalItem> Terminals { get; set; }
        public DbSet<TicketItem> Tickets { get; set; }

        public DbSet<TypeNoLimitItem> TypeNoLimitItems { get; set; }
        public DbSet<TypeIntervalItem> TypeIntervalItems { get; set; }
        public DbSet<TypeMinuteItem> TypeMinuteItems { get; set; }
        public DbSet<MonitoringItem> MonitoringItems { get; set; }
        public DbSet<WorkTimeItem> WorkTimeItems { get; set; }
        public DbSet<ItemItem> Items { get; set; }

        public virtual DbSet<MagazineDocumentType> DocumentTypes { get; set; }
        public virtual DbSet<MagazineItem> Magazines { get; set; }
        public virtual DbSet<MagazineProduct> MagazineProducts { get; set; }
        public virtual DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<ProductItem> Products { get; set; }
        public virtual DbSet<Vat> Vats { get; set; }
        
        internal void CreateDatabase()
        {
            SQLiteConnection.CreateFile(Database.Connection.ConnectionString.Substring(12, Database.Connection.ConnectionString.Length -12));
        }

        internal void Seed()
        {
            Set<UserItem>().Add(new UserItem { ID = "TestId", Firstname = "Alexander", Surname = "Testman", Login = "user", Password = "user" });
            Set<TerminalItem>().Add(new TerminalItem { ID = 1, Name = "Test Terminal 1" });
            Set<TerminalItem>().Add(new TerminalItem { ID = 2, Name = "Test Terminal 2" });
            Set<TerminalItem>().Add(new TerminalItem { ID = 3, Name = "Test Terminal 3" });

            Set<TicketGroupItem>().Add(new TicketGroupItem { Name = "Individual", Description = "Tickets for individuals" });
            Set<TicketGroupItem>().Add(new TicketGroupItem { Name = "Groups", Description = "Tickets for groups" });
            Set<TicketGroupItem>().Add(new TicketGroupItem { Name = "Family", Description = "Tickets for families" });

            Set<Vat>().Add(new Vat { Value = 10 });
            Set<Vat>().Add(new Vat { Value = 15 });
            Set<Vat>().Add(new Vat { Value = 20 });
            Set<Vat>().Add(new Vat { Value = 23 });
            Set<Vat>().Add(new Vat { Value = 30 });

            Set<ProductCategory>().Add(new ProductCategory
            {
                Active = true,
                Description = "Technology"
            });

            Set<ProductCategory>().Add(new ProductCategory
            {
                Active = true,
                Description = "Food"
            });
            Set<ProductCategory>().Add(new ProductCategory
            {
                Active = true,
                Description = "Clothes"
            });
            Set<ProductCategory>().Add(new ProductCategory
            {
                Active = true,
                Description = "Sport"
            });

            Set<MagazineDocumentType>().Add(new MagazineDocumentType
            {
                Id = 1,
                Description = "External reception to magazine (PZ)"
            });
            Set<MagazineDocumentType>().Add(new MagazineDocumentType
            {
                Id = 2,
                Description = "External issue from the magazine (WZ)"
            });
            Set<MagazineDocumentType>().Add(new MagazineDocumentType
            {
                Id = 3,
                Description = "Internal reception to the magazine (PW)"
            });
            Set<MagazineDocumentType>().Add(new MagazineDocumentType
            {
                Id = 4,
                Description = "Internal expenditure from magazine (RW)"
            });
            Set<MagazineDocumentType>().Add(new MagazineDocumentType
            {
                Id = 5,
                Description = "Inventory (IN)"
            });
            
            SaveChanges();
        }
    }

    internal class TicketSystemContextInitializer : DropCreateDatabaseIfModelChanges<TicketSystemContext>
    {
        protected override void Seed(TicketSystemContext context)
        {
            context.Seed();
        }
    }
}
