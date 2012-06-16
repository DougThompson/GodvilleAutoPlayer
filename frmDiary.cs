using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Drawing.Imaging;
using System.Data.SQLite;

namespace GodvilleAutoPlayer
{
	public partial class frmDiary : Form
	{
		string dbPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
		public string HeroName { get; set; }

		public frmDiary()
		{
			InitializeComponent();
		}

		private void frmDiary_Load(object sender, EventArgs e)
		{
			getHero();
		}
		
		public void getHero()
		{
			// Load up all the info
			try
			{
				loadHeroStatus();
				loadHeroDiary();
				loadHeroNews();
			}
			catch (Exception ex)
			{
				System.Windows.Forms.MessageBox.Show(ex.ToString());
				throw;
			}
		}

		private void loadHeroStatus()
		{
			// Get the latest Hero statuses
			using (SQLiteConnection conn = new SQLiteConnection(@"Data Source=" + dbPath + @"\gv.db;Version=3;New=False;Compress=True;"))
			{
				conn.Open();
				using (SQLiteCommand cmd = conn.CreateCommand())
				{
					string commandText = "select Updated, Motto, Personality, Guild, GuildRank, Gold, MonstersKilled, DeathCount,";
					commandText += " cast(cast((Health*100.0)/(MaxHealth*1.0) as int) as varchar(3)) || '%' as Health,";
					commandText += " Inventory || '/' || MaxInventory as Inventory,";
					commandText += " Wins || '/' || Losses as Arena, ";
					commandText += " Quest || ' (' || '#' || QuestNumber || ' - ' || QuestPercent || '%)'  as Quest,";
					commandText += " Bricks, TownName, MilestonesPassed, GodPower, Charges,PetName,PetPersonality,PetSpecies,PetLevel,PetAge,PetStatus,Weapon,Shield,Head,Body,Arms,Legs,Talisman,Gratitude,Might,Templehood,Gladiatorship,Storytelling,Mastery,Construction,Taming,Survival,Greed,Creation,Destruction,Unity,Popularity,Aggressiveness,InventoryItems,Skills";
					commandText += " from Hero where Name=@HeroName order by id desc limit 1000";
					cmd.CommandText = commandText;
					cmd.Parameters.AddWithValue("@HeroName", this.HeroName);

					SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
					DataSet ds = new DataSet();
					da.Fill(ds);

					BindingSource bindingSource1 = new BindingSource();
					grdHeroStatus.AutoGenerateColumns = true;
					bindingSource1.DataSource = ds.Tables[0];
					grdHeroStatus.DataSource = bindingSource1;
					grdHeroStatus.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
					grdHeroStatus.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
				}
			}
		}

		private void loadHeroDiary()
		{
			// Load the latest Hero Diary entries
			using (SQLiteConnection conn = new SQLiteConnection(@"Data Source=" + dbPath + @"\gv.db;Version=3;New=False;Compress=True;"))
			{
				conn.Open();
				using (SQLiteCommand cmd = conn.CreateCommand())
				{
					string commandText = "select Diary_ID as ID, Updated, EntryTime, Entry from Diary where HeroName=@HeroName order by Diary_ID desc limit 1000";
					cmd.CommandText = commandText;
					cmd.Parameters.AddWithValue("@HeroName", this.HeroName);

					SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
					DataSet ds = new DataSet();
					da = new SQLiteDataAdapter(cmd);
					ds = new DataSet();
					da.Fill(ds);

					BindingSource bindingSource = new BindingSource();
					bindingSource.DataSource = ds.Tables[0];
					grdDiary.DataSource = bindingSource;
					grdDiary.AutoGenerateColumns = true;
					grdDiary.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
					grdDiary.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
				}
			}
		}

		private void loadHeroNews()
		{
			// Load the latest Earthly News entries
			using (SQLiteConnection conn = new SQLiteConnection(@"Data Source=" + dbPath + @"\gv.db;Version=3;New=False;Compress=True;"))
			{
				conn.Open();
				using (SQLiteCommand cmd = conn.CreateCommand())
				{
					string commandText = String.Format("select ID, Updated, case when Enemy <> '' then 'Enemy: ' || Enemy Else TopMessage end as Message, BottomMessage, Progress from Detail where HeroName='{0}' order by ID desc limit 1000", HeroName.Replace("'", "''"));
					cmd.CommandText = commandText;
					SQLiteDataAdapter da = new SQLiteDataAdapter(commandText, conn);
					DataSet ds = new DataSet();
					da = new SQLiteDataAdapter(cmd);
					ds = new DataSet();
					da.Fill(ds);

					BindingSource bindingSource = new BindingSource();
					bindingSource.DataSource = ds.Tables[0];
					grdNews.DataSource = bindingSource;
					grdNews.AutoGenerateColumns = true;

					grdNews.AllowUserToResizeColumns = true;
				}
			}
		}
	}
}
