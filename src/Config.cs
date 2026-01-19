namespace Queens;

public interface IConfig
{
    public string UserAgent { get; }
    public string PageURL { get; }
    public bool Headless { get; }
    public CloudflareConfig Cloudflare { get; }
}

public readonly record struct CloudflareConfig
{
    public string AccountId { get; init; }
    public string QueueId { get; init; }
    public string ApiToken { get; init; }
}

internal readonly record struct Config : IConfig
{
    public string UserAgent { get; init; }
    public string PageURL { get; init; }
    public bool Headless { get; init; }
    public CloudflareConfig Cloudflare { get; init; }
}
