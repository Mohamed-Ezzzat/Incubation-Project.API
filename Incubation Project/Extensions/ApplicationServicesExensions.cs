using System.Linq;
using Incubation.BLL.Interfaces;
using Incubation.BLL.Repositories;
using Incubation.BLL.Services;
using Incubation_Project.Errors;
using Incubation_Project.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace Incubation_Project.Extensions
{
    public static class ApplicationServicesExensions
    {
        public static IServiceCollection AddApplicationServices (this IServiceCollection services)
        {

            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped(typeof(IGenericReposiyory<>), typeof(GenericReposiyory<>));//Allow Dependency Injection
            services.AddAutoMapper(typeof(MappingProfiles));
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = actionContext =>
                {
                    var errors = actionContext.ModelState.Where(M => M.Value.Errors.Count > 0)
                                                        .SelectMany(M => M.Value.Errors)
                                                        .Select(E => E.ErrorMessage).ToArray();

                    var responseMessage = new ApiValidationErrorReponse()
                    {
                        Errors = errors
                    };
                    return new BadRequestObjectResult(responseMessage);
                };
            });

            return services;
        }
    }
}
