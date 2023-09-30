using System;

namespace Incubation_Project.DTO
{
    public class BookingToReturnDTO
    {
        public int Id { get; set; }
        public string ChildName { get; set; }
        public string MotherName { get; set; }
        public string TypeofIllness { get; set; }
        public string PhoneNumber { get; set; }
        public string PhoneNumberofDoctor { get; set; }
        public string Age { get; set; }
        public string DateofBooking { get; set; }

    }
}
