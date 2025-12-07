using AdventOfCode.Common;
using AdventOfCode.Day07;
using Xunit;

namespace AdventOfCode.Day07.Tests;

public class Day07Tests
{
    public Day07Tests()
    {
        data = sampleInput.Split(
            '\n',
            StringSplitOptions.TrimEntries |
            StringSplitOptions.RemoveEmptyEntries
            );
    }

    [Fact]
    public void Part1_WithSampleData_ShouldBe21()
    {
        Solver solver = new();
        string result = solver.SolvePart1(data);
        Assert.Equal("21", result);
    }

    [Fact]
    public void Part2_WithSampleData_ShouldBe40()
    {
        Solver solver = new();
        string result = solver.SolvePart2(data);
        Assert.Equal("40", result);
    }

    private string[] data;
    private string sampleInput = """
.......S.......
...............
.......^.......
...............
......^.^......
...............
.....^.^.^.....
...............
....^.^...^....
...............
...^.^...^.^...
...............
..^...^.....^..
...............
.^.^.^.^.^...^.
...............
""";
}
