using Queens.Interfaces;

namespace Queens.Variables;

internal sealed class Cell(ILogger<Cell> logger, ushort id) : ICell
{


    private bool? _isQueen = null;

    public ushort Id { get; } = id;
    public bool Satisfied => _isQueen.HasValue;
    public bool Queen { set => _isQueen = value; }

    public IEnumerable<ICell> Edges { get => field.Where(e => !e.Satisfied); } = new HashSet<Cell>();

}