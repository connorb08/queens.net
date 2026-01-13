using Microsoft.Extensions.Logging;

using Moq;

using Queens.Core;
using Queens.Core.Variables;
using Queens.Data;
using Queens.Interfaces.Core;
using Queens.Interfaces.Core.Variables;
using Queens.Services;

namespace Tests.Core;

public class GraphTests
{

    private readonly ILogger<IGraph> _logger = Mock.Of<ILogger<IGraph>>();
    private readonly IFactory _factory = Mock.Of<IFactory>();

    [Fact]
    public void GraphRows_ShouldNotIterate_WhenSatisified()
    {
        GameDefinition definition = new()
        {
            SideLength = 0,
            Colors = [],
            CellColors = []
        };

        Graph graph = new(_logger, _factory, definition);
        var rows = graph.Rows;
        foreach (var row in rows)
        {
            // rows.ElementAt(2).Satisfied = true;
            Assert.False(row.Satisfied);
        }
    }
}
