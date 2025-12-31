using Queens.Enums;
using Queens.Interfaces;

namespace Queens.Variables;

internal abstract class CellGroup : ICellGroup
{
    public abstract CellGrouping Grouping { get; }

    public bool Filter()
    {
        return false;
    }
}
