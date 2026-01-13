using System.Text.Json.Serialization;

namespace Queens.Data;

internal readonly record struct GameDefinition
{
    [JsonPropertyName("sideLength")]
    public ushort SideLength { get; init; }

    [JsonPropertyName("colors")]
    public ColorData[] Colors { get; init; }

    [JsonPropertyName("cellColors")]
    public ushort[] CellColors { get; init; }

}
