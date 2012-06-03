using System;
using System.Collections.Generic;
using System.Text;

namespace halfman
{
    public class HalfManDecoder
    {
        public TreeNode treeroot = TreeNode.Root;
        public byte[] orginalData;
        public byte[] halfmanedData;

        public HalfManDecoder(byte[] data)
        {
            this.orginalData = data;
        }

        public void decoding()
        {
            
        }
    }
}
