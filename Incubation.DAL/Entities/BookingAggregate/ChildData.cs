using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Incubation.DAL.Entities.BookingAggregate
{
    public class ChildData : BaseEntity
    {
        public ChildData()
        {

        }
        public ChildData(string childName, string motherName, string typeofIllness,
            string phoneNumber, string phoneNumberofDoctor,
            string age, string prescriptionUrl)
        {
            ChildName = childName;
            MotherName = motherName;
            TypeofIllness = typeofIllness;
            PhoneNumber = phoneNumber;
            PhoneNumberofDoctor = phoneNumberofDoctor;
            Age = age;
            PrescriptionUrl = prescriptionUrl;
        }

        public string ChildName { get; set; }
        public string MotherName { get; set; }
        public string TypeofIllness { get; set; }
        public string PhoneNumber { get; set; }
        public string PhoneNumberofDoctor { get; set; }
        public string Age { get; set; }
        public string PrescriptionUrl { get; set; }






        [ForeignKey(nameof(UserRelation))]
        public int UserDateId { get; set; }
        public UserData UserRelation { get; set; }


        public List<Booking> bookings { get; set; }





    }
}
