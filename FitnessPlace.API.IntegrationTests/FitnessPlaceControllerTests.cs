using System.Net;

namespace FitnessPlace.API.IntegrationTests;

public class FitnessPlaceControllerTests
{
    //[ThingsUnderTest]_Should_[ExpectedResult]
    [Fact]
    public async Task Test1()
    {
        var application = new FitnessPlaceWebApplicationFactory();
        var client = application.CreateClient();

        var response = await client.GetAsync("/api/Member");

        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }
}
