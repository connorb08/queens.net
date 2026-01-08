namespace Queens.Data;

internal readonly record struct ColorData
{
    internal int Id { get; init; }
    internal string Name { get; init; }
    internal string RGB { get; init; }

    public override string ToString()
    {
        return $"{Name}({Id}): {RGB}";
    }
}