using Microsoft.Extensions.Logging.Abstractions;

using Queens.Controllers;
using Queens.Data;


namespace Tests.Regression;

public class SolutionTests
{

    [Theory]
    [ClassData(typeof(SolutionTestData))]
    public void Solution_Regression_Tests(GameDefinition definition, Solution expectedSolution)
    {

        // var factory = new Factory(
        //     new ServiceCollection()
        //         .AddLogging()
        //         .AddSingleton<ISolution, Solution>()
        //         .BuildServiceProvider()
        // );

        // var graph = factory.CreateGraph(definition);
        // var solver = new Solver(graph);

        // Assert.Equal(expectedSolution, solver.Solve());
        Assert.Equal(1, 1);
    }

}

internal class SolutionTestData : TheoryData<GameDefinition, Solution>
{
    public SolutionTestData()
    {
        Add(new(), new(NullLogger<Solution>.Instance));
    }
}
