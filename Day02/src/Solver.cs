using System.Text.RegularExpressions;
using AdventOfCode.Common;

namespace AdventOfCode.Day02;

public class Solver
{
    public string SolvePart1(string[] data)
    {
        long total = 0;
        List<string> pairs = data[0].Split(",").ToList();

        foreach (string pair in pairs)
        {
            long min = long.Parse(pair.Split("-")[0]);
            long max = long.Parse(pair.Split("-")[1]);
            for (long i = min; i <= max; i++)
            {
                string curr = i.ToString();
                if (curr.Length % 2 == 0)
                {
                    string left = curr[0..(curr.Length / 2)];
                    string right = curr[(curr.Length / 2)..(curr.Length)];
                    if (left == right) total += i;
                }
            }
        }

        return total.ToString();
    }

    public string SolvePart2(string[] data)
    {
        long total = 0;
        List<string> pairs = data[0].Split(",").ToList();

        foreach (string pair in pairs)
        {
            long min = long.Parse(pair.Split("-")[0]);
            long max = long.Parse(pair.Split("-")[1]);
            for (long i = min; i <= max; i++)
            {
                string curr = i.ToString();
                int testLen = curr.Length / 2;
                bool hasPattern = false;
                while (testLen > 0)
                {
                    if (curr.Length % testLen == 0)
                    {
                        int numTries = curr.Length / testLen;
                        string testPattern = curr[0..testLen];
                        bool match = true;
                        for (int j = 1; j < numTries; j++)
                        {
                            string nextPattern = curr[(j * testLen)..((j * testLen) + testLen)];
                            if (testPattern == nextPattern)
                                match = true;
                            else
                            { match = false; break; }
                        }
                        if (match) { hasPattern = true; break; }
                    }
                    testLen--;
                }
                if (hasPattern) total += i;
            }
        }

        return total.ToString();
    }
}