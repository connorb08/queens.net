using Queens.Enums;

namespace Queens.Core.Variables;

internal sealed class Color(ILogger<Color> logger) : CellGroup(logger)
{
    public override CellGrouping Grouping => CellGrouping.Color;
}