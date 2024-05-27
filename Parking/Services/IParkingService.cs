using Parking.Models;

namespace Parking.Data.Services
{
    public interface IParkingService
    {
        Task<IEnumerable<Models.Parking>> GetAllAsync();
        Task<Models.Parking> GetByIdAsync(Guid id);
        Task AddAsync(Models.Parking parking);
        Task DeleteAsync(Guid id);
        Task<Models.Parking> Update(Guid id, Models.Parking parking);
    }
}