using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Incubation.DAL.Entities;

namespace Incubation.BLL.Specifications
{
    public class DoctorSpecifications : BaseSpecification<Doctor>
    {
        public DoctorSpecifications(string userId) : 
            base(x => x.Incubator.doctors.Any(y => y.Incubator.UserId == userId))
        {
        }
    }
}
