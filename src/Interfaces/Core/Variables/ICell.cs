using Queens.Core.Variables;

namespace Queens.Interfaces.Core.Variables;

public interface ICell
{
    public int Id { get; }
    public bool Satisfied { get; }
    public IEnumerable<ICell> Edges { get; }

    public Row Row { get; }
    public Column Column { get; }
    public Color Color { get; }


    /// <summary>
    /// Adds the specified element to a set.
    /// </summary>
    /// <param name="cell"></param>
    /// <returns>
    /// true if a new connection is made between either of the cells; false if both cells are already connected.
    /// </returns>
    public void AddCorner(ICell cell);
    public void SetQueen(bool isQueen);

}
