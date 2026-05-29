using System.Text.Json.Serialization;

using Queens.Core.Variables;

namespace Queens.Data;

public class Solution
{
    [JsonPropertyName("sideLength")]
    public int SideLength { get; set; } = 0;

    [JsonPropertyName("colors")]
    public List<ColorData> Colors { get; set; } = [];

    [JsonPropertyName("cellColors")]
    public List<int> CellColors { get; set; } = [];

    [JsonPropertyName("queenPositions")]
    public List<int> Queens { get; init; } = [];

    [JsonPropertyName("cellsRemoved")]
    public List<int> Removed { get; init; } = [];

    public void AddQueen(ICell cell)
    {
        Queens.Add(cell.Id);
    }

    public void AddCross(ICell cell)
    {
        Removed.Add(cell.Id);
    }

}
