using Microsoft.EntityFrameworkCore;
using CarRentalSystem.Models;

namespace CarRentalSystem.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Booking> Bookings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure User entity
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.UserID);
                entity.HasIndex(e => e.Username).IsUnique();
                entity.Property(e => e.Username).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Password).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Role).IsRequired().HasDefaultValue("Customer");
            });

            // Configure Car entity
            modelBuilder.Entity<Car>(entity =>
            {
                entity.HasKey(e => e.CarID);
                entity.Property(e => e.CarName).IsRequired().HasMaxLength(100);
                entity.Property(e => e.CarModel).IsRequired().HasMaxLength(50);
                entity.Property(e => e.ImageUrl).HasMaxLength(200);
                entity.Property(e => e.IsAvailable).HasDefaultValue(true);
            });

            // Configure Booking entity
            modelBuilder.Entity<Booking>(entity =>
            {
                entity.HasKey(e => e.BookingID);
                entity.Property(e => e.TotalCost).HasColumnType("decimal(10,2)");

                // Configure relationships
                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.CustomerID)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.Car)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.CarID)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // Seed initial data
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    UserID = 1,
                    Username = "admin",
                    Password = "admin123",
                    Role = "Admin"
                }
            );

            modelBuilder.Entity<Car>().HasData(
                new Car
                {
                    CarID = 1,
                    CarName = "Toyota Camry",
                    CarModel = "2023",
                    ImageUrl = "https://via.placeholder.com/300x200?text=Toyota+Camry",
                    IsAvailable = true
                },
                new Car
                {
                    CarID = 2,
                    CarName = "Honda Civic",
                    CarModel = "2023",
                    ImageUrl = "https://via.placeholder.com/300x200?text=Honda+Civic",
                    IsAvailable = true
                },
                new Car
                {
                    CarID = 3,
                    CarName = "BMW X5",
                    CarModel = "2023",
                    ImageUrl = "https://via.placeholder.com/300x200?text=BMW+X5",
                    IsAvailable = false
                }
            );
        }
    }
}
