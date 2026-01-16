using Queens.Interfaces.Core.Variables;

namespace Queens.Interfaces.Data;

internal interface IStep
{
    public IEnumerable<ICell> AnalyzedCells { get; }
    public IEnumerable<ICell> RemovedCells { get; }
    public string Description { get; }
}
