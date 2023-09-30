using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Xml.Linq;
using AutoMapper;
using Incubation.BLL.Interfaces;
using Incubation.BLL.Services;
using Incubation.BLL.Specifications;
using Incubation.DAL.Constant;
using Incubation.DAL.Entities;
using Incubation.DAL.Entities.BookingAggregate;
using Incubation.DAL.Entities.Identity;
using Incubation_Project.DTO;
using Incubation_Project.Errors;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Incubation_Project.Controllers
{ 
    public class IncubatorController : BaseApiController
    {
        private readonly IGenericReposiyory<Incubator> _IncubatorRepo;
        private readonly IGenericReposiyory<Doctor> _doctorsRepo; 
        private readonly IGenericReposiyory<Bed> _bedsRepo;
        private readonly IGenericReposiyory<Booking> _bookingRepo;
        private readonly IGenericReposiyory<UserData> _userDataRepo;
        private readonly IGenericReposiyory<ChildData> _childRepo;
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;
        //private readonly POCclass bedServices;

        public IncubatorController(
            IGenericReposiyory<Incubator> IncubatorRepo,
            IGenericReposiyory<Doctor> doctorsRepo,
            IGenericReposiyory<Bed> bedsRepo,
            IGenericReposiyory<Booking> bookingRepo,
            IGenericReposiyory<UserData> userDataRepo,
            IGenericReposiyory<ChildData> childRepo,
            //POCclass bedServices,
            IMapper mapper,
            
            UserManager<AppUser> userManager)
        {
            _IncubatorRepo = IncubatorRepo;
            _doctorsRepo = doctorsRepo;
            _bedsRepo = bedsRepo;
            _bookingRepo = bookingRepo;
            _userDataRepo = userDataRepo;
            _childRepo = childRepo;
            _mapper = mapper;
            _userManager = userManager;
            //this.bedServices = bedServices;
        }
        [Authorize(Roles = Roles.User)]
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<IncubatorToReturnDTO>>> GetAllIncubator()
        {
            var spec = new IncubatorWithAdminAndDoctorSpecification();
            var incubator = await _IncubatorRepo.GetAllWithSpecAsync(spec);
            var incubatorDto = _mapper.Map<IReadOnlyList<Incubator>,
                IReadOnlyList<IncubatorToReturnDTO>>(incubator);

            if (incubatorDto == null) return NotFound(new ApiResponse(404));
            return Ok(incubatorDto);
        }

        [HttpGet("GetIncubator/{id}")]
        public async Task<ActionResult<IncubatorToReturnDTO>> GetIncubatorById(int id)
        {
            var spec = new IncubatorWithAdminAndDoctorSpecification(id);
            var incubator = await _IncubatorRepo.GetByIdWithSpecAsync(spec);
            var incubatorDto = _mapper.Map<Incubator, IncubatorToReturnDTO>(incubator);
            if (incubatorDto == null) return NotFound(new ApiResponse(404));
            //var incubator = await _IncubatorRepo.GetAllAsync();
            return Ok(incubatorDto);
        }



        
        [HttpGet("GetIncubatorByName")]
        public async Task<ActionResult<IReadOnlyList<IncubatorToReturnDTO>>> GetIncubatorByname(string name)
        {
            var spec = new GetIncubatorByName(name);
            var incubator = await _IncubatorRepo.GetAllWithSpecAsync(spec);
            var incubatorDto = _mapper.Map<IReadOnlyList<Incubator>,
                IReadOnlyList<IncubatorToReturnDTO>>(incubator);
            if (incubatorDto == null) return NotFound(new ApiResponse(404));
            //var incubator = await _IncubatorRepo.GetAllAsync();
            return Ok(incubatorDto);
        }



        [HttpGet("GetIncubatorByCity")]
        public async Task<ActionResult<IReadOnlyList<IncubatorToReturnDTO>>> GetIncubatorByCity(string city)
        {
            var spec = new IncubatorWithAdminAndDoctorSpecification(city);
            var incubator = await _IncubatorRepo.GetAllWithSpecAsync(spec);
            var incubatorDto = _mapper.Map<IReadOnlyList<Incubator>,
                IReadOnlyList<IncubatorToReturnDTO>>(incubator);
            if (incubatorDto == null) return NotFound(new ApiResponse(404));
            //var incubator = await _IncubatorRepo.GetAllAsync();
            return Ok(incubatorDto);
        }
        [HttpGet("doctors")]
        //[Authorize(Roles = Roles.Incubator)]
        public async Task<ActionResult<IReadOnlyList<DoctorToReturnDTO>>> GetDoctors()
        {
            var email = User.FindFirstValue(ClaimTypes.Email);
            var user = await _userManager.FindByEmailAsync(email);

            var spe = new DoctorSpecifications(user.Id);
            var doctors = await _doctorsRepo.GetAllWithSpecAsync(spe);

            return Ok(_mapper.Map<IReadOnlyList<DoctorToReturnDTO>>(doctors));
        }

        [HttpGet("beds")]
        //[Authorize(Roles = Roles.Incubator)]
        public async Task<ActionResult<IReadOnlyList<BedToReturnDTO>>> GetBeds()
        {
            var email = User.FindFirstValue(ClaimTypes.Email);
            var user = await _userManager.FindByEmailAsync(email);
            var spe = new BedSpecification(user.Id);
            var beds = await _bedsRepo.GetAllWithSpecAsync(spe);

           
            return Ok(_mapper.Map<IReadOnlyList<BedToReturnDTO>>(beds));
        }
        [HttpGet("Getbeds/{id}")]
        public async Task<ActionResult<BedToReturnDTO>> GetBedwithId(int id)
        {
            var spec = new BedSpecification(id);
            var bed = await _bedsRepo.GetAllWithSpecAsync(spec);
            var bedDto = _mapper.Map<IReadOnlyList<BedToReturnDTO>>(bed);
            if (bedDto == null) return NotFound(new ApiResponse(404));
            //var incubator = await _IncubatorRepo.GetAllAsync();
            return Ok(bedDto);
        }
        [HttpPost("AddDoctor")]
        //[Authorize(Roles = Roles.Incubator)]
        public async Task<ActionResult<GeneralResponseDto>> AddDoctor([FromBody] DoctorRequestDto requestDto)
        {
            var doctor = _mapper.Map<Doctor>(requestDto);
            await _doctorsRepo.Create(doctor);
            return Ok(new GeneralResponseDto
            {
                IsSuccess = true,
                Message = "Added Successfully."
            });
        }
        [HttpPost("AddBed")]
        //[Authorize(Roles = Roles.Incubator)]
        public async Task<ActionResult<GeneralResponseDto>> AddBed([FromBody] BedRequestDto requestDto)
        {
            
            var bed = _mapper.Map<Bed>(requestDto);
            await _bedsRepo.Create(bed);
            return Ok(new GeneralResponseDto
            {
                IsSuccess = true,
                Message = "Added Successfully."
            });
        }
        [HttpPost("AddChild")]
        public async Task<ActionResult<GeneralResponseDto>> AddChild([FromBody] ChildDTO childDTO)
        {
            var reservation = _mapper.Map<ChildData>(childDTO);
            await _childRepo.Create(reservation);
            return Ok(new GeneralResponseDto
            {
                IsSuccess = true,
                Message = "Booking Successfully"
            });
        }

        [HttpPost("CreateBooking")]
        public async Task<ActionResult<GeneralResponseDto>> CreateBooking([FromBody] BookingDTO bookingDTO,int Id)
        {

            var email = User.FindFirstValue(ClaimTypes.Email);
            var user = await _userManager.FindByEmailAsync(email);
            var spe = new ChildBookSpecification(Id);
            var bookings = await _childRepo.GetByIdWithSpecAsync(spe);

            var book1 = new Booking(email, bookings.ChildName,bookings.MotherName,bookings.TypeofIllness,bookings.PhoneNumber,
                bookings.PhoneNumberofDoctor,bookings.Age,bookings.PrescriptionUrl)
            { 
                IncubatorId=bookingDTO.IncubatorId,
                 bedid=bookingDTO.bedid,
                 UserDateId=bookingDTO.UserDateId,
                 childId=bookingDTO.ChildId,
            };

            Console.WriteLine(book1.ChildName);
            Console.WriteLine(book1.childId);

            var newbooking = _mapper.Map<Booking>(book1);
            await _bookingRepo.Create(newbooking);
            return Ok(new GeneralResponseDto
            {
                IsSuccess = true,
                Message = "Added Successfully."
            });
            

          

        }
        [HttpGet("GetBedData")]
        //[Authorize(Roles = Roles.Incubator)]
        public async Task<ActionResult<IReadOnlyList<BookingToReturnDTO>>> GetBedData(int id)
        {
            
            var spe = new BedDataSpecification(id);
            var booking = await _bookingRepo.GetAllWithSpecAsync(spe);

            return Ok(_mapper.Map<IReadOnlyList<BookingToReturnDTO>>(booking));
        }
        //[HttpPost("CreateBooking")]
        //public async Task<ActionResult<GeneralResponseDto>> CreateBooking([FromBody] BookingDTO bookingDTO)
        //{
        //    var reservation =_mapper.Map<Booking>(bookingDTO);
        //    await _bookingRepo.Create(reservation);
        //    return Ok(new GeneralResponseDto
        //    {
        //        IsSuccess = true,
        //        Message = "Booking Successfully"
        //    });
        //}
        [HttpGet("GetChildData")]
        //[Authorize(Roles = Roles.Incubator)]
        public async Task<ActionResult<IReadOnlyList<BookingToReturnDTO>>> GetChildData()
        {
            var email = User.FindFirstValue(ClaimTypes.Email);
            var user = await _userManager.FindByEmailAsync(email);
            var spe = new ChildDateSpecification(user.Id);
            var bookings = await _childRepo.GetAllWithSpecAsync(spe);

            //// var beds = await _bedsRepo.GetAllBedsWithSpecAsync(user.Id);

            //var beds = await bedServices.GetAllBedsWithSpecAsync(user.Id);
            return Ok(_mapper.Map<IReadOnlyList<BookingToReturnDTO>>(bookings));
        }
        [HttpGet("GetBooking")]
        //[Authorize(Roles = Roles.Incubator)]
        public async Task<ActionResult<IReadOnlyList<BookingToReturnDTO>>> GetBooking()
        {
            var email = User.FindFirstValue(ClaimTypes.Email);
            var user = await _userManager.FindByEmailAsync(email);
            var spe = new BookingSpecification(user.Id);
            var bookings = await _bookingRepo.GetAllWithSpecAsync(spe);

            //// var beds = await _bedsRepo.GetAllBedsWithSpecAsync(user.Id);

            //var beds = await bedServices.GetAllBedsWithSpecAsync(user.Id);
            return Ok(_mapper.Map<IReadOnlyList<BookingToReturnDTO>>(bookings));
        }
        [HttpGet("GetBookingofUser")]
        //[Authorize(Roles = Roles.Incubator)]
        public async Task<ActionResult<IReadOnlyList<BookingToReturnDTO>>> GetBookingofUser()
        {
            var email = User.FindFirstValue(ClaimTypes.Email);
            var user = await _userManager.FindByEmailAsync(email);
            var spe = new BookUserSpecifition(user.Id);
            var bookings = await _bookingRepo.GetAllWithSpecAsync(spe);


            return Ok(_mapper.Map<IReadOnlyList<BookingToReturnDTO>>(bookings));
        }
        [HttpDelete("DeleteBed")]
        public async Task<ActionResult<GeneralResponseDto>> DeleteBed(int id)
        {
            var reservation = new DeletebedSpecific(id);
            var bed = await _bedsRepo.GetByIdWithSpecAsync(reservation);
            await _bedsRepo.Delete(bed);
            return Ok(new GeneralResponseDto
            {
                IsSuccess = true,
                Message = "Delete Successfully"
            });
        }
        [HttpDelete("DeleteDoctor")]
        public async Task<ActionResult<GeneralResponseDto>> DeleteDoctor(int id)
        {
            var reservation = new DeleteDoctorSpecific(id);
            var doctor = await _doctorsRepo.GetByIdWithSpecAsync(reservation);
            await _doctorsRepo.Delete(doctor);
            return Ok(new GeneralResponseDto
            {
                IsSuccess = true,
                Message = "Delete Successfully"
            });
        }
        [HttpDelete("DeleteBooking")]
        public async Task<ActionResult<GeneralResponseDto>> DeleteBooking(int id)
        {
            var reservation = new DeleteBookingSpecific(id);
            var booking = await _bookingRepo.GetByIdWithSpecAsync(reservation);
            await _bookingRepo.Delete(booking);
            return Ok(new GeneralResponseDto
            {
                IsSuccess = true,
                Message = "Delete Successfully"
            });
        }
        [HttpPut("UpdateBed")]
        public async Task<ActionResult<GeneralResponseDto>> UpdateBed([FromBody] BedRequestDto requestDto, int id)
        {
            var item = new DeletebedSpecific(id);
            var bed = await _bedsRepo.GetByIdWithSpecAsync(item);
            if(bed != null)
            {
                bed.TypeofBed = requestDto.TypeofBed;
                bed.Condition = requestDto.Condition;
                bed.CostPerDay = requestDto.CostPerDay;

                await _bedsRepo.Update( bed);


                return Ok(new GeneralResponseDto
                {
                    IsSuccess = true,
                    Message = "Delete Successfully"
                });
            }
            else
            {
                return NotFound(new ApiResponse(404));
            }
        }
        [HttpPut("UpdateDoctor")]
        public async Task<ActionResult<GeneralResponseDto>> UpdateDoctor([FromBody] DoctorRequestDto requestDto, int id)
        {
            var item = new DeleteDoctorSpecific(id);
            var doctor = await _doctorsRepo.GetByIdWithSpecAsync(item);
            if (doctor != null)
            {
                doctor.Name=requestDto.Name;
                doctor.PhoneNumber = requestDto.PhoneNumber;
                doctor.Specialization = requestDto.Specialization;

                await _doctorsRepo.Update(doctor);


                return Ok(new GeneralResponseDto
                {
                    IsSuccess = true,
                    Message = "Delete Successfully"
                });
            }
            else
            {
                return NotFound(new ApiResponse(404));
            }
        }
        [HttpPut("UpdateIncubator")]
        public async Task<ActionResult<GeneralResponseDto>> UpdateIncubator([FromBody] UpdateIncubatorDTO requestDto,int id)
        {
            var email = User.FindFirstValue(ClaimTypes.Email);
            var user = await _userManager.FindByEmailAsync(email);
            var spec = new IncubatorWithAdminAndDoctorSpecification(id);
            var incubator = await _IncubatorRepo.GetByIdWithSpecAsync(spec);
            if (user == null)
            {
                return NotFound(new ApiResponse(404));

            }
            else
            {
                user.Email = requestDto.Email;
                user.DisplayName=requestDto.DisplayName;
                user.UserName = requestDto.DisplayName;
                user.NormalizedUserName=requestDto.DisplayName.ToUpper();
                user.PhoneNumber = requestDto.PhoneNumber;
                user.NormalizedEmail=requestDto.Email.ToUpper();
                
            }
            if (incubator != null)
            {
                incubator.Name = requestDto.DisplayName;
                incubator.PhoneNumber = requestDto.PhoneNumber;
                incubator.City = requestDto.City;
                incubator.Gevernorate=requestDto.Gevernorate;

                await _IncubatorRepo.Update(incubator);


                return Ok(new GeneralResponseDto
                {
                    IsSuccess = true,
                    Message = "Delete Successfully"
                });

            }
            else
            {
                return NotFound(new ApiResponse(404));
            }

        }
        [HttpPut("UpdateUserDate")]
        public async Task<ActionResult<GeneralResponseDto>> UpdateUserDate([FromBody] UpdateuserDto requestDto, int id)
        {
            var email = User.FindFirstValue(ClaimTypes.Email);
            var user = await _userManager.FindByEmailAsync(email);
            var spec = new UserDateSpecification(id);
            var userdate = await _userDataRepo.GetByIdWithSpecAsync(spec);
            if (user == null)
            {
                return NotFound(new ApiResponse(404));

            }
            else
            {
                user.Email = requestDto.Email;
                user.DisplayName = requestDto.DisplayName;
                user.UserName = requestDto.DisplayName;
                user.NormalizedUserName = requestDto.DisplayName.ToUpper();
                user.PhoneNumber = requestDto.PhoneNumber;
                user.NormalizedEmail = requestDto.Email.ToUpper();

            }
            if (userdate != null)
            {
                userdate.Name = requestDto.DisplayName;
                userdate.PhoneNumber = requestDto.PhoneNumber;
                userdate.City = requestDto.City;

                await _userDataRepo.Update(userdate);


                return Ok(new GeneralResponseDto
                {
                    IsSuccess = true,
                    Message = "Delete Successfully"
                });

            }
            else
            {
                return NotFound(new ApiResponse(404));
            }

        }
    }
}
