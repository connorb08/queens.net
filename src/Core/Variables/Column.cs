using Queens.Enums;

namespace Queens.Core.Variables;

internal sealed class Column(ILogger<Column> logger, int id) : CellGroup(logger, id)
{
    public override CellGrouping Grouping => CellGrouping.Column;
}
