using Microsoft.Extensions.DependencyInjection;

using Queens.Core;
using Queens.Data;
using Queens.Interfaces;
using Queens.Variables;

namespace Queens.Services;

internal interface IFactory
{
    public Row CreateRow();
    public Column CreateColumn();
    public Color CreateColor();
    public IGraph CreateGraph();
    public ICell CreateCell(ushort id, Row row, Column column, Color color);
}

internal class Factory(IServiceProvider serviceProvider) : IFactory
{
    public IGraph CreateGraph() => serviceProvider.GetRequiredService<IGraph>();

    public ICell CreateCell(ushort id, Row row, Column column, Color color)
    {
        return new Cell(serviceProvider.GetRequiredService<ILogger<Cell>>(), id, row, column, color);
    }

    public Row CreateRow() => serviceProvider.GetRequiredService<Row>();
    public Column CreateColumn() => serviceProvider.GetRequiredService<Column>();
    public Color CreateColor() => serviceProvider.GetRequiredService<Color>();
}
