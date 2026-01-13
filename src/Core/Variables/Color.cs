using Queens.Enums;

namespace Queens.Core.Variables;

internal sealed class Color(ILogger<Color> logger, int id) : CellGroup(logger, id)
{
    public override CellGrouping Grouping => CellGrouping.Color;
}
