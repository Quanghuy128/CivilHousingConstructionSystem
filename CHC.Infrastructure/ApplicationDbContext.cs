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

            modelBuilder.Entity<Account>();
        }
    }
}
