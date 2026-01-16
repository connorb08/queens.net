using Queens.Enums;

namespace Queens.Core.Variables;

public sealed class Color(ILogger<Color> logger, int id) : CellGroup(logger, id)
{
    public override CellGrouping Grouping => CellGrouping.Color;

    public override bool LocalSearch()
    {

        if (Rows.Count() == 1)
        {
            Row row = Rows.First();
            logger.LogInformation("All colors are in Row {Id}", row.Id);
            return row.FilterOut(c => c.Color != this);
        }

        if (Columns.Count() == 1)
        {
            Column column = Columns.First();
            logger.LogInformation("All colors are in Column {Id}", column.Id);
            return column.FilterOut(c => c.Color != this);
        }

        return RemoveSharedEdges();
    }

    private bool RemoveSharedEdges()
    {
        var edgeSets = Cells.Select(c => c.Edges.Where(e => e.Color != this).ToHashSet());
        var intersection = edgeSets.Aggregate((set1, set2) => [.. set1.Intersect(set2)]);

        bool trimmed = intersection.Count > 0;
        foreach (var cell in intersection)
        {
            logger.LogInformation("Color {Id} removing shared edge Cell {CellId}", Id, cell.Id);
            cell.SetQueen(false);
        }

        return trimmed;
    }
}
