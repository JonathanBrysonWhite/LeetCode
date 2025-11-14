using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Solutions
{
    public partial class Solution
    {
        public bool IsIsomorphic(string s, string t)
        {
            if(s == null && t == null)
            {
                return true;
            }
            if(s == null || t == null)
            {
                return false;
            }
            if(s.Length != t.Length)
            {
                return false;
            }
            Dictionary<char, char> map = new Dictionary<char, char>();
            Dictionary<char, char> map2 = new Dictionary<char, char>();
            
            for(int i = 0; i < s.Length; i++)
            {
                char c1 = s[i];
                char c2 = t[i];

                if(!map.ContainsKey(c1) && !map2.ContainsKey(c2))
                {
                    map.Add(c1, c2);
                    map2.Add(c2, c1);
                }
                else if (!map.TryGetValue(c1, out _))
                {
                    return false;
                }
                else if (map[c1] != c2)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
