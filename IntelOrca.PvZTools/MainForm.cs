using IntelOrca.PvZTools.Properties;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace IntelOrca.PvZTools
{
	public partial class MainForm : Form
	{
		PvZProcess mProcess = new PvZProcess();
		ZombieSpawner mSpawner;
		ZombieProbabilityForm mZPF = new ZombieProbabilityForm();

		Random mRand = new Random();

		public MainForm()
		{
			InitializeComponent();

			this.Icon = Resources.orca_icon;
			MessageBox.Show("PvZ Tools will only work for the original version of Plants vs. Zombies. You will have to obtain this yourself. In the likely case that this program does not work for you, it is probably because you have the wrong version. I am unable to stop the game from spawning level zombies at this time. The source code for this can be found on GitHub (https://github.com/IntelOrca/PVZTools)", "Message from the author");

			chkPool.Checked = true;

			for (int i = 0; i < Zombie.szZombieTypes.Length; i++)
				cmbZombieType.Items.Add(Zombie.szZombieTypes[i]);

			cmbZombieType.SelectedIndex = 0;

			tmrSpawn.Interval = 2000;

			//CreateSliderGroup();

			UpdateStatus();
		}

		private void SpawnZombie()
		{
			int zombieType;
			if (rdoProbability.Checked)
				zombieType = mZPF.GetRandomZombieType();
			else
				zombieType = GetZombieType();
			
			mSpawner.Spawn(zombieType, GetRandomRowFromSelection(zombieType));
		}

		private void btnSpawnZombie_Click(object sender, EventArgs e)
		{
			SpawnZombie();
		}

		private int GetZombieType()
		{
			return cmbZombieType.SelectedIndex;
		}

		private int GetRandomRowFromSelection(int type = -1)
		{
			List<int> lanes = new List<int>();
			for (int i = 0; i < 6; i++) {
				if ((i == 2 || i == 3) && type != -1 && chkPool.Checked)
					if (!Zombie.CanZombieSwim[type])
						continue;

				string ctlName = "chkLane" + i;
				CheckBox ctl = (CheckBox)grpLanes.Controls[ctlName];
				if (ctl.Checked)
					lanes.Add(i);
			}

			if (lanes.Count == 0)
				return -1;

			return lanes[mRand.Next(0, lanes.Count)];
		}

		private void tmrSpawn_Tick(object sender, EventArgs e)
		{
			if (!chkActive.Checked)
				return;

			SpawnZombie();
		}

		private void txtInterval_TextChanged(object sender, EventArgs e)
		{
			chkActive.Checked = false;

			foreach (Char c in txtInterval.Text) {
				if (!Char.IsNumber(c)) {
					txtInterval.ForeColor = Color.Red;
					return;
				}
			}

			int result;
			if (Int32.TryParse(txtInterval.Text, out result)) {
				txtInterval.ForeColor = Color.Black;
				try {
					tmrSpawn.Interval = result;
				} catch {
					txtInterval.ForeColor = Color.Red;
				}
			} else {
				txtInterval.ForeColor = Color.Red;
			}
		}

		private void btnEditProbabilities_Click(object sender, EventArgs e)
		{
			mZPF.Show();
		}

		private void chkPool_CheckedChanged(object sender, EventArgs e)
		{
			chkLane2.ForeColor = chkLane3.ForeColor = (chkPool.Checked ? Color.Blue : Color.Black);
		}

		private void tmrStatusUpdate_Tick(object sender, EventArgs e)
		{
			UpdateStatus();
		}

		private void UpdateStatus()
		{
			if (mProcess.HasProcess)
				return;

			if (!mProcess.OpenProcess()) {
				lblStatus.Text = "Status: Unable to connect...";
			} else {
				lblStatus.Text = "Status: Running...";
				mSpawner = new ZombieSpawner(mProcess);
				mSpawner.Activate();
				//Cheats.NoSunDecrease(mMemory);
			}
		}

		protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
		{
			if (mSpawner != null)
				if (mSpawner.Active)
					mSpawner.Deactivate();

			base.OnClosing(e);
		}

		private void lblAuthor_MouseEnter(object sender, EventArgs e)
		{
			lblAuthor.Font = new Font(lblAuthor.Font, FontStyle.Underline);
		}

		private void lblAuthor_MouseLeave(object sender, EventArgs e)
		{
			lblAuthor.Font = new Font(lblAuthor.Font, FontStyle.Regular);
		}

		private void lblAuthor_MouseDown(object sender, MouseEventArgs e)
		{
			Process.Start("http://tedtycoon.co.uk");
		}
	}
}
