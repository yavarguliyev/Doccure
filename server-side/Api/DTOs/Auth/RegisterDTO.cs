using Core.Enum;
using System;

namespace Api.DTOs.Auth
{
    public class RegisterDTO
    {
        public string Fullname { get; set; }
        public string Email { get; set; }
        public DateTime Birth { get; set; }
        public Gender Gender { get; set; }
    }
}