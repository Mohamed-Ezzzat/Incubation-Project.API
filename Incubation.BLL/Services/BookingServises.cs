using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Incubation.BLL.Interfaces;
using Incubation.DAL.Data;
using Incubation.DAL.Entities.BookingAggregate;

namespace Incubation.BLL.Services
{
    public class BookingServises : IBookingServises
    {
        private readonly IncubationContext _context;

        public BookingServises(IncubationContext context)
        {
            _context = context;
        }
        public Task<Booking> CreateBookingAsync(string BookerEmail, ChildData childData)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<Booking>> GetBookingAsync(string BookerEmail)
        {
            throw new NotImplementedException();
        }
    }
}
