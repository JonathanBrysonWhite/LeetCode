using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Solutions
{
    public partial class Solution
    {

        private struct QueueItem
        {
            public int r { get; set; }
            public int c { get; set; }
            public int numDiceRolls { get; set; }
        }
        public int SnakesAndLadders(int[][] board)
        {
            return Bfs(board);
        }


        private int Bfs(int[][] board)
        {
            Queue<QueueItem> bfsQueue = new();
            HashSet<int> visited = new();
            int n = board.Length;

            bfsQueue.Enqueue(new QueueItem { r = n - 1, c = 0, numDiceRolls = 0 });
            visited.Add(1);
            while(bfsQueue.TryDequeue(out QueueItem item))
            {

                //check next 6 squares - only 
                List<(int, int)> coordsToCheck = new();
                int nextNumDiceRolls = item.numDiceRolls + 1;
                (int currentR, int currentC) = (item.r, item.c);
                for(int i = 0; i < 6; i++)
                {
                    (int dy, int dx) = GetMovementVectorByCoords(currentR, currentC, n);
                    currentR += dy;
                    currentC += dx;
                    
                    int boustraphedonSquareValue = BoustraphedonCoordsToInt(currentR, currentC, n);
                    if (visited.Contains(boustraphedonSquareValue))
                        continue;
                    visited.Add(boustraphedonSquareValue);
                    if(boustraphedonSquareValue == n * n)
                    {
                        return nextNumDiceRolls;
                    }
                    int currentGridValue = board[currentR][currentC];
                    if(currentGridValue != -1)
                    {
                        (int nextR, int nextC) = IntToBoustraphedonCoords(currentGridValue, n);
                        QueueItem next = new()
                        {
                            r = nextR,
                            c = nextC,
                            numDiceRolls = nextNumDiceRolls
                        };
                        if (currentGridValue == n * n)
                            return nextNumDiceRolls;
                        bfsQueue.Enqueue(next);
                    }
                    else
                    {
                        QueueItem next = new()
                        {
                            r = currentR,
                            c = currentC,
                            numDiceRolls = nextNumDiceRolls
                        };
                        bfsQueue.Enqueue(next);
                    }
                }
            }
            return -1;
        }

        //returns movement vector with format (y, x)
        public (int, int) GetMovementVectorByCoords(int r, int c, int n)
        {
            //see if forward or backward row
            bool forward = (n - 1) % 2 == r % 2;
            if(forward)
            {
                if(c == n - 1)
                {
                    return (-1, 0);
                }
                else
                {
                    return (0, 1);
                }
            }
            else
            {
                if(c == 0)
                {
                    return (-1, 0);
                }
                else
                {
                    return (0, -1);
                }
            }
        }

        //r & c zero indexed - n is length of board edge
        private (int, int) IntToBoustraphedonCoords(int num, int n)
        {
            if (num > n * n)
                return (-1, -1);
            int r = n - ((num - 1)/ n) - 1;
            int remainder = (num - 1) % n;
            bool forwards = r % 2 == (n - 1) % 2;
            int c;
            if(forwards)
            {
                c = remainder;
            }
            else
            {
                c = n - remainder - 1;
            }
            return (r, c);
        }

        //r & c zero indexed - n is length of board edge
        public int BoustraphedonCoordsToInt(int r, int c, int n)
        {
            int max = n * n;
            int num = 0;

            num += (n - r - 1) * n;
            bool forwards = r % 2 == (n - 1) % 2;
            if(forwards)
            {
                num += (c + 1);
            }
            else
            {
                num += (n - c);
            }
            return num;
        }
    }
}
