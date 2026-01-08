using Queens.Data;
using Queens.Interfaces;
using Queens.Services;
using Queens.Variables;

namespace Queens.Core;

internal sealed class Graph(ILogger<IGraph> logger, IFactory factory) : IGraph
{
    private IEnumerable<Row> _row = new HashSet<Row>();
    private IEnumerable<Column> _column = new HashSet<Column>();
    private IEnumerable<Color> _color = new HashSet<Color>();

    public GameSolution Solve(GameDefinition definition)
    {
        logger.LogInformation("Solving game with side length {SideLength}", definition.SideLength);

        for (ushort i = 0; i < definition.SideLength; i++)
        {
            _row = _row.Append(factory.CreateRow());
            _column = _column.Append(factory.CreateColumn());
            _color = _color.Append(factory.CreateColor());
        }

        for (ushort cellId = 0; cellId < definition.CellColors.Length; cellId++)
        {
            var rowId = (ushort)(cellId / definition.SideLength);
            var columnId = (ushort)(cellId % definition.SideLength);
            var colorId = definition.CellColors[cellId];

            Row row = _row.ElementAt(rowId);
            Column column = _column.ElementAt(columnId);
            Color color = _color.ElementAt(colorId);
            ICell cell = factory.CreateCell(cellId, row, column, color);

            row.AddCell(cell);
            column.AddCell(cell);
            color.AddCell(cell);

        }

        return new GameSolution();
    }
}
