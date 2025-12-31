using System.Text.RegularExpressions;

using Microsoft.Playwright;

using Queens.Interfaces;

namespace Queens.Controllers;

internal static partial class RegexPatterns
{
    [GeneratedRegex(@"of color\s*([^,]+)", RegexOptions.IgnoreCase)]
    internal static partial Regex AriaLabelRegex();
}

internal readonly record struct ColorData
{
    internal int Id { get; init; }
    internal string Name { get; init; }
    internal string RGB { get; init; }

    public override string ToString()
    {
        return $"{Name}({Id}): {RGB}";
    }
}

internal readonly record struct StartState
{
    internal int SideLength { get; init; }
    internal ColorData[] Colors { get; init; }
    internal int[] CellColors { get; init; }
}

internal sealed class PageController(ILogger<PageController>? logger) : IPageController, IAsyncDisposable
{

    private readonly Regex _ariaLabelRegex = RegexPatterns.AriaLabelRegex();
    private bool _disposed;
    private IPlaywright _playwright = null!;
    private IBrowser _browser = null!;
    private IBrowserContext _context = null!;
    private IPage _page = null!;

    public async Task<StartState> LoadGame()
    {
        _playwright = await Playwright.CreateAsync();
        _browser = await _playwright.Chromium.LaunchAsync(new()
        {
            Headless = true
        });
        _context = await _browser.NewContextAsync(new()
        {
            UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/120.0.0.0 Safari/537.36"
        });
        _page = await _context.NewPageAsync();
        await _page.GotoAsync("https://www.linkedin.com/games/view/queens/desktop");
        var startButton = await _page.WaitForSelectorAsync("#launch-footer-start-button");

        if (startButton is null)
        {
            //logger.LogCritical("Start button not found");
            throw new InvalidOperationException("Start button not found");
        }

        await startButton.ClickAsync();

        var tableCells = await _page.QuerySelectorAllAsync("div.queens-cell-with-border");
        var colors = new Dictionary<int, ColorData>();

        var cellsInfo = await Task.WhenAll(
            tableCells.Select(async (cell) =>
            {
                var cellIdx = cell.EvaluateAsync<string>("e => e.getAttribute('data-cell-idx')");
                var cellClass = cell.EvaluateAsync<string>("e => e.getAttribute('class')");
                var ariaLabel = cell.EvaluateAsync<string>("e => e.getAttribute('aria-label')");
                var colorValue = cell.EvaluateAsync<string>("e => window.getComputedStyle(e).backgroundColor");

                string?[] values = await Task.WhenAll(cellIdx, cellClass, ariaLabel, colorValue);

                if (!int.TryParse(values[0], out var cellId)) throw new InvalidOperationException("Failed to parse cell index");
                if (!int.TryParse(values[1]?.Split("-").Last().Trim(), out var colorId)) throw new InvalidOperationException("Failed to parse cell color");
                var colorName = values[2]?.Match(_ariaLabelRegex)?.Groups[1]?.Value.Trim() ?? throw new InvalidOperationException("Failed to parse color name");
                var colorRGB = values[3] ?? throw new InvalidOperationException("Failed to parse color value");

                if (!colors.ContainsKey(colorId))
                {
                    colors[colorId] = new ColorData
                    {
                        Id = colorId,
                        Name = colorName,
                        RGB = colorRGB
                    };
                }

                return (cellId, colorId);
            })
        );

        StartState state = new()
        {
            SideLength = (int)Math.Sqrt(cellsInfo.Length),
            Colors = [.. colors.Values],
            CellColors = [.. cellsInfo.OrderBy(c => c.cellId).Select(c => c.colorId)]
        };

        return state;

    }

    public async ValueTask DisposeAsync()
    {
        if (_disposed) return;

        if (_page is not null)
        {
            await _page.CloseAsync();
        }

        if (_context is not null)
        {
            await _context.CloseAsync();
            await _context.DisposeAsync();
        }

        if (_browser is not null)
        {
            await _browser.CloseAsync();
            await _browser.DisposeAsync();
        }

        _playwright?.Dispose();
        _disposed = true;
    }

}
