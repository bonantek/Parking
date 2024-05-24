namespace Parking.Models
{
    public class Car
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string RegistrationNumber { get; set; } = String.Empty;
        public string Model { get; set; } = String.Empty;
        public string Make { get; set; } = String.Empty;
        //public string UserId { get; set; }
        ////public ApplicationUser User { get; set; }
        
        public ICollection<Reservation> Reservations { get; set; }
    }
}