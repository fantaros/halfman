using System;
using System.Collections.Generic;
using System.Text;

namespace halfman
{
    public class HalfManTreeSerial
    {
        public static byte[] serial(TreeNode root)
        {
            List<byte> buffer = new List<byte>();
            IDictionary<String,int> tree = root.getAllPairs();
            foreach (KeyValuePair<String, int> kvp in tree)
            {
                try
                {
                    byte b = byte.Parse(kvp.Key);
                    Bit v = Bit.parse(kvp.Value.ToString());
                    buffer.Add(b);
                    buffer.AddRange(v.orginal);

                }
                finally
                {
                    ;
                }
            }
            return buffer.ToArray();
        }
    }
}
