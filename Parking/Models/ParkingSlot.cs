namespace Parking.Models
{
    public class ParkingSlot
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid ParkingId { get; set; }
        public Parking Parking { get; set; }
        public int SlotNr { get; set; }
        public ICollection<Reservation> Reservations { get; set; }
    }

}