using AdventOfCode.Common;
using AdventOfCode.Day03;
using Xunit;

namespace AdventOfCode.Day03.Tests;

public class Day03Tests
{
    public Day03Tests()
    {
        data = sampleInput.Split(
            '\n',
            StringSplitOptions.TrimEntries |
            StringSplitOptions.RemoveEmptyEntries
            );
    }

    [Fact]
    public void Part1_WithSampleData_ShouldBe357()
    {
        Solver solver = new();
        string result = solver.SolvePart1(data);
        Assert.Equal("357", result);
    }

    [Fact]
    public void Part2_WithSampleData_ShouldBe3121910778619()
    {
        Solver solver = new();
        string result = solver.SolvePart2(data);
        Assert.Equal("3121910778619", result);
    }

    private string[] data;
    private string sampleInput = """
987654321111111
811111111111119
234234234234278
818181911112111
""";
}
