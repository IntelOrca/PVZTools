using System;

namespace IntelOrca.MemPatch
{
	public class CodeReplacement : IMemoryEdit
	{
		AppProcess mProcess;
		uint mAddress;
		int mReplacedInstructionSize;
		byte[] mNewCode;
		byte[] mOldCode;

		public CodeReplacement(uint address, int replacedInstructionSize) :
			this(address, replacedInstructionSize, Hack.GetArrayNOPs(replacedInstructionSize))
		{
		}

		public CodeReplacement(uint address, int replacedInstructionSize, byte[] newCode)
		{
			if (replacedInstructionSize < newCode.Length)
				throw new Exception("The new code is longer than the code being replaced.");

			mAddress = address;
			mReplacedInstructionSize = replacedInstructionSize;
			mNewCode = newCode;
		}

		public void Activate()
		{
			//Backup the old code
			mOldCode = mProcess.GetBytes((int)mAddress, mReplacedInstructionSize);

			//Write the new code
			mProcess.WriteBytes((int)mAddress, mNewCode);

			//Write any additional NOPs
			Hack.WriteNOPs(mProcess, mAddress + (uint)mNewCode.Length, mReplacedInstructionSize - mNewCode.Length);
		}

		public void Deactivate()
		{
			//Write original instructions
			mProcess.WriteBytes((int)mAddress, mOldCode);
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
