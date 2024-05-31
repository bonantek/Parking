using Parking.Models;

namespace Parking.Data.Services
{

    public interface IReservationService
    {
        Task<Reservation> CreateReservation(Reservation reservation);
        Task<IEnumerable<Reservation>> GetAllForUser(ApplicationUser user);
        Task<IEnumerable<Reservation>> GetAllForParkingSlot(ParkingSlot parkingSlot);
    }
}