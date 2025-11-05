using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Solutions
{
    public class Trie
    {
        private class TrieNode
        {
            public char val { get; set; }
            public Dictionary<char, TrieNode> children { get; set; }

            public TrieNode()
            {
                children = new Dictionary<char, TrieNode>();
                val = ' ';
            }

            public TrieNode(char _val)
            {
                val = _val;
                children = new Dictionary<char, TrieNode>();
            }
        }

        private TrieNode root { get; }
        public Trie()
        {
            root = new TrieNode();
        }

        public void Insert(string word)
        {
            TrieNode current = root;
            for (int i = 0; i < word.Length; i++)
            {
                char currentChar = word[i];
                TrieNode? next = null;
                if (!current.children.TryGetValue(currentChar, out next))
                {
                    next = new TrieNode(currentChar);
                    if(!current.children.ContainsKey(currentChar))
                        current.children.Add(currentChar, next);
                }
                current = next;
                if (i == word.Length - 1)
                {
                    if(!current.children.ContainsKey('\0'))
                    current.children.Add('\0', new TrieNode('\0'));
                }
            }
        }

        public bool Search(string word)
        {
            TrieNode current = root;
            for (int i = 0; i < word.Length; i++)
            {
                char currentChar = word[i];
                TrieNode? next = null;

                if (!current.children.TryGetValue(currentChar, out next))
                {
                    return false;
                }
                current = next;
            }
            if (current.children.ContainsKey('\0'))
            {
                return true;
            }
            return false;
        }

        public bool StartsWith(string prefix)
        {
            TrieNode current = root;
            for (int i = 0; i < prefix.Length; i++)
            {
                char currentChar = prefix[i];
                TrieNode? next = null;

                if (!current.children.TryGetValue(currentChar, out next))
                {
                    return false;
                }
                current = next;
            }
            return true;
        }
    }

    /**
     * Your Trie object will be instantiated and called as such:
     * Trie obj = new Trie();
     * obj.Insert(word);
     * bool param_2 = obj.Search(word);
     * bool param_3 = obj.StartsWith(prefix);
     */
}

