namespace Queens.Interfaces;

internal interface ICell
{
    public ushort Id { get; }
    public bool Queen { set; }
    public bool Satisfied { get; }
    public IEnumerable<ICell> Edges { get; }

}
