using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Parking.Models
{
    public class Car
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required]
        public string RegistrationNumber { get; set; } = String.Empty;
        
        [Required]
        public string Model { get; set; } = String.Empty;
        
        [Required]
        public string Make { get; set; } = String.Empty;
       
        [ValidateNever]
        public ICollection<Reservation> Reservations { get; set; }
        [Required]
        public string UserId { get; set; }
        [ValidateNever]
        public ApplicationUser User { get; set; }
    }
}