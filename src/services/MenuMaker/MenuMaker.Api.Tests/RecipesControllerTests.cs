using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MenuMaker.Api.Tests;
public class RecipesControllerTests : IClassFixture<CustomWebApplicationFactory<MenuMaker.Api.Program>>
{
    private readonly HttpClient _client;
    private readonly CustomWebApplicationFactory<Program>
        _factory;

    public RecipesControllerTests(CustomWebApplicationFactory<Program> factory)
    {
        _factory = factory;
        _client = factory.CreateClient(new WebApplicationFactoryClientOptions
        {
            AllowAutoRedirect = false
        });
    }

    [Fact]
    public async Task Get_Recipes()
    {
        // Arrange

        //Act
        var response = await _client.GetAsync("/api/v1/recipes");

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
}
