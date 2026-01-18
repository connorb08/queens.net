namespace Queens.Data;

public readonly record struct GameSolution
{
    public int SideLength { get; init; }
    public ColorData[] Colors { get; init; }
    public int[] Queens { get; init; }
    public int[] Removed { get; init; }
    public int[] CellColors { get; init; }
    public IEnumerable<GameStep> Steps { get; init; }
}
