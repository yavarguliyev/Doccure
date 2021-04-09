using Api;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net.Http;
using Xunit;

namespace Testing.TestingControllers.v1
{
    public abstract class TestBase : IClassFixture<WebApplicationFactory<Startup>>
    {
        protected readonly HttpClient client = new WebApplicationFactory<Api.Startup>().CreateClient();
    }
}