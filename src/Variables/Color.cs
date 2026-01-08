using Queens.Enums;

namespace Queens.Variables;

internal sealed class Color(ILogger<Color> logger) : CellGroup(logger)
{
    public override CellGrouping Grouping => CellGrouping.Color;
}