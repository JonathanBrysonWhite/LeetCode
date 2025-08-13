using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public partial class Solution
    {
        public int GetMinimumDifference(TreeNode root)
        {
            Stack<TreeNode> nodeStack = new();
            nodeStack.Push(root);
            int difference = int.MaxValue;
            while(nodeStack.Count > 0)
            {
                TreeNode node = nodeStack.Pop();
                if(node.left != null)
                {
                    if (node.val - node.left.val < difference)
                        difference = node.val - node.left.val;
                    nodeStack.Push(node.left);
                }
                if(node.right != null)
                {
                    if (node.right.val - node.val < difference)
                        difference = node.right.val - node.val;
                    nodeStack.Push(node.right);
                }
            }
            return difference;
        }
    }
}
