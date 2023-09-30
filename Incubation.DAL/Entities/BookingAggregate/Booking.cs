using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Incubation.DAL.Entities.BookingAggregate
{
    public class Booking :BaseEntity
    {
        public Booking(
            string bookerEmail,
            string childName,
            string motherName, string typeofIllness,
            string phoneNumber, string phoneNumberofDoctor,
            string age, string prescriptionUrl)
        {
            BookerEmail = bookerEmail;
            ChildName = childName;
            MotherName = motherName;
            TypeofIllness = typeofIllness;
            PhoneNumber = phoneNumber;
            PhoneNumberofDoctor = phoneNumberofDoctor;
            Age = age;
            PrescriptionUrl = prescriptionUrl;
        }

        //public Booking()
        //{

        //}
        //public Booking(string bookerEmail, ChildData bookingData)
        //{
        //    BookerEmail = bookerEmail;
        //    BookingData = bookingData;
        //}


        public string BookerEmail { get; set; }
        public DateTimeOffset DateofBooking { get; set; } = DateTimeOffset.Now;

        public string ChildName { get; set; }
        public string MotherName { get; set; }
        public string TypeofIllness { get; set; }
        public string PhoneNumber { get; set; }
        public string PhoneNumberofDoctor { get; set; }
        public string Age { get; set; }
        public string PrescriptionUrl { get; set; }

        public BookingState bookingState { get; set; } = BookingState.Pending;

        [ForeignKey(nameof(BookinginIncubator))]
        public int IncubatorId { get; set; }
        public Incubator BookinginIncubator { get; set; } //incubator

        [ForeignKey(nameof(UserRelation))]
        public int UserDateId { get; set; }
        public UserData UserRelation { get; set; } // User 

        [ForeignKey(nameof(ChildData))]
        public int childId { get; set; }
        //[NotMapped]
        public virtual ChildData ChildData { get; set; } //Child

        [ForeignKey(nameof(BedData))]
        public int bedid { get; set; }
        //[NotMapped]
        public virtual Bed BedData { get; set; }//Bed


        //public Bed Bed { get; set; }



    }
}
