using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Incubation.DAL.Entities
{
    public class Doctor:BaseEntity
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Specialization { get; set; }

        public int? IncubatorId { get; set; }
        [ForeignKey("IncubatorId")]
        public Incubator Incubator { get; set; }

        //public virtual ICollection<Incubator> Incubators { get; set; }


        //public Incubator Incubator { get; set; }//Navigational Property
        //[ForeignKey("IncubatorId")]
        //public int IncubatorId  { get; set; }


        //public virtual ICollection<IncubatorWithDoctors> DoctorsInIncubator { get; set; }=new HashSet<IncubatorWithDoctors>();

        //public ICollection<Incubator> incubators { get; set; }
        //public DoctorsInIncubator DoctorsInIncubator { get; set; }//Navigational Property

        //public IList<DoctorsInIncubator> DoctorsInIncubators { get; set; }

    }
}
