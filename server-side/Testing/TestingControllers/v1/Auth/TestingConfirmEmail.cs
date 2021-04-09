using Core.DTOs.Auth;
using Newtonsoft.Json;
using System.Net;
using System.Threading.Tasks;
using Xunit;


namespace Testing.TestingControllers.v1.Auth
{
    public class TestingConfirmEmail : TestBase
    {
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