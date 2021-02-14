﻿using Core.Enum;

namespace Core.DTOs.Auth
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
        public string InviteToken { get; set; }
        public string ConfirmToken { get; set; }
        public string ConnectionId { get; set; }

        public UserRole Role { get; set; }
        public Gender Gender { get; set; }

        public int? AdminId { get; set; }
        public int? DoctorId { get; set; }
        public int? PatientId { get; set; }

        public bool Status { get; set; }
    }
}