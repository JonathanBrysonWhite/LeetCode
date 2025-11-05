using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Solutions
{
    public partial class Solution
    {
        public double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            int na = nums1.Length, nb = nums2.Length;
            int n = na + nb;
            if(n % 2 == 0)
            {
                return (Solve(nums1, nums2, n / 2, 0, na - 1, 0, nb - 1) +
                    Solve(nums1, nums2, n / 2 - 1, 0, na - 1, 0, nb - 1))
                    / 2;
            }
            return Solve(nums1, nums2, n / 2, 0, na - 1, 0, nb - 1);
        }

        private double Solve(int[] A, int[] B, int k, int aStart, int aEnd, int bStart, int bEnd)
        {
            if(aStart > aEnd)
            {
                return B[k - aStart];
            }
            if(bStart > bEnd)
            {
                return A[k - bStart];
            }
            int aIndex = (aStart + aEnd) / 2;
            int bIndex = (bStart + bEnd) / 2;
            int aValue = A[aIndex];
            int bValue = B[bIndex];

            if (aIndex + bIndex < k)
            {
                if (aValue < bValue)
                    return Solve(A, B, k, aIndex + 1, aEnd, bStart, bEnd);
                else
                    return Solve(A, B, k, aStart, aEnd, bIndex + 1, bEnd);
            }
            else
            {
                if (aValue < bValue)
                    return Solve(A, B, k, aStart, aEnd, bStart, bIndex - 1);
                else
                    return Solve(A, B, k, aStart, aIndex - 1, bStart, bEnd);
            }
        }
    }
}
