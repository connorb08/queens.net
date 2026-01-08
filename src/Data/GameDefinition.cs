namespace Queens.Data;

internal readonly record struct GameDefinition
{
    internal int SideLength { get; init; }
    internal ColorData[] Colors { get; init; }
    internal int[] CellColors { get; init; }

    public override string ToString()
    {
        return $"SideLength: {SideLength}, Colors: [{string.Join(", ", Colors)}], CellColors: [{string.Join(", ", CellColors)}]";
    }
}