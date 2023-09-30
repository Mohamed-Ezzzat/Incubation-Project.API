using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Incubation.DAL.Entities.BookingAggregate;

namespace Incubation.BLL.Specifications
{
    public class BookingSpecification :BaseSpecification<Booking>
    {
        public BookingSpecification(string userId):
            base(x => x.BookinginIncubator.bookings.Any(y => y.BookinginIncubator.UserId == userId))
        {

        }
    }
    public class ChildDateSpecification : BaseSpecification<ChildData>
    {
        public ChildDateSpecification(string userId) :
            base(x => x.UserRelation.Children.Any(y => y.UserRelation.UserId == userId))
        {

        }
    }
    public class ChildBookSpecification : BaseSpecification<ChildData>
    {
        public ChildBookSpecification(int id) :
            base(x => x.Id==id)
        {

        }
    }
    public class BedDataSpecification : BaseSpecification<Booking>
    {
        public BedDataSpecification(int id):
            base(x => x.bedid==id)
        { }
    }
}
