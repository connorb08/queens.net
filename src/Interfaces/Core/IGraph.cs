using Queens.Data;

namespace Queens.Interfaces;

internal interface IGraph
{

    public GameSolution Solve(GameDefinition definition);

}
