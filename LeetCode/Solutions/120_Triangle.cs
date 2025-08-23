using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Solutions
{
    public partial class Solution
    {
        public int MinimumTotal(IList<IList<int>> triangle)
        {

            //iterate from bottom to top of triangle

            //for n - 2th row, look at columns j and j+1 for the i + 1th row
            //pick the lesser of those two values and add them to the current value
            //iterate til at the top of the triangle, return dp[0][0]

            List<List<int>> input = triangle.Select(x => x.ToList()).ToList();
            //create 2d array representing sum of total to get from bottom to current point
            List<List<int>> dp = new List<List<int>>();
            for (int i = 0; i < input.Count; i++)
            {
                List<int> rowToAdd = new List<int>(input[i].Count);
                dp.Add(rowToAdd);
            }

            //instantiate n-1th row of sums as the base case
            int n = input.Count;
            for (int j = 0; j < input[n - 1].Count; j++)
            {
                dp[n - 1].Add(input[n - 1][j]);
            }

            for (int i = n - 2; i >= 0; i--)
            {
                int m = input[i].Count;
                for (int j = 0; j < m; j++)
                {
                    int l = dp[i + 1][j];
                    int r = dp[i + 1][j + 1];
                    if (l < r)
                    {
                        dp[i].Add(l + input[i][j]);
                    }
                    else
                    {
                        dp[i].Add(r + input[i][j]);
                    }
                }
            }
            return dp[0][0];
        }

        public int MinimumTotalOptimized(IList<IList<int>> triangle)
        {
            int m = triangle.Count;
            // start with last row
            int[] dp = triangle[m - 1].ToArray();

            for (int i = m - 2; i >= 0; i--)
            {
                for (int j = 0; j < triangle[i].Count; j++)
                {
                    dp[j] = Math.Min(dp[j], dp[j + 1]) + triangle[i][j];
                }
            }

            return dp[0];
        }
    }
}
