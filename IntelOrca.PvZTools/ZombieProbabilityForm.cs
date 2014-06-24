using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace IntelOrca.PvZTools
{
	public partial class ZombieProbabilityForm : Form
	{
		private Random mRandom = new Random();
		private Panel[] mPanels = new Panel[2];
		private ZombieProbabilitySlider[] mSliders;

		public ZombieProbabilityForm()
		{
			this.SuspendLayout();
			this.MinimizeBox = false;
			this.MaximizeBox = false;
			this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
			this.Text = "Zombie Probability";
			this.ClientSize = new Size(400, 26 * 17);

			mPanels[0] = new Panel();
			mPanels[0].Location = new Point(3, 3);
			mPanels[0].Size = new Size(this.ClientSize.Width / 2 - 6, this.ClientSize.Height - 6);

			mPanels[1] = new Panel();
			mPanels[1].Location = new Point(this.ClientSize.Width / 2 + 3, 3);
			mPanels[1].Size = new Size(this.ClientSize.Width / 2 - 6, this.ClientSize.Height - 6);

			int full = Zombie.szZombieTypes.Length;
			int half = full / 2 + 1;

			mSliders = new ZombieProbabilitySlider[full];
			for (int i = 0; i < half; i++)
				mSliders[i] = CreateSlider(mPanels[0], i * 25, i);

			for (int i = half; i < full; i++)
				mSliders[i] = CreateSlider(mPanels[1], (i - half) * 25, i);

			this.Controls.Add(mPanels[0]);
			this.Controls.Add(mPanels[1]);

			this.ClientSize = new Size(this.ClientSize.Width, this.ClientSize.Height + 26);

			Button btnAllOff = new Button();
			btnAllOff.Location = new Point(3, this.ClientSize.Height - 26);
			btnAllOff.Size = new Size(80, 23);
			btnAllOff.Text = "All off";
			btnAllOff.Click += new EventHandler(btnAllOff_Click);
			this.Controls.Add(btnAllOff);

			Button btnAllOn = new Button();
			btnAllOn.Location = new Point(btnAllOff.Right + 3, btnAllOff.Top);
			btnAllOn.Size = new Size(80, 23);
			btnAllOn.Text = "All on";
			btnAllOn.Click += new EventHandler(btnAllOn_Click);
			this.Controls.Add(btnAllOn);

			this.ResumeLayout();
		}

		private ZombieProbabilitySlider CreateSlider(Panel panel, int y, int type)
		{
			ZombieProbabilitySlider zps = new ZombieProbabilitySlider();
			zps.Location = new Point(0, y);
			zps.Size = new Size(panel.Width, 23);
			zps.Text = Zombie.szZombieTypes[type];
			zps.Tag = type;
			panel.Controls.Add(zps);
			return zps;
		}

		private void btnAllOff_Click(object sender, EventArgs e)
		{
			foreach (ZombieProbabilitySlider slider in mSliders)
				slider.Probability = 0.0;
		}

		private void btnAllOn_Click(object sender, EventArgs e)
		{
			foreach (ZombieProbabilitySlider slider in mSliders)
				slider.Probability = 1.0;
		}

		protected override void OnClosing(CancelEventArgs e)
		{
			this.Hide();

			e.Cancel = true;
			base.OnClosing(e);
		}

		public int GetRandomZombieType()
		{
			int current = 0, total = 0;
			foreach (ZombieProbabilitySlider slider in mSliders)
				total += (int)(slider.Probability * 100.0);
			int r = mRandom.Next(0, total);
			foreach (ZombieProbabilitySlider slider in mSliders) {
				int max = current + (int)(slider.Probability * 100.0);
				if (r >= current && r < max)
					return (int)slider.Tag;
				current = max;
			}

			return 0;
		}
	}
}
