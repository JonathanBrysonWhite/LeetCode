using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Solutions
{
    public partial class Solution
    {

        Queue<(int, int)> bfsQueue = new();
        List<(int, int)> vectors = new() { (1, 0), (0, 1), (-1, 0), (0, -1) };

        public int NumIslands(char[][] grid)
        {
            int m = grid.Length;
            int n = grid[0].Length;
            int numIslands = 0;
            bool[,] visited = new bool[m,n];

            void Bfs(int i, int j)
            {
                bfsQueue.Enqueue((i, j));
                visited[i, j] = true;
                while(bfsQueue.TryDequeue(out (int, int) coords))
                {
                    (int y, int x) = coords;
                    foreach((int, int) vector in vectors)
                    {
                        (int dy, int dx) = vector;
                        int ny = dy + y;
                        int nx = dx + x;
                        if(nx >= 0 && nx < n && ny >= 0 && ny < m && !visited[ny, nx] && grid[ny][nx] == '1')
                        {
                            visited[ny, nx] = true;
                            bfsQueue.Enqueue((ny, nx));
                        }
                    }
                }
            }

            for(int i = 0; i < m; i++)
            {
                for(int j = 0; j < n; j++)
                {
                    if (!visited[i,j] && grid[i][j] == '1')
                    {
                        //bfs here
                        Bfs(i, j);
                        numIslands++;
                    }
                }
            }
            return numIslands;
        }
    }
}
