using Queens.Enums;

namespace Queens.Variables;

internal sealed class Row : CellGroup
{
    public override CellGrouping Grouping => CellGrouping.Row;
}