using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Solutions
{
    internal partial class Solution
    {
        public int FindKthLargest(int[] nums, int k)
        {
            PriorityQueue<int, int> minHeap = new PriorityQueue<int, int>();
            for(int i = 0; i < nums.Length; i++)
            {
                if(minHeap.Count < k)
                {
                    minHeap.Enqueue(nums[i], nums[i]);
                }
                else
                {
                    if (nums[i] > minHeap.Peek())
                    {
                        minHeap.Dequeue();
                        minHeap.Enqueue(nums[i], nums[i]);
                    }
                }
            }
            return minHeap.Peek();
        }
    }
}
