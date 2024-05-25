using Microsoft.AspNetCore.Identity;

namespace Parking.Models
{
    
    public class ApplicationUser : IdentityUser
    {
        public ICollection<Reservation> Reservations { get; set; } 
        public ICollection<Car> Cars { get; set; } 
        public string FullName { get; set; } = String.Empty;
    }
    
}