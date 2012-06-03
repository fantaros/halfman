using System;
using System.Collections.Generic;
namespace halfman
{
	public class BitHelper
	{
		public static byte[] covert (string allbits) {
			List<byte> buffer = new List<byte> ();
			int indexer = 0;
			foreach (char c in allbits) {
				if (c == '1') {
					addBit (indexer, buffer, 1);	
				} else if (c == '0') {
					addBit (indexer, buffer, 0);
				}	
			}
			return buffer.ToArray ();
		}
		
		public static IList<byte> addBit (int index, IList<byte> list, byte value, int bitscount) {
			int listoffset = index % 8;
			int listindex = index - listoffset * 8;
			if (listoffset >= list.Count) {
				int last = listoffset - list.Count + 1;
				for (int j=0; j<last; ++j) {
					list.Add (0);
				}
			}
			byte org = list [listoffset];
			for (int i=0; i<bitscount; ++i) {
				byte current = value & 1;
				org = org | current;
				org = org << 1;
				value = value >> 1;
			}
			list [listoffset] = org;
		}
		
		public static IList<byte> addBit (int index, IList<byte> list, byte value) {
			return addBit (index,list,(byte)(value & 1),1);
		}
	}
}

