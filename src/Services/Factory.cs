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
    public IGraph CreateGraph(GameDefinition gameDefinition);
    public ICell CreateCell(ushort id, Row row, Column column, Color color);
}

internal class Factory(IServiceProvider serviceProvider) : IFactory
{
    public IGraph CreateGraph(GameDefinition gameDefinition)
    {
        return new Graph(serviceProvider.GetRequiredService<ILogger<IGraph>>(), this, gameDefinition);
    }

    public ICell CreateCell(ushort id, Row row, Column column, Color color)
    {
        return new Cell(serviceProvider.GetRequiredService<ILogger<Cell>>(), id, row, column, color);
    }

    public Row CreateRow()
    {
        return new Row(serviceProvider.GetRequiredService<ILogger<Row>>());
    }

    public Column CreateColumn()
    {
        return new Column(serviceProvider.GetRequiredService<ILogger<Column>>());
    }

    public Color CreateColor()
    {
        return new Color(serviceProvider.GetRequiredService<ILogger<Color>>());
    }
}
