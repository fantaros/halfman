using System;
using System.Collections.Generic;
using System.Text;

namespace halfman
{
    public class HalfManEncoder
    {
        public TreeNode treeroot = TreeNode.Root;
        public byte[] orginalData;
        public byte[] halfmanedData;

        public HalfManEncoder(byte[] data)
        {
            this.orginalData = data;
        }

        public void encoding()
        {
            
        }
    }
}
