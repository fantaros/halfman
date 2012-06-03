using System;
using System.Collections.Generic;
using System.Text;

namespace halfman
{
    public class Program
    {
        public static void Main (string[] args)
		{
			byte[] buffer = new byte[]{ 0,1,1,2,2,2,2,3,3,3,3,3,3,3,3};
			HalfManEncoder en = new HalfManEncoder (buffer);
			en.encoding ();
			//Console.ReadKey ();
        }
    }
}
