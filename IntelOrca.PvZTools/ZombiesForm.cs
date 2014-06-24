using System;
using System.IO;
using System.Windows.Forms;

namespace IntelOrca.PvZTools
{
	partial class ZombiesForm : Form
	{
		PvZProcess mProcess;

		public ZombiesForm(PvZProcess process)
		{
			mProcess = process;

			InitializeComponent();

			DoubleBuffered = true;

			AddColumn("IDX");
			AddColumn("X");
			AddColumn("Y");
			AddColumn("Layer");
			AddColumn("Health");
			AddColumn("Offset");

			if (!mProcess.IsRunning)
				throw new Exception();

			ReadZombies();
		}

		private void AddColumn(string name)
		{
			dgvZombies.Columns.Add("col" + name, name);
		}

		private Zombie ZombieFromFile(string path)
		{
			return new Zombie(File.ReadAllBytes(path));
		}

		private Zombie SetZombieFromBase(Zombie z, string baseZombie)
		{
			return SetZombieFromBase(z, ZombieFromFile(baseZombie));
		}

		private Zombie SetZombieFromBase(Zombie z, Zombie baseZombie)
		{
			Zombie z2 = (Zombie)baseZombie.Clone();
			z2.X = z.X;
			z2.Y = z.Y;
			z2.Row = z.Row;
			z2.AppBasePointer = z.AppBasePointer;
			z2.BoardPointer = z.BoardPointer;
			return z2;
		}

		private void ReadZombies()
		{
			dgvZombies.Rows.Clear();

			int numZombies = 0;

			for (int i = 0; ; i++) {
				int offset = GetZombieOffset(i);
				byte[] zom = ReadZombie(i);
				if (zom[0] == 0x00)
					break;

				Zombie zombie = new Zombie(zom);

				if (zombie.Type != 2) {
					//zombie = SetZombieFromBase(zombie, "zombies\\cone.dat");
					//WriteZombie(i, zombie);
				}

				//if (zombie.Type == 2)
					//File.WriteAllBytes("zombies\\cone.dat", zombie.Data);
				

				//if (zombie.X < 200) {
				//    zombie.X = 600;
				//    WriteZombie(i, zombie);
				//}

				dgvZombies.Rows.Add(i, zombie.X, zombie.Y, zombie.Row, zombie.Health, String.Format("0x{0:X}", offset));

				numZombies++;
			}

			//copyZom = new Zombie(ReadZombie(numZombies - 1));
		}

		Zombie copyZom;

		private int GetZombieAddress(int idx)
		{
			return mProcess.GetPointerAddress(0x69A508, new int[] { 0x1A10, 0x1C, 0x18, 0x8C, idx * Zombie.StructSize });
		}

		private byte[] ReadZombie(int idx)
		{
			return mProcess.GetBytes(GetZombieAddress(idx), Zombie.StructSize);
		}

		private void WriteZombie(int idx, Zombie zombie)
		{
			mProcess.WriteBytes(GetZombieAddress(idx), zombie.Data);
		}

		private int GetZombieOffset(int idx)
		{
			int structSize = 0x15C;

			int static_ptr = 0x69A508;
			int[] offsets = new int[] { 0x1A10, 0x1C, 0x18, 0x8C, idx * structSize };

			return mProcess.GetPointerAddress(static_ptr, offsets);
		}

		private void tmrUpdate_Tick(object sender, EventArgs e)
		{
			ReadZombies();
		}
	}
}
