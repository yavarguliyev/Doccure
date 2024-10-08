﻿using System.Threading.Tasks;

namespace Core.Services.Rest
{
    public interface IEmailService
    {
        Task Send(string email, string name, object data);
    }
}