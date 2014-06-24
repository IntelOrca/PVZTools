using System;

namespace IntelOrca.MemPatch
{
	public class MemorySet : IMemoryEdit
	{
		AppProcess mProcess;
		uint mAddress;
		byte[] mNewValues;
		byte[] mOldValues;

		public MemorySet(uint address, byte[] values)
		{
			mAddress = address;
			mNewValues = values;
		}

		public MemorySet(uint address, byte value, int count)
		{
			mAddress = address;
			mNewValues = new byte[count];
			for (int i = 0; i < count; i++)
				mNewValues[i] = value;
		}

		public void Activate()
		{
			//Backup the old values
			mOldValues = mProcess.GetBytes((int)mAddress, mNewValues.Length);

			//Write the new values
			mProcess.WriteBytes((int)mAddress, mNewValues);
		}

		public void Deactivate()
		{
			//Write original values
			mProcess.WriteBytes((int)mAddress, mOldValues);
		}

		public AppProcess Process
		{
			get
			{
				return mProcess;
			}
			set
			{
				mProcess = value;
			}
		}
	}
}
