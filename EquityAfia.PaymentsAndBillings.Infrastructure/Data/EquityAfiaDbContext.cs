// Infrastructure/Data/EquityAfiaDbContext.cs
using Microsoft.EntityFrameworkCore;
using EquityAfia.PaymentsAndBillings.Domain.Entities;

namespace EquityAfia.PaymentsAndBillings.Infrastructure.Data
{
    public class EquityAfiaDbContext : DbContext
    {
        public EquityAfiaDbContext(DbContextOptions<EquityAfiaDbContext> options) : base(options)
        {
        }

        public DbSet<Billing> Billings { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Payment> Payments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Service>()
                .HasKey(s => s.ServiceId); // Assuming ServiceId is the primary key

            modelBuilder.Entity<Service>()
                .Property(s => s.AmountCharged)
                .HasColumnType("decimal(18, 2)"); // Adjust precision and scale as needed

            modelBuilder.Entity<Service>()
                .HasOne(s => s.Billing)
                .WithMany(b => b.Services)
                .HasForeignKey(s => s.BillingId);

            modelBuilder.Entity<Product>()
                .HasKey(p => p.ProductId); // Assuming ProductId is the primary key

            modelBuilder.Entity<Product>()
                .HasOne(p => p.Billing)
                .WithMany(b => b.Products)
                .HasForeignKey(p => p.BillingId);

            base.OnModelCreating(modelBuilder);
        }

    }
}
