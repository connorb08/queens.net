namespace Queens.Data;

public readonly record struct CellUpdate
{

    public int Id { get; init; }

    public bool IsQueen { get; init; }

    public string Reason { get; init; }

}
