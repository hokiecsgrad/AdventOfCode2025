using AdventOfCode.Common;

namespace AdventOfCode.Day01;

public class Solver
{
    public string SolvePart1(string[] data)
    {
        int total = 0;

        int dial = 50;
        int max = 99;

        foreach (string line in data)
        {
            char turn = line[0];
            int distance = int.Parse(line[1..]);

            dial += turn == 'L' ? -distance : distance;
            dial %= max + 1;
            
            if (dial == 0) total++;
        }
        
        return total.ToString();
    }

    public string SolvePart2(string[] data)
    {
        int total = 0;

        int min = 0;
        int dial = 50;
        int max = 99;

        foreach (string line in data)
        {
            char turn = line[0];
            int direction = turn == 'L' ? -1 : 1;
            int distance = int.Parse(line[1..]);

            for (int i = 0; i < distance; i++)
            {
                dial += direction;
                if (dial < min) dial = max;
                if (dial > max) dial = min;
                if (dial == 0) total++;
            }
        }
        
        return total.ToString();
    }
}