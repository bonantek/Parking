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

        public async Task<Car> GetByIdAsync(Guid id)
        {
            var car = await _context.Cars.FindAsync(id);
            return car;
        }
        
        public async Task AddAsync(Car car)
        {
            await _context.Cars.AddAsync(car);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var car = await _context.Cars.FindAsync(id);
            if (car != null)
            {
                _context.Cars.Remove(car);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Car>> GetAllByUserAsync(string userId)
        {
            return await _context.Cars.Where(car => car.UserId == userId).ToListAsync();
            
        }
    }
}