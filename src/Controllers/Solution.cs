using System.Text.Json.Serialization;

using Queens.Data;
using Queens.Interfaces.Core.Variables;

namespace Queens.Controllers;

public interface ISolution
{
    public int SideLength { get; set; }
    public ColorData[] Colors { get; set; }
    public int[] CellColors { get; set; }

    public int[] Queens { get; }
    public int[] Removed { get; }
    public void AddCross(ICell cell);
    public void AddQueen(ICell cell);
}

public sealed class Solution(
    ILogger<Solution> logger
) : ISolution
{

    private readonly List<int> _queens = [];
    private readonly List<int> _removed = [];

    [JsonPropertyName("sideLength")]
    public int SideLength { get; set; } = 0;

    [JsonPropertyName("colors")]
    public ColorData[] Colors { get; set; } = [];

    [JsonPropertyName("cellColors")]
    public int[] CellColors { get; set; } = [];

    [JsonPropertyName("queens")]
    public int[] Queens => [.. _queens];

    [JsonPropertyName("removed")]
    public int[] Removed => [.. _removed];

    public void AddQueen(ICell cell)
    {
        _queens.Add(cell.Id);
    }

    public void AddCross(ICell cell)
    {
        _removed.Add(cell.Id);
    }
}
