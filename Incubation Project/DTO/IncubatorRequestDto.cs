using System.ComponentModel.DataAnnotations;

namespace Incubation_Project.DTO
{
    public class IncubatorRequestDto
    {
        [Required(ErrorMessage = "Name Is Required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Name Is Required")]
        public string City { get; set; }
        [Required(ErrorMessage = "Name Is Required")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "Name Is Required")]
        public string Email { get; set; }
    }
}
