using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Solutions
{
    public partial class Solution
    {
        public int RemoveElement(int[] nums, int val)
        {
            int k = nums.Length;
            int l = 0, r = k - 1;
            while(l < r)
            {
                if (nums[l] == val)
                {
                    Swap(nums, l, r);
                    r--;
                }
                else
                {
                    l++;
                }
            }
            return l;
        }
        private void Swap(int[] nums, int l, int r)
        {
            int temp = nums[l];
            nums[l] = nums[r];
            nums[r] = temp;
        }
    }
}
