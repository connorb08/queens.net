using Queens.Core.Variables;
using Queens.Data;

namespace Queens.Services;

public interface ISolutionManager
{
    int SideLength { get; set; }
    ColorData[] Colors { get; set; }
    int[] CellColors { get; set; }
    int[] Queens { get; }
    int[] Removed { get; }

    void AddCross(ICell cell);
    void AddQueen(ICell cell);
    ISolution GetSolution();
}

public sealed class SolutionManager(
    ILogger<SolutionManager> logger
) : ISolutionManager
{
    private readonly List<int> _queens = [];
    private readonly List<int> _removed = [];

    public int SideLength { get; set; } = 0;
    public ColorData[] Colors { get; set; } = [];
    public int[] CellColors { get; set; } = [];
    public int[] Queens => [.. _queens];
    public int[] Removed => [.. _removed];

    public void AddQueen(ICell cell)
    {
        _queens.Add(cell.Id);
    }

    public void AddCross(ICell cell)
    {
        _removed.Add(cell.Id);
    }

    public ISolution GetSolution()
    {
        return new Solution()
        {
            SideLength = SideLength,
            Colors = Colors,
            CellColors = CellColors,
            Queens = Queens,
            Removed = Removed
        };
    }
}
