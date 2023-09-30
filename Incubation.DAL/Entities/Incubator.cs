using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Incubation.DAL.Entities.BookingAggregate;
using Incubation.DAL.Entities.Identity;

namespace Incubation.DAL.Entities
{
    public class Incubator:BaseEntity
    {
        public string Name { get; set; }
        public string City { get; set; }
        public string Gevernorate { get; set; }
        public string PhoneNumber { get; set; }
        [ForeignKey(nameof(AppUser))]
        public string UserId { get; set; }
        public virtual AppUser AppUser { get; set; }
        
        public virtual Admin Admins { get; set; } //Navigational Property
        //public Doctor Doctor { get; set; }
        //public virtual ICollection<Doctor> Doctors { get; set; }
        //public virtual ICollection<Bed> Beds { get; set; }
        //public Booking booking { get; set; }

        public List<Bed> beds { get; set; }
        public List<Doctor> doctors { get; set; }
        public List<Booking> bookings { get; set; }



    }
}
