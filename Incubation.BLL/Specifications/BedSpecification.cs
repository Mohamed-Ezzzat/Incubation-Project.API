using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Incubation.DAL.Entities;
using Incubation.DAL.Entities.BookingAggregate;

namespace Incubation.BLL.Specifications
{
    public class BedSpecification : BaseSpecification<Bed>
    {
        //public BedSpecification(string userId) :
        //    base(x => x.Incubators.Any(y => y.UserId == userId))
        //{
        //}
        public BedSpecification(string userId) :
            base(x => x.Incubator.beds.Any(y => y.Incubator.UserId == userId))
        {

        }
        public BedSpecification(int id) : 
            base(I => I.Incubator.beds.Any(y=>y.IncubatorId==id))
        {
            //AddInclude(I => I.Incubator.beds.Any(y=>y.IncubatorId==id));


        }
        
    }

    public class BookUserSpecifition : BaseSpecification<Booking>
    {
        public BookUserSpecifition(string userId) :
            base(x => x.UserRelation.bookings.Any(y => y.UserRelation.UserId == userId))
        {
        }


    }
}
