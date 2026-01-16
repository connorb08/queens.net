using Microsoft.Extensions.Hosting;

using Queens.Data;
using Queens.Interfaces;
using Queens.Interfaces.Core;
using Queens.Services;

namespace Queens.Controllers;

internal sealed class SolutionController(
    ILogger<SolutionController> logger,
    IPageController pageController,
    IFactory factory,
    IHostApplicationLifetime lifetime
) : BackgroundService
{

    private GameDefinition _definition = new();
    private GameSolution _solution = new();
    private IGraph _graph = null!;

    protected override async Task ExecuteAsync(CancellationToken cancellationToken)
    {
        await Setup();
        await SolveAndPublishResult();
        lifetime.StopApplication();
    }

    private async Task Setup()
    {
        _definition = await pageController.GetGameDefinition();
        _graph = factory.CreateGraph(_definition);
    }

    private async Task SolveAndPublishResult()
    {
        _solution = Solve();
        logger.LogInformation("Solution found: {Solution}", _solution.ToJson());
        return;
    }

    private bool Search()
    {
        foreach (var row in _graph.Rows)
            if (row.LocalSearch())
                return true;

        foreach (var col in _graph.Columns)
            if (col.LocalSearch())
                return true;

        foreach (var color in _graph.Colors)
            if (color.LocalSearch())
                return true;

        foreach (var colorCombination in _graph.Colors.Combinations())
        {

        }

        return false;
    }

    private GameSolution Solve()
    {

        int iteration = 0;
        int maxIterations = 1000;
        while (Search() && iteration < maxIterations)
        {
            iteration++;
        }


        // foreach (var col in _graph.Columns)
        // {
        //     if (col.LocalSearch())
        //     {
        //         break;
        //     }
        // }

        // foreach (var color in _graph.Colors)
        // {
        //     if (color.LocalSearch())
        //     {
        //         break;
        //     }
        // }




        // _graph.Rows.CombineAll();

        // bool shouldTrim = false;
        // foreach (var rowCombination in _graph.Rows.Combinations())
        // {

        //     logger.LogDebug("Row combination: {Combination}", string.Join(", ", rowCombination.Select(r => r.Id)));

        //     if (rowCombination.Count == 0)
        //     {
        //         break;
        //     }

        //     var rowCells = rowCombination.SelectMany(row => row.Cells);

        //     logger.LogDebug("Row cells: {Cells}", string.Join(", ", rowCells.Select(c => c.Id)));

        //     var cellEdges = rowCells.Select(cell => cell.Edges.Where(edge => !rowCells.Contains(edge)));

        //     logger.LogDebug("Cell edges: {Edges}", string.Join(", ", cellEdges.SelectMany(e => e).Select(e => e.Id)));

        //     var sharedEdges = cellEdges.Aggregate((acc, next) => acc.Intersect(next));
        //     // var sharedEdges = rowCells.SelectMany(cell => cell.Edges.Where(edge => !rowCells.Contains(edge)));

        //     logger.LogDebug("Shared edges: {Edges}", string.Join(", ", sharedEdges.Select(e => e.Id)));

        //     if (sharedEdges.Any())
        //     {
        //         shouldTrim = true;
        //     }

        //     if (!shouldTrim)
        //     {
        //         continue;
        //     }

        //     foreach (var edge in sharedEdges)
        //     {
        //         edge.SetQueen(false);
        //     }

        //     break;
        // }

        // foreach (var col in _graph.Columns)
        // {
        //     col.LocalSearch();
        // }

        // foreach (var color in _graph.Colors)
        // {
        //     color.LocalSearch();
        // }

        var cells = _graph.Cells.Select(c => c.Id).ToArray();

        logger.LogInformation("Cells with queens: {Cells}", string.Join(", ", cells));

        var solution = new GameSolution();
        return solution;
    }

}
