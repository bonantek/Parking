using Microsoft.EntityFrameworkCore;
using Parking.Models;

namespace Parking.Data.Services
{
    public class CarService : ICarService
    {
        private readonly AppDbContext _context;

        public CarService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Car>> GetAllAsync()
        {
            var cars = await _context.Cars.ToListAsync();
            return cars;
        }

        public Task<Car> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }
        
        public async Task AddAsync(Car car)
        {
            await _context.Cars.AddAsync(car);
            await _context.SaveChangesAsync();
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}