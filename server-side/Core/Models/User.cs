using Core.Enum;
using System;
using System.Collections.Generic;

namespace Core.Models
{
    public class User : BaseEntity
    {
        public string Code { get; set; }
        public string Photo { get; set; }
        public string PhotoURL { get; set; }
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

        public ICollection<Chat> Doctors { get; set; }
        public ICollection<Chat> Patients { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<CommentReply> CommentReplies { get; set; }
        public ICollection<Review> ReviewsDoctors { get; set; }
        public ICollection<Review> ReviewsPatients { get; set; }
        public ICollection<ReviewReply> ReviewRepliesDoctor { get; set; }
        public ICollection<ReviewReply> ReviewRepliesPatient { get; set; }
    }
}