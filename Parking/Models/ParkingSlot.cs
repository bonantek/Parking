namespace Parking.Models
{
    public class ParkingSlot
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public int ParkingId { get; set; }
        public Parking Parking { get; set; }
        public string SlotNr { get; set; } = string.Empty;
    }

}