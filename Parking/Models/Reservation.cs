namespace Parking.Models
{
    public class Reservation
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid ParkingSlotId { get; set; }
        public ParkingSlot ParkingSlot { get; set; }
        public DateTime ReservationDate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Guid CarId { get; set; }
        public Car Car { get; set; }
        public bool IsActive { get; set; }
        
        public string UserId { get; set; } 
        public ApplicationUser User { get; set; }
    }
}