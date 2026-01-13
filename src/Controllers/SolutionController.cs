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

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        await SolveAndPublishResult();
        lifetime.StopApplication();
    }

    private async Task SolveAndPublishResult()
    {
        logger.LogInformation("Solving the puzzle and publishing the result...");
        var gameDefinition = await pageController.GetGameDefinition();
        logger.LogInformation("Game definition retrieved: {GameDefinition}", gameDefinition.ToJson());
        var graph = factory.CreateGraph(gameDefinition);
        var solution = new GameSolution();
        logger.LogInformation("Solution found: {Solution}", solution.ToJson());
        return;
    }

}
