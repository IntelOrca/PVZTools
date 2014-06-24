using System;

namespace IntelOrca.PvZTools
{
	class Zombie : ICloneable
	{
		public const int StructSize = 0x15C;
		public static string[] szZombieTypes = new string[] { "Normal", "Flag", "Conehead", "Pole Vaulting", "Buckethead", "Newspaper", "Screen Door", "Football", "Dancing", "Backup Dancer", "Ducky Tube", "Snorkel", "Zomboni", "Bobsled Team", "Dolphin Rider", "Jack-in-the-box", "Balloon", "Digger", "Pogo", "Yeti", "Bungee", "Ladder", "Catapult", "Gargantuar", "Imp", "Dr. Zomboss", "Peashooter", "Wall-nut", "Jalapeno", "Gatling Pea", "Squash", "Tall-nut", "Giga-Gargantuar" };
		public static bool[] CanZombieSwim = new bool[] { true, false, false, false, false, false, false, false, false, false, true, true, false, false, true, false, false, false, false, false, true, false, false, false, false, false, false, false, false, false, false, false, false };
		public static bool[] ZombieMustSwim = new bool[] { false, false, false, false, false, false, false, false, false, false, true, true, false, false, true, false, false, false, false, false, true, false, false, false, false, false, false, false, false, false, false, false, false };

		private byte[] mData;

		public Zombie(byte[] data)
		{
			mData = data;
		}

		public object Clone()
		{
			byte[] cpyData = new byte[mData.Length];
			Array.Copy(mData, cpyData, mData.Length);
			return new Zombie(cpyData);
		}

		public byte[] Data
		{
			get
			{
				return mData;
			}
		}

		public int AppBasePointer
		{
			get
			{
				return BitConverter.ToInt32(mData, 0x00);
			}
			set
			{
				byte[] buffer = BitConverter.GetBytes(value);
				Array.Copy(buffer, 0, mData, 0x00, buffer.Length);
			}
		}

		public int BoardPointer
		{
			get
			{
				return BitConverter.ToInt32(mData, 0x04);
			}
			set
			{
				byte[] buffer = BitConverter.GetBytes(value);
				Array.Copy(buffer, 0, mData, 0x04, buffer.Length);
			}
		}

		public int DrawX
		{
			get
			{
				return BitConverter.ToInt32(mData, 0x08);
			}
			set
			{
				byte[] buffer = BitConverter.GetBytes(value);
				Array.Copy(buffer, 0, mData, 0x08, buffer.Length);
			}
		}

		public int DrawY
		{
			get
			{
				return BitConverter.ToInt32(mData, 0x0C);
			}
			set
			{
				byte[] buffer = BitConverter.GetBytes(value);
				Array.Copy(buffer, 0, mData, 0x0C, buffer.Length);
			}
		}

		public int Visible
		{
			get
			{
				return BitConverter.ToInt32(mData, 0x18);
			}
			set
			{
				byte[] buffer = BitConverter.GetBytes(value);
				Array.Copy(buffer, 0, mData, 0x18, buffer.Length);
			}
		}

		public int Row
		{
			get
			{
				return BitConverter.ToInt32(mData, 0x1C);
			}
			set
			{
				byte[] buffer = BitConverter.GetBytes(value);
				Array.Copy(buffer, 0, mData, 0x1C, buffer.Length);
			}
		}

		public int Shadow
		{
			get
			{
				return BitConverter.ToInt32(mData, 0x22);
			}
			set
			{
				byte[] buffer = BitConverter.GetBytes(value);
				Array.Copy(buffer, 0, mData, 0x22, buffer.Length);
			}
		}

		public int Type
		{
			get
			{
				return BitConverter.ToInt32(mData, 0x24);
			}
			set
			{
				byte[] buffer = BitConverter.GetBytes(value);
				Array.Copy(buffer, 0, mData, 0x24, buffer.Length);
			}
		}

		public float X
		{
			get
			{
				return BitConverter.ToSingle(mData, 0x2C);
			}
			set
			{
				byte[] buffer = BitConverter.GetBytes(value);
				Array.Copy(buffer, 0, mData, 0x2C, buffer.Length);
			}
		}

		public float Y
		{
			get
			{
				return BitConverter.ToSingle(mData, 0x30);
			}
			set
			{
				byte[] buffer = BitConverter.GetBytes(value);
				Array.Copy(buffer, 0, mData, 0x30, buffer.Length);
			}
		}

		public int BoundaryX
		{
			get
			{
				return BitConverter.ToInt32(mData, 0x8C);
			}
			set
			{
				byte[] buffer = BitConverter.GetBytes(value);
				Array.Copy(buffer, 0, mData, 0x8C, buffer.Length);
			}
		}

		public int BoundaryY
		{
			get
			{
				return BitConverter.ToInt32(mData, 0x90);
			}
			set
			{
				byte[] buffer = BitConverter.GetBytes(value);
				Array.Copy(buffer, 0, mData, 0x8C, buffer.Length);
			}
		}

		public int BoundaryWidth
		{
			get
			{
				return BitConverter.ToInt32(mData, 0x94);
			}
			set
			{
				byte[] buffer = BitConverter.GetBytes(value);
				Array.Copy(buffer, 0, mData, 0x8C, buffer.Length);
			}
		}

		public int BoundaryHeight
		{
			get
			{
				return BitConverter.ToInt32(mData, 0x98);
			}
			set
			{
				byte[] buffer = BitConverter.GetBytes(value);
				Array.Copy(buffer, 0, mData, 0x8C, buffer.Length);
			}
		}

		public bool Blue
		{
			get
			{
				return (BitConverter.ToInt32(mData, 0xAC) > 0);
			}
			set
			{
				byte[] buffer = BitConverter.GetBytes((value ? 1 : 0));
				Array.Copy(buffer, 0, mData, 0xAC, buffer.Length);
			}
		}

		public bool Butter
		{
			get
			{
				return (BitConverter.ToInt32(mData, 0xB0) > 0);
			}
			set
			{
				byte[] buffer = BitConverter.GetBytes((value ? 1 : 0));
				Array.Copy(buffer, 0, mData, 0xB0, buffer.Length);
			}
		}

		public bool Frozen
		{
			get
			{
				return (BitConverter.ToInt32(mData, 0xB4) > 0);
			}
			set
			{
				byte[] buffer = BitConverter.GetBytes((value ? 1 : 0));
				Array.Copy(buffer, 0, mData, 0xB4, buffer.Length);
			}
		}

		public int Helmet
		{
			get
			{
				return BitConverter.ToInt32(mData, 0xC4);
			}
		}

		public int Health
		{
			get
			{
				return BitConverter.ToInt32(mData, 0xC8);
			}
		}

		public int HelmetHealth
		{
			get
			{
				return BitConverter.ToInt32(mData, 0xD0);
			}
		}


	}
}
