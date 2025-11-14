using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Solutions
{
    public partial class Solution
    {
        public int RemoveDuplicates(int[] nums)
        {
            int k = nums.Length;
            int j = 0;
            for(int i = 0; i < nums.Length - 1; i++)
            {
                nums[j++] = nums[i];
                while (i < nums.Length - 1 && nums[i] == nums[i + 1])
                {
                    i++;
                    k--;
                }
            }
            return k;
        }
    }
}
