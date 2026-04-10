using System.Text.Json.Serialization;

namespace ApiTesting.Models;

public class Data
{
    // Common fields
    [JsonPropertyName("color")]
    public string? Color { get; set; }

    [JsonPropertyName("price")]
    public double? Price { get; set; }

    // Capacity variants (The JSON uses multiple keys for this)
    [JsonPropertyName("capacity")]
    public string? Capacity { get; set; }

    [JsonPropertyName("capacity GB")]
    public int? CapacityGb { get; set; }

    [JsonPropertyName("generation")]
    public string? Generation { get; set; }

    // Laptop / Tablet specific
    [JsonPropertyName("CPU model")]
    public string? CpuModel { get; set; }

    [JsonPropertyName("Hard disk size")]
    public string? HardDiskSize { get; set; }

    [JsonPropertyName("Screen size")]
    public double? ScreenSize { get; set; }

    // Watch specific
    [JsonPropertyName("Strap Colour")]
    public string? StrapColour { get; set; }

    [JsonPropertyName("Case Size")]
    public string? CaseSize { get; set; }

    // Other
    [JsonPropertyName("year")]
    public int? Year { get; set; }

    [JsonPropertyName("Description")]
    public string? Description { get; set; }
}