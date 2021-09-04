using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace Api.Extensions {
  public static class SwaggerServiceExtensions {
    public static IServiceCollection AddSwaggerDocumentation (this IServiceCollection services) {
      // swagger documentation for api
      services.AddSwaggerGen (options => {
        options.SwaggerDoc ("v1", new OpenApiInfo { Version = "v1", Title = "Api" });

        options.AddSecurityDefinition ("Bearer", new OpenApiSecurityScheme {
          Description = "JWT Authorization header using the Bearer scheme (Example: Authorization: 'Bearer {token}')",
            Name = "Authorization",
            In = ParameterLocation.Header,
            // In = OpenApiSecurityApiKeyLocation.Header,
            Type = SecuritySchemeType.ApiKey,
            // Type = Type = OpenApiSecuritySchemeType.ApiKey,
            Scheme = "Bearer",
            // Contact = new OpenApiContact { Name = "Yavar Guliyev" },
            // License = new OpenApiLicense { Name = "MIT", Url = new Uri ("https://en.wikipedia.org/wiki/MIT_License") }
        });

        options.AddSecurityRequirement (new OpenApiSecurityRequirement {
          {
            new OpenApiSecurityScheme {
              Reference = new OpenApiReference {
                Type = ReferenceType.SecurityScheme,
                  Id = "Bearer"
              }
            }, Array.Empty<string> ()
          }
        });

        // options.OperationProcessors.Add (new AspNetCoreOperationSecurityScopeProcessor ("JWT"))
      });

      return services;
    }

    public static IApplicationBuilder UseSwaggerDocumentation (this IApplicationBuilder app) {
      app.UseSwagger ();
      app.UseSwaggerUI (s => {
        s.DocumentTitle = "Swagger Documentation";
        s.SwaggerEndpoint ("/swagger/v1/swagger.json", "api/v1");
        s.DocExpansion (DocExpansion.None);
      });

      return app;
    }
  }
}