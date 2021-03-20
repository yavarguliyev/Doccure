﻿using Core.DTOs.Auth;
using Core.Enum;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Testing.TestingControllers.v1.Auth
{
    public class TestingRegister : IClassFixture<WebApplicationFactory<Api.Startup>>
    {
        private readonly HttpClient client;

        public TestingRegister(WebApplicationFactory<Api.Startup> fixture)
        {
            client = fixture.CreateClient();
        }

        [Fact]
        public async Task Register_Email_Cannot_Be_Null()
        {
            var model = new RegisterDTO 
            { 
                Email = "", 
                Phone = "+994 55 904-68-23",
                Password = "AZaz12",
                ConfirmPassword = "AZaz12",
                Birth = new DateTime(1990, 06, 29),
                Gender = Gender.Male
            };

            var json = JsonConvert.SerializeObject(model);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("/api/v1/auth/register", data);
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async Task Register_Is_Already_Exist()
        {
            var model = new RegisterDTO
            {
                Email = "admin@admin.com",
                Phone = "+994 55 904-68-23",
                Password = "AZaz12",
                ConfirmPassword = "AZaz12",
                Birth = new DateTime(1990, 06, 29),
                Gender = Gender.Male
            };

            var json = JsonConvert.SerializeObject(model);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("/api/v1/auth/register", data);
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }
    }
}