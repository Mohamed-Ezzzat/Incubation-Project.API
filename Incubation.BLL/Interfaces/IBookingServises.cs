using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Incubation.DAL.Entities.BookingAggregate;

namespace Incubation.BLL.Interfaces
{
    public interface IBookingServises
    {
        Task<Booking> CreateBookingAsync(string BookerEmail, ChildData childData);

        Task<IReadOnlyList<Booking>> GetBookingAsync(string BookerEmail);

    }
}
