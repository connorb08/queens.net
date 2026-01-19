using System.Text.Json.Serialization;

namespace Queens.Data;

public interface ISolution
{
    [JsonPropertyName("sideLength")]
    public int SideLength { get; }
    [JsonPropertyName("colors")]
    // public ColorData[] Colors { get; }
    public string[] Colors { get; }
    [JsonPropertyName("cellColors")]
    public int[] CellColors { get; }
    [JsonPropertyName("queenPositions")]
    public int[] Queens { get; }
    [JsonPropertyName("cellsRemoved")]
    public int[] Removed { get; }
}

public class Solution : ISolution
{
    public required int SideLength { get; init; }
    public required string[] Colors { get; init; }
    public required int[] CellColors { get; init; }
    public required int[] Queens { get; init; }
    public required int[] Removed { get; init; }
}
