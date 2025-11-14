using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Solutions
{
    public partial class Solution
    {
        public Node CloneGraph(Node node)
        {
            if (node == null)
            {
                return null;
            }
            Dictionary<int, Node> visited = new Dictionary<int, Node>();
            Queue<(Node, Node)> bfsQueue = new Queue<(Node, Node)>();
            Node rootNode = new Node();
            bfsQueue.Enqueue((node, rootNode));
            visited.Add(node.val, rootNode);
            while(bfsQueue.Count > 0)
            {
                (Node visitee, Node copy) = bfsQueue.Dequeue();
                copy.val = visitee.val;
                foreach(Node neighbor in visitee.neighbors)
                {

                    if(visited.ContainsKey(neighbor.val))
                    {
                        copy.neighbors.Add(visited[neighbor.val]);
                        continue;
                    }
                    Node neighborCopy = new Node();
                    copy.neighbors.Add(neighborCopy);
                    bfsQueue.Enqueue((neighbor, neighborCopy));
                    visited.Add(neighbor.val, neighborCopy);
                }
            }

            return rootNode;
        }
    }

    public class Node
    {
        public int val;
        public IList<Node> neighbors;

        public Node()
        {
            val = 0;
            neighbors = new List<Node>();
        }

        public Node(int _val)
        {
            val = _val;
            neighbors = new List<Node>();
        }

        public Node(int _val, List<Node> _neighbors)
        {
            val = _val;
            neighbors = _neighbors;
        }
    }
}

