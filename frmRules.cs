using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SQLite;

namespace GodvilleAutoPlayer
{
	public partial class frmRules : Form
	{
		string dbPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
		public string HeroName { get; set; }

		public frmRules()
		{
			InitializeComponent();
		}

		private void frmRules_Load(object sender, EventArgs e)
		{
			loadRules();
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			// Save the rules.  Right now, with 3 hardcoded rules, just delete
			// and then save them all initially
			using (SQLiteConnection conn = new SQLiteConnection(@"Data Source=" + dbPath + @"\gv.db;Version=3;New=False;Compress=True;"))
			{
				conn.Open();
				using (SQLiteCommand cmd = conn.CreateCommand())
				{
					string commandText = "delete from RuleDefinition where HeroName = @HeroName";
					cmd.CommandText = commandText;
					cmd.CommandType = CommandType.Text;
					cmd.Parameters.AddWithValue("@HeroName", this.HeroName);
					cmd.ExecuteNonQuery();

					cmd.Parameters.Clear();
					commandText = "insert into RuleDefinition (HeroName,Name,Active,Action,Minutes,Condition,Comparison,Value) values (@HeroName,@Name,@Active,@Action,@Minutes,@Condition,@Comparison,@Value)";
					cmd.CommandText = commandText;
					cmd.CommandType = CommandType.Text;
					cmd.Parameters.AddWithValue("@HeroName", this.HeroName);
					cmd.Parameters.AddWithValue("@Name", "Rule1");
					cmd.Parameters.AddWithValue("@Active", (chkRule1.Checked == true ? "T" : "F"));
					cmd.Parameters.AddWithValue("@Action", ddlAction1.Text);
					cmd.Parameters.AddWithValue("@Minutes", tbxMinutes1.Text);
					cmd.Parameters.AddWithValue("@Condition", ddlCondition1.Text);
					cmd.Parameters.AddWithValue("@Comparison", ddlComparison1.Text);
					cmd.Parameters.AddWithValue("@Value", tbxValue1.Text);
					cmd.ExecuteNonQuery();

					cmd.Parameters.Clear();
					commandText = "insert into RuleDefinition (HeroName,Name,Active,Action,Minutes,Condition,Comparison,Value) values (@HeroName,@Name,@Active,@Action,@Minutes,@Condition,@Comparison,@Value)";
					cmd.CommandText = commandText;
					cmd.CommandType = CommandType.Text;
					cmd.Parameters.AddWithValue("@HeroName", this.HeroName);
					cmd.Parameters.AddWithValue("@Name", "Rule2");
					cmd.Parameters.AddWithValue("@Active", (chkRule2.Checked == true ? "T" : "F"));
					cmd.Parameters.AddWithValue("@Action", ddlAction2.Text);
					cmd.Parameters.AddWithValue("@Minutes", tbxMinutes2.Text);
					cmd.Parameters.AddWithValue("@Condition", ddlCondition2.Text);
					cmd.Parameters.AddWithValue("@Comparison", ddlComparison2.Text);
					cmd.Parameters.AddWithValue("@Value", tbxValue2.Text);
					cmd.ExecuteNonQuery();

					cmd.Parameters.Clear();
					commandText = "insert into RuleDefinition (HeroName,Name,Active,Action,Minutes,Condition,Comparison,Value) values (@HeroName,@Name,@Active,@Action,@Minutes,@Condition,@Comparison,@Value)";
					cmd.CommandText = commandText;
					cmd.CommandType = CommandType.Text;
					cmd.Parameters.AddWithValue("@HeroName", this.HeroName);
					cmd.Parameters.AddWithValue("@Name", "Rule3");
					cmd.Parameters.AddWithValue("@Active", (chkRule3.Checked == true ? "T" : "F"));
					cmd.Parameters.AddWithValue("@Action", ddlAction3.Text);
					cmd.Parameters.AddWithValue("@Minutes", tbxMinutes3.Text);
					cmd.Parameters.AddWithValue("@Condition", ddlCondition3.Text);
					cmd.Parameters.AddWithValue("@Comparison", ddlComparison3.Text);
					cmd.Parameters.AddWithValue("@Value", tbxValue3.Text);
					cmd.ExecuteNonQuery();
				}
			}

			MessageBox.Show("Rules saved", "Saving...", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void loadRules()
		{
			// Load the rules and update the UI
			using (SQLiteConnection conn = new SQLiteConnection(@"Data Source=" + dbPath + @"\gv.db;Version=3;New=False;Compress=True;"))
			{
				conn.Open();
				using (SQLiteCommand cmd = conn.CreateCommand())
				{
					string CommandText = String.Format("select * from RuleDefinition where HeroName='{0}' order by Name", HeroName.Replace("'", "''"));

					SQLiteDataAdapter da = new SQLiteDataAdapter(CommandText, conn);
					DataSet ds = new DataSet();
					da.Fill(ds);

					if (ds.Tables.Count > 0)
					{
						if (ds.Tables[0].Rows.Count == 3)
						{
							DataRow row = ds.Tables[0].Rows[0];
							chkRule1.Checked = row["Active"].ToString() == "T";
							ddlAction1.Text = row["Action"].ToString();
							tbxMinutes1.Text = row["Minutes"].ToString();
							ddlCondition1.Text = row["Condition"].ToString();
							ddlComparison1.Text = row["Comparison"].ToString();
							tbxValue1.Text = row["Value"].ToString();

							row = ds.Tables[0].Rows[1];
							chkRule2.Checked = row["Active"].ToString() == "T";
							ddlAction2.Text = row["Action"].ToString();
							tbxMinutes2.Text = row["Minutes"].ToString();
							ddlCondition2.Text = row["Condition"].ToString();
							ddlComparison2.Text = row["Comparison"].ToString();
							tbxValue2.Text = row["Value"].ToString();

							row = ds.Tables[0].Rows[2];
							chkRule3.Checked = row["Active"].ToString() == "T";
							ddlAction3.Text = row["Action"].ToString();
							tbxMinutes3.Text = row["Minutes"].ToString();
							ddlCondition3.Text = row["Condition"].ToString();
							ddlComparison3.Text = row["Comparison"].ToString();
							tbxValue3.Text = row["Value"].ToString();
						}
					}
				}
			}
		}

	}
}
