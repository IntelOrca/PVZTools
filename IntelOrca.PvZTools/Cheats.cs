using IntelOrca.MemPatch;

namespace IntelOrca.PvZTools
{
	static class Cheats
	{
		public static void NoSunDecrease(PvZProcess process)
		{
			CodeReplacement cr = new CodeReplacement(0x41BA76, 6);
			cr.Activate();
		}
	}
}
