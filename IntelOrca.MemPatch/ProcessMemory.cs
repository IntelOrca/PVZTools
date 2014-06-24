using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace IntelOrca.MemPatch
{
	/// <summary>
	/// ProcessMemoryReader is a class that enables direct reading a process memory
	/// </summary>
	class ProcessMemoryReaderApi
	{
		#region Public Methods

		[DllImport("kernel32.dll")]
		public static extern Int32 GetExitCodeProcess(IntPtr hProcess, out uint lpExitCode);

		[DllImport("kernel32.dll")]
		public static extern Int32 CloseHandle(IntPtr hObject);

		[DllImport("kernel32.dll")]
		public static extern IntPtr OpenProcess(UInt32 dwDesiredAccess, Int32 bInheritHandle, UInt32 dwProcessId);

		[DllImport("kernel32.dll")]
		public static extern Int32 ReadProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, [In, Out] byte[] buffer, UInt32 size, out IntPtr lpNumberOfBytesRead);

		[DllImport("kernel32.dll")]
		public static extern Int32 WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, [In, Out] byte[] buffer, UInt32 size, out IntPtr lpNumberOfBytesWritten);

		[DllImport("kernel32.dll")]
		public static extern IntPtr VirtualAllocEx(IntPtr hProcess, IntPtr lpBaseAddress, UInt32 size, UInt32 flAllocationType, UInt32 flProtect);

		[DllImport("kernel32.dll")]
		public static extern IntPtr VirtualFreeEx(IntPtr hProcess, IntPtr lpAddress, UInt32 size, UInt32 dwFreeType);

		[DllImport("kernel32.dll")]
		public static extern IntPtr VirtualProtectEx(IntPtr hProcess, IntPtr lpAddress, UInt32 size, UInt32 flNewProtect, out UInt32 lpflOldProtect);

		[DllImport("kernel32.dll")]
		public static extern IntPtr OpenThread(ThreadAccess dwDesiredAccess, bool bInheritHandle, uint dwThreadId);

		[DllImport("kernel32.dll")]
		public static extern uint SuspendThread(IntPtr hThread);

		[DllImport("kernel32.dll")]
		public static extern int ResumeThread(IntPtr hThread);


		#endregion Public Methods

		#region Other

		// constants information can be found in <winnt.h>
		[Flags]
		public enum ProcessAccessType
		{
			PROCESS_TERMINATE = (0x0001),
			PROCESS_CREATE_THREAD = (0x0002),
			PROCESS_SET_SESSIONID = (0x0004),
			PROCESS_VM_OPERATION = (0x0008),
			PROCESS_VM_READ = (0x0010),
			PROCESS_VM_WRITE = (0x0020),
			PROCESS_DUP_HANDLE = (0x0040),
			PROCESS_CREATE_PROCESS = (0x0080),
			PROCESS_SET_QUOTA = (0x0100),
			PROCESS_SET_INFORMATION = (0x0200),
			PROCESS_QUERY_INFORMATION = (0x0400)
		}

		public enum AllocationType
		{
			MEM_COMMIT = 0x1000,
			MEM_RESERVE = 0x2000,
			MEM_RESET = 0x80000,
		}

		public enum FreeType
		{
			MEM_DECOMMIT = 0x4000,
			MEM_RELEASE = 0x8000,
		}

		[Flags]
		public enum MemoryProtection
		{
			PAGE_EXECUTE = 0x10,
			PAGE_EXECUTE_READ = 0x20,
			PAGE_EXECUTE_READWRITE = 0x40,
			PAGE_EXECUTE_WRITECOPY = 0x80,
			PAGE_NOACCESS = 0x01,
			PAGE_READONLY = 0x02,
			PAGE_READWRITE = 0x04,
			PAGE_WRITECOPY = 0x08,
		}

		[Flags]
		public enum ThreadAccess : int
		{
			TERMINATE = (0x0001),
			SUSPEND_RESUME = (0x0002),
			GET_CONTEXT = (0x0008),
			SET_CONTEXT = (0x0010),
			SET_INFORMATION = (0x0020),
			QUERY_INFORMATION = (0x0040),
			SET_THREAD_TOKEN = (0x0080),
			IMPERSONATE = (0x0100),
			DIRECT_IMPERSONATION = (0x0200)
		}

		#endregion Other
	}

	public class ProcessMemory
	{
		#region Fields

		private Process mReadProcess = null;
		private IntPtr m_hProcess = IntPtr.Zero;

		#endregion Fields

		#region Constructors

		public ProcessMemory()
		{
		}

		#endregion Constructors

		#region Public Properties

		/// <summary>	
		/// Process from which to read		
		/// </summary>
		public Process ReadProcess
		{
			get
			{
				return mReadProcess;
			}
			set
			{
				mReadProcess = value;
			}
		}

		#endregion Public Properties

		#region Public Methods

		public int GetExitCode()
		{
			if (m_hProcess == IntPtr.Zero)
				return 0;

			uint exitCode;
			int status = ProcessMemoryReaderApi.GetExitCodeProcess(m_hProcess, out exitCode);
			return (int)exitCode;
		}

		public void CloseHandle()
		{
			int iRetValue;
			iRetValue = ProcessMemoryReaderApi.CloseHandle(m_hProcess);
			if (iRetValue == 0)
				throw new Exception("CloseHandle failed");
		}

		public void OpenProcess()
		{
			//			m_hProcess = ProcessMemoryReaderApi.OpenProcess(ProcessMemoryReaderApi.PROCESS_VM_READ, 1, (uint)m_ReadProcess.Id);
			ProcessMemoryReaderApi.ProcessAccessType access;
			access = ProcessMemoryReaderApi.ProcessAccessType.PROCESS_VM_READ
				| ProcessMemoryReaderApi.ProcessAccessType.PROCESS_VM_WRITE
				| ProcessMemoryReaderApi.ProcessAccessType.PROCESS_VM_OPERATION;
			m_hProcess = ProcessMemoryReaderApi.OpenProcess((uint)access, 1, (uint)mReadProcess.Id);
		}

		public byte[] ReadProcessMemory(IntPtr MemoryAddress, uint bytesToRead, out int bytesRead)
		{
			uint old;
			ProcessMemoryReaderApi.VirtualProtectEx(m_hProcess, MemoryAddress, bytesToRead, (uint)ProcessMemoryReaderApi.MemoryProtection.PAGE_READWRITE, out old);

			byte[] buffer = new byte[bytesToRead];

			IntPtr ptrBytesRead;
			ProcessMemoryReaderApi.ReadProcessMemory(m_hProcess, MemoryAddress, buffer, bytesToRead, out ptrBytesRead);

			bytesRead = ptrBytesRead.ToInt32();

			return buffer;
		}

		public void WriteProcessMemory(IntPtr MemoryAddress, byte[] bytesToWrite, out int bytesWritten)
		{
			uint old;
			ProcessMemoryReaderApi.VirtualProtectEx(m_hProcess, MemoryAddress, (uint)bytesToWrite.Length, (uint)ProcessMemoryReaderApi.MemoryProtection.PAGE_READWRITE, out old);

			IntPtr ptrBytesWritten;
			ProcessMemoryReaderApi.WriteProcessMemory(m_hProcess, MemoryAddress, bytesToWrite, (uint)bytesToWrite.Length, out ptrBytesWritten);

			bytesWritten = ptrBytesWritten.ToInt32();
		}

		public IntPtr AllocateMemory(uint size)
		{
			return ProcessMemoryReaderApi.VirtualAllocEx(m_hProcess, IntPtr.Zero, size, (uint)ProcessMemoryReaderApi.AllocationType.MEM_COMMIT, (uint)ProcessMemoryReaderApi.MemoryProtection.PAGE_EXECUTE_READWRITE);
		}

		public void FreeMemory(IntPtr address)
		{
			ProcessMemoryReaderApi.VirtualFreeEx(m_hProcess, address, 0, (int)ProcessMemoryReaderApi.FreeType.MEM_RELEASE);
		}

		public void SuspendProcess()
		{
			foreach (ProcessThread thread in mReadProcess.Threads) {
				IntPtr openThread = ProcessMemoryReaderApi.OpenThread(ProcessMemoryReaderApi.ThreadAccess.SUSPEND_RESUME, false, (uint)thread.Id);
				if (openThread == IntPtr.Zero)
					continue;

				ProcessMemoryReaderApi.SuspendThread(openThread);
			}
		}

		public void ResumeProcess()
		{
			foreach (ProcessThread thread in mReadProcess.Threads) {
				IntPtr openThread = ProcessMemoryReaderApi.OpenThread(ProcessMemoryReaderApi.ThreadAccess.SUSPEND_RESUME, false, (uint)thread.Id);
				if (openThread == IntPtr.Zero)
					continue;

				ProcessMemoryReaderApi.ResumeThread(openThread);
			}
		}

		#endregion Public Methods
	}
}
