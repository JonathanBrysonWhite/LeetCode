using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Solutions
{
    internal partial class Solution
    {
        public TreeNode BuildTree106Naive(int[] inorder, int[] postorder)
        {
            int pLength = postorder.Length;
            int pIndex = pLength - 1;
            return NaiveHelper106(inorder, postorder, 0, pLength - 1, ref pIndex);
        }

        private TreeNode NaiveHelper106(int[] inorder, int[] postorder, int inStart, int inEnd, ref int pIndex)
        {
            if (inStart > inEnd)
                return null;

            TreeNode node = new TreeNode(postorder[pIndex]);
            pIndex--;

            if (inStart == inEnd)
                return node;

            int iIndex = Search106(inorder, inStart, inEnd, node.val);

            node.right = NaiveHelper106(inorder, postorder, iIndex + 1, inEnd, ref pIndex);
            node.left = NaiveHelper106(inorder, postorder, inStart, iIndex - 1, ref pIndex);

            return node;
        }

        private int Search106(int[] inorder, int inStart, int inEnd, int target)
        {
            for (int i = inStart; i <= inEnd; i++)
            {
                if (inorder[i] == target)
                    return i;
            }
            return -1;
        }

        public TreeNode BuildTree106(int[] inorder, int[] postorder)
        {
            int n = inorder.Length;
            int postIndex = n - 1;
            Dictionary<int, int> inorderMap = [];
            for(int i = 0; i < n; i++)
            {
                inorderMap[inorder[i]] = i;
            }
            return TreeBuilder106(inorder, postorder, 0, n - 1, inorderMap, ref postIndex);
        }

        private TreeNode TreeBuilder106(int[] inorder, int[] postorder, int inStart, int inEnd, Dictionary<int, int> inorderMap, ref int postIndex)
        {
            if (inStart > inEnd)
                return null;

            int currValue = postorder[postIndex];
            postIndex--;
    
            TreeNode node = new TreeNode(currValue);

            if (inStart == inEnd)
                return node;

            int inIndex = inorderMap[currValue];

            node.right = TreeBuilder106(inorder, postorder, inIndex + 1, inEnd, inorderMap, ref postIndex);
            node.left = TreeBuilder106(inorder, postorder, inStart, inIndex - 1, inorderMap, ref postIndex);

            return node;
        }
    }
}
