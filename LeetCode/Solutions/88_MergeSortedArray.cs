using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Solutions
{
    public partial class Solution
    {
        public void Merge(int[] nums1, int m, int[] nums2, int n)
        {
            int i = m - 1, j = n -1;
            int k = m + n - 1;
            while(j > 0)
            {
                if (i >= 0 && nums1[i] >= nums2[j])
                {
                    nums1[k] = nums1[i--];
                }
                else
                {
                    nums1[k] = nums2[j--];
                }
                k--;
            }
        }
    }
}
