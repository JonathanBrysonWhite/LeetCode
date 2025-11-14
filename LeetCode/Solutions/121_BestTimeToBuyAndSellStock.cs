using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Solutions
{
    public partial class Solution
    {
        public int MaxProfit(int[] prices)
        {
            int minSoFar = prices[0];
            int maxProfit = 0;
            if(prices.Length ==1)
            {
                return maxProfit;
            }
            for(int i = 1; i < prices.Length; i++)
            {
                if (prices[i] < minSoFar)
                {
                    minSoFar = prices[i];
                }
                else if (prices[i] - minSoFar > maxProfit)
                {
                    maxProfit = prices[i] - minSoFar;
                }
            }
            return maxProfit;
        }
    }
}
