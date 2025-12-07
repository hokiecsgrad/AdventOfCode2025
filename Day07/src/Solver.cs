using AdventOfCode.Common;

namespace AdventOfCode.Day07;

public class Solver
{
    public string SolvePart1(string[] data)
    {
        char[,] grid = CreateGrid(data);

        Stack<(int row, int col)> laserPositions = new();
        (int row, int col) startPos = FindCharPos(grid, 'S');
        laserPositions.Push(startPos);

        // DrawGrid(grid);

        int numBeamSplits = 0;
        while (laserPositions.Count > 0)
        {
            (int row, int col) currPos = laserPositions.Pop();
            if (currPos.row == grid.GetLength(0) - 1)
            {
                continue;
            }
            if (grid[currPos.row + 1, currPos.col] == '.')
            {
                grid[currPos.row + 1, currPos.col] = '|';
                laserPositions.Push((currPos.row + 1, currPos.col));
            }
            else if (grid[currPos.row + 1, currPos.col] == '^')
            {
                numBeamSplits++;
                grid[currPos.row + 1, currPos.col - 1] = '|';
                laserPositions.Push((currPos.row + 1, currPos.col - 1));
                grid[currPos.row + 1, currPos.col + 1] = '|';
                laserPositions.Push((currPos.row + 1, currPos.col + 1));
            }

            //DrawGrid(grid);
            //System.Threading.Thread.Sleep(500);

        }

        // DrawGrid(grid);
        return numBeamSplits.ToString();
    }

    public string SolvePart2(string[] data)
    {
        char[,] grid = CreateGrid(data);

        // create a cache for memoization
        long[,] gridCache = new long[grid.GetLength(0), grid.GetLength(1)];
        for (int row = 0; row < grid.GetLength(0); row++)
            for (int col = 0; col < grid.GetLength(1); col++)
                gridCache[row, col] = 0;

        // find the start position
        (int row, int col) startPos = FindCharPos(grid, 'S');

        // recursively test out all the paths
        long uniquePaths = FindPaths(grid, (startPos.row + 1, startPos.col), gridCache);

        return uniquePaths.ToString();
    }

    private long FindPaths(char[,] grid, (int row, int col) currPos, long[,] gridCache)
    {
        while (currPos.row <= grid.GetLength(0) - 1 && grid[currPos.row, currPos.col] == '.')
            currPos.row++;
        if (currPos.row > grid.GetLength(0) - 1) return 1;

        long numPaths = 0;
        if (grid[currPos.row, currPos.col] == '^')
        {
            if (gridCache[currPos.row, currPos.col] != 0)
                return gridCache[currPos.row, currPos.col];
            else
            {
                numPaths = FindPaths(grid, (currPos.row, currPos.col - 1), gridCache);
                numPaths += FindPaths(grid, (currPos.row, currPos.col + 1), gridCache);
            }
        }

        gridCache[currPos.row, currPos.col] = numPaths;

        return numPaths;
    }

    private char[,] CreateGrid(string[] data)
    {
        char[,] grid = new char[data.Length, data[0].Length];

        for (int row = 0; row < data.Length; row++)
            for (int col = 0; col < data[row].Length; col++)
                grid[row, col] = data[row][col];

        return grid;
    }

    private (int, int) FindCharPos(char[,] grid, char target)
    {
        for (int row = 0; row < grid.GetLength(0); row++)
            for (int col = 0; col < grid.GetLength(1); col++)
                if (grid[row, col] == target) return (row, col);

        return (-1, -1);
    }

    private void DrawGrid(char[,] grid)
    {
        Console.Clear();
        for (int row = 0; row < grid.GetLength(0); row++)
        {
            for (int col = 0; col < grid.GetLength(1); col++)
                Console.Write(grid[row, col]);
            Console.WriteLine();
        }
    }

}