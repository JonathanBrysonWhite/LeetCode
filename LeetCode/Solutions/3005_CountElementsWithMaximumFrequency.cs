using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Solutions
{
    public partial class Solution
    {
        public int MaxFrequencyElements(int[] nums)
        {
            Dictionary<int, int> frequencies = [];
            int maxFrequency = -1;
            int finalCount = 0;
            foreach(int n in nums)
            {
                if(frequencies.ContainsKey(n))
                {
                    frequencies[n]++;
                }
                else
                {
                    frequencies.Add(n, 1);
                }
            }
            foreach(int n in frequencies.Keys)
            {
                if (frequencies[n] > maxFrequency)
                {
                    maxFrequency = frequencies[n];
                    finalCount = maxFrequency;
                }
                else if (frequencies[n] == maxFrequency)
                {
                    finalCount += maxFrequency;
                }
            }
            return finalCount;
        }
    }
}
