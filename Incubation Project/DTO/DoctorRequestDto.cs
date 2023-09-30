using System.ComponentModel.DataAnnotations;

namespace Incubation_Project.DTO
{
    public class DoctorRequestDto
    {
        [Required(ErrorMessage ="Name Is Required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "PhoneNumber Is Required")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "Specialization Is Required")]
        public string Specialization { get; set; }
        public int IncubatorId { get; set; }
    }
}
