using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Incubation.DAL.Entities;

namespace Incubation.BLL.Specifications
{
    public class DoctorWithIncubatorSpecification : BaseSpecification<Doctor>
    {
        public DoctorWithIncubatorSpecification()
        {
            //AddInclude(d=>d.Incubator);
        }
        public DoctorWithIncubatorSpecification(int id) : base(I => I.Id == id)
        {
            //AddInclude(d => d.Incubator);
        }

    }
}
