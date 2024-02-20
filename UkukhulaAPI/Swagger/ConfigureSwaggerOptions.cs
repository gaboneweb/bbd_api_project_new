using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace UkukhulaAPI.Swagger{

    public class ConfigureSwaggerOptions : IConfigureOptions<SwaggerGenOptions>{
        public void Configure(SwaggerGenOptions swaggerGenOptions){
            swaggerGenOptions.AddSecurityDefinition("Bearer",new OpenApiSecurityScheme
            {
                In = ParameterLocation.Header,
                Description = "Please provider a valid token",
                Name = "Authorization",
                Type= SecuritySchemeType.Http,
                BearerFormat = "JWT",
                Scheme = "Bearer"
            });

            swaggerGenOptions.AddSecurityRequirement(new OpenApiSecurityRequirement{
                {
                    new OpenApiSecurityScheme{
                        Reference = new OpenApiReference{
                            Type = ReferenceType.SecurityScheme,
                            Id ="Bearer"
                        }

                    },
                    Array.Empty<string>()

                }
            });
        }
    }
}