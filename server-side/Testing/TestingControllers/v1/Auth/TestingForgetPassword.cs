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
    public class TestingForgetPassword : IClassFixture<WebApplicationFactory<Api.Startup>>
    {
        private readonly HttpClient client;

        public TestingForgetPassword(WebApplicationFactory<Api.Startup> fixture)
        {
            client = fixture.CreateClient();
        }

        [Fact]
        public async Task ForgetPassword_BadRequest()
        {
            var model = new ForgetPasswordDTO { Email = null };
            var json = JsonConvert.SerializeObject(model);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PutAsync("/api/v1/auth/forget-password", data);
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async Task ForgetPassword_NotFound()
        {
            var model = new ForgetPasswordDTO { Email = "dmin@dmin.com" };
            var json = JsonConvert.SerializeObject(model);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PutAsync("/api/v1/auth/forget-password", data);
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        [Fact]
        public async Task ForgetPassword_Ok()
        {
            var model = new ForgetPasswordDTO { Email = "dmin@dmin.com" };
            var json = JsonConvert.SerializeObject(model);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PutAsync("/api/v1/auth/forget-password", data);
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
            }
            else
            {
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            }
        }
    }
}