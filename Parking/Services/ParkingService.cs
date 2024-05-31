using Microsoft.EntityFrameworkCore;
using Parking.Models;

namespace Parking.Data.Services
{

    public class ParkingService : IParkingService
    {
        private readonly AppDbContext _context;

        public ParkingService(AppDbContext context)
        {
            _context = context;
        }
        
        public async Task<IEnumerable<Models.Parking>> GetAllAsync()
        {
            var parkings = await _context.Parkings.ToListAsync();
            return parkings;
        }

        public async Task<Models.Parking> GetByIdAsync(Guid id)
        {
            var parking = await _context.Parkings.FindAsync(id);
            return parking;
        }

        public async Task AddAsync(Models.Parking parking)
        {
            await _context.Parkings.AddAsync(parking);
            await _context.SaveChangesAsync();


            for (int i = 1; i <= parking.Capacity; i++)
            {
                await _context.AddAsync(new ParkingSlot { SlotNr = i, ParkingId = parking.Id });
            }

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var parkingToDeleted = await _context.Parkings.FindAsync(id);
            if (parkingToDeleted != null)
            {
                _context.Parkings.Remove(parkingToDeleted);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Models.Parking> GetByIdWithSlotsAndReservations(Guid id)
        {
            return await _context.Parkings
                .Include(p => p.ParkingSlots)
                .ThenInclude(ps => ps.Reservations)
                .SingleAsync(p => p.Id == id);
        }
    }

}