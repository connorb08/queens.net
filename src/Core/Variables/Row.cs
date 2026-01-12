using Queens.Enums;

namespace Queens.Core.Variables;

internal sealed class Row(ILogger<Row> logger) : CellGroup(logger)
{
    public override CellGrouping Grouping => CellGrouping.Row;
}
