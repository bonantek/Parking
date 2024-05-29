using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Parking.Models
{
    
    public class ApplicationUser : IdentityUser
    {
        [ValidateNever]
        public ICollection<Reservation> Reservations { get; set; } 
        [ValidateNever]
        public ICollection<Car> Cars { get; set; } 
        public string FullName { get; set; } = String.Empty;
    }
    
}