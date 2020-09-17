namespace IntelOrca.PvZTools
{
	partial class MainForm
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
            this.btnSpawnZombie = new System.Windows.Forms.Button();
            this.tmrSpawn = new System.Windows.Forms.Timer(this.components);
            this.grpZombie = new System.Windows.Forms.GroupBox();
            this.rdoSpecific = new System.Windows.Forms.RadioButton();
            this.rdoProbability = new System.Windows.Forms.RadioButton();
            this.cmbZombieType = new System.Windows.Forms.ComboBox();
            this.btnEditProbabilities = new System.Windows.Forms.Button();
            this.grpTimedLoop = new System.Windows.Forms.GroupBox();
            this.lblInterval = new System.Windows.Forms.Label();
            this.chkActive = new System.Windows.Forms.CheckBox();
            this.txtInterval = new System.Windows.Forms.TextBox();
            this.chkPool = new System.Windows.Forms.CheckBox();
            this.grpLanes = new System.Windows.Forms.GroupBox();
            this.chkLane5 = new System.Windows.Forms.CheckBox();
            this.chkLane4 = new System.Windows.Forms.CheckBox();
            this.chkLane3 = new System.Windows.Forms.CheckBox();
            this.chkLane2 = new System.Windows.Forms.CheckBox();
            this.chkLane1 = new System.Windows.Forms.CheckBox();
            this.chkLane0 = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.tmrStatusUpdate = new System.Windows.Forms.Timer(this.components);
            this.lblAuthor = new System.Windows.Forms.Label();
            this.grpZombie.SuspendLayout();
            this.grpTimedLoop.SuspendLayout();
            this.grpLanes.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSpawnZombie
            // 
            this.btnSpawnZombie.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSpawnZombie.Location = new System.Drawing.Point(26, 112);
            this.btnSpawnZombie.Name = "btnSpawnZombie";
            this.btnSpawnZombie.Size = new System.Drawing.Size(194, 23);
            this.btnSpawnZombie.TabIndex = 0;
            this.btnSpawnZombie.Text = "Spawn Zombie";
            this.btnSpawnZombie.UseVisualStyleBackColor = true;
            this.btnSpawnZombie.Click += new System.EventHandler(this.btnSpawnZombie_Click);
            // 
            // tmrSpawn
            // 
            this.tmrSpawn.Interval = 1000;
            this.tmrSpawn.Tick += new System.EventHandler(this.tmrSpawn_Tick);
            // 
            // grpZombie
            // 
            this.grpZombie.Controls.Add(this.rdoSpecific);
            this.grpZombie.Controls.Add(this.rdoProbability);
            this.grpZombie.Controls.Add(this.cmbZombieType);
            this.grpZombie.Controls.Add(this.btnEditProbabilities);
            this.grpZombie.Controls.Add(this.btnSpawnZombie);
            this.grpZombie.Location = new System.Drawing.Point(128, 57);
            this.grpZombie.Name = "grpZombie";
            this.grpZombie.Size = new System.Drawing.Size(226, 141);
            this.grpZombie.TabIndex = 1;
            this.grpZombie.TabStop = false;
            this.grpZombie.Text = "Zombie";
            // 
            // rdoSpecific
            // 
            this.rdoSpecific.AutoSize = true;
            this.rdoSpecific.Location = new System.Drawing.Point(6, 51);
            this.rdoSpecific.Name = "rdoSpecific";
            this.rdoSpecific.Size = new System.Drawing.Size(14, 13);
            this.rdoSpecific.TabIndex = 10;
            this.rdoSpecific.UseVisualStyleBackColor = true;
            // 
            // rdoProbability
            // 
            this.rdoProbability.AutoSize = true;
            this.rdoProbability.Checked = true;
            this.rdoProbability.Location = new System.Drawing.Point(6, 24);
            this.rdoProbability.Name = "rdoProbability";
            this.rdoProbability.Size = new System.Drawing.Size(14, 13);
            this.rdoProbability.TabIndex = 9;
            this.rdoProbability.TabStop = true;
            this.rdoProbability.UseVisualStyleBackColor = true;
            // 
            // cmbZombieType
            // 
            this.cmbZombieType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbZombieType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbZombieType.FormattingEnabled = true;
            this.cmbZombieType.Location = new System.Drawing.Point(26, 48);
            this.cmbZombieType.Name = "cmbZombieType";
            this.cmbZombieType.Size = new System.Drawing.Size(194, 21);
            this.cmbZombieType.TabIndex = 1;
            // 
            // btnEditProbabilities
            // 
            this.btnEditProbabilities.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditProbabilities.Location = new System.Drawing.Point(26, 19);
            this.btnEditProbabilities.Name = "btnEditProbabilities";
            this.btnEditProbabilities.Size = new System.Drawing.Size(194, 23);
            this.btnEditProbabilities.TabIndex = 5;
            this.btnEditProbabilities.Text = "Edit Probabilities";
            this.btnEditProbabilities.UseVisualStyleBackColor = true;
            this.btnEditProbabilities.Click += new System.EventHandler(this.btnEditProbabilities_Click);
            // 
            // grpTimedLoop
            // 
            this.grpTimedLoop.Controls.Add(this.lblInterval);
            this.grpTimedLoop.Controls.Add(this.chkActive);
            this.grpTimedLoop.Controls.Add(this.txtInterval);
            this.grpTimedLoop.Location = new System.Drawing.Point(128, 204);
            this.grpTimedLoop.Name = "grpTimedLoop";
            this.grpTimedLoop.Size = new System.Drawing.Size(226, 67);
            this.grpTimedLoop.TabIndex = 2;
            this.grpTimedLoop.TabStop = false;
            this.grpTimedLoop.Text = "Timed Loop";
            // 
            // lblInterval
            // 
            this.lblInterval.AutoSize = true;
            this.lblInterval.Location = new System.Drawing.Point(6, 22);
            this.lblInterval.Name = "lblInterval";
            this.lblInterval.Size = new System.Drawing.Size(45, 13);
            this.lblInterval.TabIndex = 2;
            this.lblInterval.Text = "Interval:";
            // 
            // chkActive
            // 
            this.chkActive.AutoSize = true;
            this.chkActive.Location = new System.Drawing.Point(6, 45);
            this.chkActive.Name = "chkActive";
            this.chkActive.Size = new System.Drawing.Size(56, 17);
            this.chkActive.TabIndex = 1;
            this.chkActive.Text = "Active";
            this.chkActive.UseVisualStyleBackColor = true;
            this.chkActive.CheckedChanged += new System.EventHandler(this.chkActive_CheckedChanged);
            // 
            // txtInterval
            // 
            this.txtInterval.Location = new System.Drawing.Point(59, 19);
            this.txtInterval.Name = "txtInterval";
            this.txtInterval.Size = new System.Drawing.Size(71, 20);
            this.txtInterval.TabIndex = 0;
            this.txtInterval.Text = "2000";
            this.txtInterval.TextChanged += new System.EventHandler(this.txtInterval_TextChanged);
            // 
            // chkPool
            // 
            this.chkPool.AutoSize = true;
            this.chkPool.Location = new System.Drawing.Point(6, 19);
            this.chkPool.Name = "chkPool";
            this.chkPool.Size = new System.Drawing.Size(76, 17);
            this.chkPool.TabIndex = 6;
            this.chkPool.Text = "Pool Level";
            this.chkPool.UseVisualStyleBackColor = true;
            this.chkPool.CheckedChanged += new System.EventHandler(this.chkPool_CheckedChanged);
            // 
            // grpLanes
            // 
            this.grpLanes.Controls.Add(this.chkLane5);
            this.grpLanes.Controls.Add(this.chkPool);
            this.grpLanes.Controls.Add(this.chkLane4);
            this.grpLanes.Controls.Add(this.chkLane3);
            this.grpLanes.Controls.Add(this.chkLane2);
            this.grpLanes.Controls.Add(this.chkLane1);
            this.grpLanes.Controls.Add(this.chkLane0);
            this.grpLanes.Location = new System.Drawing.Point(12, 57);
            this.grpLanes.Name = "grpLanes";
            this.grpLanes.Size = new System.Drawing.Size(110, 141);
            this.grpLanes.TabIndex = 7;
            this.grpLanes.TabStop = false;
            this.grpLanes.Text = "Lanes";
            // 
            // chkLane5
            // 
            this.chkLane5.AutoSize = true;
            this.chkLane5.Checked = true;
            this.chkLane5.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkLane5.Location = new System.Drawing.Point(6, 119);
            this.chkLane5.Name = "chkLane5";
            this.chkLane5.Size = new System.Drawing.Size(32, 17);
            this.chkLane5.TabIndex = 15;
            this.chkLane5.Text = "6";
            this.chkLane5.UseVisualStyleBackColor = true;
            // 
            // chkLane4
            // 
            this.chkLane4.AutoSize = true;
            this.chkLane4.Checked = true;
            this.chkLane4.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkLane4.Location = new System.Drawing.Point(6, 104);
            this.chkLane4.Name = "chkLane4";
            this.chkLane4.Size = new System.Drawing.Size(32, 17);
            this.chkLane4.TabIndex = 14;
            this.chkLane4.Text = "5";
            this.chkLane4.UseVisualStyleBackColor = true;
            // 
            // chkLane3
            // 
            this.chkLane3.AutoSize = true;
            this.chkLane3.Checked = true;
            this.chkLane3.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkLane3.ForeColor = System.Drawing.Color.Blue;
            this.chkLane3.Location = new System.Drawing.Point(6, 89);
            this.chkLane3.Name = "chkLane3";
            this.chkLane3.Size = new System.Drawing.Size(32, 17);
            this.chkLane3.TabIndex = 13;
            this.chkLane3.Text = "4";
            this.chkLane3.UseVisualStyleBackColor = true;
            // 
            // chkLane2
            // 
            this.chkLane2.AutoSize = true;
            this.chkLane2.Checked = true;
            this.chkLane2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkLane2.ForeColor = System.Drawing.Color.Blue;
            this.chkLane2.Location = new System.Drawing.Point(6, 74);
            this.chkLane2.Name = "chkLane2";
            this.chkLane2.Size = new System.Drawing.Size(32, 17);
            this.chkLane2.TabIndex = 12;
            this.chkLane2.Text = "3";
            this.chkLane2.UseVisualStyleBackColor = true;
            // 
            // chkLane1
            // 
            this.chkLane1.AutoSize = true;
            this.chkLane1.Checked = true;
            this.chkLane1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkLane1.Location = new System.Drawing.Point(6, 59);
            this.chkLane1.Name = "chkLane1";
            this.chkLane1.Size = new System.Drawing.Size(32, 17);
            this.chkLane1.TabIndex = 11;
            this.chkLane1.Text = "2";
            this.chkLane1.UseVisualStyleBackColor = true;
            // 
            // chkLane0
            // 
            this.chkLane0.AutoSize = true;
            this.chkLane0.Checked = true;
            this.chkLane0.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkLane0.Location = new System.Drawing.Point(6, 44);
            this.chkLane0.Name = "chkLane0";
            this.chkLane0.Size = new System.Drawing.Size(32, 17);
            this.chkLane0.TabIndex = 10;
            this.chkLane0.Text = "1";
            this.chkLane0.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblStatus);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(342, 39);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Status";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(6, 18);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(40, 13);
            this.lblStatus.TabIndex = 0;
            this.lblStatus.Text = "Status:";
            // 
            // tmrStatusUpdate
            // 
            this.tmrStatusUpdate.Enabled = true;
            this.tmrStatusUpdate.Interval = 5000;
            this.tmrStatusUpdate.Tick += new System.EventHandler(this.tmrStatusUpdate_Tick);
            // 
            // lblAuthor
            // 
            this.lblAuthor.AutoSize = true;
            this.lblAuthor.ForeColor = System.Drawing.Color.Blue;
            this.lblAuthor.Location = new System.Drawing.Point(9, 279);
            this.lblAuthor.Name = "lblAuthor";
            this.lblAuthor.Size = new System.Drawing.Size(145, 13);
            this.lblAuthor.TabIndex = 9;
            this.lblAuthor.Text = "PvZ Tools by Ted John 2012";
            this.lblAuthor.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lblAuthor_MouseDown);
            this.lblAuthor.MouseEnter += new System.EventHandler(this.lblAuthor_MouseEnter);
            this.lblAuthor.MouseLeave += new System.EventHandler(this.lblAuthor_MouseLeave);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(362, 303);
            this.Controls.Add(this.lblAuthor);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grpLanes);
            this.Controls.Add(this.grpTimedLoop);
            this.Controls.Add(this.grpZombie);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PvZ Tools";
            this.grpZombie.ResumeLayout(false);
            this.grpZombie.PerformLayout();
            this.grpTimedLoop.ResumeLayout(false);
            this.grpTimedLoop.PerformLayout();
            this.grpLanes.ResumeLayout(false);
            this.grpLanes.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btnSpawnZombie;
		private System.Windows.Forms.Timer tmrSpawn;
		private System.Windows.Forms.GroupBox grpZombie;
		private System.Windows.Forms.ComboBox cmbZombieType;
		private System.Windows.Forms.GroupBox grpTimedLoop;
		private System.Windows.Forms.Label lblInterval;
		private System.Windows.Forms.CheckBox chkActive;
		private System.Windows.Forms.TextBox txtInterval;
		private System.Windows.Forms.Button btnEditProbabilities;
		private System.Windows.Forms.CheckBox chkPool;
		private System.Windows.Forms.RadioButton rdoSpecific;
		private System.Windows.Forms.RadioButton rdoProbability;
		private System.Windows.Forms.GroupBox grpLanes;
		private System.Windows.Forms.CheckBox chkLane5;
		private System.Windows.Forms.CheckBox chkLane4;
		private System.Windows.Forms.CheckBox chkLane3;
		private System.Windows.Forms.CheckBox chkLane2;
		private System.Windows.Forms.CheckBox chkLane1;
		private System.Windows.Forms.CheckBox chkLane0;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label lblStatus;
		private System.Windows.Forms.Timer tmrStatusUpdate;
		private System.Windows.Forms.Label lblAuthor;
	}
}