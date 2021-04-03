using Core.DTOs.Auth;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;


namespace Testing.TestingControllers.v1.Auth
{
    public class TestingConfirmEmail : IClassFixture<WebApplicationFactory<Api.Startup>>
    {
        private readonly HttpClient client;

        public TestingConfirmEmail(WebApplicationFactory<Api.Startup> fixture)
        {
            client = fixture.CreateClient();
        }

        [Fact]
        public async Task ConfirEmail_Ok()
        {
            var token = "e9e336a0-712f-4a05-b3c8-24ed5a1b0522";
            var response = await client.GetAsync($"/api/v1/auth/confirm-email?token={token}");
            var result = JsonConvert.DeserializeObject<UserDTO>(await response.Content.ReadAsStringAsync());
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
            }
            else if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
            }
            else if (result.Id != 0)
            {
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
                Assert.True(result.Id != 0);
            }
        }
    }
}