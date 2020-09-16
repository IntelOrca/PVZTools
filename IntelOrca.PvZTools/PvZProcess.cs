#nullable enable
using System;
using System.Linq;
using Microsoft.Win32;
using IntelOrca.MemPatch;
using System.IO;

namespace IntelOrca.PvZTools
{
	class PvZProcess : AppProcess
	{
		internal PvZProcess()
        {
			(string? path, bool goty) = GetInstallLocation(@"SOFTWARE\WOW6432Node\Microsoft\Windows\CurrentVersion\Uninstall"); //as 32bit
			if (path is null)
			{
				(path, goty) = GetInstallLocation(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall"); //as 64bit
				if (path is null) throw new NullReferenceException("Could not find a Plants vs. Zombies installation.");
			}

			GOTY = goty;
			StartupPath = path;
		}

        readonly string[] displayNames = new string[] { "Plants vs. Zombies", "Plants vs. Zombies SDR" };
        readonly string goty = "Plants vs. Zombies: Game of the Year";

		private (string? path, bool goty) GetInstallLocation(string regkey)
        {
            using RegistryKey installed = Registry.LocalMachine.OpenSubKey(regkey);
            foreach (string id in installed.GetSubKeyNames())
            {
                using RegistryKey program = installed.OpenSubKey(id);
				string displayName = (string)program.GetValue("DisplayName");

				if (displayNames.Contains(displayName))
					return ((string)program.GetValue("InstallLocation") ?? Path.GetDirectoryName((string)program.GetValue("DisplayIcon")), false);
				else if (goty == (string)program.GetValue("DisplayName"))
					return ((string)program.GetValue("InstallLocation") ?? Path.GetDirectoryName((string)program.GetValue("DisplayIcon")), true);
            }

			return (null, false);
        }

		public override string StartupPath { get; }

		public override string ExecutablePath => StartupPath + '\\' + ProcessName;

		public override string ProcessName => GOTY ? "popcapgame1" : "PlantsVsZombies";

		public bool GOTY { get; private set; }
	}
}
