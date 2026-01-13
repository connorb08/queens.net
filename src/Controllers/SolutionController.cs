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

    private GameSolution Solve()
    {
        _ = _graph;
        var solution = new GameSolution();
        return solution;
    }

}
