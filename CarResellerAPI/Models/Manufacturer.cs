using System.ComponentModel.DataAnnotations;

namespace CarResellerAPI.Models
{
    public class Manufacturer
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string brandList { get; set; } 
        [Required]
        public string address { get; set; }
        [Required]
        public long phoneNumber { get; set; }
        [Required]
        public int yearOfFoundation { get; set; }
    }
}
