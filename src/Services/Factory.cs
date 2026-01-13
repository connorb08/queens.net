using Microsoft.Extensions.DependencyInjection;

using Queens.Core.Variables;
using Queens.Data;
using Queens.Interfaces;
using Queens.Interfaces.Core;

namespace Queens.Services;

internal interface IFactory
{
    public Row CreateRow(int id);
    public Column CreateColumn(int id);
    public Color CreateColor(int id);
    public IGraph CreateGraph(GameDefinition definition);
    public ICell CreateCell(int id, Row row, Column column, Color color);
}

internal class Factory(IServiceProvider serviceProvider) : IFactory
{
    public IGraph CreateGraph(GameDefinition definition) =>
        serviceProvider.GetRequiredService<IGraph>()
        .Construct(definition);

    public ICell CreateCell(int id, Row row, Column column, Color color)
    {
        return new Cell(serviceProvider.GetRequiredService<ILogger<Cell>>(), id, row, column, color);
    }

    public Row CreateRow(int id) => new(serviceProvider.GetRequiredService<ILogger<Row>>(), id);
    public Column CreateColumn(int id) => new(serviceProvider.GetRequiredService<ILogger<Column>>(), id);
    public Color CreateColor(int id) => new(serviceProvider.GetRequiredService<ILogger<Color>>(), id);
}
