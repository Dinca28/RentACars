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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Car>().HasData(
                new Car { Id = 1, Brand = "BMW", Model = "X5", Year = 2022, PricePerDay = 100, ImageUrl = "https://link-to-bmw.jpg", Location = "Dobrich" },
                new Car { Id = 2, Brand = "Mercedes", Model = "C-Class", Year = 2021, PricePerDay = 90, ImageUrl = "https://link-to-mercedes.jpg", Location = "Varna" },
                new Car { Id = 3, Brand = "Audi", Model = "A4", Year = 2020, PricePerDay = 80, ImageUrl = "https://link-to-audi.jpg", Location = "Sofia" },
                new Car { Id = 4, Brand = "Toyota", Model = "Corolla", Year = 2023, PricePerDay = 70, ImageUrl = "https://link-to-toyota.jpg", Location = "Plovdiv" }
            );
        }
    }
}
