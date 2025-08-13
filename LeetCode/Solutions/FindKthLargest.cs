using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public partial class Solution
    {
        Random _random = new Random();
        public int FindKthLargest(int[] nums, int k)
        {
            //k is always valid per boundary conditions
            int targetIndex = nums.Length - k;
            return QuickSelect(nums, 0, nums.Length - 1, targetIndex);
        }

        private int QuickSelect(int[] nums, int left, int right, int targetIndex)
        {
            if (left == right)
                return nums[left];
            int pivotIndex = _random.Next(left, right + 1);

            Swap(nums, pivotIndex, right);

            int finalPivotIndex = Partition(nums, left, right);

            if (targetIndex == pivotIndex)
                return nums[targetIndex];
            else if (targetIndex < finalPivotIndex)
                return QuickSelect(nums, left, finalPivotIndex - 1, targetIndex);
            else
                return QuickSelect(nums, finalPivotIndex + 1, right, targetIndex);
        }

        private int Partition(int[] nums, int left, int right)
        {
            int pivot = nums[right];
            int i = left - 1;
            for (int j = left; j <= right; j++)
            {
                if (nums[j] <= pivot)
                {
                    i++;
                    Swap(nums, i, j);
                }
            }
            Swap(nums, i + 1, right);
            return i + 1;
        }

        private void Swap(int[] nums, int a, int b)
        {
            int temp = nums[a];
            nums[a] = nums[b];
            nums[b] = temp;
        }
    }
}
