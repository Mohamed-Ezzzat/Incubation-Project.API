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
    public class UserData : BaseEntity
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string City { get; set; }
        [ForeignKey(nameof(User))]
        public string UserId { get; set; }
        public virtual AppUser User { get; set; }


        public virtual ICollection<Booking> bookings { get; set; } = new List<Booking>();
        public virtual ICollection<ChildData> Children { get; set; } = new List<ChildData>();
        
    }
}
