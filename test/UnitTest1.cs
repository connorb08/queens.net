using Microsoft.Extensions.Logging;

using Moq;

using Queens.Core.Variables;
using Queens.Interfaces.Core.Variables;

namespace Tests;

public class UnitTest1
{

    private readonly ILogger<Cell> _logger = Mock.Of<ILogger<Cell>>();
    private readonly ICellGroup _row = Mock.Of<ICellGroup>();
    private readonly ICellGroup _column = Mock.Of<ICellGroup>();
    private readonly ICellGroup _color = Mock.Of<ICellGroup>();

    [Fact]
    public void Test1()
    {
        Cell cell = new(_logger, 1, row: _row, column: _column, color: _color);
        Assert.NotNull(cell);
    }
}
