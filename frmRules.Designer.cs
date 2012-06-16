namespace GodvilleAutoPlayer
{
	partial class frmRules
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
			if (disposing && (components != null))
			{
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRules));
			this.label1 = new System.Windows.Forms.Label();
			this.ddlCondition1 = new System.Windows.Forms.ComboBox();
			this.chkRule1 = new System.Windows.Forms.CheckBox();
			this.ddlAction1 = new System.Windows.Forms.ComboBox();
			this.tbxMinutes1 = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.ddlComparison1 = new System.Windows.Forms.ComboBox();
			this.tbxValue1 = new System.Windows.Forms.TextBox();
			this.tbxValue2 = new System.Windows.Forms.TextBox();
			this.ddlComparison2 = new System.Windows.Forms.ComboBox();
			this.label3 = new System.Windows.Forms.Label();
			this.tbxMinutes2 = new System.Windows.Forms.TextBox();
			this.ddlAction2 = new System.Windows.Forms.ComboBox();
			this.chkRule2 = new System.Windows.Forms.CheckBox();
			this.ddlCondition2 = new System.Windows.Forms.ComboBox();
			this.label4 = new System.Windows.Forms.Label();
			this.tbxValue3 = new System.Windows.Forms.TextBox();
			this.ddlComparison3 = new System.Windows.Forms.ComboBox();
			this.label5 = new System.Windows.Forms.Label();
			this.tbxMinutes3 = new System.Windows.Forms.TextBox();
			this.ddlAction3 = new System.Windows.Forms.ComboBox();
			this.chkRule3 = new System.Windows.Forms.CheckBox();
			this.ddlCondition3 = new System.Windows.Forms.ComboBox();
			this.label6 = new System.Windows.Forms.Label();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnSave = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(168, 13);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(59, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Hero every";
			// 
			// ddlCondition1
			// 
			this.ddlCondition1.FormattingEnabled = true;
			this.ddlCondition1.Items.AddRange(new object[] {
            "God Power",
            "Current Health (%)"});
			this.ddlCondition1.Location = new System.Drawing.Point(348, 10);
			this.ddlCondition1.Name = "ddlCondition1";
			this.ddlCondition1.Size = new System.Drawing.Size(121, 21);
			this.ddlCondition1.TabIndex = 1;
			this.ddlCondition1.Text = "God Power";
			// 
			// chkRule1
			// 
			this.chkRule1.AutoSize = true;
			this.chkRule1.Location = new System.Drawing.Point(12, 12);
			this.chkRule1.Name = "chkRule1";
			this.chkRule1.Size = new System.Drawing.Size(57, 17);
			this.chkRule1.TabIndex = 2;
			this.chkRule1.Text = "Rule 1";
			this.chkRule1.UseVisualStyleBackColor = true;
			// 
			// ddlAction1
			// 
			this.ddlAction1.FormattingEnabled = true;
			this.ddlAction1.Items.AddRange(new object[] {
            "Encourage",
            "Punish"});
			this.ddlAction1.Location = new System.Drawing.Point(75, 10);
			this.ddlAction1.Name = "ddlAction1";
			this.ddlAction1.Size = new System.Drawing.Size(84, 21);
			this.ddlAction1.TabIndex = 4;
			this.ddlAction1.Text = "Encourage";
			// 
			// tbxMinutes1
			// 
			this.tbxMinutes1.Location = new System.Drawing.Point(233, 10);
			this.tbxMinutes1.Name = "tbxMinutes1";
			this.tbxMinutes1.Size = new System.Drawing.Size(49, 20);
			this.tbxMinutes1.TabIndex = 5;
			this.tbxMinutes1.Text = "15";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(288, 13);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(54, 13);
			this.label2.TabIndex = 6;
			this.label2.Text = "minutes, if";
			// 
			// ddlComparison1
			// 
			this.ddlComparison1.FormattingEnabled = true;
			this.ddlComparison1.Items.AddRange(new object[] {
            ">",
            "<",
            "=",
            ">=",
            "<="});
			this.ddlComparison1.Location = new System.Drawing.Point(475, 10);
			this.ddlComparison1.Name = "ddlComparison1";
			this.ddlComparison1.Size = new System.Drawing.Size(33, 21);
			this.ddlComparison1.TabIndex = 7;
			this.ddlComparison1.Tag = "";
			this.ddlComparison1.Text = ">";
			// 
			// tbxValue1
			// 
			this.tbxValue1.Location = new System.Drawing.Point(514, 10);
			this.tbxValue1.Name = "tbxValue1";
			this.tbxValue1.Size = new System.Drawing.Size(49, 20);
			this.tbxValue1.TabIndex = 8;
			this.tbxValue1.Text = "25";
			// 
			// tbxValue2
			// 
			this.tbxValue2.Location = new System.Drawing.Point(514, 42);
			this.tbxValue2.Name = "tbxValue2";
			this.tbxValue2.Size = new System.Drawing.Size(49, 20);
			this.tbxValue2.TabIndex = 16;
			this.tbxValue2.Text = "25";
			// 
			// ddlComparison2
			// 
			this.ddlComparison2.FormattingEnabled = true;
			this.ddlComparison2.Items.AddRange(new object[] {
            ">",
            "<",
            "=",
            ">=",
            "<="});
			this.ddlComparison2.Location = new System.Drawing.Point(475, 42);
			this.ddlComparison2.Name = "ddlComparison2";
			this.ddlComparison2.Size = new System.Drawing.Size(33, 21);
			this.ddlComparison2.TabIndex = 15;
			this.ddlComparison2.Tag = "";
			this.ddlComparison2.Text = ">";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(288, 45);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(54, 13);
			this.label3.TabIndex = 14;
			this.label3.Text = "minutes, if";
			// 
			// tbxMinutes2
			// 
			this.tbxMinutes2.Location = new System.Drawing.Point(233, 42);
			this.tbxMinutes2.Name = "tbxMinutes2";
			this.tbxMinutes2.Size = new System.Drawing.Size(49, 20);
			this.tbxMinutes2.TabIndex = 13;
			this.tbxMinutes2.Text = "15";
			// 
			// ddlAction2
			// 
			this.ddlAction2.FormattingEnabled = true;
			this.ddlAction2.Items.AddRange(new object[] {
            "Encourage",
            "Punish"});
			this.ddlAction2.Location = new System.Drawing.Point(75, 42);
			this.ddlAction2.Name = "ddlAction2";
			this.ddlAction2.Size = new System.Drawing.Size(84, 21);
			this.ddlAction2.TabIndex = 12;
			this.ddlAction2.Text = "Encourage";
			// 
			// chkRule2
			// 
			this.chkRule2.AutoSize = true;
			this.chkRule2.Location = new System.Drawing.Point(12, 44);
			this.chkRule2.Name = "chkRule2";
			this.chkRule2.Size = new System.Drawing.Size(57, 17);
			this.chkRule2.TabIndex = 11;
			this.chkRule2.Text = "Rule 2";
			this.chkRule2.UseVisualStyleBackColor = true;
			// 
			// ddlCondition2
			// 
			this.ddlCondition2.FormattingEnabled = true;
			this.ddlCondition2.Items.AddRange(new object[] {
            "God Power",
            "Current Health (%)"});
			this.ddlCondition2.Location = new System.Drawing.Point(348, 42);
			this.ddlCondition2.Name = "ddlCondition2";
			this.ddlCondition2.Size = new System.Drawing.Size(121, 21);
			this.ddlCondition2.TabIndex = 10;
			this.ddlCondition2.Text = "God Power";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(168, 45);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(59, 13);
			this.label4.TabIndex = 9;
			this.label4.Text = "Hero every";
			// 
			// tbxValue3
			// 
			this.tbxValue3.Location = new System.Drawing.Point(514, 74);
			this.tbxValue3.Name = "tbxValue3";
			this.tbxValue3.Size = new System.Drawing.Size(49, 20);
			this.tbxValue3.TabIndex = 24;
			this.tbxValue3.Text = "25";
			// 
			// ddlComparison3
			// 
			this.ddlComparison3.FormattingEnabled = true;
			this.ddlComparison3.Items.AddRange(new object[] {
            ">",
            "<",
            "=",
            ">=",
            "<="});
			this.ddlComparison3.Location = new System.Drawing.Point(475, 74);
			this.ddlComparison3.Name = "ddlComparison3";
			this.ddlComparison3.Size = new System.Drawing.Size(33, 21);
			this.ddlComparison3.TabIndex = 23;
			this.ddlComparison3.Tag = "";
			this.ddlComparison3.Text = ">";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(288, 77);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(54, 13);
			this.label5.TabIndex = 22;
			this.label5.Text = "minutes, if";
			// 
			// tbxMinutes3
			// 
			this.tbxMinutes3.Location = new System.Drawing.Point(233, 74);
			this.tbxMinutes3.Name = "tbxMinutes3";
			this.tbxMinutes3.Size = new System.Drawing.Size(49, 20);
			this.tbxMinutes3.TabIndex = 21;
			this.tbxMinutes3.Text = "15";
			// 
			// ddlAction3
			// 
			this.ddlAction3.FormattingEnabled = true;
			this.ddlAction3.Items.AddRange(new object[] {
            "Encourage",
            "Punish"});
			this.ddlAction3.Location = new System.Drawing.Point(75, 74);
			this.ddlAction3.Name = "ddlAction3";
			this.ddlAction3.Size = new System.Drawing.Size(84, 21);
			this.ddlAction3.TabIndex = 20;
			this.ddlAction3.Text = "Encourage";
			// 
			// chkRule3
			// 
			this.chkRule3.AutoSize = true;
			this.chkRule3.Location = new System.Drawing.Point(12, 76);
			this.chkRule3.Name = "chkRule3";
			this.chkRule3.Size = new System.Drawing.Size(57, 17);
			this.chkRule3.TabIndex = 19;
			this.chkRule3.Text = "Rule 3";
			this.chkRule3.UseVisualStyleBackColor = true;
			// 
			// ddlCondition3
			// 
			this.ddlCondition3.FormattingEnabled = true;
			this.ddlCondition3.Items.AddRange(new object[] {
            "God Power",
            "Current Health (%)"});
			this.ddlCondition3.Location = new System.Drawing.Point(348, 74);
			this.ddlCondition3.Name = "ddlCondition3";
			this.ddlCondition3.Size = new System.Drawing.Size(121, 21);
			this.ddlCondition3.TabIndex = 18;
			this.ddlCondition3.Text = "God Power";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(168, 77);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(59, 13);
			this.label6.TabIndex = 17;
			this.label6.Text = "Hero every";
			// 
			// btnCancel
			// 
			this.btnCancel.Location = new System.Drawing.Point(488, 113);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 25;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// btnSave
			// 
			this.btnSave.Location = new System.Drawing.Point(407, 113);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(75, 23);
			this.btnSave.TabIndex = 26;
			this.btnSave.Text = "Save";
			this.btnSave.UseVisualStyleBackColor = true;
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// frmRules
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(588, 154);
			this.Controls.Add(this.btnSave);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.tbxValue3);
			this.Controls.Add(this.ddlComparison3);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.tbxMinutes3);
			this.Controls.Add(this.ddlAction3);
			this.Controls.Add(this.chkRule3);
			this.Controls.Add(this.ddlCondition3);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.tbxValue2);
			this.Controls.Add(this.ddlComparison2);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.tbxMinutes2);
			this.Controls.Add(this.ddlAction2);
			this.Controls.Add(this.chkRule2);
			this.Controls.Add(this.ddlCondition2);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.tbxValue1);
			this.Controls.Add(this.ddlComparison1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.tbxMinutes1);
			this.Controls.Add(this.ddlAction1);
			this.Controls.Add(this.chkRule1);
			this.Controls.Add(this.ddlCondition1);
			this.Controls.Add(this.label1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "frmRules";
			this.Text = "Rules";
			this.Load += new System.EventHandler(this.frmRules_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox ddlCondition1;
		private System.Windows.Forms.CheckBox chkRule1;
		private System.Windows.Forms.ComboBox ddlAction1;
		private System.Windows.Forms.TextBox tbxMinutes1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox ddlComparison1;
		private System.Windows.Forms.TextBox tbxValue1;
		private System.Windows.Forms.TextBox tbxValue2;
		private System.Windows.Forms.ComboBox ddlComparison2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox tbxMinutes2;
		private System.Windows.Forms.ComboBox ddlAction2;
		private System.Windows.Forms.CheckBox chkRule2;
		private System.Windows.Forms.ComboBox ddlCondition2;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox tbxValue3;
		private System.Windows.Forms.ComboBox ddlComparison3;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox tbxMinutes3;
		private System.Windows.Forms.ComboBox ddlAction3;
		private System.Windows.Forms.CheckBox chkRule3;
		private System.Windows.Forms.ComboBox ddlCondition3;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnSave;

	}
}