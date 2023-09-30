using AutoMapper;
using Incubation.BLL.Interfaces;
using Incubation.DAL.Entities;
using Incubation.DAL.Entities.BookingAggregate;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Incubation_Project.Controllers
{
    public class BookingController : BaseApiController
    {
        private readonly IGenericReposiyory<Incubator> _incubatorRepo;
        private readonly IGenericReposiyory<Booking> _bookingRepo;
        private readonly IMapper _mapper;

        public BookingController(IGenericReposiyory<Incubator> IncubatorRepo,
            IGenericReposiyory<Booking> bookingRepo,
            //IBookingServises<Booking> bookingServises,
            IMapper mapper)
        {
            _incubatorRepo = IncubatorRepo;
            _bookingRepo = bookingRepo;
            _mapper = mapper;
        }
    }
}
