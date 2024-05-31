namespace Parking.Models
{
    public class ParkingSlot
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid ParkingId { get; set; }
        public Parking Parking { get; set; }
        public int SlotNr { get; set; }
        public ICollection<Reservation> Reservations { get; set; }

        public bool IsAvailable(DateTime StartDate, DateTime EndDate)
        {
            return !Reservations.Any(reservation => reservation.IsActive
                                                   && reservation.EndDate > DateTime.Now.ToUniversalTime()
                                                   && StartDate <= reservation.EndDate
                                                   && EndDate >= reservation.StartDate);
        }
    }

}