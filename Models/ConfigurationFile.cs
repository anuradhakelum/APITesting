using System;

namespace ApiTesting.Models;

public class ConfigurationFile
{
    public string Hostname { get; set; }
    public Uri BaseUrl { get; set; }
}