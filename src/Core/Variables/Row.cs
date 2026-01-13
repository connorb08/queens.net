using Queens.Enums;

namespace Queens.Core.Variables;

internal sealed class Row(ILogger<Row> logger, int id) : CellGroup(logger, id)
{
    public override CellGrouping Grouping => CellGrouping.Row;
}
