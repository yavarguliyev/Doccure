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
    public class TestingLogin : IClassFixture<WebApplicationFactory<Api.Startup>>
    {
        private readonly HttpClient client;

        public TestingLogin(WebApplicationFactory<Api.Startup> fixture)
        {
            client = fixture.CreateClient();
        }

        [Fact]
        public async Task Login_Unauthorized()
        {
            var model = new LoginDTO { Email = "dmin@dmin.com", Password = "AZaz12" };
            var json = JsonConvert.SerializeObject(model);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("/api/v1/auth/login", data);
            var result = JsonConvert.DeserializeObject<UserDTO>(await response.Content.ReadAsStringAsync());
            Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
            Assert.True(result.Id == 0);
            Assert.True(result.Token == null);
        }

        [Fact]
        public async Task Login_Ok()
        {
            var model = new LoginDTO { Email = "admin@admin.com", Password = "yavar10Yr" };
            var json = JsonConvert.SerializeObject(model);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("/api/v1/auth/login", data);
            var result = JsonConvert.DeserializeObject<UserDTO>(await response.Content.ReadAsStringAsync());
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.True(result.Id != 0);
            Assert.True(result.Token != null);
        }
    }
}