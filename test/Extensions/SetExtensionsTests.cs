using Queens.Extensions;

using Shouldly;

namespace Tests.Extensions;

public class SetExtensionsTests
{
    [Fact]
    public void Combinations_WhenEmpty_ReturnsEmpty()
    {
        IReadOnlySet<int> set = new HashSet<int>();

        var actual = set.Combinations().ToList();

        Assert.Empty(actual);
    }

    [Fact]
    public void Combinations_WhenOneItem_ReturnsSingleCombination()
    {
        IReadOnlySet<int> set = new HashSet<int> { 5 };

        var actual = set.Combinations().ToList();

        Assert.Single(actual);
        Assert.True(actual[0].SetEquals(new HashSet<int> { 5 }));
    }

    [Fact]
    public void Combinations_WhenThreeItems_ReturnsAllNonEmptySubsets()
    {
        IReadOnlySet<int> set = new HashSet<int> { 1, 2, 3 };

        var actual = set.Combinations().ToList();

        var expected = new List<IReadOnlySet<int>>
        {
            new HashSet<int> { 1 },
            new HashSet<int> { 2 },
            new HashSet<int> { 3 },
            new HashSet<int> { 1, 2 },
            new HashSet<int> { 1, 3 },
            new HashSet<int> { 2, 3 },
            new HashSet<int> { 1, 2, 3 }
        };

        Assert.Equal(expected.Count, actual.Count);
        foreach (var expectedSet in expected)
        {
            Assert.Contains(actual, actualSet => actualSet.SetEquals(expectedSet));
        }
    }

    [Fact]
    public void Combinations_WhenLoopBreaks_ResetsEnumerator()
    {
        IReadOnlySet<int> set = new HashSet<int> { 1, 2, 3 };

        foreach (var combination in set.Combinations())
        {
            if (combination.Count == 2)
            {
                break;
            }
        }

        set.Combinations().First().Count.ShouldBe(1);
        set.Combinations().First().First().ShouldBe(1);

    }
}
