using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Incubation.BLL.Interfaces;
using Incubation.BLL.Specifications;
using Incubation.DAL.Entities;
using Incubation_Project.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Incubation_Project.Controllers
{
    
    public class DoctorController :BaseApiController
    {
        private readonly IGenericReposiyory<Doctor> _doctorsRepo;
        private readonly IGenericReposiyory<Incubator> _incubatorRepo;
        private readonly IMapper _mapper;

        public DoctorController(IGenericReposiyory<Doctor> doctorsRepo,
            IGenericReposiyory<Incubator> incubatorRepo,
            IMapper mapper)
        {
            _doctorsRepo = doctorsRepo;
            _incubatorRepo = incubatorRepo;
            _mapper = mapper;
        }
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IReadOnlyList<DoctorToReturnDTO>>> GetAllDoctors()
        {
            var spec = new DoctorWithIncubatorSpecification();
            var doctor = await _doctorsRepo.GetAllWithSpecAsync(spec);
            var doctorDto = _mapper.Map<IReadOnlyList<Doctor>, IReadOnlyList<DoctorToReturnDTO>>(doctor);
            if (doctorDto == null) return NotFound(404);

            //var incubator = await _IncubatorRepo.GetAllAsync();
            return Ok(doctorDto);
        }
        //[HttpPost]
        //public async Task<ActionResult<Doctor>> PostDoctor([FromBody]DoctorToReturnDTO doctor)
        //{
        //    if (doctor == null)
        //        return BadRequest();
        //    int newId = doctor.Id + 1;
        //    Doctor doctor1 = new Doctor
        //    {
        //        Id = newId,
        //        Name = doctor.Name,
        //        PhoneNumber = doctor.PhoneNumber,
        //        Specialization = doctor.Specialization,
        //    };
            

        //}





    }
}
