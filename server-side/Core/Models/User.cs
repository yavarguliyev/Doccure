using Core.Enum;
using System;

namespace Core.Models
{
    public class User : BaseEntity
    {
        public string Code { get; set; }
        public string Photo { get; set; }
        public string Fullname { get; set; }
        public string Slug { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public UserRole Role { get; set; }
        public Gender Gender { get; set; }
        public DateTime Birth { get; set; }
        public string Token { get; set; }
        public string InviteToken { get; set; }
        public string ConfirmToken { get; set; }
        public string ConnectionId { get; set; }

        public int? AdminId { get; set; }
        public int? DoctorId { get; set; }
        public int? PatientId { get; set; }

        public Admin Admin { get; set; }
        public Doctor Doctor { get; set; }
        public Patient Patient { get; set; }
    }
}