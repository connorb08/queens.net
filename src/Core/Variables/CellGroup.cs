using Queens.Enums;
using Queens.Interfaces.Core.Variables;

namespace Queens.Core.Variables;

public abstract class CellGroup(ILogger<CellGroup> logger, int id) : ICellGroup
{

    private readonly HashSet<ICell> _cells = [];

    public abstract CellGrouping Grouping { get; }
    public int Id { get; } = id;
    public bool Satisfied => _cells.All(cell => cell.Satisfied);

    public IEnumerable<ICell> Cells => _cells.Where(cell => !cell.Satisfied);
    public IEnumerable<Row> Rows => Cells.Select(cell => cell.Row).Distinct();
    public IEnumerable<Column> Columns => Cells.Select(cell => cell.Column).Distinct();
    public IEnumerable<Color> Colors => Cells.Select(cell => cell.Color).Distinct();

    public abstract bool LocalSearch();

    public void AddCell(ICell cell)
    {
        ArgumentNullException.ThrowIfNull(cell);
        _cells.Add(cell);
    }

    public bool FilterOut(Func<ICell, bool> predicate, string reason)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        var cellsToRemove = Cells.Where(predicate).ToList();
        foreach (var cell in cellsToRemove)
        {
            cell.SetQueen(false, reason);
        }
        return cellsToRemove.Count > 0;
    }
}
