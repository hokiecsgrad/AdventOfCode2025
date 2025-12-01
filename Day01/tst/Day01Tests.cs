using AdventOfCode.Common;
using AdventOfCode.Day01;
using Xunit;

namespace AdventOfCode.Day01.Tests;

public class Day01Tests
{
    public Day01Tests()
    {
        data = sampleInput.Split(
            '\n',
            StringSplitOptions.TrimEntries |
            StringSplitOptions.RemoveEmptyEntries
            );
    }

    [Fact]
    public void Part1_WithSampleData_ShouldBe3()
    {
        Solver solver = new Solver();
        string result = solver.SolvePart1(data);
        Assert.Equal("3", result);
    }

    [Fact]
    public void Part2_WithSampleData_ShouldBe6()
    {
        Solver solver = new Solver();
        string result = solver.SolvePart2(data);
        Assert.Equal("6", result);
    }

    private readonly string[] data;
    private string sampleInput = """
L68
L30
R48
L5
R60
L55
L1
L99
R14
L82
""";
}
