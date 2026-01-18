namespace Queens.Data;

public readonly record struct GameStep
{
    public string Description { get; init; }
    public bool DidUpdate { get; init; }
    public bool PlacedQueen { get; init; }
    public int[] AnalyzedCells { get; init; }
    public IEnumerable<CellUpdate> UpdatedCells { get; init; }
}
