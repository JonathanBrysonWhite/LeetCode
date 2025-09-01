using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Solutions
{
    public partial class Solution
    {
        TreeNode prev = null;
        int ans = int.MaxValue;
        public int GetMinimumDifference(TreeNode root)
        {
            preorder(root);
            return ans;
        }

        public void preorder(TreeNode root)
        {
            TreeNode curr = root;
            if (root.left != null)
            {
                preorder(root.left);
            }
            if(prev != null)
            {
                int diff = Math.Abs(root.val - prev.val);
                if(diff < ans)
                {
                    ans = diff;
                }

            }
            prev = root;
            if (curr.right != null)
            {
                preorder(curr.right);
            }
        }
    }
}
