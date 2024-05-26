using Parking.Models;

namespace Parking.Data.Services
{
    public interface IParkingService
    {
        Task<IEnumerable<Models.Parking>> GetAllAsync();
        Task<Models.Parking> GetByIdAsync();
        Task AddAsync(Models.Parking parking);
        void Delete(Guid id);
        Parking.Models.Parking Update(Guid id, Models.Parking parking);
    }
}