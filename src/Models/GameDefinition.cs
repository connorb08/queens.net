using System.Text.Json.Serialization;

namespace Queens.Data;

public readonly record struct GameDefinition
{

    [JsonPropertyName("sideLength")]
    public int SideLength { get; init; }

    [JsonPropertyName("colors")]
    public List<ColorData> Colors { get; init; }

    [JsonPropertyName("cellColors")]
    public List<int> CellColors { get; init; }

}
