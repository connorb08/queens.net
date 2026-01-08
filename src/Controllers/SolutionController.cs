using Microsoft.Extensions.Hosting;

using Queens.Interfaces;

namespace Queens.Controllers;

internal sealed class SolutionController(
    ILogger<SolutionController> logger,
    IPageController pageController
) : IHostedService, IAsyncDisposable
{

    public async Task SolveAndPublishResult()
    {
        logger.LogInformation("Solving the puzzle and publishing the result...");
        var gameDefinition = await pageController.GetGameDefinition();
        Console.WriteLine(gameDefinition);
        return;
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        await SolveAndPublishResult();
    }

    public async Task StopAsync(CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
    }

    public async ValueTask DisposeAsync()
    {
        await ValueTask.CompletedTask;
    }
}