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
        long total = 0;

        char[,] grid = CreateGrid(data);

        int maxRows = grid.GetLength(0) - 1;
        int maxCols = grid.GetLength(1) - 1;

        List<long> values = new();
        char currOperator = ' ';
        for (int i = 0; i <= maxCols; i++)
        {
            // read number vertically
            string buildNum = "";
            for (int numIndex = 0; numIndex < maxRows; numIndex++)
                buildNum += grid[numIndex, i].ToString();
            if (!string.IsNullOrWhiteSpace(buildNum)) values.Add(long.Parse(buildNum));

            // read operator
            if (grid[maxRows, i] != ' ')
                currOperator = grid[maxRows, i];

            // if vertical number is empty, run calculations and add to total
            if (string.IsNullOrWhiteSpace(buildNum) || i == maxCols)
            {
                long answer = currOperator == '+' ? 0 : 1;
                foreach (long val in values)
                {
                    switch (currOperator)
                    {
                        case '+': answer += val; break;
                        case '*': answer *= val; break;
                    }
                }
                total += answer;
                values = new();
            }
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