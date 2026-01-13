using Queens.Enums;
using Queens.Interfaces;

namespace Queens.Core.Variables;

internal abstract class CellGroup(ILogger<CellGroup> logger, int id) : ICellGroup
{
    public abstract CellGrouping Grouping { get; }
    public IEnumerable<ICell> Cells { get; } = new HashSet<ICell>();
    public int Id { get; } = id;
    public bool Satisfied => Cells.All(cell => cell.Satisfied);

    public void AddCell(ICell cell)
    {
        ArgumentNullException.ThrowIfNull(cell);
        (Cells as HashSet<ICell>)?.Add(cell);
    }

    public bool Filter()
    {
        return false;
    }
}
