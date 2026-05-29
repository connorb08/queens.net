using Queens.Core.Variables;

namespace Queens.Data;

internal interface IStep
{
    public IEnumerable<ICell> AnalyzedCells { get; }
    public IEnumerable<ICell> RemovedCells { get; }
    public string Description { get; }
}
