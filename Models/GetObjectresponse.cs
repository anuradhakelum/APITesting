using System.Text.Json.Serialization;

namespace ApiTesting.Models;

public class GetObjectResponse
{
    [JsonPropertyName("id")]
    public string Id { get; set; } = string.Empty;

    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;
    
    [JsonPropertyName("data")]
    public Data? Data { get; set; }
}
