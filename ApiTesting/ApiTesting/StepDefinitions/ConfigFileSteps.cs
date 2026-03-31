using ApiTesting.Models;
using Reqnroll;
using Xunit;

namespace ApiTesting.StepDefinitions;

[Binding]
public sealed class ConfigFileSteps(ConfigurationFile configuration)
{
    private readonly string _hostname = configuration.Hostname;
    
    [Then("the hostname is {string}")]
    public void ThenTheHostnameIs(string name)
    {
        Assert.Equal(name, _hostname);
    }
}