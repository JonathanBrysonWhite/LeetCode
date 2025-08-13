using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public partial class Solution
    {
        public bool SearchMatrix(int[][] matrix, int target)
        {
            //binary search rows
            int m = matrix.Length;
            int n = matrix[0].Length;

            int low = 0, high = m - 1;
            int targetRow = -1;
            while(low <= high)
            {
                int mid = (low + high) / 2;
                if (matrix[mid][0] <= target && matrix[mid][n - 1] <= target)
                {
                    targetRow = mid;
                    break;
                }
                else if (target >= matrix[mid][0])
                {
                    low = mid + 1;
                }
                else if (target <= matrix[mid][0])
                {
                    high = mid - 1;
                }
            }
            if (targetRow == -1)
                return false;

            //now binary search the found row;
            low = 0;
            high = n - 1;
            while(low <= high)
            {
                int mid = (low + high) / 2;
                if (matrix[targetRow][mid] == target)
                    return true;
                else if (target >= matrix[targetRow][mid])
                    low = mid + 1;
                else if (target <= matrix[targetRow][mid])
                    high = mid - 1;
            }
            return false;
        }
    }
}
