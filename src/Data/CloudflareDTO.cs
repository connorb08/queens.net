using System.Data.Common;
using System.Text.Json.Serialization;

using Queens.Controllers;

namespace Queens.Data;

public class CloudflareDTOBody(ISolution solution, GameStep[] steps)
{
    [JsonPropertyName("queueKey")]
    public string QueueKey { get; } = "queens";
    [JsonPropertyName("solution")]
    public ISolution Solution { get; } = solution;
    [JsonPropertyName("steps")]
    public GameStep[] Steps { get; } = steps;
}

public class CloudflareDTO(ISolution solution, GameStep[] steps)
{
    [JsonPropertyName("body")]
    public CloudflareDTOBody Body { get; } = new CloudflareDTOBody(solution, steps);
}
