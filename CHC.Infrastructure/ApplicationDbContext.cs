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
        public DbSet<Material> Materials { get; set; }
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<Interior> Interiors { get; set; }
        public DbSet<InteriorDetail> InteriorDetails { get; set; }
        public DbSet<Quotation> Quotations { get; set; }
        #endregion DbSet

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseNpgsql("server=db-postgresql-sgp1-25425-do-user-15933004-0.c.db.ondigitalocean.com;port=25060;database=defaultdb;uid=doadmin;password=AVNS_gji6s3Aop8tNMQ0jabg;TrustServerCertificate=True;SslMode=Require;Pooling=false;");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

            modelBuilder.HasDefaultSchema("chc");

            #region Entity Relation

            modelBuilder.Entity<Account>()
                .HasMany(p => p.Contracts)
                .WithOne(d => d.Customer)
                .HasForeignKey(p => p.CustomerId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Account>()
                .HasMany(p => p.Feedbacks)
                .WithOne(d => d.Customer)
                .HasForeignKey(p => p.CustomerId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Account>()
                .HasMany(p => p.Quotations)
                .WithOne(d => d.Customer)
                .HasForeignKey(p => p.CustomerId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Quotation>()
                .HasMany(p => p.Interiors)
                .WithMany(d => d.Quotations)
                .UsingEntity(j => j.ToTable("quotation_detail"));

            modelBuilder.Entity<Interior>()
                .HasMany(p => p.Materials)
                .WithMany(d => d.Interiors)
                .UsingEntity<InteriorDetail>(
                    l => l.HasOne<Material>(e => e.Material).WithMany(e => e.InteriorDetails),
                    l => l.HasOne<Interior>(e => e.Interior).WithMany(e => e.InteriorDetails)
                );

            modelBuilder.Entity<Interior>()
                .HasOne(p => p.Staff)
                .WithMany(d => d.Interiors)
                .HasForeignKey(p => p.StaffId);

            modelBuilder.Entity<Feedback>()
                .HasOne(p => p.Customer)
                .WithMany(d => d.Feedbacks)
                .HasForeignKey(p => p.CustomerId);

            modelBuilder.Entity<Feedback>()
                .HasOne(p => p.Interior)
                .WithMany(d => d.Feedbacks)
                .HasForeignKey(p => p.InteriorId);
            #endregion
        }
    }
}
