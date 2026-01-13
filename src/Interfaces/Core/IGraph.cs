using Queens.Data;
using Queens.Interfaces.Core.Variables;

namespace Queens.Interfaces.Core;

internal interface IGraph
{
    public IGraph Construct(GameDefinition definition);

    public IEnumerable<ICellGroup> Rows { get; }
    public IEnumerable<ICellGroup> Columns { get; }
    public IEnumerable<ICellGroup> Colors { get; }
    public IEnumerable<ICell> Cells { get; }
}
