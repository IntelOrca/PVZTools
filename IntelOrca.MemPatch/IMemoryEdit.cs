
namespace IntelOrca.MemPatch
{
	public interface IMemoryEdit
	{
		AppProcess Process
		{
			get;
			set;
		}

		void Activate();
		void Deactivate();
	}
}
