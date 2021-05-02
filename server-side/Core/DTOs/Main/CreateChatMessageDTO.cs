﻿using FluentValidation;

namespace Core.DTOs.Main
{
    public class CreateChatMessageDTO
    {
        public string DoctorContent { get; set; }
        public string PatientContent { get; set; }
        public string Photo { get; set; }

        public int ChatId { get; set; }
        public int UserId { get; set; }
    }

    public class ChatMessageModifyValidator : AbstractValidator<CreateChatMessageDTO>
    {
        public ChatMessageModifyValidator()
        {
        }
    }
}