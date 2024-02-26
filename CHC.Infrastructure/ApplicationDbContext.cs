using CHC.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;
using System.Security.Principal;

namespace CHC.Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public ApplicationDbContext()
        {
        }

        #region DbSet
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<TransactionDetail> TransactionDetails { get; set; }
        #endregion DbSet

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseNpgsql("server=localhost;port=5432;database=chc;uid=postgres;password=root;TrustServerCertificate=True");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

            modelBuilder.HasDefaultSchema("chc");

            #region Entity Relation

            modelBuilder.Entity<Account>()
                .HasMany(p => p.OwnedMaterials)
                .WithMany(d => d.OwnerAccounts)
                .UsingEntity(j => j.ToTable("owner_material"));

            modelBuilder.Entity<Material>()
                .HasOne(p => p.Category)
                .WithMany(d => d.Materials)
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Material>()
                .HasOne(p => p.Supplier)
                .WithMany(d => d.ProvidedMaterials)
                .HasForeignKey(p => p.SupplierId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Material>()
                .HasOne(p => p.SellerAccount)
                .WithMany(d => d.SellMaterials)
                .HasForeignKey(p => p.SellerId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Transaction>()
                .HasOne(p => p.Customer)
                .WithMany(d => d.Transactions)
                .HasForeignKey(p => p.CustomerId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<TransactionDetail>()
                .HasOne(p => p.Transaction)
                .WithOne(d => d.TransactionDetail)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<TransactionDetail>()
                .HasMany(p => p.Materials)
                .WithMany(d => d.TransactionDetails)
                .UsingEntity(j => j.ToTable("transactiondetail_material"));

            #endregion
        }
    }
}
