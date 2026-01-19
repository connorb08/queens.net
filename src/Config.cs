namespace Queens;

internal interface IConfig
{
    public string UserAgent { get; }
    public string PageURL { get; }
    public bool Headless { get; }
    public ICloudflareConfig Cloudflare { get; }
}

internal interface ICloudflareConfig
{
    public string AccountId { get; }
    public string QueueId { get; }
    public string ApiToken { get; }
}

internal readonly record struct Config : IConfig
{
    public string UserAgent { get; init; }
    public string PageURL { get; init; }
    public bool Headless { get; init; }
    public ICloudflareConfig Cloudflare { get; init; }
}
