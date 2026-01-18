using Queens.Data;

namespace Queens.Controllers;

public sealed class Solution(
    ILogger<Solution> logger
)
{
    private readonly GameSolution _solution = new();
    public void Publish()
    {
        logger.LogInformation("Solution found: {Solution}", _solution.ToJson());
    }
}
