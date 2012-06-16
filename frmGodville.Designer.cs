namespace GodvilleAutoPlayer
{
	partial class frmGodville
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGodville));
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.lblRules = new System.Windows.Forms.Label();
            this.lblDiary = new System.Windows.Forms.Label();
            this.lblPunish = new System.Windows.Forms.Label();
            this.lblEncourage = new System.Windows.Forms.Label();
            this.tbxDiary = new System.Windows.Forms.TextBox();
            this.tbxNews = new System.Windows.Forms.TextBox();
            this.lblHero = new System.Windows.Forms.Label();
            this.picTurbo = new System.Windows.Forms.PictureBox();
            this.pnlLogin = new System.Windows.Forms.Panel();
            this.btnLogIn = new System.Windows.Forms.Button();
            this.tbxGodPassword = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbxGodName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picTurbo)).BeginInit();
            this.pnlLogin.SuspendLayout();
            this.SuspendLayout();
            // 
            // webBrowser1
            // 
            this.webBrowser1.Location = new System.Drawing.Point(12, 21);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(247, 141);
            this.webBrowser1.TabIndex = 0;
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.White;
            this.pnlMain.Controls.Add(this.lblRules);
            this.pnlMain.Controls.Add(this.lblDiary);
            this.pnlMain.Controls.Add(this.lblPunish);
            this.pnlMain.Controls.Add(this.lblEncourage);
            this.pnlMain.Controls.Add(this.tbxDiary);
            this.pnlMain.Controls.Add(this.tbxNews);
            this.pnlMain.Controls.Add(this.lblHero);
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(354, 110);
            this.pnlMain.TabIndex = 3;
            // 
            // lblRules
            // 
            this.lblRules.AutoSize = true;
            this.lblRules.BackColor = System.Drawing.Color.White;
            this.lblRules.Enabled = false;
            this.lblRules.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRules.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblRules.Location = new System.Drawing.Point(330, 5);
            this.lblRules.Name = "lblRules";
            this.lblRules.Size = new System.Drawing.Size(21, 14);
            this.lblRules.TabIndex = 11;
            this.lblRules.Text = "Ru";
            this.lblRules.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip1.SetToolTip(this.lblRules, "View History");
            this.lblRules.Click += new System.EventHandler(this.lblRules_Click);
            // 
            // lblDiary
            // 
            this.lblDiary.AutoSize = true;
            this.lblDiary.BackColor = System.Drawing.Color.White;
            this.lblDiary.Enabled = false;
            this.lblDiary.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDiary.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblDiary.Location = new System.Drawing.Point(314, 5);
            this.lblDiary.Name = "lblDiary";
            this.lblDiary.Size = new System.Drawing.Size(17, 14);
            this.lblDiary.TabIndex = 10;
            this.lblDiary.Text = "Di";
            this.lblDiary.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip1.SetToolTip(this.lblDiary, "View History");
            this.lblDiary.Click += new System.EventHandler(this.lblDiary_Click);
            this.lblDiary.MouseEnter += new System.EventHandler(this.showHand);
            this.lblDiary.MouseLeave += new System.EventHandler(this.resetHand);
            // 
            // lblPunish
            // 
            this.lblPunish.AutoSize = true;
            this.lblPunish.BackColor = System.Drawing.Color.White;
            this.lblPunish.Enabled = false;
            this.lblPunish.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPunish.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblPunish.Location = new System.Drawing.Point(17, 5);
            this.lblPunish.Name = "lblPunish";
            this.lblPunish.Size = new System.Drawing.Size(14, 14);
            this.lblPunish.TabIndex = 9;
            this.lblPunish.Text = "P";
            this.lblPunish.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip1.SetToolTip(this.lblPunish, "Punish Hero!");
            this.lblPunish.Click += new System.EventHandler(this.lblPunish_Click);
            this.lblPunish.MouseEnter += new System.EventHandler(this.showHand);
            this.lblPunish.MouseLeave += new System.EventHandler(this.resetHand);
            // 
            // lblEncourage
            // 
            this.lblEncourage.AutoSize = true;
            this.lblEncourage.BackColor = System.Drawing.Color.White;
            this.lblEncourage.Enabled = false;
            this.lblEncourage.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEncourage.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblEncourage.Location = new System.Drawing.Point(3, 5);
            this.lblEncourage.Name = "lblEncourage";
            this.lblEncourage.Size = new System.Drawing.Size(13, 14);
            this.lblEncourage.TabIndex = 8;
            this.lblEncourage.Text = "E";
            this.lblEncourage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip1.SetToolTip(this.lblEncourage, "Encourage Hero!");
            this.lblEncourage.Click += new System.EventHandler(this.lblEncourage_Click);
            this.lblEncourage.MouseEnter += new System.EventHandler(this.showHand);
            this.lblEncourage.MouseLeave += new System.EventHandler(this.resetHand);
            // 
            // tbxDiary
            // 
            this.tbxDiary.Location = new System.Drawing.Point(3, 66);
            this.tbxDiary.Multiline = true;
            this.tbxDiary.Name = "tbxDiary";
            this.tbxDiary.Size = new System.Drawing.Size(348, 39);
            this.tbxDiary.TabIndex = 7;
            // 
            // tbxNews
            // 
            this.tbxNews.Location = new System.Drawing.Point(3, 23);
            this.tbxNews.Multiline = true;
            this.tbxNews.Name = "tbxNews";
            this.tbxNews.Size = new System.Drawing.Size(348, 39);
            this.tbxNews.TabIndex = 6;
            // 
            // lblHero
            // 
            this.lblHero.AutoSize = true;
            this.lblHero.BackColor = System.Drawing.Color.White;
            this.lblHero.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHero.Location = new System.Drawing.Point(33, 5);
            this.lblHero.Name = "lblHero";
            this.lblHero.Size = new System.Drawing.Size(271, 14);
            this.lblHero.TabIndex = 3;
            this.lblHero.Text = "H: 000%  GP: 000%  G: 00000 coins  Q: 000% Mi: 000";
            // 
            // picTurbo
            // 
            this.picTurbo.Location = new System.Drawing.Point(3, 232);
            this.picTurbo.Name = "picTurbo";
            this.picTurbo.Size = new System.Drawing.Size(11, 11);
            this.picTurbo.TabIndex = 8;
            this.picTurbo.TabStop = false;
            // 
            // pnlLogin
            // 
            this.pnlLogin.Controls.Add(this.btnLogIn);
            this.pnlLogin.Controls.Add(this.tbxGodPassword);
            this.pnlLogin.Controls.Add(this.label2);
            this.pnlLogin.Controls.Add(this.tbxGodName);
            this.pnlLogin.Controls.Add(this.label1);
            this.pnlLogin.Location = new System.Drawing.Point(0, 116);
            this.pnlLogin.Name = "pnlLogin";
            this.pnlLogin.Size = new System.Drawing.Size(354, 110);
            this.pnlLogin.TabIndex = 4;
            // 
            // btnLogIn
            // 
            this.btnLogIn.BackColor = System.Drawing.Color.Gainsboro;
            this.btnLogIn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogIn.Location = new System.Drawing.Point(276, 83);
            this.btnLogIn.Name = "btnLogIn";
            this.btnLogIn.Size = new System.Drawing.Size(75, 23);
            this.btnLogIn.TabIndex = 10;
            this.btnLogIn.Text = "Log In";
            this.btnLogIn.UseVisualStyleBackColor = false;
            this.btnLogIn.Click += new System.EventHandler(this.btnLogIn_Click);
            // 
            // tbxGodPassword
            // 
            this.tbxGodPassword.Location = new System.Drawing.Point(3, 60);
            this.tbxGodPassword.Name = "tbxGodPassword";
            this.tbxGodPassword.PasswordChar = '*';
            this.tbxGodPassword.Size = new System.Drawing.Size(348, 20);
            this.tbxGodPassword.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 14);
            this.label2.TabIndex = 8;
            this.label2.Text = "Password";
            // 
            // tbxGodName
            // 
            this.tbxGodName.Location = new System.Drawing.Point(3, 20);
            this.tbxGodName.Name = "tbxGodName";
            this.tbxGodName.Size = new System.Drawing.Size(348, 20);
            this.tbxGodName.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 14);
            this.label1.TabIndex = 3;
            this.label1.Text = "God Name or Email";
            // 
            // toolTip1
            // 
            this.toolTip1.AutomaticDelay = 250;
            // 
            // frmGodville
            // 
            this.AcceptButton = this.btnLogIn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(354, 110);
            this.Controls.Add(this.picTurbo);
            this.Controls.Add(this.pnlLogin);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.webBrowser1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmGodville";
            this.Text = "Godville";
            this.Load += new System.EventHandler(this.frmGodville_Load);
            this.Resize += new System.EventHandler(this.frmGodville_Resize);
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picTurbo)).EndInit();
            this.pnlLogin.ResumeLayout(false);
            this.pnlLogin.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.WebBrowser webBrowser1;
		private System.Windows.Forms.Panel pnlMain;
		private System.Windows.Forms.Label lblHero;
		private System.Windows.Forms.TextBox tbxDiary;
		private System.Windows.Forms.TextBox tbxNews;
		private System.Windows.Forms.PictureBox picTurbo;
		private System.Windows.Forms.Panel pnlLogin;
		private System.Windows.Forms.TextBox tbxGodName;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnLogIn;
		private System.Windows.Forms.TextBox tbxGodPassword;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label lblPunish;
		private System.Windows.Forms.Label lblEncourage;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.Label lblDiary;
		private System.Windows.Forms.Label lblRules;

	}
}