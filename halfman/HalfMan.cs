using System;
namespace halfman
{
	public class HalfMan
	{
		public HalfMan create ()
		{
			return new HalfMan ();
		}
		
		protected HalfManEncoder encoder;
		protected HalfManDecoder decoder;
		public HalfMan ()
		{
			
		}
		
		public byte[] encoding (byte[] filebytes)
		{
			encoder = new HalfManEncoder (filebytes);
			return null;
		}
		
		public byte[] decoding (byte[] filebytes)
		{
			decoder = new HalfManDecoder (filebytes);
			return null;
		}
	}
}

