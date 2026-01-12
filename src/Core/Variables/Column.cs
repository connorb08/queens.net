using Queens.Enums;

namespace Queens.Core.Variables;

internal sealed class Column(ILogger<Column> logger) : CellGroup(logger)
{
    public override CellGrouping Grouping => CellGrouping.Column;
}
