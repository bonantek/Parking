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
        }

        
        
    }
}