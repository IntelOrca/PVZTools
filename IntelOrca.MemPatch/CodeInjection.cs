using System;

namespace IntelOrca.MemPatch
{
	public class CodeInjection : IMemoryEdit
	{
		AppProcess mProcess;
		uint mAddress;
		int mReplacedInstructionSize;
		byte[] mNewCode;

		uint mAllocatedMemory;

		public CodeInjection(uint address, int replacedInstructionSize, byte[] newCode)
		{
			if (replacedInstructionSize < 5)
				throw new Exception("Replaced instruction size much be greater than 5.");

			mAddress = address;
			mReplacedInstructionSize = replacedInstructionSize;
			mNewCode = newCode;
		}

		public void Activate()
		{
			//Allocate the memory required
			mAllocatedMemory = mProcess.AllocateMemory((uint)(mNewCode.Length + mReplacedInstructionSize + Hack.JMPSize));
			if (mAllocatedMemory == 0)
				throw new Exception();

			//Write the new code in the allocated memory
			mProcess.WriteBytes((int)mAllocatedMemory, mNewCode);

			//Copy the old code
			Hack.CopyInstructions(mProcess, mAddress, mAllocatedMemory + (uint)mNewCode.Length, mReplacedInstructionSize);

			//Write jump at the end of the allocated memory
			Hack.WriteJump(mProcess, mAllocatedMemory + (uint)mNewCode.Length + (uint)mReplacedInstructionSize, mAddress + (uint)mReplacedInstructionSize);

			//Write jump address
			Hack.WriteJump(mProcess, mAddress, mAllocatedMemory);

			//Write nops to be clean
			Hack.WriteNOPs(mProcess, mAddress + Hack.JMPSize, mReplacedInstructionSize - Hack.JMPSize);
		}

		public void Deactivate()
		{
			//Write original instructions
			Hack.CopyInstructions(mProcess, mAllocatedMemory + (uint)mNewCode.Length, mAddress, mReplacedInstructionSize);

			//Free the allocated memory
			mProcess.FreeMemory(mAllocatedMemory);
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
