using Microsoft.Extensions.Hosting;

using Queens.Data;
using Queens.Interfaces;
using Queens.Interfaces.Core;
using Queens.Services;

namespace Queens.Controllers;

internal sealed class Solver(
    ILogger<Solver> logger,
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

            bool trimmed = false;

            int numberOfColors = colorCombination.Count;
            var rows = colorCombination.SelectMany(c => c.Cells).Select(c => c.Row).Distinct().ToHashSet();
            if (rows.Count == numberOfColors)
            {
                foreach (var row in rows)
                {
                    trimmed |= row.FilterOut(c => !colorCombination.Contains(c.Color), "Color combination mismatch");
                }
            }

            var columns = colorCombination.SelectMany(c => c.Cells).Select(c => c.Column).Distinct().ToHashSet();
            if (columns.Count == numberOfColors)
            {
                foreach (var column in columns)
                {
                    trimmed |= column.FilterOut(c => !colorCombination.Contains(c.Color), "Color combination mismatch");
                }
            }

            if (trimmed)
                return true;
            else
                continue;
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

        var unsatisfied = _graph.Cells.Select(c => c.Id).ToArray();
        var queens = _graph.Queens.Select(c => c.Id).ToArray();
        var removed = _graph.Removed.Select(c => c.Id).ToArray();

        logger.LogInformation("Cells with queens: {Cells}", string.Join(", ", queens));
        logger.LogInformation("Cells removed: {Cells}", string.Join(", ", removed));
        logger.LogInformation("Cells unsatisfied: {Cells}", string.Join(", ", unsatisfied));

        var solution = new GameSolution();
        return solution;
    }

}
