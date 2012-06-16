namespace GodvilleAutoPlayer
{
	partial class frmDiary
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDiary));
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabDiary = new System.Windows.Forms.TabPage();
			this.tabNews = new System.Windows.Forms.TabPage();
			this.tabHero = new System.Windows.Forms.TabPage();
			this.grdHeroStatus = new System.Windows.Forms.DataGridView();
			this.grdDiary = new System.Windows.Forms.DataGridView();
			this.grdNews = new System.Windows.Forms.DataGridView();
			this.tabControl1.SuspendLayout();
			this.tabDiary.SuspendLayout();
			this.tabNews.SuspendLayout();
			this.tabHero.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.grdHeroStatus)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.grdDiary)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.grdNews)).BeginInit();
			this.SuspendLayout();
			// 
			// tabControl1
			// 
			this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.tabControl1.Controls.Add(this.tabHero);
			this.tabControl1.Controls.Add(this.tabDiary);
			this.tabControl1.Controls.Add(this.tabNews);
			this.tabControl1.Location = new System.Drawing.Point(2, 3);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(904, 743);
			this.tabControl1.TabIndex = 0;
			// 
			// tabDiary
			// 
			this.tabDiary.Controls.Add(this.grdDiary);
			this.tabDiary.Location = new System.Drawing.Point(4, 22);
			this.tabDiary.Name = "tabDiary";
			this.tabDiary.Padding = new System.Windows.Forms.Padding(3);
			this.tabDiary.Size = new System.Drawing.Size(896, 717);
			this.tabDiary.TabIndex = 0;
			this.tabDiary.Text = "Diary";
			this.tabDiary.UseVisualStyleBackColor = true;
			// 
			// tabNews
			// 
			this.tabNews.Controls.Add(this.grdNews);
			this.tabNews.Location = new System.Drawing.Point(4, 22);
			this.tabNews.Name = "tabNews";
			this.tabNews.Padding = new System.Windows.Forms.Padding(3);
			this.tabNews.Size = new System.Drawing.Size(896, 717);
			this.tabNews.TabIndex = 1;
			this.tabNews.Text = "News from Battlefield";
			this.tabNews.UseVisualStyleBackColor = true;
			// 
			// tabHero
			// 
			this.tabHero.Controls.Add(this.grdHeroStatus);
			this.tabHero.Location = new System.Drawing.Point(4, 22);
			this.tabHero.Name = "tabHero";
			this.tabHero.Size = new System.Drawing.Size(896, 717);
			this.tabHero.TabIndex = 2;
			this.tabHero.Text = "Hero Status";
			this.tabHero.UseVisualStyleBackColor = true;
			// 
			// grdHeroStatus
			// 
			this.grdHeroStatus.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.grdHeroStatus.Dock = System.Windows.Forms.DockStyle.Fill;
			this.grdHeroStatus.Location = new System.Drawing.Point(0, 0);
			this.grdHeroStatus.Name = "grdHeroStatus";
			this.grdHeroStatus.Size = new System.Drawing.Size(896, 717);
			this.grdHeroStatus.TabIndex = 0;
			// 
			// grdDiary
			// 
			this.grdDiary.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.grdDiary.Dock = System.Windows.Forms.DockStyle.Fill;
			this.grdDiary.Location = new System.Drawing.Point(3, 3);
			this.grdDiary.Name = "grdDiary";
			this.grdDiary.Size = new System.Drawing.Size(890, 711);
			this.grdDiary.TabIndex = 1;
			// 
			// grdNews
			// 
			this.grdNews.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.grdNews.Dock = System.Windows.Forms.DockStyle.Fill;
			this.grdNews.Location = new System.Drawing.Point(3, 3);
			this.grdNews.Name = "grdNews";
			this.grdNews.Size = new System.Drawing.Size(890, 711);
			this.grdNews.TabIndex = 1;
			// 
			// frmDiary
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(908, 748);
			this.Controls.Add(this.tabControl1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "frmDiary";
			this.Text = "Godville: Hero\'s Exploits";
			this.Load += new System.EventHandler(this.frmDiary_Load);
			this.tabControl1.ResumeLayout(false);
			this.tabDiary.ResumeLayout(false);
			this.tabNews.ResumeLayout(false);
			this.tabHero.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.grdHeroStatus)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.grdDiary)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.grdNews)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabHero;
		private System.Windows.Forms.TabPage tabDiary;
		private System.Windows.Forms.TabPage tabNews;
		private System.Windows.Forms.DataGridView grdHeroStatus;
		private System.Windows.Forms.DataGridView grdDiary;
		private System.Windows.Forms.DataGridView grdNews;
	}
}