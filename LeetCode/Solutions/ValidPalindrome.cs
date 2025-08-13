using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LeetCode
{
    public partial class Solution
    {
        public bool IsPalindrome(string s)
        {
            s = Regex.Replace(s, "[^A-Za-z0-9]", "");
            s = s.ToLower();
            int l = 0, r = s.Length - 1;
            while(r > l)
            {
                if (s[l++] != s[r--])
                    return false;
            }
            return true;
        }
    }
}
