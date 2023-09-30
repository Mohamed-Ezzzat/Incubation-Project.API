using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace Incubation_Project.Extensions
{
    public static class SwaggerServicesExtension
    {
            public static IServiceCollection AddSwaggerDocumentation(this IServiceCollection services)
            {
                services.AddSwaggerGen(c =>
                {
                    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Incubation_Project.API", Version = "v1" });

                    var securitySchema = new OpenApiSecurityScheme
                    {
                        Description = "JWT Auth Bearer Scheme",
                        Name = "Authorization",
                        In = ParameterLocation.Header,
                        Type = SecuritySchemeType.Http,
                        Scheme = "Bearer",
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    };

                    c.AddSecurityDefinition("Bearer", securitySchema);
                    var securityRequirement = new OpenApiSecurityRequirement { { securitySchema, new[] { "Bearer" } } };
                    c.AddSecurityRequirement(securityRequirement);
                });
                return services;
            }
            public static IApplicationBuilder UseSwaggerDocumentation(this IApplicationBuilder app)
            {
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Incubation_Project v1"));
                return app;
            }
    }
    
}
