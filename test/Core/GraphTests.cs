using Microsoft.Extensions.DependencyInjection;

using Queens.Data;
using Queens.Interfaces.Core;
using Queens.Services;

namespace Tests.Core;

public class GraphTests
{
    private readonly Factory _factory = new(
        new ServiceCollection()
            .AddLogging()
            .BuildServiceProvider()
    );
    private readonly GameDefinition _definition = new()
    {
        SideLength = 4,
        Colors = [
                new ColorData()
                {
                    Id = 0,
                    Name = "Red",
                    RGB = "rgb(255,0,0)"
                },
                new ColorData()
                {
                    Id = 1,
                    Name = "Green",
                    RGB = "rgb(0,255,0)"
                },
                new ColorData()
                {
                    Id = 2,
                    Name = "Blue",
                    RGB = "rgb(0,0,255)"
                },
                new ColorData()
                {
                    Id = 3,
                    Name = "Yellow",
                    RGB = "rgb(255,255,0)"
                }
            ],
        CellColors = [
                0,0,0,0,
                0,0,1,1,
                2,2,2,2,
                2,2,3,3
            ]
    };

    [Fact]
    public void GraphRows_ShouldNotIterate_WhenSatisified()
    {

        IGraph graph = _factory.CreateGraph(_definition);

        foreach (var row in graph.Rows)
        {
            foreach (var cell in graph.Rows.ElementAt(1).Cells)
            {
                cell.SetQueen(true);
            }
            Assert.NotEqual(1, row.Id);
        }
    }
}
