using AdventOfCode.Common;
using AdventOfCode.Day02;
using Xunit;

namespace AdventOfCode.Day02.Tests;

public class Day02Tests
{
    public Day02Tests()
    {
        data = sampleInput.Split(
            '\n',
            StringSplitOptions.TrimEntries |
            StringSplitOptions.RemoveEmptyEntries
            );
    }

    [Fact]
    public void Part1_WithSampleData_ShouldBe1227775554()
    {
        Solver solver = new();
        string result = solver.SolvePart1(data);
        Assert.Equal("1227775554", result);
    }

    [Fact]
    public void Part2_WithSampleData_ShouldBe4174379265()
    {
        Solver solver = new();
        string result = solver.SolvePart2(data);
        Assert.Equal("4174379265", result);
    }

    private string[] data;
    private string sampleInput = "11-22,95-115,998-1012,1188511880-1188511890,222220-222224,1698522-1698528,446443-446449,38593856-38593862,565653-565659,824824821-824824827,2121212118-2121212124";
}
