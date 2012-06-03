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

        public static TreeNode create (params Object[] plist)
		{
			if (plist == null) {
				return new TreeNode ();
			} else {
				TreeNode tree = new TreeNode ();
				tree.Key = (plist.Length > 0) ? ((plist [0] != null && plist [0] is String) ? (String)plist [0] : "ROOT") : "ROOT";
				tree.Count = (plist.Length > 1) ? ((plist [1] != null && plist [1] is Int32) ? (Int32)plist[1] : int.MaxValue) : int.MaxValue;
                tree.Left = (plist.Length > 2) ? ((plist[2] != null && plist[2] is TreeNode) ? (TreeNode)plist[2] : null) : null;
                tree.Right = (plist.Length > 3) ? ((plist[3] != null && plist[3] is TreeNode) ? (TreeNode)plist[3] : null) : null;
                return tree;
            }
        }
		
		internal string Key;

		internal int Count;
		
		internal string Code;

		internal TreeNode Left;

		internal TreeNode Right;

        private TreeNode ()
		{
			this.Key = "ROOT";
			this.Count = int.MaxValue;
			this.Code = null;
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

        public IList<int> getAllCount()
        {
            IList<int> result = new List<int>();
            mergeAllCount(result, this);
            return result;
        }

        private void mergeAllCount (IList<int> rs, TreeNode current)
		{
			if (current != null) {
				mergeAllCount (rs, current.Left);
				rs.Add (current.Count);
				mergeAllCount(rs, current.Right);
            }
            else
            {
                return;
            }
        }

        public IDictionary<String,int> getAllPairs ()
		{
			IDictionary<String, int> result = new Dictionary<String, int>();
            mergeAllPairs(result, this);
            return result;
        }

        private void mergeAllPairs (IDictionary<String, int> rs, TreeNode current)
        {
            if (current != null)
            {
                mergeAllPairs(rs, current.Left);
                rs.Add(current.Key,current.Count);
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
		
		public void coding ()
		{
			String leftcode = "0";
			String rightcode = "1";
			codeLeft (this.Left, leftcode,rightcode);
			codeRight (this.Right,leftcode,rightcode);
		}
		
		public void codeLeft (TreeNode left, string leftcode, string rightcode)
		{
			if (left == null) {
				return;
			} else {
				left.Code = leftcode;
				leftcode = "0" + leftcode;
				rightcode = "0" + rightcode;
				codeLeft (left.Left, leftcode,rightcode);
				codeRight (left.Right, leftcode,rightcode);
			}
		}
		
		public void codeRight (TreeNode right, string leftcode, string rightcode)
		{
			if (right == null) {
				return;
			} else {
				right.Code = rightcode;
				leftcode = "1" + leftcode;
				rightcode = "1" + rightcode ;
				codeLeft (right.Left, leftcode,rightcode);
				codeRight (right.Right, leftcode,rightcode);
			}
		}
    }
}
