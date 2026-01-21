using System.Net.Http.Headers;
using System.Net.Http.Json;

using Queens.Data;

namespace Queens.Controllers;

public sealed class Publisher(ILogger<Publisher> logger, IConfig config) : IDisposable
{
    private bool _disposed;
    private readonly Uri _uri = new($"https://api.cloudflare.com/client/v4/accounts/{config.Cloudflare.AccountId}/queues/{config.Cloudflare.QueueId}/messages");
    private readonly HttpClient _httpClient = new()
    {
        DefaultRequestHeaders =
        {
            Authorization = new AuthenticationHeaderValue("Bearer", config.Cloudflare.ApiToken),
        },
    };

    public async Task PublishSolution(ISolution solution)
    {
        try
        {
            string accountId = config.Cloudflare.AccountId;
            string queueId = config.Cloudflare.QueueId;
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync(_uri, new CloudflareDTO(solution, []));
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            logger.LogInformation($"Response: {responseBody}");
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "An error occurred while publishing the solution.");
            throw;
        }
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    private void Dispose(bool shouldDispose)
    {
        if (!_disposed)
        {
            if (shouldDispose)
            {
                _httpClient?.Dispose();
            }
            _disposed = true;
        }
    }

}
