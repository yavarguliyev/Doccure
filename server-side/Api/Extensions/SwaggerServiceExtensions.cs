using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerUI;
using System;
using System.Collections.Generic;

namespace Api.Extensions
{
  public static class SwaggerServiceExtensions
  {
    public static IServiceCollection AddSwaggerDocumentation(this IServiceCollection services)
    {
      // swagger documentation for api
      services.AddSwaggerGen(options =>
      {
        options.SwaggerDoc("v1", new OpenApiInfo { Version = "v1", Title = "Api" });

        var security = new Dictionary<string, IEnumerable<string>>
          {
                    {"Bearer", new string[] { }},
          };

        options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        {
          Description = "JWT Authorization header using the Bearer scheme (Example: Authorization: 'Bearer {token}')",
          Name = "Authorization",
          In = ParameterLocation.Header,
          Type = SecuritySchemeType.ApiKey,
          Scheme = "Bearer"
        });

        options.AddSecurityRequirement(new OpenApiSecurityRequirement
          {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        }, Array.Empty<string>()
                    }
          });
      });

      return services;
    }

    public static IApplicationBuilder UseSwaggerDocumentation(this IApplicationBuilder app)
    {
      app.UseSwagger();
      app.UseSwaggerUI(s =>
      {
        s.RoutePrefix = "/swagger";
        s.DocumentTitle = "Swagger Documentation";
        s.SwaggerEndpoint("/swagger/v1/swagger.json", "api/v1");
        s.DocExpansion(DocExpansion.None);
      });

      return app;
    }
  }
}