using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Solutions
{
    public partial class Solution
    {
        public bool WordPattern(string pattern, string s)
        {
            Dictionary<char, string> patternMap = new Dictionary<char, string>();
            Dictionary<string, char> stringMap = new Dictionary<string, char>();
            string[] strings = s.Split(' ');

            if (pattern.Length != strings.Length)
            {
                return false;
            }

            for (int i = 0; i < pattern.Length; i++)
            {
                char c = pattern[i];
                string word = strings[i];

                if (!patternMap.ContainsKey(c))
                {
                    patternMap.Add(c, word);
                    if (!stringMap.TryAdd(word, c))
                    {
                        return false;
                    }
                }
                else if (!stringMap.ContainsKey(word))
                {
                    return false;
                }
                else if (patternMap[c] != word || stringMap[word] != c)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
