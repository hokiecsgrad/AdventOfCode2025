using AdventOfCode.Common;

namespace AdventOfCode.Day09;

public class Solver
{
    public string SolvePart1(string[] data)
    {
        List<(long x, long y)> tiles = CreateRedTilePositions(data);
        long maxArea = 0;

        for (int i = 0; i < tiles.Count; i++)
        {
            for (int j = i + 1; j < tiles.Count; j++)
            {
                if (tiles[i].x == tiles[j].x || tiles[i].y == tiles[j].y)
                    continue;

                // Calculate Area between tiles
                long area = (Math.Abs(tiles[i].x - tiles[j].x)+1) * (Math.Abs(tiles[i].y - tiles[j].y)+1);
                maxArea = Math.Max(maxArea, area);
            }
        }

        return maxArea.ToString();
    }

    public string SolvePart2(string[] data)
    {
        List<(long col, long row)> tiles = CreateRedTilePositions(data);
        long maxArea = 0;

        char[,] grid = new char[tiles.Max(t => t.row) + 2, tiles.Max(t => t.col) + 3];
        for (int row = 0; row < grid.GetLength(0); row++)
            for (int col = 0; col < grid.GetLength(1); col++)
                grid[row, col] = '.';
        
        // Draw a path connecting all red tiles
        (long col, long row) prevTile = tiles[0];
        (long col, long row) currTile;
        for (int i = 1; i < tiles.Count; i++)
        {
            currTile = tiles[i];
            grid[prevTile.row, prevTile.col] = 'R';

            if (prevTile.col == currTile.col)
            {
                if (prevTile.row < currTile.row)
                    for (long row = prevTile.row+1; row < currTile.row; row++)
                        grid[row, currTile.col] = 'G';  
                else
                    for (long row = prevTile.row-1; row > currTile.row; row--)
                        grid[row, currTile.col] = 'G';  
            }
            else if (prevTile.row == currTile.row)
            {
                if (prevTile.col < currTile.col)
                    for (long col = prevTile.col+1; col < currTile.col; col++)
                        grid[currTile.row, col] = 'G';
                else
                    for (long col = prevTile.col-1; col > currTile.col; col--)
                        grid[currTile.row, col] = 'G';
            }
        
            grid[currTile.row, currTile.col] = 'R';
            prevTile = currTile;
        }

        currTile = tiles[0];
        grid[prevTile.row, prevTile.col] = 'R';

        if (prevTile.col == currTile.col)
        {
            if (prevTile.row < currTile.row)
                for (long row = prevTile.row+1; row < currTile.row; row++)
                    grid[row, currTile.col] = 'G';  
            else
                for (long row = prevTile.row-1; row > currTile.row; row--)
                    grid[row, currTile.col] = 'G';  
        }
        else if (prevTile.row == currTile.row)
        {
            if (prevTile.col < currTile.col)
                for (long col = prevTile.col+1; col < currTile.col; col++)
                    grid[currTile.row, col] = 'G';
            else
                for (long col = prevTile.col-1; col > currTile.col; col--)
                    grid[currTile.row, col] = 'G';
        }

        // walk grid to fill in all the green tiles
        prevTile = tiles[0];
        for (int i = 1; i < tiles.Count; i++)
        {
            currTile = tiles[i];

            // figure out direction to walk
            if (prevTile.col == currTile.col && prevTile.row < currTile.row)
            {
                for (long row = prevTile.row+1; row < currTile.row; row++)
                {
                    grid[row, currTile.col] = 'G';  
                    // turn right and fill in all spaces with green tiles
                    long currCol = prevTile.col-1;
                    while (grid[row, currCol] == '.')
                        grid[row, currCol--] = 'G';
                }
            }
            else if (prevTile.col == currTile.col && prevTile.row > currTile.row)
            {
                for (long row = prevTile.row-1; row > currTile.row; row--)
                {
                    grid[row, currTile.col] = 'G';  
                    // turn right and fill in all spaces with green tiles
                    long currCol = prevTile.col+1;
                    while (grid[row, currCol] == '.')
                        grid[row, currCol++] = 'G';
                }
                
            }
            else if (prevTile.row == currTile.row && prevTile.col < currTile.col)
            {
                for (long col = prevTile.col+1; col < currTile.col; col++)
                {
                    grid[currTile.row, col] = 'G';
                    // turn right and fill in all spaces with green tiles
                    long currRow = prevTile.row+1;
                    while (grid[currRow, col] == '.')
                        grid[currRow++, col] = 'G';
                }
            }
            else if (prevTile.row == currTile.row && prevTile.col > currTile.col)
            {
                for (long col = prevTile.col-1; col > currTile.col; col--)
                {
                    grid[currTile.row, col] = 'G';
                    // turn right and fill in all spaces with green tiles
                    long currRow = prevTile.row-1;
                    while (grid[currRow, col] == '.')
                        grid[currRow--, col] = 'G';
                }
            }
        
            prevTile = currTile;
        }

        currTile = tiles[0];

        // figure out direction to walk
        if (prevTile.col == currTile.col && prevTile.row < currTile.row)
        {
            for (long row = prevTile.row+1; row < currTile.row; row++)
            {
                grid[row, currTile.col] = 'G';  
                // turn right and fill in all spaces with green tiles
                long currCol = prevTile.col-1;
                while (grid[row, currCol] == '.')
                    grid[row, currCol--] = 'G';
            }
        }
        else if (prevTile.col == currTile.col && prevTile.row > currTile.row)
        {
            for (long row = prevTile.row-1; row > currTile.row; row--)
            {
                grid[row, currTile.col] = 'G';  
                // turn right and fill in all spaces with green tiles
                long currCol = prevTile.col+1;
                while (grid[row, currCol] == '.')
                    grid[row, currCol++] = 'G';
            }
        }
        else if (prevTile.row == currTile.row && prevTile.col < currTile.col)
        {
            for (long col = prevTile.col+1; col < currTile.col; col++)
            {
                grid[currTile.row, col] = 'G';
                // turn right and fill in all spaces with green tiles
                long currRow = prevTile.row+1;
                while (grid[currRow, col] == '.')
                    grid[currRow++, col] = 'G';
            }
        }
        else if (prevTile.row == currTile.row && prevTile.col > currTile.col)
        {
            for (long col = prevTile.col-1; col > currTile.col; col--)
            {
                grid[currTile.row, col] = 'G';
                // turn right and fill in all spaces with green tiles
                long currRow = prevTile.row-1;
                while (grid[currRow, col] == '.')
                    grid[currRow--, col] = 'G';
            }
        }

        // Now loop over all pairs of red tiles and find the area with the largest set of all green tiles
        for (int i = 0; i < tiles.Count; i++)
        {
            for (int j = i + 1; j < tiles.Count; j++)
            {
                if (tiles[i].row == tiles[j].row || tiles[i].col == tiles[j].col)
                    continue;

                // find top left corner
                (long topRow, long leftCol) = (Math.Min(tiles[i].row, tiles[j].row), Math.Min(tiles[i].col, tiles[j].col));
                // find bottom right corner
                (long bottomRow, long rightCol) = (Math.Max(tiles[i].row, tiles[j].row), Math.Max(tiles[i].col, tiles[j].col));

                // verify all tiles inside are green
                bool allGreen = true;
                for (long row = topRow; row <= bottomRow; row++)
                {
                    for (long col = leftCol; col <= rightCol; col++)
                    {
                        if (grid[row, col] != 'G' && grid[row, col] != 'R')
                        {
                            allGreen = false;
                            break;;
                        }
                    }
                    if (!allGreen)
                        break;
                }
                if (allGreen)
                {
                    // Calculate Area between tiles
                    long area = (Math.Abs(tiles[i].col - tiles[j].col)+1) * (Math.Abs(tiles[i].row - tiles[j].row)+1);
                    maxArea = Math.Max(maxArea, area);
                }
            }
        }

        // draw grid for debugging
        for (int row = 0; row < grid.GetLength(0); row++)
        {
            for (int col = 0; col < grid.GetLength(1); col++)
                Console.Write(grid[row, col]);
            
            Console.WriteLine();
        }

        return maxArea.ToString();
    }





    private List<(long col, long row)> CreateRedTilePositions(string[] data)
    {
        List<(long col, long row)> tiles = new();
        foreach (string line in data)
        {
            string[] parts = line.Split(',', StringSplitOptions.TrimEntries);
            tiles.Add((
                long.Parse(parts[0]),
                long.Parse(parts[1])
                ));
        }

        return tiles;
    }


}