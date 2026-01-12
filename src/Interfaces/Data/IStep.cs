namespace Queens.Interfaces;

internal interface IStep
{
    public IEnumerable<ICell> AnalyzedCells { get; }
    public IEnumerable<ICell> RemovedCells { get; }
    public string Description { get; }
}