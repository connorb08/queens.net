using System.Text.Json.Serialization;

using Queens.Controllers;

namespace Queens.Data;

public class CloudflareDTO(ISolution solution)
{
    [JsonPropertyName("body")]
    public ISolution Body { get; } = solution;
}
