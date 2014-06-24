using System;

namespace IntelOrca.MemPatch
{
	public class MemorySwap : IMemoryEdit
	{
		AppProcess mProcess;
		uint mAddressA;
		uint mAddressB;
		int mCount;

		public MemorySwap(uint addressA, uint addressB, int count)
		{
			mAddressA = addressA;
			mAddressB = addressB;
			mCount = count;
		}

		private void Swap()
		{
			//Get the values from both addresses
			byte[] bufA = mProcess.GetBytes((int)mAddressA, mCount);
			byte[] bufB = mProcess.GetBytes((int)mAddressB, mCount);

			//Write them back but swapped
			mProcess.WriteBytes((int)mAddressA, bufB);
			mProcess.WriteBytes((int)mAddressB, bufA);
		}

		public void Activate()
		{
			Swap();
		}

		public void Deactivate()
		{
			Swap();
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
