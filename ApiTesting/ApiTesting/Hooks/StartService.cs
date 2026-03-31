using ApiTesting.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Reqnroll;
using Reqnroll.Microsoft.Extensions.DependencyInjection;

namespace ApiTesting.Hooks;

[Binding]
public class StartService
{
    /// <summary>
    /// Configures the dependency injection container for each Reqnroll scenario.
    /// Loads configuration from Config.json, with optional local overrides from Config.local.json,
    /// and registers the bound <see cref="ConfigurationFile"/> model as a singleton service.
    /// </summary>
    [ScenarioDependencies]
    public static IServiceCollection SetServices()
    {
        var service = new ServiceCollection();
        
        var configuration = new ConfigurationBuilder()
            .AddJsonFile("Config.json")
            .AddJsonFile("Config.local.json", optional: true, reloadOnChange: true)
            .Build();
        
        var configFile = configuration.Get<ConfigurationFile>();
        service.AddSingleton(configFile);
        
        return service;
    }
}