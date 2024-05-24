using Microsoft.EntityFrameworkCore;
using Parking.Models;

namespace Parking.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        
        public DbSet<Models.Parking> Parkings { get; set; }
        
        public DbSet<ParkingSlot> ParkingSlots { get; set; }
        
        public DbSet<Reservation> Reservations { get; set; }
        
        public DbSet<Car> Cars { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Models.Parking>()
                .HasMany(p => p.ParkingSlots)
                .WithOne(ps => ps.Parking)
                .HasForeignKey(ps => ps.ParkingId);

            modelBuilder.Entity<Reservation>()
                .HasOne(r => r.ParkingSlot)
                .WithMany(ps => ps.Reservations)
                .HasForeignKey(r => r.ParkingSlotId);

            modelBuilder.Entity<Reservation>()
                .HasOne(r => r.Car)
                .WithMany(c => c.Reservations)
                .HasForeignKey(r => r.CarId);
            
            modelBuilder.Entity<Models.Parking>().HasData(
                new Models.Parking
                {
                    Id = Guid.NewGuid(),
                    Name = "Parking A",
                    City = "Warszawa",
                    Street = "Lazienkowska",
                    StreetNr = "1",
                    Capacity = 100,
                    Logo = "",
                    Description = "Big parking near Legia"
                },
                new Models.Parking
                {
                    Id = Guid.NewGuid(),
                    Name = "Parking B",
                    City = "Krakow",
                    Street = "Reymonta",
                    StreetNr = "2",
                    Capacity = 150,
                    Logo = "",
                    Description = "Parking dla kibicow Cracovii"
                },
                new Models.Parking
                {
                    Id = Guid.NewGuid(),
                    Name = "Parking Wiselka",
                    City = "Krakow",
                    Street = "Reymonta",
                    StreetNr = "3",
                    Capacity = 200,
                    Logo = "",
                    Description = "Parking Wiselki"
                });
        }
        
        

        
        
    }
}