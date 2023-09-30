using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Incubation.DAL.Data;
using Incubation.DAL.Entities.Identity;
using Incubation.DAL.IdentityDb;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Incubation_Project
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            using var scope = host.Services.CreateScope();

            var services = scope.ServiceProvider;

            var loggerFactory = services.GetRequiredService<ILoggerFactory>();
            try
            {
                
                var context = services.GetRequiredService<IncubationContext>();
                await context.Database.MigrateAsync();

                //var identityContext = services.GetRequiredService<AppIdentityDbContext>();
                //await identityContext.Database.MigrateAsync();
                var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
                await IncubatorDbSeed.SeedRoles(roleManager);

                var userManager = services.GetRequiredService<UserManager<AppUser>>();
                await IncubatorDbSeed.SeedUsersAsync(userManager);

            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<Program>();
                logger.LogError(ex, "an error occured during applying migration");

            }
            host.Run();

        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
