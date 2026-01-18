using System.Text.Json.Serialization;

namespace Queens.Data;

public readonly record struct GameDefinition
{
    [JsonPropertyName("sideLength")]
    public int SideLength { get; init; }

    [JsonPropertyName("colors")]
    public ColorData[] Colors { get; init; }

    [JsonPropertyName("cellColors")]
    public int[] CellColors { get; init; }

}
