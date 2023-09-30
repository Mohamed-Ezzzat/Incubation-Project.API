using AutoMapper;
using Incubation.DAL.Entities;
using Incubation.DAL.Entities.BookingAggregate;
using Incubation_Project.DTO;

namespace Incubation_Project.Helpers
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<Incubator, IncubatorToReturnDTO>();
                //.ForMember(d => d.Admins, O => O.MapFrom(S => S.Admins.Name));
                //.ForMember(d=>d.IncubatorDoctors, O=>O.MapFrom(S=>S.IncubatorDoctors.ToString()))
                
            CreateMap<Doctor, DoctorToReturnDTO>();
            CreateMap<Bed, BedToReturnDTO>();
            CreateMap<DoctorRequestDto, Doctor>();
            CreateMap<BedRequestDto, Bed>();
            CreateMap<BookingDTO, Booking>();

            CreateMap<ChildDTO, ChildData>();

            CreateMap<Booking, BookingToReturnDTO>();
            CreateMap<ChildData, BookingToReturnDTO>();
        }
    }
}
