using System;
using System.Collections.Generic;
using System.Text;

namespace halfman
{
    public class HalfManEncoder
    {
        internal TreeNode treeroot = TreeNode.Root;
        internal byte[] orginalData;
        internal byte[] halfmanedData = null;
		internal IDictionary<byte,int> dictionary;

        public HalfManEncoder(byte[] data)
        {
            this.orginalData = data;
        }

        public void encoding ()
		{
			dictionary = new Dictionary<byte, int> ();
			foreach (byte data in orginalData) {
				if (dictionary.ContainsKey (data)) {
					dictionary [data] = dictionary [data] + 1;
				} else {
					dictionary.Add (data, 1);
				}
			}
			List<TreeNode> nodes = new List<TreeNode> ();
			foreach (KeyValuePair<byte,int> kvp in dictionary) {
				nodes.Add (TreeNode.create (kvp.Key.ToString (), kvp.Value));
			}
			//nodes.Add (TreeNode.Root);
			nodes.Sort (new Comparison<TreeNode> (this.nodeCompare));
			while (nodes.Count>1) {
				TreeNode f = nodes [0];
				TreeNode s = nodes [1];
				if (f.Key != "Connect") {
					Console.WriteLine ("{0}:{1}", f.Key, f.Count);
				}
				if (s.Key != "Connect") {
					Console.WriteLine ("{0}:{1}", s.Key, s.Count);
				}
				TreeNode n = TreeNode.create ("Connect", f.Count + s.Count);
				n.Left = s;
				n.Right = f;
				nodes.Remove (f);
				nodes.Remove (s);
				nodes.Add (n);
				nodes.Sort (new Comparison<TreeNode> (this.nodeCompare));
			}
			TreeNode root = nodes [0];
			root.coding ();
			IList<TreeNode> all = root.getAll ();
			foreach (TreeNode tr in all) {
				if (tr.Key != "Connect") {
					Console.WriteLine ("{0}:{1}",tr.Key,tr.Code);
				}
			}
        }
		
		public int nodeCompare (TreeNode a, TreeNode b)
		{
			if (a.Count > b.Count) {
				return 1;
			} else if (a.Count < b.Count) {
				return -1;
			} else {
				return 0;
			}
		}
    }
}
