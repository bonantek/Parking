using Parking.Models;

namespace Parking.Data.Services
{

    public interface IReservationService
    {
        Task<Reservation> CreateReservation(Reservation reservation);
    }
}