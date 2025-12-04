using AdventOfCode.Common;

namespace AdventOfCode.Day04;

public class Solver
{
    public string SolvePart1(string[] data)
    {
        char[,] grid = CreateGrid(data);
        int total = 0;

        for (int row = 0; row < data.Length; row++)

            for (int col = 0; col < data[row].Length; col++)

                if (grid[row,col] == '@' && CountNeighbors(grid, row, col) < 4)
                    total++;

        return total.ToString();
    }

    public string SolvePart2(string[] data)
    {
        char[,] grid = CreateGrid(data);
        char[,] nextGrid = new char[grid.GetLength(0), grid.GetLength(1)];
        Array.Copy(grid, nextGrid, grid.GetLength(0) * grid.GetLength(1));
        int total = 0;
        int numMoved = 0;

        do
        {
            numMoved = 0;
            for (int row = 0; row < data.Length; row++)

                for (int col = 0; col < data[row].Length; col++)

                    if (grid[row,col] == '@' && CountNeighbors(grid, row, col) < 4)
                    {
                        numMoved++;
                        nextGrid[row, col] = '.';
                    }

            Array.Copy(nextGrid, grid, grid.GetLength(0) * grid.GetLength(1));
            total += numMoved;
        } while (numMoved > 0);

        return total.ToString();
    }

    public char[,] CreateGrid(string[] data)
    {
        char[,] grid = new char[data.Length, data[0].Length];

        for (int row = 0; row < data.Length; row++)
            for (int col = 0; col < data[row].Length; col++)
                grid[row, col] = data[row][col];

        return grid;
    }    

    private int CountNeighbors(char[,] grid, int row, int col)
    {
        int neighbors = 0;
        for (int i = -1; i <= 1; i++)
        {
            for (int j = -1; j <= 1; j++)
            {
                if (i == 0 && j == 0) continue;
                if (row + i < 0 || row + i >= grid.GetLength(0)) continue;
                if (col + j < 0 || col + j >= grid.GetLength(1)) continue;

                if (grid[row + i, col + j] == '@')
                {
                    neighbors++;
                }
            }
        }
        return neighbors;
    }
}