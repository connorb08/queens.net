using Microsoft.Extensions.DependencyInjection;

using Queens.Core.Variables;
using Queens.Data;
using Queens.Interfaces;
using Queens.Interfaces.Core;
using Queens.Interfaces.Core.Variables;

namespace Queens.Services;

internal interface IFactory
{
    public ICellGroup CreateRow(int id);
    public ICellGroup CreateColumn(int id);
    public ICellGroup CreateColor(int id);
    public IGraph CreateGraph(GameDefinition definition);
    public ICell CreateCell(int id, ICellGroup row, ICellGroup column, ICellGroup color);
}

internal class Factory(IServiceProvider serviceProvider) : IFactory
{
    public IGraph CreateGraph(GameDefinition definition) =>
        serviceProvider.GetRequiredService<IGraph>()
        .Construct(definition);

    public ICell CreateCell(int id, ICellGroup row, ICellGroup column, ICellGroup color)
    {
        return new Cell(serviceProvider.GetRequiredService<ILogger<Cell>>(), id, row, column, color);
    }

    public ICellGroup CreateRow(int id) => new Row(serviceProvider.GetRequiredService<ILogger<Row>>(), id);
    public ICellGroup CreateColumn(int id) => new Column(serviceProvider.GetRequiredService<ILogger<Column>>(), id);
    public ICellGroup CreateColor(int id) => new Color(serviceProvider.GetRequiredService<ILogger<Color>>(), id);
}
