using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Solutions
{
    public partial class Solution
    {
        public bool IsSubsequence(string s, string t)
        {
            if(s.Length > t.Length)
            {
                return false;
            }
            int m = s.Length, n = t.Length;
            int sIdx = 0, tIdx = 0;

            while(sIdx < m && tIdx < n)
            {
                while (s[sIdx] != t[tIdx])
                {
                    tIdx++;
                    if(tIdx == n)
                    {
                        return false;
                    }
                }
                sIdx++;
                tIdx++;
            }
            return true;
        }
    }
}
