using System;
using System.Collections.Generic;
using System.Text;

namespace halfman
{
    public class TreeNode
    {
        private static TreeNode root = new TreeNode();

        public static TreeNode Root
        {
            get
            {
                return root;
            }
        }

        public static TreeNode create(params Object[] plist)
        {
            if (plist == null)
            {
                return new TreeNode();
            }
            else
            {
                TreeNode tree = new TreeNode();
                tree.Key = (plist.Length > 0) ? ((plist[0] != null && plist[0] is String) ? (String)plist[0] : "ROOT") : "ROOT";
                tree.Value = (plist.Length > 1) ? ((plist[1] != null && plist[1] is String) ? (String)plist[1] : "") : "";
                tree.Left = (plist.Length > 2) ? ((plist[2] != null && plist[2] is TreeNode) ? (TreeNode)plist[2] : null) : null;
                tree.Right = (plist.Length > 3) ? ((plist[3] != null && plist[3] is TreeNode) ? (TreeNode)plist[3] : null) : null;
                return tree;
            }
        }
		
		internal String Key;

		internal String Value;

		internal TreeNode Left;

		internal TreeNode Right;

        private TreeNode()
		{
            this.Key = "ROOT";
            this.Value = "";
            this.Left = null;
            this.Right = null;
        }

        public IList<TreeNode> getAll()
        {
            IList<TreeNode> result = new List<TreeNode>();
            mergeAll(result, this);
            return result;
        }

        private void mergeAll(IList<TreeNode> rs,TreeNode current)
        {
            if (current != null)
            {
                mergeAll(rs, current.Left);
                rs.Add(current);
                mergeAll(rs, current.Right);
            }
            else
            {
                return;
            }
        }

        public IList<String> getAllKeys()
        {
            IList<String> result = new List<String>();
            mergeAllKeys(result, this);
            return result;
        }

        private void mergeAllKeys(IList<String> rs, TreeNode current)
        {
            if (current != null)
            {
                mergeAllKeys(rs, current.Left);
                rs.Add(current.Key);
                mergeAllKeys(rs, current.Right);
            }
            else
            {
                return;
            }
        }

        public IList<String> getAllValues()
        {
            IList<String> result = new List<String>();
            mergeAllValues(result, this);
            return result;
        }

        private void mergeAllValues(IList<String> rs, TreeNode current)
        {
            if (current != null)
            {
                mergeAllValues(rs, current.Left);
                rs.Add(current.Value);
                mergeAllValues(rs, current.Right);
            }
            else
            {
                return;
            }
        }

        public IDictionary<String,String> getAllPairs()
        {
            IDictionary<String, String> result = new Dictionary<String, String>();
            mergeAllPairs(result, this);
            return result;
        }

        private void mergeAllPairs(IDictionary<String, String> rs, TreeNode current)
        {
            if (current != null)
            {
                mergeAllPairs(rs, current.Left);
                rs.Add(current.Key,current.Value);
                mergeAllPairs(rs, current.Right);
            }
            else
            {
                return;
            }
        }

        public void editLeft(TreeNode left)
        {
            this.Left = left;
        }

        public void editRight(TreeNode right)
        {
            this.Right = right;
        }
    }
}
