using Queens.Data;

namespace Queens.Interfaces;

internal interface IPageController : IAsyncDisposable
{
    public Task<GameDefinition> GetGameDefinition();
}
