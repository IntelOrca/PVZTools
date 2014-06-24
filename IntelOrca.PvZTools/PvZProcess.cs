using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IntelOrca.MemPatch;

namespace IntelOrca.PvZTools
{
	class PvZProcess : AppProcess
	{
		public override string StartupPath
		{
			get { return @"C:\Program Files (x86)\PopCap Games\Plants vs. Zombies"; }
		}

		public override string ExecutablePath
		{
			get { return @"C:\Program Files (x86)\PopCap Games\Plants vs. Zombies\PlantsVsZombies.exe"; }
		}

		public override string ProcessName
		{
			get { return @"popcapgame1"; }
		}
	}
}
