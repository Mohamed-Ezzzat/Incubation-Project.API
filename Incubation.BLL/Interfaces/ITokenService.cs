using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Incubation.DAL.Entities;
using Incubation.DAL.Entities.Identity;
using Microsoft.AspNetCore.Identity;

namespace Incubation.BLL.Interfaces
{
    public interface ITokenService
    {
        Task<string> CreataToken(AppUser user, UserManager<AppUser> userManager);
    }
}
