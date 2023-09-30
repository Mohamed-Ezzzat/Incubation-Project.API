using Incubation.DAL.Entities;
using System.Collections.Generic;

namespace Incubation_Project.DTO
{
    public class DoctorToReturnDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Specialization { get; set; }
    }
}
