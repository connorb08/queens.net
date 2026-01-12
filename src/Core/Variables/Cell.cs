using Queens.Interfaces;

namespace Queens.Core.Variables;

internal sealed class Cell(ILogger<Cell> logger, ushort id, Row row, Column column, Color color) : ICell
{

    // #region Fields

    private readonly ILogger<Cell> _logger = logger;
    private readonly Row _row = row;
    private readonly Column _column = column;
    private readonly Color _color = color;
    private readonly HashSet<ICell> _corners = [];
    private bool? _isQueen = null;

    // #endregion

    // #region Properties

    public ushort Id { get; } = id;
    public bool Satisfied => _isQueen.HasValue;
    public IEnumerable<ICell> Edges => _corners
        .Concat(_row.Cells)
        .Concat(_column.Cells)
        .Concat(_color.Cells)
        .Where(cell => cell.Id != Id && !cell.Satisfied);

    // #endregion

    // #region Methods

    public bool AddCorner(ICell cell)
    {
        return _corners.Add(cell) | cell.AddCorner(this);
    }

    public void SetQueen(bool isQueen)
    {
        _isQueen = isQueen;
    }

    // #endregion

}
