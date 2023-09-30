using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Incubation.DAL.Constant;
using Incubation.DAL.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Incubation.DAL.IdentityDb
{
    public class IncubatorDbSeed
    {
        public static async Task SeedRoles(RoleManager<IdentityRole> roleManager)
        {
            if (!await roleManager.Roles.AnyAsync())
            {
                await roleManager.CreateAsync(new IdentityRole { Id = Guid.NewGuid().ToString(), Name = Roles.Incubator, NormalizedName = Roles.Incubator.ToUpper(), ConcurrencyStamp = Guid.NewGuid().ToString() });
                await roleManager.CreateAsync(new IdentityRole { Id = Guid.NewGuid().ToString(), Name = Roles.User, NormalizedName = Roles.User.ToUpper(), ConcurrencyStamp = Guid.NewGuid().ToString() });
            }
        }
        public static async Task SeedUsersAsync(UserManager<AppUser> userManager)
        {
            if (!userManager.Users.Any())
            {
                var user = new AppUser()
                {
                    DisplayName = "Mohamed Ezzat",
                    UserName = "mohamedezzat22",
                    Email = "mohamedezzat22@gmail.com",
                    Incubator = new Entities.Incubator()
                    {
                        Name = "Mohamed Ezzat",
                        PhoneNumber = "01225385213",
                        City = "Menufia"
                    },
                    UserData = null,
                };

                var result = await userManager.CreateAsync(user, "123456");
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, Roles.Incubator);
                }



                var user1 = new AppUser()
                {
                    DisplayName = "mohammed Khaled",
                    UserName = "mohammed22",
                    Email = "mohamed22@gmail.com",
                    UserData = new Entities.UserData()
                    {
                        Name = "Mohammed Khaled",
                        PhoneNumber = "01225385213",
                        City = "Menufia"
                    },
                    Incubator = null
                };
                var result2 = await userManager.CreateAsync(user1, "123456");
                if (result2.Succeeded)
                {
                    await userManager.AddToRoleAsync(user1, Roles.User);
                }
            }
        }
    }
}
