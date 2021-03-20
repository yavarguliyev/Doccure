using Microsoft.AspNetCore.Mvc.Testing;
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
        public async Task ConfirEmail_NotFound()
        {
            var token = "e9e336a0-712f-4a05-b3c8-24ed5a1b0522";
            var response = await client.GetAsync($"/api/v1/auth/confirm-email?token={token}");
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        [Fact]
        public async Task ConfirEmail_Token_Cannot_Be_Empty()
        {
            string token = null;
            var response = await client.GetAsync($"/api/v1/auth/confirm-email?token={token}");
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }
    }
}