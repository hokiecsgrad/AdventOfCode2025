using AdventOfCode.Common;
using AdventOfCode.Day08;
using Xunit;

namespace AdventOfCode.Day08.Tests;

public class Day08Tests
{
    public Day08Tests()
    {
        data = sampleInput.Split(
            '\n',
            StringSplitOptions.TrimEntries |
            StringSplitOptions.RemoveEmptyEntries
            );
    }

    [Fact]
    public void Part1_WithSampleData_ShouldBe40()
    {
        Solver solver = new();
        string result = solver.SolvePart1(data);
        Assert.Equal("40", result);
    }

    [Fact]
    public void Part2_WithSampleData_ShouldBe25272()
    {
        Solver solver = new();
        string result = solver.SolvePart2(data);
        Assert.Equal("25272", result);
    }

    private string[] data;
    private string sampleInput = """
162,817,812
57,618,57
906,360,560
592,479,940
352,342,300
466,668,158
542,29,236
431,825,988
739,650,466
52,470,668
216,146,977
819,987,18
117,168,530
805,96,715
346,949,466
970,615,88
941,993,340
862,61,35
984,92,344
425,690,689
""";
}
