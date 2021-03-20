using Api.Libs;
using Core;
using Core.DTOs.Admin.Admin_Doctor;
using Core.DTOs.Auth;
using Core.DTOs.Doctor;
using Core.Services.Common;
using Core.Services.Data;
using Core.Services.Rest;
using Data;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Services.Common;
using Services.Data;
using Services.Mappings;
using Services.Rest;
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
                    .AddFluentValidation(options => 
                    {
                        options.RegisterValidatorsFromAssemblyContaining<LoginDTO>();
                        options.RegisterValidatorsFromAssemblyContaining<RegisterDTO>();
                        options.RegisterValidatorsFromAssemblyContaining<ForgetPasswordDTO>();
                        options.RegisterValidatorsFromAssemblyContaining<ResetPasswordDTO>();
                        options.RegisterValidatorsFromAssemblyContaining<AuthPasswordUpdateDTO>();
                        options.RegisterValidatorsFromAssemblyContaining<AdminCreateDoctorDTO>();
                        options.RegisterValidatorsFromAssemblyContaining<NewDoctorModifyDTO>();
                        options.RegisterValidatorsFromAssemblyContaining<UserProfileUpdateDTO>();
                    })
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
            services.AddRouting(options => options.LowercaseUrls = true);

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
            services.AddAutoMapper(typeof(MappingProfiles).Assembly);

            // unit of Work
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            // services
            services.AddTransient<IAdminService, AdminService>();
            services.AddTransient<IDoctorService, DoctorService>();
            services.AddTransient<IPatientService, PatientService>();
            services.AddTransient<IUserService, UserService>();

            services.AddTransient<IDoctorSocialMediaUrlLinkService, DoctorSocialMediaUrlLinkService>();
            services.AddTransient<IPrivacyService, PrivacyService>();
            services.AddTransient<ISettingPhotoService, SettingPhotoService>();
            services.AddTransient<ISettingService, SettingService>();
            services.AddTransient<ISocialMediaService, SocialMediaService>();
            services.AddTransient<ITermService, TermService>();

            // file upload
            services.AddSingleton<IFileManager, FileManager>();

            // activity services
            services.AddTransient<IActivityService, ActivityService>();

            // send email
            services.AddTransient<IEmailService, EmailService>();

            // http Accessor
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            // api auth
            services.AddTransient<IAuth, Auth>();

            return services;
        }
    }
}