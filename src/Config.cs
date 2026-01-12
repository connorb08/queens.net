namespace Queens;

internal interface IConfig
{
    public string UserAgent { get; }
    public string PageURL { get; }
    public bool Headless { get; }
}

internal readonly record struct Config : IConfig
{
    public string UserAgent { get; init; }
    public string PageURL { get; init; }
    public bool Headless { get; init; }
}
