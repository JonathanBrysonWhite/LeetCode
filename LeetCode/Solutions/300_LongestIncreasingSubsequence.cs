using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Solutions
{
    public partial class Solution
    {
        public int LengthOfLIS(int[] nums)
        {
            List<int> lisList = new List<int>();
            foreach (int num in nums)
            {
                if (lisList.Count == 0)
                {
                    lisList.Add(num);
                    continue;
                }
                if (num > lisList[lisList.Count - 1])
                {
                    lisList.Add(num);
                    continue;
                }
                else
                {
                    int i = lisList.BinarySearch(num);

                    if(i < 0)
                    {
                        i = ~i;
                    }
                    lisList[i] = num;
                }
            }
            return lisList.Count;
        }
    }
}
