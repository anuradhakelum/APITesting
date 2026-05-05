using System;

namespace ApiTesting.Models;

public class ConfigurationFile
{
    public string Hostname { get; set; }
    public Uri BaseUrl { get; set; }
    public string Token { get; set; }
}