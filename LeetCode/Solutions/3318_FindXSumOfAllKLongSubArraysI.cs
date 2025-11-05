using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Solutions
{
    public partial class Solution
    {
        public int[] FindXSum(int[] nums, int k, int x)
        {
            int n = nums.Length;
            int[] ans = new int[n - k + 1];
            Dictionary<int, int> freqs = new Dictionary<int, int>();
            for(int i = 0; i < k; i++)
            {
                if (freqs.ContainsKey(nums[i]))
                    freqs[nums[i]]++;
                else
                    freqs.Add(nums[i], 1);
            }
            ans[0] = CalculateXSum(freqs, x);

            for(int i = 1; i < n - k + 1; i++)
            {
                int outNum = nums[i - 1];
                int inNum = nums[i + k - 1];
                freqs[outNum]--;
                if (freqs[outNum] == 0)
                    freqs.Remove(outNum);
                if (freqs.ContainsKey(inNum))
                    freqs[inNum]++;
                else
                    freqs.Add(inNum, 1);
                ans[i] = CalculateXSum(freqs, x);
            }
            return ans;
        }

        private int CalculateXSum(Dictionary<int, int> freqs, int x)
        {
            var pq = new PriorityQueue<(int num, int frequency), (int frequency, int num)>(
                Comparer<(int frequency, int num)>.Create((a, b) =>
                {
                    int cmp = b.frequency.CompareTo(a.frequency);
                    return cmp != 0 ? cmp : b.num.CompareTo(a.num);
                })
            );

            foreach(var kv in freqs)
            {
                pq.Enqueue((kv.Key, kv.Value), (kv.Value, kv.Key));
            }

            int sum = 0;
            int count = 0;
            while(pq.Count > 0 && count < x)
            {
                var (num, freqVal) = pq.Dequeue();
                sum += num * freqVal;
                count++;
            }

            return sum;
        }
    }
}
