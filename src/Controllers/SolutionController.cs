using Microsoft.Extensions.Hosting;

using Queens.Interfaces;

namespace Queens.Controllers;

internal sealed class SolutionController(
    ILogger<SolutionController> logger,
    IPageController pageController,
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
        return;
    }

}