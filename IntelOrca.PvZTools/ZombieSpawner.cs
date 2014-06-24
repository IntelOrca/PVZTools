using IntelOrca.MemPatch;

namespace IntelOrca.PvZTools
{
	class ZombieSpawner
	{
		private PvZProcess mProcess;
		private CodeInjection mSpawnerCode;
		private bool mActive;

		public ZombieSpawner(PvZProcess process)
		{
			mProcess = process;
			byte[] code = new byte[] {
				0x50,																	//push ebx
				0x53,																	//push eax
				0xA1, 0xF9, 0x29, 0x6E, 0x00,											//eax, [6E29F9]
				0x83, 0xF8, 0x01,														//cmp eax, 1
				0x75, 0x1F,																//je 1Fh
				0xFF, 0x35, 0xFD, 0x29, 0x6E, 0x00,										//push [6E29FD]
				0xFF, 0x35, 0x01, 0x2A, 0x6E, 0x00,										//push [6E2A01]
				0x8B, 0xC7,																//mov eax, edi
				0xBB, 0xC0, 0xDD, 0x40, 0x00,											//mov ebx, 40DDC0h
				0xFF, 0xD3,																//call ebx
				0xC7, 0x05, 0xF9, 0x29, 0x6E, 0x00, 0x00, 0x00, 0x00, 0x00,				//mov [6E29F9], 0
				0x5B,																	//pop eax
				0x58 };																	//pop ebx

			//412A3C
			//412C0E
			//412DE0
			//412F86
			//413059		- 1
			//4263D2
			//429B90
			//42A103
			//439181		- MUST KEEP
			//534E17

			mProcess = process;
			mSpawnerCode = new CodeInjection(0x413D23, 6, code);
			mSpawnerCode.Process = mProcess;
		}

		public void Activate()
		{
			mActive = true;
			mSpawnerCode.Activate();
		}

		public void Deactivate()
		{
			mActive = false;
			mSpawnerCode.Deactivate();
		}

		public void Spawn(int type, int row)
		{
			//Set type
			mProcess.WriteInt32(0x006E2A01, type);

			//Set row
			mProcess.WriteInt32(0x006E29FD, row);

			//Set flag
			mProcess.WriteInt32(0x006E29F9, 1);
		}

		public bool Active
		{
			get
			{
				return mActive;
			}
		}
	}
}
