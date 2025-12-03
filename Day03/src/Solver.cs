using AdventOfCode.Common;

namespace AdventOfCode.Day03;

public class Solver
{
    public string SolvePart1(string[] data)
    {
        long total = 0;
        int digitLength = 2;

        total = SolvePuzzle(data, digitLength);

        return total.ToString();
    }

    public string SolvePart2(string[] data)
    {
        long total = 0;
        int digitLength = 12;

        total = SolvePuzzle(data, digitLength);

        return total.ToString();
    }

    private long SolvePuzzle(string[] data, int digitLength)
    {
        long total = 0;

        foreach (string line in data)
        {
            long lineTotal = 0;
            int max = 0;
            int maxPos = -1;

            for (int i = 1; i <= digitLength; i++)
            {
                (max, maxPos) = FindLargestDigit(line, maxPos + 1, line.Length - (digitLength - i) - 1);
                lineTotal += max * (long)Math.Pow(10, digitLength - i);
            }

            total += lineTotal;        
        }

        return total;
    }

    private (int, int) FindLargestDigit(string line, int startPos = 0, int endPos = -1)
    {
        int max = 0;
        int maxPos = -1;
        for (int i = startPos; i <= endPos; i++)
        {
            int curr = (int)Char.GetNumericValue(line[i]);
            if (curr == 9) { max = 9; maxPos = i; break; }
            if (curr > max) { max = curr; maxPos = i; }
        }
        return (max, maxPos);
    }
}