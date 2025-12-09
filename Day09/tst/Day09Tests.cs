using AdventOfCode.Common;
using AdventOfCode.Day09;
using Xunit;

namespace AdventOfCode.Day09.Tests;

public class Day09Tests
{
    public Day09Tests()
    {
        data = sampleInput.Split(
            '\n',
            StringSplitOptions.TrimEntries |
            StringSplitOptions.RemoveEmptyEntries
            );
    }

    [Fact]
    public void Part1_WithSampleData_ShouldBe50()
    {
        Solver solver = new();
        string result = solver.SolvePart1(data);
        Assert.Equal("50", result);
    }

    [Fact]
    public void Part2_WithSampleData_ShouldBe24()
    {
        Solver solver = new();
        string result = solver.SolvePart2(data);
        Assert.Equal("24", result);
    }

    private string[] data;
    private string sampleInput = """
7,1
11,1
11,7
9,7
9,5
2,5
2,3
7,3
""";
}
