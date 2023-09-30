using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Incubation.DAL.Constant;
using Incubation.DAL.Entities;

namespace Incubation.BLL.Specifications
{
    public class IncubatorWithAdminAndDoctorSpecification : BaseSpecification<Incubator>
    {
        public IncubatorWithAdminAndDoctorSpecification( )
        {
            AddInclude(I => I.Admins);
            AddOrder(I => I.Id);
        }
        public IncubatorWithAdminAndDoctorSpecification(int id) : base(I => I.Id ==id)
        {
            AddInclude(I => I.Admins);


        }
        public IncubatorWithAdminAndDoctorSpecification( string City ) : base(I => I.City.ToLower() == City.ToLower())
        {
            //AddOrder(I => I.City);
        }

    }

    public class UserDateSpecification : BaseSpecification<UserData>
    {
        public UserDateSpecification(int id): base (I => I.Id == id)
        {

        }
    }
    public class GetIncubatorByName : BaseSpecification<Incubator>
    {
        public GetIncubatorByName(string name):base (I => I.Name.ToLower().Contains( name.ToLower()))
        {
            //AddOrder(I => I.Name);

        }
    }
}
