using System.ComponentModel.DataAnnotations;

namespace Parking.Models
{
    public class Parking
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Street { get; set; } = string.Empty;
        public string StreetNr { get; set; } = string.Empty;
        public int Capacity { get; set; }
        public string Logo { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}