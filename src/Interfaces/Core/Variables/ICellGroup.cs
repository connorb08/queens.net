using Queens.Enums;

namespace Queens.Interfaces;

internal interface ICellGroup
{

    public CellGrouping Grouping { get; }
    public IEnumerable<ICell> Cells { get; }
    public bool Satisfied { get; }

    /// <summary>
    /// Filters the cell group based on specific criteria.
    /// </summary>
    /// <returns>True if a cell was removed.</returns>
    public bool Filter();

    public void AddCell(ICell cell);
}
