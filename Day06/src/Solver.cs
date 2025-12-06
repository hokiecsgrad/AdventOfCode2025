using System.Numerics;
using AdventOfCode.Common;

namespace AdventOfCode.Day06;

public class Solver
{
    public string SolvePart1(string[] data)
    {
        long total = 0;

        List<List<string>> values = new();
        for (int i = 0; i < data.Length; i++)
            values.Add(data[i].Split(" ", StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries).ToList());

        for (int col = 0; col < values[0].Count; col++)
        {
            char operation = values[values.Count - 1][col][0];
            long answer = operation == '+' ? 0 : 1;
            for (int row = 0; row < values.Count - 1; row++)
            {
                switch (operation)
                {
                    case '+': answer += int.Parse(values[row][col]); break;
                    case '*': answer *= int.Parse(values[row][col]); break;
                }
            }
            total += answer;
        }

        return total.ToString();
    }

    public string SolvePart2(string[] data)
    {
        BigInteger total = 0;

        char[,] grid = CreateGrid(data);

        int maxRows = grid.GetLength(0) - 1;
        int maxCols = grid.GetLength(1) - 1;

        int numProbs = 0;
        for (int col = 0; col <= maxCols; col++)
            if (grid[maxRows, col] != ' ') numProbs++;

        int minCol = -1;
        int maxCol = -1;
        int currCol = 0;
        for (int i = 1; i <= numProbs; i++)
        {
            // find first occurance of operator
            while (currCol < maxCols && grid[maxRows, currCol] == ' ') currCol++;
            minCol = currCol;

            if (minCol > maxCols) break;

            BigInteger answer = grid[maxRows, minCol] == '+' ? 0 : 1;

            // find next occurance of operator and set maxCol to that -2
            currCol++;
            while (currCol <= maxCols && grid[maxRows, currCol] == ' ') currCol++;
            if (currCol >= maxCols)
                maxCol = maxCols;
            else
                maxCol = currCol - 2;

            // build first number from maxCol
            currCol = maxCol;
            while (currCol >= minCol)
            {
                string buildNum = "";
                for (int j = 0; j < maxRows; j++)
                    buildNum += grid[j, currCol].ToString();

                long currNum = long.Parse(buildNum);
                switch (grid[maxRows, minCol])
                {
                    case '+': answer += currNum; break;
                    case '*': answer *= currNum; break;
                }
                currCol--;
            }

            total += answer;

            currCol = maxCol + 1;
        }

        return total.ToString();
    }

    private char[,] CreateGrid(string[] data)
    {
        char[,] grid = new char[data.Length, data[0].Length];

        for (int row = 0; row < data.Length; row++)
            for (int col = 0; col < data[row].Length; col++)
                grid[row, col] = data[row][col];

        return grid;
    }

}