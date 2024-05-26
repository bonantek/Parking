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

        public Task<Models.Parking> GetByIdAsync()
        {
            throw new NotImplementedException();
        }

        public Task AddAsync(Models.Parking parking)
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Models.Parking Update(Guid id, Models.Parking parking)
        {
            throw new NotImplementedException();
        }
    }

}