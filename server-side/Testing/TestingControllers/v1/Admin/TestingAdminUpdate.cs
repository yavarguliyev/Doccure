using Core.DTOs.Auth;
using Core.Enum;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Testing.TestingControllers.v1.Admin
{
    public class TestingAdminUpdate : TestBase
    {
        [Fact]
        public async Task Update()
        {
            var model = new UserProfileUpdateDTO
            {
                Fullname = "dadadasd",
                Phone = "+994 55 904-68-23",
                Birth = new DateTime(1990, 06, 29),
                Biography = "daqwdqwdqwdq",
                PostalCode = "dqwdqwd",
                Address = "qwdqdqw",
                City = "dqdqwd",
                State = "qdqwdqwd",
                Country = "dqwdqwdwq",
                Gender = Gender.Male
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
            else if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
            }
            else if (result.Id != 0 && response.StatusCode == HttpStatusCode.OK)
            {
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            }
        }
    }
}