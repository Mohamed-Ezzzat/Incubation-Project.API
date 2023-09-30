using System.ComponentModel.DataAnnotations;

namespace Incubation_Project.DTO
{
    public class ChildDTO
    {
        [Required(ErrorMessage = "ChildName Is Required")]
        public string ChildName { get; set; }
        [Required(ErrorMessage = "MotherName Is Required")]
        public string MotherName { get; set; }
        [Required(ErrorMessage = "TypeofIllness Is Required")]
        public string TypeofIllness { get; set; }
        [Required(ErrorMessage = "PhoneNumber Is Required")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "PhoneNumberofDoctor Is Required")]
        public string PhoneNumberofDoctor { get; set; }
        [Required(ErrorMessage = "Age Is Required")]
        public string Age { get; set; }
        public string PrescriptionUrl { get; set; }
        public int UserDateId { get; set; }

    }
}
