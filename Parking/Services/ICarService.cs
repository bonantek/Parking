using Parking.Models;

namespace Parking.Data.Services
{

    public interface ICarService
    {
        Task<IEnumerable<Car>> GetAllAsync();
        Task<Car> GetByIdAsync(Guid id);
        Task AddAsync(Car car);
        Task DeleteAsync(Guid id);
    }

}