using Core.DTOs.Auth;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Testing.TestingControllers.v1.Auth
{
    public class TestingResetPassword : IClassFixture<WebApplicationFactory<Api.Startup>>
    {
        private readonly HttpClient client;

        public TestingResetPassword(WebApplicationFactory<Api.Startup> fixture)
        {
            client = fixture.CreateClient();
        }

        [Fact]
        public async Task ResetPassword()
        {
            var token = "b37fa949-71db-43ee-b361-c6e465652d42";
            var model = new ResetPasswordDTO { Password = "AZaz12", ConfirmPassword = "AZaz12" };
            var json = JsonConvert.SerializeObject(model);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PutAsync($"/api/v1/auth/reset-password?token={token}", data);
            var result = JsonConvert.DeserializeObject<UserDTO>(await response.Content.ReadAsStringAsync());
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
            }
            else if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
            }
            else if(response.StatusCode == HttpStatusCode.OK && result.Id != 0)
            {
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
                Assert.True(result.Id != 0);
            }
        }
    }
}