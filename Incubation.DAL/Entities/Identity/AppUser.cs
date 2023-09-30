using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Incubation.DAL.Entities.Identity
{
    public class AppUser :IdentityUser
    {
        public string DisplayName { get; set; }
        public virtual UserData? UserData { get; set; }
        //public int UserDataId { get; set; }
        public virtual Incubator? Incubator { get; set; }
        //public int IncubatorId { get; set; }
    }
}
