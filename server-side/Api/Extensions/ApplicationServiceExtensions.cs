using Api.Libs;
using AutoMapper;
using Core;
using Core.Services.Data;
using Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Services.Data;
using System;
using System.Text.Json.Serialization;

namespace Api.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            // controllers without view
            services.AddControllers()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                });

            // Api versioning
            services.AddApiVersioning(v =>
            {
                // shows that api accept any versions
                v.ReportApiVersions = true;

                // if there is available version show the default version
                v.AssumeDefaultVersionWhenUnspecified = true;

                // default version 1.0
                v.DefaultApiVersion = new ApiVersion(1, 0);
            });

            // api cors for allowing methods that coming from different localhosts
            services.AddCors();

            // routing to lowercase
            services.AddRouting(options => options.LowercaseUrls = true);// controllers without view

            // swagger documentation for api
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Api"
                });
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
                        },
                        Array.Empty<string>()
                    }
                });
            });

            // database connection

            services.AddDbContext<DataContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"),
                x => x.MigrationsAssembly("Data")));

            services.AddScoped<DbContext>(provider => provider.GetService<DataContext>());

            // auto mapper profiles
            services.AddAutoMapper(typeof(Startup));

            // unit of Work
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            // services
            services.AddTransient<IAdminService, AdminService>();
            services.AddTransient<IDoctorService, DoctorService>();
            services.AddTransient<IPatientService, PatientService>();
            services.AddTransient<IUserService, UserService>();

            // http Accessor
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            // api auth
            services.AddTransient<IAuth, Auth>();

            return services;
        }
    }
}