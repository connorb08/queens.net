using Queens.Core.Variables;
using Queens.Enums;

namespace Queens.Interfaces.Core.Variables;

public interface ICellGroup
{

    public CellGrouping Grouping { get; }
    public IEnumerable<ICell> Cells { get; }
    public bool Satisfied { get; }
    public int Id { get; }
    public string? ColorName { get; }

    public IEnumerable<Row> Rows { get; }
    public IEnumerable<Column> Columns { get; }
    public IEnumerable<Color> Colors { get; }

    // #region Setup Methods

    public void AddCell(ICell cell);

    // #endregion

    /// <summary>
    /// Filters out the cell group based on specific criteria.
    /// </summary>
    /// <returns>True if a cell was removed.</returns>
    public bool FilterOut(Func<ICell, bool> predicate, string reason);

    public bool LocalSearch();

}
