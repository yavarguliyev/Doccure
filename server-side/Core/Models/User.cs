using Core.Enum;
using System;

namespace Core.Models
{
    public class User : BaseEntity
    {
        public int Age
        {
            get
            {
                var now = DateTime.Today;
                var age = now.Year - Birth.Year;
                if (Birth > now.AddYears(-age)) age--;
                return age;
            }
        }

        public string Code { get; set; }
        public string Photo { get; set; }
        public string Fullname { get; set; }
        public string Slug { get; set; }
        public string Email { get; set; }
        public DateTime Birth { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }

        public string Biography { get; set; }
        public string PostalCode { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }

        public UserRole Role { get; set; }
        public Gender Gender { get; set; }

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