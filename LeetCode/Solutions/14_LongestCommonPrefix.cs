using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Solutions
{
    public partial class Solution
    {
        public string LongestCommonPrefix(string[] strs)
        {
            StringBuilder sb = new StringBuilder();
            if (strs == null || strs.Length == 0)
                return "";

            string prefix = strs[0];
            foreach(string str in strs)
            {
                int i = 0;
                string newprefix = "";
                while (i < prefix.Length && i < str.Length)
                {
                    if (prefix[i] == str[i])
                    {
                        sb.Append(str[i]);
                    }
                    else
                    {
                        break;
                    }
                        i++;
                }
                prefix = sb.ToString();
                sb.Clear();
            }
            return prefix;
        }
    }
}
