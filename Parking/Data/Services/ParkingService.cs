using Microsoft.EntityFrameworkCore;

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

        public Models.Parking Update(Guid id, Models.Parking parking)
        {
            throw new NotImplementedException();
        }
    }

}