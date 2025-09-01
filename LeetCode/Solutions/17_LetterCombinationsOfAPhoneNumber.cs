using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Solutions
{
    public partial class Solution
    {
        private Dictionary<char, string[]> keypadMap = new Dictionary<char, string[]>
        {
            { '2', ["a", "b", "c"] },
            { '3', ["d", "e", "f"] },
            { '4', ["g", "h", "i"] },
            { '5', ["j", "k", "l"] },
            { '6', ["m", "n", "o"] },
            { '7', ["p", "q", "r", "s"] },
            { '8', ["t", "u", "v"] },
            { '9', ["w", "x", "y", "z"] }
        };
        public IList<string> LetterCombinations(string digits)
        {
            List<string> solutions = new List<string>();
            char[] chars = digits.ToCharArray();
            if (chars.Length == 0)
                return solutions;
            foreach(string s in keypadMap[chars[0]])
            {
                solutions.Add(s);
            }

            for(int i = 1; i < digits.Length; i++)
            {
                List<string> newList = new List<string>();
                string[] valuesToAdd = keypadMap[chars[i]];
                foreach(string s in solutions)
                {
                    foreach(string s2 in valuesToAdd)
                    {
                        newList.Add(s + s2);
                    }
                }
                solutions = newList;
            }

            return solutions;
        }
    }
}
