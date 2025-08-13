using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public partial class Solution
    {
        public void Rotate1(int[] nums, int k)
        {
            int len = nums.Length;
            int rotationFactor = NormalizeIndex((len - k) % len, len);
            int[] copy = new int[len];
            Array.Copy(nums, copy, len);
            for (int i = 0; i < len; i++)
            {
                nums[i] = copy[(i + rotationFactor) % len];
            }
            Console.WriteLine(string.Join(", ", nums));
        }

        private int NormalizeIndex(int i, int len)
        {
            if (i >= 0) return i;
            return NormalizeIndex(len + i, len);
        }

        public void Rotate(int[] nums, int k)
        {
            Array.Reverse(nums);
            int rotationPoint = k % nums.Length;
            Array.Reverse(nums, 0, rotationPoint);
            Array.Reverse(nums, rotationPoint, nums.Length - rotationPoint);
            Console.WriteLine(string.Join(", ", nums));
        }
    }
}
