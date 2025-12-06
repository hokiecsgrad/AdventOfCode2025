using AdventOfCode.Common;
using AdventOfCode.Day06;
using Xunit;

namespace AdventOfCode.Day06.Tests;

public class Day06Tests
{
    public Day06Tests()
    {
        data = File.ReadAllLines("sampleInput.txt");

    }

    [Fact]
    public void Part1_WithSampleData_ShouldBe4277556()
    {
        Solver solver = new();
        string result = solver.SolvePart1(data);
        Assert.Equal("4277556", result);
    }

    [Fact]
    public void Part2_WithSampleData_ShouldBe3263827()
    {
        Solver solver = new();
        string result = solver.SolvePart2(data);
        Assert.Equal("3263827", result);
    }

    private string[] data;
}
