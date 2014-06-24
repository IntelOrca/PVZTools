using System;
using System.Drawing;
using System.Windows.Forms;

namespace IntelOrca.PvZTools
{
	class ZombieProbabilitySlider : Control
	{
		private Label mLabel;
		private TrackBar mTrackBar;

		public ZombieProbabilitySlider()
		{
			this.SuspendLayout();

			mLabel = new Label();
			mLabel.AutoSize = false;
			mLabel.TextAlign = ContentAlignment.MiddleLeft;
			mLabel.ForeColor = Color.DarkGray;
			mLabel.Text = this.Text;
			mLabel.MouseDown += new MouseEventHandler(mLabel_MouseDown);

			mTrackBar = new TrackBar();
			mTrackBar.TickStyle = TickStyle.None;
			mTrackBar.Maximum = 100;
			mTrackBar.LargeChange = 10;
			mTrackBar.AutoSize = false;
			mTrackBar.ValueChanged += new EventHandler(mTrackBar_ValueChanged);

			this.Controls.Add(mLabel);
			this.Controls.Add(mTrackBar);

			this.ResumeLayout();

			this.Width = 100;
			this.Height = 23;
		}

		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);

			mLabel.Location = new Point(0, 0);
			mLabel.Size = new Size((int)(this.Width * 0.45), this.Height);
			mTrackBar.Location = new Point(mLabel.Right + 3, 0);
			mTrackBar.Size = new Size(this.Width - mTrackBar.Left, this.Height);
		}

		private void mTrackBar_ValueChanged(object sender, EventArgs e)
		{
			if (mTrackBar.Value == 0)
				mLabel.ForeColor = Color.DarkGray;
			else
				mLabel.ForeColor = Color.Black;
		}

		void mLabel_MouseDown(object sender, MouseEventArgs e)
		{
			if (mTrackBar.Value > 0)
				mTrackBar.Value = 0;
			else
				mTrackBar.Value = 100;
		}

		public override string Text
		{
			get
			{
				return mLabel.Text;
			}
			set
			{
				mLabel.Text = value;
			}
		}

		public double Probability
		{
			get
			{
				return (double)mTrackBar.Value / 100.0;
			}
			set
			{
				mTrackBar.Value = Math.Max(Math.Min((int)(value * 100.0), 100), 0);
			}
		}
	}
}
