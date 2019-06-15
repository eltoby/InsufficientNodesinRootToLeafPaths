using System;
using System.Collections.Generic;
using System.Text;

namespace InsufficientNodesinRootToLeafPaths
{
    class Solution
    {
        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) { val = x; }
        }

        public TreeNode SufficientSubset(TreeNode root, int limit)
        {
            var cumulative = 0;

            var result = TurnToNull(root, limit, cumulative);
            return result;
        }

        private TreeNode TurnToNull(TreeNode node, int limit, int cumulative)
        {
            cumulative += node.val;

            var leaf = node.left == null && node.right == null;

            if (leaf)
            {
                if (cumulative < limit)
                    node = null;
            }
            else
            { 
                if (node.left != null)
                    node.left = this.TurnToNull(node.left, limit, cumulative);

                if (node.right != null)
                    node.right = this.TurnToNull(node.right, limit, cumulative);

                if (node.left == null && node.right == null)
                    node = null;
            }

            return node;
        }
    }
}
