using AdventOfCode.Common;
using AdventOfCode.Day05;
using Xunit;

namespace AdventOfCode.Day05.Tests;

public class Day05Tests
{
    public Day05Tests()
    {
        data = sampleInput.Split(
            '\n',
            StringSplitOptions.TrimEntries
            );
    }

    [Fact]
    public void Part1_WithSampleData_ShouldBe3()
    {
        Solver solver = new();
        string result = solver.SolvePart1(data);
        Assert.Equal("3", result);
    }

    [Fact]
    public void Part2_WithSampleData_ShouldBe14()
    {
        Solver solver = new();
        string result = solver.SolvePart2(data);
        Assert.Equal("14", result);
    }

    private string[] data;
    private string sampleInput = """
3-5
10-14
16-20
12-18

1
5
8
11
17
32
""";
}
