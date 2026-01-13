using Queens.Data;

namespace Queens.Interfaces.Core;

internal interface IGraph
{
    public IGraph Construct(GameDefinition definition);
}
