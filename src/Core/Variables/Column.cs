using Queens.Enums;

namespace Queens.Core.Variables;

public sealed class Column(ILogger<Column> logger, int id) : CellGroup(logger, id)
{
    public override CellGrouping Grouping => CellGrouping.Column;

    public override bool LocalSearch()
    {

        if (Colors.Count() == 1)
        {
            Color color = Colors.First();
            logger.LogInformation("All cells in Column {Id} are of color {Color}", Id, color.Id);
            return color.FilterOut(c => c.Column != this);
        }

        return RemoveSharedEdges();
    }

    private bool RemoveSharedEdges()
    {
        var edgeSets = Cells.Select(c => c.Edges.Where(e => e.Column != this).ToHashSet());
        var intersection = edgeSets.Aggregate((set1, set2) => [.. set1.Intersect(set2)]);

        bool trimmed = intersection.Count > 0;
        foreach (var cell in intersection)
        {
            logger.LogInformation("Column {Id} removing shared edge Cell {CellId}", Id, cell.Id);
            cell.SetQueen(false);
        }

        return trimmed;
    }
}
