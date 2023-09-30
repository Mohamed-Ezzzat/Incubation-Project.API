using System.ComponentModel.DataAnnotations;

namespace Incubation_Project.DTO
{
    public class UpdateIncubatorDTO
    {
        
        public string DisplayName { get; set; }

        
        [EmailAddress]
        public string Email { get; set; }
        
        public string PhoneNumber { get; set; }
        
        public string City { get; set; }
        
        public string Gevernorate { get; set; }



    }
    public class UpdateuserDto
    {

        public string DisplayName { get; set; }


        [EmailAddress]
        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string City { get; set; }


    }
}
