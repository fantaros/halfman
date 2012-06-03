using System;
using System.Collections.Generic;
using System.Text;

namespace halfman
{
    public class Bit
    {
        internal byte[] orginal;
        internal int bit;

        public Bit(long orginal, int bit)
        {
            this.orginal = BitConverter.GetBytes(orginal);
            this.bit = bit;
        }

        public Bit(byte[] buffer, int bit)
        {
            this.orginal = buffer;
            this.bit = bit;
        }

        public static implicit operator Bit(byte value)
        {
            return new Bit(value,sizeof(byte)*8);
        }

        public static implicit operator Bit(int value)
        {
            return new Bit(value, sizeof(int) * 8);
        }

        public static implicit operator Bit(short value)
        {
            return new Bit(value, sizeof(short) * 8);
        }

        public static implicit operator Bit(long value)
        {
            return new Bit(value, sizeof(long) * 8);
        }

        public static Bit parse(String value)
        {
            List<byte> buffer = new List<byte>();
            int bits = 0;
			foreach(char c in value)
			{
				if(c=='1')
				{
					
				}
			}
            return new Bit(buffer.ToArray(), 0);
        }

        public override bool Equals(object obj)
        {
            Bit bobjs = obj as Bit;
            if (bobjs == null)
            {
                return false;
            }
            else
            {
                if (bobjs.bit != this.bit)
                {
                    return false;
                }
                else
                {
                    bool same = true;
                    for (int i = 0; i < bobjs.bit; ++i)
                    {
                        if (bobjs.getBit(i) != this.getBit(i))
                        {
                            same = false;
                            break;
                        }
                    }
                    return same;
                }
            }
        }

        public byte getBit(int index)
        {
            int xoffset = index % 8;
            int yoffset = index - xoffset * 8 - 1;
            if (orginal.Length <= xoffset)
            {
                throw new ArgumentOutOfRangeException(String.Format("此位符号中没有足够多的位数(total:{0},your require:{1})", orginal.Length * 8, index));
            }
            else
            {
                return (byte)((orginal[xoffset] >> yoffset) & 1);
            }
        }

        public override int GetHashCode()
        {
            return orginal.GetHashCode();
        }
    }
}
