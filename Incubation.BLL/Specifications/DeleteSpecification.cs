using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Incubation.DAL.Entities;
using Incubation.DAL.Entities.BookingAggregate;

namespace Incubation.BLL.Specifications
{
    //public class DeleteSpecification
    //{
    //}
    public class DeletebedSpecific : BaseSpecification<Bed>
    {
        public DeletebedSpecific(int Id) : base(I => I.Id == Id)
        {

        }

    }
    public class DeleteDoctorSpecific : BaseSpecification<Doctor>
    {
        public DeleteDoctorSpecific(int Id) : base(I => I.Id == Id)
        {

        }

    }
    public class DeleteBookingSpecific : BaseSpecification<Booking>
    {
        public DeleteBookingSpecific(int Id) : base(I => I.Id == Id)
        {

        }
    }
}
