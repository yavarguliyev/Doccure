using Core.Enum;
using System;

namespace Api.DTOs.Auth
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string Photo { get; set; }
        public string Fullname { get; set; }
        public string Slug { get; set; }
        public string Email { get; set; }
        public string Birth { get; set; }
        public string Token { get; set; }
        public UserRole Role { get; set; }

        public Nullable<int> AdminId { get; set; }
        public Nullable<int> DoctorId { get; set; }
        public Nullable<int> PatientId { get; set; }
    }
}