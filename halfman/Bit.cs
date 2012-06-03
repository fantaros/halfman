using System;
using System.Collections.Generic;
using System.Text;

namespace halfman
{
    public class Bit
    {
		#region Property Region
        internal byte[] orginal;
        internal int bits;
		
		public byte[] Original 
		{
			get
			{ 
				return orginal; 
			}
			set
			{ 
				orginal = value;
			}
		}
		
		public int BitCount 
		{
			get
			{ 
				return bits;
			}
			set
			{ 
				bits = value; 
			}
		}

        public Bit(long orginal, int bit)
        {
            this.orginal = BitConverter.GetBytes(orginal);
            this.bits = bit;
        }

        public Bit(byte[] buffer, int bit)
        {
            this.orginal = buffer;
            this.bits = bit;
        }
		
		public Bit (byte[] buffer)
		{
			this.orginal = buffer;
			this.bits = buffer.Length;
		}
		#endregion

        public static implicit operator Bit(byte value)
        {
            return new Bit(value,sizeof(byte)*8);
        }

        public static implicit operator Bit(int value)
        {
            return new Bit(value, sizeof(int) * 8);
        }

        public static implicit operator Bit(long value)
        {
            return new Bit(value, sizeof(long) * 8);
        }

        public static Bit parse (String value)
		{
			List<byte> buffer = new List<byte> ();
			int bit = 0;
			foreach (char c in value) {
				if (c == '1') {
					buffer.Add (1);
					bit++;
				} else if (c == '0') {
					buffer.Add (0);
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
                if (bobjs.bits != this.bits)
                {
                    return false;
                }
                else
                {
                    bool same = true;
                    for (int i = 0; i < bobjs.bits; ++i)
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
		
		public byte[] serial ()
		{
			return this.orginal;
		}
		
		public void deSerial (byte[] data)
		{
			this.orginal = data;
			this.bits = data.Length;
		}
    }
}
