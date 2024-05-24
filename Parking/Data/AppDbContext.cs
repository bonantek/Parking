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
        
        
    }
}