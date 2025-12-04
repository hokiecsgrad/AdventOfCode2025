using AdventOfCode.Common;
using AdventOfCode.Day04;
using Xunit;

namespace AdventOfCode.Day04.Tests;

public class Day04Tests
{
    public Day04Tests()
    {
        data = sampleInput.Split(
            '\n',
            StringSplitOptions.TrimEntries |
            StringSplitOptions.RemoveEmptyEntries
            );
    }

    [Fact]
    public void Part1_WithSampleData_ShouldBe13()
    {
        Solver solver = new();
        string result = solver.SolvePart1(data);
        Assert.Equal("13", result);
    }

    [Fact]
    public void Part2_WithSampleData_ShouldBe43()
    {
        Solver solver = new();
        string result = solver.SolvePart2(data);
        Assert.Equal("43", result);
    }

    private string[] data;
    private string sampleInput = """
..@@.@@@@.
@@@.@.@.@@
@@@@@.@.@@
@.@@@@..@.
@@.@@@@.@@
.@@@@@@@.@
.@.@.@.@@@
@.@@@.@@@@
.@@@@@@@@.
@.@.@@@.@.
""";
}
