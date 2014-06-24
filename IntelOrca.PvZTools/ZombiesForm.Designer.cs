namespace IntelOrca.PvZTools
{
	partial class ZombiesForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.dgvZombies = new System.Windows.Forms.DataGridView();
			this.tmrUpdate = new System.Windows.Forms.Timer(this.components);
			((System.ComponentModel.ISupportInitialize)(this.dgvZombies)).BeginInit();
			this.SuspendLayout();
			// 
			// dgvZombies
			// 
			this.dgvZombies.AllowUserToAddRows = false;
			this.dgvZombies.AllowUserToDeleteRows = false;
			this.dgvZombies.AllowUserToResizeColumns = false;
			this.dgvZombies.AllowUserToResizeRows = false;
			this.dgvZombies.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.dgvZombies.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dgvZombies.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvZombies.Location = new System.Drawing.Point(12, 12);
			this.dgvZombies.Name = "dgvZombies";
			this.dgvZombies.ReadOnly = true;
			this.dgvZombies.RowHeadersVisible = false;
			this.dgvZombies.Size = new System.Drawing.Size(372, 359);
			this.dgvZombies.TabIndex = 0;
			// 
			// tmrUpdate
			// 
			this.tmrUpdate.Enabled = true;
			this.tmrUpdate.Interval = 500;
			this.tmrUpdate.Tick += new System.EventHandler(this.tmrUpdate_Tick);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(396, 383);
			this.Controls.Add(this.dgvZombies);
			this.Name = "MainForm";
			this.Text = "Form1";
			((System.ComponentModel.ISupportInitialize)(this.dgvZombies)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.DataGridView dgvZombies;
		private System.Windows.Forms.Timer tmrUpdate;
	}
}

