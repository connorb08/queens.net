using System.Text.Json.Serialization;

namespace Queens.Data;

public readonly record struct ColorData
{

    [JsonPropertyName("id")]
    public int Id { get; init; }

    [JsonPropertyName("name")]
    public string Name { get; init; }

    [JsonPropertyName("rgb")]
    public string RGB { get; init; }

}
