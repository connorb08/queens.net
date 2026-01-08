using Queens.Enums;
using Queens.Interfaces;

namespace Queens.Variables;

internal sealed class Row(ILogger<Row> logger) : CellGroup(logger)
{
    public override CellGrouping Grouping => CellGrouping.Row;
}
