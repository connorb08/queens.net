using Queens.Interfaces.Core.Variables;

namespace Queens.Interfaces.Core;

public interface IGraph
{
    public IReadOnlySet<ICellGroup> Rows { get; }
    public IReadOnlySet<ICellGroup> Columns { get; }
    public IReadOnlySet<ICellGroup> Colors { get; }
    public IReadOnlySet<ICell> Cells { get; }
    public IReadOnlySet<ICell> Removed { get; }
    public IReadOnlySet<ICell> Queens { get; }
}
