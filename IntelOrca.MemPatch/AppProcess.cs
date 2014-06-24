using System;
using System.Diagnostics;
using System.IO;

namespace IntelOrca.MemPatch
{
	public abstract class AppProcess
	{
		private ProcessMemory mMemory = new ProcessMemory();

		public abstract string StartupPath
		{
			get;
		}

		public abstract string ExecutablePath
		{
			get;
		}

		public abstract string ProcessName
		{
			get;
		}

		public bool HasProcess
		{
			get
			{
				Process process = mMemory.ReadProcess;
				if (process != null) {
					return !process.HasExited;
				} else {
					return false;
				}
			}
		}

		public bool IsRunning
		{
			get
			{
				return (GetExistingProcess() != null);
			}
		}

		public void CloseProcess()
		{
			try {
				if (mMemory.ReadProcess != null) {
					mMemory.CloseHandle();
					mMemory.ReadProcess.Dispose();
					mMemory.ReadProcess = null;
				}
			} catch (Exception) {

			}
		}

		public bool OpenProcess()
		{
			Process process = GetExistingProcess();
			if (process != null) {
				mMemory.ReadProcess = process;
				mMemory.OpenProcess();

				return true;
			} else {
				return false;
			}
		}

		private Process GetExistingProcess()
		{
			Process[] myProcesses = Process.GetProcessesByName(ProcessName);
			if (myProcesses.Length > 0)
				return myProcesses[0];
			else
				return null;
		}

		public void StartProcess()
		{
			Process p = new Process();
			p.StartInfo.FileName = ExecutablePath;
			p.StartInfo.WorkingDirectory = StartupPath;

			if (!File.Exists(p.StartInfo.FileName)) {
				throw new Exception(String.Format("'{0}' does not exist.", p.StartInfo.FileName));
			}

			if (p.Start()) {
				mMemory.ReadProcess = p;
				mMemory.OpenProcess();
			} else {
				throw new Exception(String.Format("Unable to start {0}", p.StartInfo.FileName));
			}
		}

		public void SuspendProcess()
		{
			mMemory.SuspendProcess();
		}

		public void ResumeProcess()
		{
			mMemory.ResumeProcess();
		}

		public byte[] GetBytes(int address, int size)
		{
			int bytesRead;
			return mMemory.ReadProcessMemory((IntPtr)address, (uint)size, out bytesRead);
		}

		public short GetInt16(int address)
		{
			int bytesRead;
			byte[] buffer = mMemory.ReadProcessMemory((IntPtr)address, 2, out bytesRead);
			return BitConverter.ToInt16(buffer, 0);
		}

		public int GetInt32(int address)
		{
			int bytesRead;
			byte[] buffer = mMemory.ReadProcessMemory((IntPtr)address, 4, out bytesRead);
			return BitConverter.ToInt32(buffer, 0);
		}

		public byte GetInt8(int address)
		{
			int bytesRead;
			byte[] buffer = mMemory.ReadProcessMemory((IntPtr)address, 1, out bytesRead);
			return buffer[0];
		}

		public void WriteBytes(int address, params byte[] values)
		{
			int bytesWritten;
			mMemory.WriteProcessMemory((IntPtr)address, values, out bytesWritten);
		}

		public void WriteInt16(int address, ushort value)
		{
			int bytesWritten;
			byte[] buffer = BitConverter.GetBytes(value);
			mMemory.WriteProcessMemory((IntPtr)address, buffer, out bytesWritten);
		}

		public void WriteInt16(int address, short value)
		{
			int bytesWritten;
			byte[] buffer = BitConverter.GetBytes(value);
			mMemory.WriteProcessMemory((IntPtr)address, buffer, out bytesWritten);
		}

		public void WriteInt32(int address, uint value)
		{
			int bytesWritten;
			byte[] buffer = BitConverter.GetBytes(value);
			mMemory.WriteProcessMemory((IntPtr)address, buffer, out bytesWritten);
		}

		public void WriteInt32(int address, int value)
		{
			int bytesWritten;
			byte[] buffer = BitConverter.GetBytes(value);
			mMemory.WriteProcessMemory((IntPtr)address, buffer, out bytesWritten);
		}

		public void WriteInt8(int address, byte value)
		{
			int bytesWritten;
			byte[] buffer = new byte[1];
			buffer[0] = value;
			mMemory.WriteProcessMemory((IntPtr)address, buffer, out bytesWritten);
		}

		public int GetPointerAddress(int address, int[] offsets)
		{
			if (offsets.Length == 0) {
				return GetInt32(address);
			} else {
				address = GetInt32(address);
				for (int i = 0; i < offsets.Length - 1; i++) {
					address += offsets[i];
					address = GetInt32(address);
				}
				return address + offsets[offsets.Length - 1];
			}
		}

		public uint AllocateMemory(uint size)
		{
			return (uint)mMemory.AllocateMemory(size);
		}

		public void FreeMemory(uint address)
		{
			mMemory.FreeMemory((IntPtr)address);
		}

		public Process Process
		{
			get
			{
				return mMemory.ReadProcess;
			}
		}
	}
}
