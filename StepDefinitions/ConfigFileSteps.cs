using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using ApiTesting.Context;
using ApiTesting.Models;
using FluentAssertions;
using Reqnroll;
using Xunit;

namespace ApiTesting.StepDefinitions;

[Binding]
public sealed class ConfigFileSteps(
    ConfigurationFile configuration,
    HttpClient httpClient,
    IReqnrollOutputHelper reqnrollOutputHelper,
    ResponseContext responsecontext)
{
    private readonly string _hostname = configuration.Hostname;
    
    [Then("the hostname is {string}")]
    public void ThenTheHostnameIs(string name)
    {
        Assert.Equal(name, _hostname);
    }

    [When("the user hit the access point")]
    public async Task WhenTheUserHitTheAccessPoint()
    {
        var response = await httpClient.GetAsync("objects");
        var res = JsonSerializer.Deserialize<List<GetObjectResponse>>(await response.Content.ReadAsStringAsync());
        responsecontext.responseMessage = response;
    }

    [Then("the response code is {int}")]
    public void ThenTheResponseCodeIs(int expectedStatusCode)
    {
        var actualStatusCode = responsecontext.responseMessage;
        actualStatusCode.StatusCode.Should().Be((HttpStatusCode)expectedStatusCode);
    }

    [When("the user hits the collection endpoint")]
    public async Task WhenTheUserHitsTheCollectionEndpoint()
    {
        httpClient.DefaultRequestHeaders.Add("x-api-key", configuration.Token);
        var response = await httpClient.GetAsync("collections");
    
        // Store the response for assertion
        responsecontext.responseMessage = response;
    
        // Only deserialize if the response is successful
        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();
            try
            {
                var res = JsonSerializer.Deserialize<List<GetObjectResponse>>(content);
            }
            catch (JsonException ex)
            {
                reqnrollOutputHelper.WriteLine($"Failed to deserialize response: {ex.Message}");
                reqnrollOutputHelper.WriteLine($"Response content: {content}");
                throw;
            }
        }
    }
}