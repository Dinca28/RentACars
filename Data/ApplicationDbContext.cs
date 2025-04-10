using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RentACars.Models;

namespace RentACars.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Car> Cars { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Model> Models { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Example of defining one-to-many relationships
            modelBuilder.Entity<Car>()
                .HasOne(c => c.Brand)
                .WithMany(b => b.Cars)
                .HasForeignKey(c => c.BrandId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Car>()
                .HasOne(c => c.City)
                .WithMany(ci => ci.Cars)
                .HasForeignKey(c => c.CityId)
                .OnDelete(DeleteBehavior.SetNull); // You can change the delete behavior if needed

            modelBuilder.Entity<Car>()
                .HasOne(c => c.Model)
                .WithMany(m => m.Cars)
                .HasForeignKey(c => c.ModelId)
                .OnDelete(DeleteBehavior.SetNull); // Assuming you don't want cascading deletes

            modelBuilder.Entity<Model>()
                .HasOne(m => m.Brand)
                .WithMany(b => b.Models)
                .HasForeignKey(m => m.BrandId)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
