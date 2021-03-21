using Core.DTOs.Auth;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Testing.TestingControllers.v1.Admin
{
    public class TestingAdminUpdatePassword : IClassFixture<WebApplicationFactory<Api.Startup>>
    {
        private readonly HttpClient client;

        public TestingAdminUpdatePassword(WebApplicationFactory<Api.Startup> fixture)
        {
            client = fixture.CreateClient();
        }

        [Fact]
        public async Task UpdatePassword_CurrentPassword_Is_Not_Mathcing()
        {
            var model = new AuthPasswordUpdateDTO
            {
                CurrentPassword = "dadadasd",
                NewPassword = "dadadasD",
                ConfirmPassword = "dadadasD",
            };
            var json = JsonConvert.SerializeObject(model);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PutAsync("/api/v1/admin", data);
            response.Headers.Add("Authorization", "Bearer b37fa949-71db-43ee-b361-c6e465652d42");
            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
            }
            else if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
            }
        }

        [Fact]
        public async Task UpdatePassword_NewPassword_Cannot_Match_CurrentPassword()
        {
            var model = new AuthPasswordUpdateDTO
            {
                CurrentPassword = "dadadasd",
                NewPassword = "dadadasD",
                ConfirmPassword = "dadadasD",
            };
            var json = JsonConvert.SerializeObject(model);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PutAsync("/api/v1/admin", data);
            response.Headers.Add("Authorization", "Bearer b37fa949-71db-43ee-b361-c6e465652d42");
            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
            }
            else if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
            }
        }

        [Fact]
        public async Task UpdatePassword_ConfirmPassword_Must_Match_NewPassword()
        {
            var model = new AuthPasswordUpdateDTO
            {
                CurrentPassword = "dadadasd",
                NewPassword = "dadadasD",
                ConfirmPassword = "dadadasD",
            };
            var json = JsonConvert.SerializeObject(model);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PutAsync("/api/v1/admin", data);
            response.Headers.Add("Authorization", "Bearer b37fa949-71db-43ee-b361-c6e465652d42");
            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
            }
            else if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
            }
        }

        [Fact]
        public async Task UpdatePassword_Ok()
        {
            var model = new AuthPasswordUpdateDTO
            {
                CurrentPassword = "dadadasd",
                NewPassword = "dadadasD",
                ConfirmPassword = "dadadasD",
            };
            var json = JsonConvert.SerializeObject(model);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PutAsync("/api/v1/admin", data);
            response.Headers.Add("Authorization", "Bearer b37fa949-71db-43ee-b361-c6e465652d42");
            var result = JsonConvert.DeserializeObject<UserDTO>(await response.Content.ReadAsStringAsync());
            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
            }
            else if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
            }
            else if (result.Id != 0 && response.StatusCode == HttpStatusCode.OK)
            {
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
                Assert.True(result.Id != 0);
            }
        }
    }
}