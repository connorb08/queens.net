using System.Text.Json.Serialization;

namespace Queens.Data;

public interface ISolution
{
    public int SideLength { get; }
    public ColorData[] Colors { get; }
    public int[] CellColors { get; }
    public int[] Queens { get; }
    public int[] Removed { get; }
}

public class Solution : ISolution
{
    [JsonPropertyName("sideLength")]
    public required int SideLength { get; init; }

    [JsonPropertyName("colors")]
    public required ColorData[] Colors { get; init; }

    [JsonPropertyName("cellColors")]
    public required int[] CellColors { get; init; }

    [JsonPropertyName("queens")]
    public required int[] Queens { get; init; }

    [JsonPropertyName("removed")]
    public required int[] Removed { get; init; }
}
