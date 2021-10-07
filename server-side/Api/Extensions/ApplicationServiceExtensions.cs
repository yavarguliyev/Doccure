using System;
using System.Text.Json.Serialization;
using Api.Libs;
using Core;
using Core.DTOs.Admin.Admin_Doctor;
using Core.DTOs.Auth;
using Core.DTOs.Doctor;
using Core.DTOs.Main;
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
using Services.Common;
using Services.Data;
using Services.Mappings;
using Services.Rest;

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
                    options.RegisterValidatorsFromAssemblyContaining<CreateChatMessageDTO>();
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
            services.AddCors(opt =>
            {
                opt.AddPolicy("CorsPolicy", policy =>
                {
                    policy
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials()
                        .WithOrigins("http://localhost:4200", "https://localhost:4200");
                });
            });

            // routing to lowercase
            services.AddRouting(options => options.LowercaseUrls = true);

            // swagger documentation for api
            services.AddSwaggerDocumentation();

            // database connection

            services.AddDbContext<DataContext>(options =>
            {
                var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

                string connStr;

                // Depending on if in development or production, use either Heroku-provided
                // connection string, or development connection string from env var.
                if (env == "Development")
                {
                    // Use connection string from file.
                    connStr = configuration.GetConnectionString("DefaultConnection");
                    Console.WriteLine(connStr);
                }
                else
                {
                    // Use connection string provided at runtime by Heroku.
                    var connUrl = Environment.GetEnvironmentVariable("DATABASE_URL");

                    // Parse connection URL to connection string for Npgsql
                    connUrl = connUrl.Replace("postgres://", string.Empty);
                    var pgUserPass = connUrl.Split("@")[0];
                    var pgHostPortDb = connUrl.Split("@")[1];
                    var pgHostPort = pgHostPortDb.Split("/")[0];
                    var pgDb = pgHostPortDb.Split("/")[1];
                    var pgUser = pgUserPass.Split(":")[0];
                    var pgPass = pgUserPass.Split(":")[1];
                    var pgHost = pgHostPort.Split(":")[0];
                    var pgPort = pgHostPort.Split(":")[1];

                    connStr = $"Server={pgHost};Port={pgPort};User Id={pgUser};Password={pgPass};Database={pgDb}; SSL Mode=Require; Trust Server Certificate=true";
                }

                // Whether the connection string came from the local development configuration file
                // or from the environment variable from Heroku, use it to set up your DbContext.
                options.UseNpgsql(connStr);
            });

            // auto mapper profiles
            services.AddAutoMapper(typeof(MappingProfiles).Assembly);

            // unit of Work
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            // services
            services.AddTransient<IAdminService, AdminService>();
            services.AddTransient<IChatService, ChatService>();
            services.AddTransient<IChatMessageService, ChatMessageService>();
            services.AddTransient<ICommentService, CommentService>();
            services.AddTransient<ICommentReplyService, CommentReplyService>();
            services.AddTransient<IDoctorService, DoctorService>();
            services.AddTransient<IPatientService, PatientService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IReviewService, ReviewService>();
            services.AddTransient<IReviewReplyService, ReviewReplyService>();

            services.AddTransient<IBlogService, BlogService>();
            services.AddTransient<IDoctorSocialMediaUrlLinkService, DoctorSocialMediaUrlLinkService>();

            services.AddTransient<IFeatureService, FeatureService>();
            services.AddTransient<ISpecialityService, SpecialityService>();
            services.AddTransient<IPrivacyService, PrivacyService>();
            services.AddTransient<ISettingPhotoService, SettingPhotoService>();
            services.AddTransient<ISettingService, SettingService>();
            services.AddTransient<ISocialMediaService, SocialMediaService>();
            services.AddTransient<ITermService, TermService>();

            // signalR
            services.AddSignalR().AddJsonProtocol(options =>
            {
                options.PayloadSerializerOptions.Converters.Add(new JsonStringEnumConverter());
            });

            // file upload
            services.AddTransient<ICloudinaryService, CloudinaryService>();

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