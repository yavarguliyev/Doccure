using Core.Enum;
using System;

namespace Core.DTOs.Auth
{
    public class RegisterDTO
    {
        public string Fullname { get; set; }
        public string Email { get; set; }
        public DateTime Birth { get; set; }
        public Gender Gender { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}