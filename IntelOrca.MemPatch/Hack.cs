using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace IntelOrca.MemPatch
{
	public static class Hack
	{
		public const byte NOP = 0x90;
		public const int JMPSize = 5;

		public static ushort SwapEndian(ushort value)
		{
			byte[] bytes = BitConverter.GetBytes(value);
			Array.Reverse(bytes);
			return BitConverter.ToUInt16(bytes, 0);
		}

		public static uint SwapEndian(uint value)
		{
			byte[] bytes = BitConverter.GetBytes(value);
			Array.Reverse(bytes);
			return BitConverter.ToUInt32(bytes, 0);
		}

		public static byte[] ByteArrayMerge(params object[] bytes)
		{
			ByteConverter bc = new ByteConverter();

			List<byte> totalBytes = new List<byte>();
			foreach (object o in bytes) {
				if (o is byte[]) {
					totalBytes.AddRange((byte[])o);
				} else if (o is byte) {
					totalBytes.Add((byte)o);
				} else {
					if (bc.CanConvertTo(o.GetType()))
						totalBytes.Add((byte)bc.ConvertTo(o, typeof(byte)));
					else
						continue;
				}
			}

			return totalBytes.ToArray();
		}

		public static byte[] GetArrayNOPs(int size)
		{
			byte[] arr = new byte[size];
			for (int i = 0; i < arr.Length; i++)
				arr[i] = NOP;
			return arr;
		}

		public static void WriteNOPs(AppProcess process, uint address, int count)
		{
			if (count <= 0)
				return;

			byte[] nops = new byte[count];
			for (int i = 0; i < count; i++)
				nops[i] = NOP;

			process.WriteBytes((int)address, nops);
		}

		public static void WriteJump(AppProcess process, uint srcAddress, uint destAddress)
		{
			process.WriteInt8((int)srcAddress, 0xE9);
			process.WriteInt32((int)srcAddress + 1, destAddress - srcAddress - JMPSize);
		}

		public static void CopyInstructions(AppProcess process, uint srcAddress, uint destAddress, int size)
		{
			byte[] instructions = process.GetBytes((int)srcAddress, size);
			process.WriteBytes((int)destAddress, instructions);
		}

		public static uint InjectCode(AppProcess process, uint address, int replacedInstructionSize, byte[] newCode)
		{
			if (replacedInstructionSize < 5)
				throw new Exception("Replaced instruction size much be greater than 5.");

			//Allocate the memory required
			uint allocatedMem = process.AllocateMemory((uint)(newCode.Length + replacedInstructionSize + JMPSize));

			//Write the new code in the allocated memory
			process.WriteBytes((int)allocatedMem, newCode);

			//Copy the old code
			CopyInstructions(process, address, allocatedMem + (uint)newCode.Length, replacedInstructionSize);

			//Write jump at the end of the allocated memory
			WriteJump(process, allocatedMem + (uint)newCode.Length + (uint)replacedInstructionSize, address + (uint)replacedInstructionSize);

			//Write jump address
			WriteJump(process, address, allocatedMem);

			//Write nops to be clean
			WriteNOPs(process, address + JMPSize, replacedInstructionSize - JMPSize);

			return allocatedMem;
		}

		public static uint DeinjectCode(AppProcess process, uint allocatedMem, uint address, int replacedInstructionSize, int newCodeLength)
		{
			if (replacedInstructionSize < 5)
				throw new Exception("Replaced instruction size much be greater than 5.");

			//Write original instructions
			CopyInstructions(process, allocatedMem + (uint)newCodeLength, address, replacedInstructionSize);

			//Free the allocated memory
			process.FreeMemory(allocatedMem);

			return allocatedMem;
		}
	}
}
