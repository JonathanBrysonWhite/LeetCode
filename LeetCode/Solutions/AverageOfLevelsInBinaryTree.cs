using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{

public class TreeNode {
    public int val;
    public TreeNode left;
    public TreeNode right;
    public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
        this.val = val;
        this.left = left;
        this.right = right;
    }
}
 
    public partial class Solution
    {
        public IList<double> AverageOfLevels(TreeNode root)
        {
            List<List<double>> levelValues = new List<List<double>>();
            Queue<Tuple<int, TreeNode>> bfsQueue = new Queue<Tuple<int, TreeNode>>();
            IList<double> rVal = new List<double>();
            bfsQueue.Enqueue(new Tuple<int, TreeNode>(0, root));
            while(bfsQueue.Count > 0)
            {
                Tuple<int, TreeNode> workingNode = bfsQueue.Dequeue();
                if(levelValues.Count <= workingNode.Item1)
                {
                    levelValues.Add(new List<double>());
                }
                levelValues[workingNode.Item1].Add(workingNode.Item2.val);
                if(workingNode.Item2.left != null)
                {
                    Tuple<int, TreeNode> left = new Tuple<int, TreeNode>(workingNode.Item1 + 1, workingNode.Item2.left);
                    bfsQueue.Enqueue(left);
                }
                if(workingNode.Item2.right != null)
                {
                    Tuple<int, TreeNode> right = new Tuple<int, TreeNode>(workingNode.Item1 + 1, workingNode.Item2.right);
                    bfsQueue.Enqueue(right);
                }
            }

            int i = 0;
            foreach (List<double> ints in levelValues)
            {
                double average = Math.Round((double)ints.Sum() / (double)ints.Count, 5);
                rVal.Add(average);
            }
            return rVal;
        }
    }
}
