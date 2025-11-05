using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Solutions
{
    public partial class Solution
    {
        public string MergeAlternately(string word1, string word2)
        {
            int l1 = word1.Length;
            int l2 = word2.Length;
            int p1 = 0, p2 = 0;
            StringBuilder sb = new StringBuilder(l1 + l2);
            while(p1 < l1 && p2 < l2)
            {
                sb.Append(word1[p1++].ToString() + word2[p2++].ToString());
            }
            while(p1 < l1)
            {
                sb.Append(word1[p1++].ToString());
            }
            while(p2 < l2)
            {
                sb.Append(word2[p2++].ToString());
            }
            return sb.ToString();
        }
    }
}
