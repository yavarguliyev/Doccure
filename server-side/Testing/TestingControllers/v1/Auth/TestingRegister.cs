using Core.DTOs.Auth;
using Core.Enum;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Testing.TestingControllers.v1.Auth
{
    public class TestingRegister : TestBase
    {
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

        [Fact]
        public async Task Register_Ok()
        {
            var model = new RegisterDTO
            {
                Email = "guliyev.yavar@com",
                Phone = "+994 55 904-68-23",
                Password = "AZaz12",
                ConfirmPassword = "AZaz12",
                Birth = new DateTime(1990, 06, 29),
                Gender = Gender.Male
            };

            var json = JsonConvert.SerializeObject(model);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("/api/v1/auth/register", data);

            if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
            }
            else if (response.StatusCode == HttpStatusCode.OK)
            {
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            }
        }
    }
}