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
            IDictionary<String,String> tree = root.getAllPairs();
            foreach (KeyValuePair<String, String> kvp in tree)
            {
                try
                {
                    byte b = byte.Parse(kvp.Key);
                    Bit v = Bit.parse(kvp.Value);
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
