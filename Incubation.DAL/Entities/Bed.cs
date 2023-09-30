using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Incubation.DAL.Entities.BookingAggregate;

namespace Incubation.DAL.Entities
{
    public class Bed:BaseEntity
    {
        public string TypeofBed { get; set; }
        public string Condition { get; set; }
        public string CostPerDay { get; set; }


        public int IncubatorId { get; set; }
        [ForeignKey("IncubatorId")]
        public Incubator Incubator { get; set; }




    
        public virtual List<Booking> Bookings { get; set; } 


        //[ForeignKey(nameof(ChildData))]
        //public int childId { get; set; }
        //public ChildData ChildData { get; set; }


        //public Booking booking { get; set; }



        //public virtual ICollection<Incubator> Incubators { get; set; }


        //public Incubator Incubator { get; set; }//Navigational Property
        //[ForeignKey("IncubatorId")]
        //public int IncubatorId { get; set; }
        //public virtual Children Children { get; set; } //one to one relation
        //public int ChildrenId { get; set; }


        //public ICollection<Incubator> incubators { get; set; }
        //public Incubator Incubators { get; set; } //Navigational Property
        //public int IncubatorsId { get; set; }
    }
}
