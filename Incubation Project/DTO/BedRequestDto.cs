using System.ComponentModel.DataAnnotations;

namespace Incubation_Project.DTO
{
    public class BedRequestDto
    {
        [Required(ErrorMessage = "Name Is Required")]
        public string TypeofBed { get; set; }
        [Required(ErrorMessage = "Condition Is Required")]
        public string Condition { get; set; }
        [Required(ErrorMessage = "CostPerDay Is Required")]
        public string CostPerDay { get; set; }

        public int IncubatorId { get; set; }

    }
}
