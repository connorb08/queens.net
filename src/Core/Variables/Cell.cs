using Queens.Interfaces.Core.Variables;

namespace Queens.Core.Variables;

internal sealed class Cell(ILogger<Cell> logger, int id, ICellGroup row, ICellGroup column, ICellGroup color) : ICell
{

    // #region Fields

    private readonly ICellGroup _row = row;
    private readonly ICellGroup _column = column;
    private readonly ICellGroup _color = color;
    private readonly HashSet<ICell> _corners = [];
    private bool? _isQueen = null;

    // #endregion

    // #region Properties

    public int Id { get; } = id;
    public bool Satisfied => _isQueen.HasValue;
    public IEnumerable<ICell> Edges => _corners
        .Concat(_row.Cells)
        .Concat(_column.Cells)
        .Concat(_color.Cells)
        .Where(cell => cell.Id != Id && !cell.Satisfied)
        .Distinct();

    public Row Row => (Row)_row;
    public Column Column => (Column)_column;
    public Color Color => (Color)_color;
    // #endregion

    // #region Methods

    public void AddCorner(ICell cell)
    {
        _corners.Add(cell);
    }

    public void SetQueen(bool isQueen)
    {
        if (isQueen)
            logger.PlaceQueen(Id);
        else
            logger.PlaceCross(Id, "reason");

        _isQueen = isQueen;
    }

    // #endregion

}
