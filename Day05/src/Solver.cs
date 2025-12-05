using AdventOfCode.Common;

namespace AdventOfCode.Day05;

public class Solver
{
    public string SolvePart1(string[] data)
    {
        int count = 0;

        int i = 0;
        
        List<(long start, long end)> ranges;
        ranges = ParseRanges(data, ref i);
        
        i++; // skip blank line
        
        while (i < data.Length)
        {
            long value = long.Parse(data[i]);
            foreach (var range in ranges)
            {
                if (value >= range.start && value <= range.end)
                {
                    count++;
                    break;
                }
            }
            i++;
        }

        return count.ToString();
    }

    public string SolvePart2(string[] data)
    {
        int i = 0;
        List<(long start, long end)> ranges;
        ranges = MergeRanges( ParseRanges(data, ref i) );

        long totalCount = 0;
        foreach (var range in ranges)
            totalCount += range.end - range.start + 1;

        return totalCount.ToString();
    }

    private List<(long start, long end)> ParseRanges(string[] data, ref int index)
    {
        List<(long start, long end)> ranges = new();
        while (data[index] != "")
        {
            string[] parts = data[index].Split('-', StringSplitOptions.TrimEntries);
            long min = long.Parse(parts[0]);
            long max = long.Parse(parts[1]);
            ranges.Add((start: (long)min, end: (long)max));
            index++;
        }

        ranges.Sort((a, b) => a.start.CompareTo(b.start));

        return ranges;
    }

    private List<(long start, long end)> MergeRanges(List<(long start, long end)> ranges)
    {
        List<(long start, long end)> merged = new();

        (long start, long end) current = ranges[0];
        for (int i = 1; i < ranges.Count; i++)
        {
            (long start, long end) next = ranges[i];
            if (next.start <= current.end + 1)
                current.end = Math.Max(current.end, next.end);
            else
            {
                merged.Add(current);
                current = next;
            }
        }

        merged.Add(current);

        return merged;
    }
}