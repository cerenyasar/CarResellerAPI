
using System.ComponentModel.DataAnnotations;

namespace CarResellerAPI.Models
{
    public class Car
    {
        public int Id { get; set; }
        [Required]
        public string Brand { get; set; }
        [Required]
        public string Model { get; set; }
        [Required]
        public string VehicleIdentificationNumber { get; set; }
        [Required]
        public string LisencePlate { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime RegistrationDate { get; set; }
        [Required]
        public int Power { get; set; }
        public string BodyType { get; set; }
        public string Color { get; set; }

    }
}
