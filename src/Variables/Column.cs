using Queens.Enums;

namespace Queens.Variables;

internal sealed class Column : CellGroup
{
    public override CellGrouping Grouping => CellGrouping.Column;
}