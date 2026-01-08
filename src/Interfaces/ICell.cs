namespace Queens.Interfaces;

internal interface ICell
{
    public ushort Id { get; }
    public bool Satisfied { get; }
    public IEnumerable<ICell> Edges { get; }

    /// <summary>
    /// Adds the specified element to a set.
    /// </summary>
    /// <param name="cell"></param>
    /// <returns>
    /// true if a new connection is made between either of the cells; false if both cells are already connected.
    /// </returns>
    public bool AddCorner(ICell cell);
    public void SetQueen(bool isQueen);

}
