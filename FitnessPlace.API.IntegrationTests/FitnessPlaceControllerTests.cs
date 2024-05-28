using System.Net;
using System.Net.Http.Json;
using FitnessPlace.Business.DTOs;

namespace FitnessPlace.API.IntegrationTests;

public class FitnessPlaceControllerTests
{
    //[ThingsUnderTest]_Should_[ExpectedResult]
    [Fact]
    public async Task WhenNoMembers_Should_ReturnNotFound()
    {
        var application = new FitnessPlaceWebApplicationFactory();
        var client = application.CreateClient();

        var response = await client.GetAsync("/api/Member");

        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }

    [Fact]
    public async Task CreateMembers_Should_ReturnCreated()
    {
        var application = new FitnessPlaceWebApplicationFactory();
        var client = application.CreateClient();
        MemberCreateDto memberCreateDto = new()
        {
            FirstName = "Sam",
            LastName = "Jenkins",
            Address = "This is test address",
            Email = "testemail@mail.com",
            MobileNumber = "0466822133"
        };
        JsonContent MemberCreateDtoContent = JsonContent.Create(memberCreateDto);
        var response = await client.PostAsync("/api/Member", MemberCreateDtoContent);

        Assert.Equal(HttpStatusCode.Created, response.StatusCode);
    }
}
