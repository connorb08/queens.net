using Queens.Interfaces;

namespace Queens.Variables;

internal sealed class Cell(ILogger<Cell> logger, ushort id) : ICell
{
    public ushort Id { get; } = id;
}