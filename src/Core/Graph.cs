using Queens.Core.Variables;
using Queens.Data;
using Queens.Interfaces;
using Queens.Interfaces.Core;
using Queens.Interfaces.Core.Variables;
using Queens.Services;

namespace Queens.Core;

internal sealed class Graph(ILogger<IGraph> logger, IFactory factory) : IGraph
{
    private readonly HashSet<ICell> _cells = [];
    private readonly HashSet<ICellGroup> _rows = [];
    private readonly HashSet<ICellGroup> _columns = [];
    private readonly HashSet<ICellGroup> _colors = [];

    public IEnumerable<ICell> Cells => _cells.Where(cell => cell.Satisfied);
    public IEnumerable<ICellGroup> Rows => _rows.Where(row => row.Satisfied);
    public IEnumerable<ICellGroup> Columns => _columns.Where(column => column.Satisfied);
    public IEnumerable<ICellGroup> Colors => _colors.Where(color => color.Satisfied);

    public IGraph Construct(GameDefinition definition)
    {
        logger.LogInformation("Constructing graph with side length {SideLength}", definition.SideLength);
        for (int i = 0; i < definition.SideLength; i++)
        {
            _rows.Add(factory.CreateRow(_rows.Count));
            _columns.Add(factory.CreateColumn(_columns.Count));
            _colors.Add(factory.CreateColor(_colors.Count));
        }

        for (int cellId = 0; cellId < definition.CellColors.Length; cellId++)
        {
            int rowId = cellId / definition.SideLength;
            int columnId = cellId % definition.SideLength;
            int colorId = definition.CellColors[cellId];

            var row = _rows.ElementAt(rowId);
            var column = _columns.ElementAt(columnId);
            var color = _colors.ElementAt(colorId);
            ICell cell = factory.CreateCell(cellId, row, column, color);

            _cells.Add(cell);
            row.AddCell(cell);
            column.AddCell(cell);
            color.AddCell(cell);

            // Add top-left corner if it exists
            if (rowId > 0 && columnId > 0)
            {
                int topLeftId = (rowId - 1) * definition.SideLength + (columnId - 1);
                ICell? topLeftCell = _cells.FirstOrDefault(c => c.Id == topLeftId);
                if (topLeftCell is not null)
                {
                    cell.AddCorner(topLeftCell);
                }
            }

            // // Add top-right corner if it exists
            if (rowId > 0 && columnId < definition.SideLength - 1)
            {
                int topRightId = (rowId - 1) * definition.SideLength + (columnId + 1);
                ICell? topRightCell = _cells.FirstOrDefault(c => c.Id == topRightId);
                if (topRightCell is not null)
                {
                    cell.AddCorner(topRightCell);
                }
            }
        }

        return this;
    }
}
