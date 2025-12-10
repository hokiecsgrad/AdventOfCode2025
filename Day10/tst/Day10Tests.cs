using AdventOfCode.Common;
using AdventOfCode.Day10;
using Xunit;

namespace AdventOfCode.Day10.Tests;

public class Day10Tests
{
    public Day10Tests()
    {
        data = sampleInput.Split(
            '\n',
            StringSplitOptions.TrimEntries |
            StringSplitOptions.RemoveEmptyEntries
            );
    }

    [Fact]
    public void Part1_WithSampleData_ShouldBe7()
    {
        Solver solver = new();
        string result = solver.SolvePart1(data);
        Assert.Equal("7", result);
    }

    [Fact]
    public void Part2_WithSampleData_ShouldBe33()
    {
        Solver solver = new();
        string result = solver.SolvePart2(data);
        Assert.Equal("33", result);
    }

    private string[] data;
    private string sampleInput = """
[.##.] (3) (1,3) (2) (2,3) (0,2) (0,1) {3,5,4,7}
[...#.] (0,2,3,4) (2,3) (0,4) (0,1,2) (1,2,3,4) {7,5,12,7,2}
[.###.#] (0,1,2,3,4) (0,3,4) (0,1,2,4,5) (1,2) {10,11,11,5,10,5}
""";
}
