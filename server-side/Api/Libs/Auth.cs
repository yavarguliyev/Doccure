using Core.Enum;
using Core.Models;
using Core.Services.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;

namespace Api.Libs
{
    public interface IAuth
    {
        public User Admin { get; }
        public User Doctor { get; }
        public User Patient { get; }
    }

    public class Auth : IAuth
    {
        private readonly IHttpContextAccessor _accessor;
        private readonly IUserService _userService;

        public Auth(IHttpContextAccessor accessor, IUserService userService)
        {
            _accessor = accessor;
            _userService = userService;
        }

        public User Admin
        {
            get
            {
                bool hasHeader = _accessor.HttpContext.Request.Headers.TryGetValue("Authorization", out StringValues header);
                if (!hasHeader)
                {
                    return null;
                }

                string encoded = header;
                if (encoded != null && encoded.StartsWith("Bearer "))
                {
                    string token = encoded.Substring("Bearer ".Length).Trim();

                    User admin = _userService.GetByTokenAsync(token.ToString()).Result;
                    if (admin != null && admin.Role == UserRole.Admin)
                    {
                        return admin;
                    }
                }

                return null;
            }
        }

        public User Doctor
        {
            get
            {
                bool hasHeader = _accessor.HttpContext.Request.Headers.TryGetValue("Authorization", out StringValues header);
                if (!hasHeader)
                {
                    return null;
                }

                string encoded = header;
                if (encoded != null && encoded.StartsWith("Bearer "))
                {
                    string token = encoded.Substring("Bearer ".Length).Trim();

                    User doctor = _userService.GetByTokenAsync(token.ToString()).Result;
                    if (doctor != null && doctor.Role == UserRole.Doctor)
                    {
                        return doctor;
                    }
                }

                return null;
            }
        }

        public User Patient
        {
            get
            {
                bool hasHeader = _accessor.HttpContext.Request.Headers.TryGetValue("Authorization", out StringValues header);
                if (!hasHeader)
                {
                    return null;
                }

                string encoded = header;
                if (encoded != null && encoded.StartsWith("Bearer "))
                {
                    string token = encoded.Substring("Bearer ".Length).Trim();

                    User patient = _userService.GetByTokenAsync(token.ToString()).Result;
                    if (patient != null && patient.Role == UserRole.Patient)
                    {
                        return patient;
                    }
                }

                return null;
            }
        }
    }
}