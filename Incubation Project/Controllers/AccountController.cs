using System;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using Incubation.BLL.Interfaces;
using Incubation.BLL.Services;
using Incubation.DAL.Constant;
using Incubation.DAL.Data;
using Incubation.DAL.Entities;
using Incubation.DAL.Entities.Identity;
using Incubation_Project.DTO;
using Incubation_Project.Errors;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace Incubation_Project.Controllers
{

    public class AccountController : BaseApiController
    {
        
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ITokenService _tokenService;
        private readonly IGenericReposiyory<UserData> _userDataRepo;
        private readonly IncubationContext _context;
        private readonly IGenericReposiyory<Incubator> _incubatorRepo;

        public AccountController(UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager,
            ITokenService tokenService,
            IGenericReposiyory<UserData> userDataRepo,
            IncubationContext context,
            IGenericReposiyory<Incubator> IncubatorRepo)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
            _userDataRepo = userDataRepo;
            _context = context;
            _incubatorRepo = IncubatorRepo;
        }
        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
        {
            
            var user = await _userManager.FindByEmailAsync(loginDto.Email);
            if (User == null) return Unauthorized(new ApiResponse(401));
            var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);
            if (!result.Succeeded) return Unauthorized(new ApiResponse(401));
            var userData = await _context.userDatas.FirstOrDefaultAsync(u => u.UserId == user.Id);
            var incubator = await _context.incubators.FirstOrDefaultAsync(i => i.UserId == user.Id);

            var roleName = _userManager.GetRolesAsync(user).Result.FirstOrDefault();
            Console.WriteLine(roleName);
            if (roleName == "User")
            {

                return Ok(new UserDto()
                {
                    Id = userData.Id,
                    DisplayName = user.DisplayName,
                    Email = user.Email,
                    City = userData.City,
                    RoleName = _userManager.GetRolesAsync(user).Result.FirstOrDefault(),
                    Token = await _tokenService.CreataToken(user, _userManager),
                });
            }
            else
            {
                return Ok(new UserDto()
                {
                    Id = incubator.Id,
                    DisplayName = user.DisplayName,
                    Email = user.Email,
                    City = incubator.City,
                    Gevernorate = incubator.Gevernorate,
                    RoleName = _userManager.GetRolesAsync(user).Result.FirstOrDefault(),
                    Token = await _tokenService.CreataToken(user, _userManager),
                });
            }
           

        }

        [HttpPost("registerUser")]
        public async Task<ActionResult<UserDto>> RegisterUser(RegisterDto registerDto)
        {

            var user = new AppUser()
            {
                DisplayName = registerDto.DisplayName,
                Email = registerDto.Email,
                UserName = registerDto.Email.Split('@')[0],
                UserData = new UserData()
                { 

                    PhoneNumber=registerDto.PhoneNumber,
                    Name=registerDto.DisplayName,
                    City=registerDto.City,

                },
            };
            var result = await _userManager.CreateAsync(user, registerDto.Password);
            if (!result.Succeeded) return BadRequest(new ApiResponse(400));

            await _userManager.AddToRoleAsync(user, Roles.User);
            return Ok(new UserDto()
            {



                Id = user.UserData.Id,
                DisplayName = user.DisplayName,
                Email = user.Email,
                City= user.UserData.City,
                RoleName = Roles.User,
                Token = await _tokenService.CreataToken(user, _userManager)



            });

        }
        [HttpPost("registerIncubator")]
        public async Task<ActionResult<UserDto>> RegisterInc(RegisterDto registerDto)
        {

            var user = new AppUser()
            {
                DisplayName = registerDto.DisplayName,
                Email = registerDto.Email,
                UserName = registerDto.Email.Split("@")[0],
                Incubator = new Incubator()
                {
                    PhoneNumber = registerDto.PhoneNumber,
                    Name = registerDto.DisplayName,
                    City = registerDto.City,
                    Gevernorate=registerDto.Gevernorate,
                },


            };

            var result = await _userManager.CreateAsync(user, registerDto.Password);
            if (!result.Succeeded) return BadRequest(new ApiResponse(400));

            await _userManager.AddToRoleAsync(user, Roles.Incubator);
            return Ok(new UserDto()
            {
                Id = user.Incubator.Id,
                DisplayName = user.DisplayName,
                Email = user.Email,
                City = user.Incubator.City,
                Gevernorate=user.Incubator.Gevernorate,
                RoleName = Roles.Incubator,
                Token = await _tokenService.CreataToken(user, _userManager)
            });

        }
        [Authorize(Roles = Roles.User)]
        [HttpGet("GetCurrentUser")]
        public async Task<ActionResult<UserDto>> GetCurrentUser()
        {
            var email = User.FindFirstValue(ClaimTypes.Email);
            var user = await _userManager.FindByEmailAsync(email);
            return Ok(new UserDto()
            {

                Email = user.Email,
                DisplayName = user.DisplayName,
                Token = await _tokenService.CreataToken(user, _userManager)
            });
        }


    }
}
