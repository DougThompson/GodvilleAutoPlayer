using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;
using System.Data;

namespace GodvilleAutoPlayer
{
	struct HeroDiaryEntry
	{
		public string TimeStamp;
		public string Content;
		public bool Saved;
	}

	struct HeroDetailsEntry
	{
		public string Enemy;
		public string TopMessage;
		public string BottomMessage;
		public int Progress;
		public int Progress2;
	}

	class Hero
	{
		public string Name { get; set; }
		public string GodName { get; set; }
		public DateTime Updated { get; set; }
		public string Motto { get; set; }
		public string Personality { get; set; }
		public string Guild { get; set; }
		public string GuildRank { get; set; }
		public int Level { get; set; }
		public int LevelPercent { get; set; }
		public int Inventory { get; set; }
		public int MaxInventory { get; set; }
		public int Health { get; set; }
		public int MaxHealth { get; set; }
		public string Quest { get; set; }
		public int QuestNumber { get; set; }
		public int QuestPercent { get; set; }
		public int Gold { get; set; }
		public int MonstersKilled { get; set; }
		public int DeathCount { get; set; }
		public int Wins { get; set; }
		public int Losses { get; set; }
		public string Bricks { get; set; }
		public string TownName { get; set; }
		public string Retirement { get; set; }
		public string Aura { get; set; }
		public string AuraDuration { get; set; }
		public int MilestonesPassed { get; set; }
		public int GodPower { get; set; }
		public int Charges { get; set; }

		public string PetName { get; set; }
		public string PetPersonality { get; set; }
		public string PetSpecies { get; set; }
		public string PetLevel { get; set; }
		public string PetAge { get; set; }
		public string PetStatus { get; set; }

		public string Weapon { get; set; }
		public string Shield { get; set; }
		public string Head { get; set; }
		public string Body { get; set; }
		public string Arms { get; set; }
		public string Legs { get; set; }
		public string Talisman { get; set; }
		
		public int Gratitude { get; set; }
		public int Might { get; set; }
		public int Templehood { get; set; }
		public int Gladiatorship { get; set; }
		public int Storytelling { get; set; }

		public int Mastery { get; set; }
		public int Construction { get; set; }
		public int Taming { get; set; }
		public int Survival { get; set; }
		public int Greed { get; set; }
		public int Creation { get; set; }
		public int Destruction { get; set; }

		public int Unity { get; set; }
		public int Popularity { get; set; }
		public int Aggressiveness { get; set; }

		public List<string> InventoryItems { get; set; }
		public List<string> Skills { get; set; }
		public List<HeroDiaryEntry> DiaryEntries { get; set; }
		public List<HeroDetailsEntry> DetailsEntries { get; set; }

		string dbPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);

		public Hero()
		{
			DiaryEntries = new List<HeroDiaryEntry>();
			DetailsEntries = new List<HeroDetailsEntry>();
			InventoryItems = new List<string>();
			Skills = new List<string>();

			avoidNulls();
		}

		private void avoidNulls()
		{
			try
			{
				Type t = this.GetType();
				foreach (System.Reflection.PropertyInfo p in t.GetProperties())
				{
					if (p.PropertyType.FullName == "System.String")
						p.SetValue(this, "", null);
				}
			}
			catch (Exception ex)
			{
				System.Windows.Forms.MessageBox.Show(ex.ToString());
				throw;
			}
		}

		public bool compare(Hero second)
		{
			try
			{
				string name;
				foreach (System.Reflection.PropertyInfo pf in this.GetType().GetProperties())
				{
					name = pf.Name;
					if ((pf.GetValue(this, null) == null) && (pf.GetValue(second, null) != null))
					{
						return false;
					}
					else if ((pf.GetValue(this, null) == null) && (pf.GetValue(second, null) == null))
					{
						//Do nothing
					}
					else if (!pf.GetValue(this, null).Equals(pf.GetValue(second, null)))
					{
						return false;
					}
				}

				return true;
			}
			catch (Exception ex)
			{
				System.Windows.Forms.MessageBox.Show(ex.ToString());
				throw;
			}
		}

		public Hero clone()
		{
			try
			{
				Hero second = new Hero();
				foreach (System.Reflection.PropertyInfo pf in this.GetType().GetProperties())
				{
					pf.SetValue(second, pf.GetValue(this, null), null);
				}

				return second;
			}
			catch //(Exception ex)
			{
				return null;
				//System.Windows.Forms.MessageBox.Show(ex.ToString());
				throw;
			}
		}

		public void saveDiaryEntry(HeroDiaryEntry DiaryEntry)
		{
			try
			{
				using (SQLiteConnection conn = new SQLiteConnection(@"Data Source=" + dbPath + @"\gv.db;Version=3;New=False;Compress=True;"))
				{
					conn.Open();
					using (SQLiteCommand cmd = conn.CreateCommand())
					{
						string commandText = "select count(*) as diarycount from Diary where HeroName=@HeroName and EntryTime=@EntryTime and Entry=@Entry and Updated >= @Updated";
						cmd.Parameters.AddWithValue("@HeroName", this.Name);
						cmd.Parameters.AddWithValue("@EntryTime", DiaryEntry.TimeStamp);
						cmd.Parameters.AddWithValue("@Entry", DiaryEntry.Content);
						cmd.Parameters.AddWithValue("@Updated", DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd HH:mm:ss"));

						cmd.CommandText = commandText;
						cmd.CommandType = CommandType.Text;
						object ret = cmd.ExecuteScalar();
						if (int.Parse((ret == null) ? "0" : ret.ToString()) == 0)
						{
							cmd.Parameters.Clear();
							commandText = "insert into Diary (HeroName, Updated, EntryTime, Entry) values (@HeroName, @Updated, @EntryTime, @Entry)";
							cmd.Parameters.AddWithValue("@HeroName", this.Name);
							cmd.Parameters.AddWithValue("@Updated", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
							cmd.Parameters.AddWithValue("@EntryTime", DiaryEntry.TimeStamp);
							cmd.Parameters.AddWithValue("@Entry", DiaryEntry.Content);

							cmd.CommandText = commandText;
							cmd.CommandType = CommandType.Text;
							cmd.ExecuteNonQuery();
						}
						DiaryEntry.Saved = true;
					}
				}

			}
			catch (Exception ex)
			{
				System.Windows.Forms.MessageBox.Show(ex.ToString());
				throw;
			}
		}

		public void saveDetailEntry(HeroDetailsEntry DetailEntry)
		{
			try
			{
				using (SQLiteConnection conn = new SQLiteConnection(@"Data Source=" + dbPath + @"\gv.db;Version=3;New=False;Compress=True;"))
				{
					conn.Open();
					using (SQLiteCommand cmd = conn.CreateCommand())
					{
						string commandText = "insert into Detail (HeroName, Updated, Enemy, TopMessage, BottomMessage, Progress) values (@HeroName, @Updated, @Enemy, @TopMessage, @BottomMessage, @Progress)";
						cmd.Parameters.AddWithValue("@HeroName", this.Name);
						cmd.Parameters.AddWithValue("@Updated", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
						cmd.Parameters.AddWithValue("@Enemy", (DetailEntry.Enemy ?? ""));
						cmd.Parameters.AddWithValue("@TopMessage", (DetailEntry.TopMessage ?? ""));
						cmd.Parameters.AddWithValue("@BottomMessage", (DetailEntry.BottomMessage ?? ""));
						cmd.Parameters.AddWithValue("@Progress", DetailEntry.Progress.ToString());

						cmd.CommandText = commandText;
						cmd.CommandType = CommandType.Text;
						cmd.ExecuteNonQuery();
					}
				}

			}
			catch (Exception ex)
			{
				System.Windows.Forms.MessageBox.Show(ex.ToString());
				throw;
			}
		}

		public void saveHero()
		{
			try
			{
				using (SQLiteConnection conn = new SQLiteConnection(@"Data Source=" + dbPath + @"\gv.db;Version=3;New=False;Compress=True;"))
				{
					conn.Open();
					using (SQLiteCommand cmd = conn.CreateCommand())
					{
						string commandText = "insert into Hero (Name,GodName,Updated,Motto,Personality,Guild,GuildRank,Level,LevelPercent,Inventory,MaxInventory,Health,MaxHealth,QuestNumber,Quest,QuestPercent,Gold,MonstersKilled,DeathCount,Wins,Losses,Bricks,TownName,MilestonesPassed,GodPower,Charges,PetName,PetPersonality,PetSpecies,PetLevel,PetAge,PetStatus,Weapon,Shield,Head,Body,Arms,Legs,Talisman,Gratitude,Might,Templehood,Gladiatorship,Storytelling,Mastery,Construction,Taming,Survival,Greed,Creation,Destruction,Unity,Popularity,Aggressiveness,InventoryItems,Skills) values (@Name,@GodName,@Updated,@Motto,@Personality,@Guild,@GuildRank,@Level,@LevelPercent,@Inventory,@MaxInventory,@Health,@MaxHealth,@QuestNumber,@Quest,@QuestPercent,@Gold,@MonstersKilled,@DeathCount,@Wins,@Losses,@Bricks,@TownName,@MilestonesPassed,@GodPower,@Charges,@PetName,@PetPersonality,@PetSpecies,@PetLevel,@PetAge,@PetStatus,@Weapon,@Shield,@Head,@Body,@Arms,@Legs,@Talisman,@Gratitude,@Might,@Templehood,@Gladiatorship,@Storytelling,@Mastery,@Construction,@Taming,@Survival,@Greed,@Creation,@Destruction,@Unity,@Popularity,@Aggressiveness,@InventoryItems,@Skills)";
						cmd.Parameters.AddWithValue("@Name", this.Name);
						cmd.Parameters.AddWithValue("@GodName", this.GodName);
						cmd.Parameters.AddWithValue("@Updated", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
						cmd.Parameters.AddWithValue("@Motto", this.Motto);
						cmd.Parameters.AddWithValue("@Personality", this.Personality);
						cmd.Parameters.AddWithValue("@Guild", this.Guild);
						cmd.Parameters.AddWithValue("@GuildRank", this.GuildRank);
						cmd.Parameters.AddWithValue("@Level", this.Level);
						cmd.Parameters.AddWithValue("@LevelPercent", this.LevelPercent);
						cmd.Parameters.AddWithValue("@Inventory", this.Inventory);
						cmd.Parameters.AddWithValue("@MaxInventory", this.MaxInventory);
						cmd.Parameters.AddWithValue("@Health", this.Health);
						cmd.Parameters.AddWithValue("@MaxHealth", this.MaxHealth);
						cmd.Parameters.AddWithValue("@QuestNumber", this.QuestNumber);
						cmd.Parameters.AddWithValue("@Quest", this.Quest);
						cmd.Parameters.AddWithValue("@QuestPercent", this.QuestPercent);
						cmd.Parameters.AddWithValue("@Gold", this.Gold);
						cmd.Parameters.AddWithValue("@MonstersKilled", this.MonstersKilled);
						cmd.Parameters.AddWithValue("@DeathCount", this.DeathCount);
						cmd.Parameters.AddWithValue("@Wins", this.Wins);
						cmd.Parameters.AddWithValue("@Losses", this.Losses);
						cmd.Parameters.AddWithValue("@Bricks", this.Bricks);
						cmd.Parameters.AddWithValue("@TownName", this.TownName);
						cmd.Parameters.AddWithValue("@MilestonesPassed", this.MilestonesPassed);
						cmd.Parameters.AddWithValue("@GodPower", this.GodPower);
						cmd.Parameters.AddWithValue("@Charges", this.Charges);
						cmd.Parameters.AddWithValue("@PetName", this.PetName);
						cmd.Parameters.AddWithValue("@PetPersonality", this.PetPersonality);
						cmd.Parameters.AddWithValue("@PetSpecies", this.PetSpecies);
						cmd.Parameters.AddWithValue("@PetLevel", this.PetLevel);
						cmd.Parameters.AddWithValue("@PetAge", this.PetAge);
						cmd.Parameters.AddWithValue("@PetStatus", this.PetStatus);
						cmd.Parameters.AddWithValue("@Weapon", this.Weapon);
						cmd.Parameters.AddWithValue("@Shield", this.Shield);
						cmd.Parameters.AddWithValue("@Head", this.Head);
						cmd.Parameters.AddWithValue("@Body", this.Body);
						cmd.Parameters.AddWithValue("@Arms", this.Arms);
						cmd.Parameters.AddWithValue("@Legs", this.Legs);
						cmd.Parameters.AddWithValue("@Talisman", this.Talisman);
						cmd.Parameters.AddWithValue("@Gratitude", this.Gratitude);
						cmd.Parameters.AddWithValue("@Might", this.Might);
						cmd.Parameters.AddWithValue("@Templehood", this.Templehood);
						cmd.Parameters.AddWithValue("@Gladiatorship", this.Gladiatorship);
						cmd.Parameters.AddWithValue("@Storytelling", this.Storytelling);
						cmd.Parameters.AddWithValue("@Mastery", this.Mastery);
						cmd.Parameters.AddWithValue("@Construction", this.Construction);
						cmd.Parameters.AddWithValue("@Taming", this.Taming);
						cmd.Parameters.AddWithValue("@Survival", this.Survival);
						cmd.Parameters.AddWithValue("@Greed", this.Greed);
						cmd.Parameters.AddWithValue("@Creation", this.Creation);
						cmd.Parameters.AddWithValue("@Destruction", this.Destruction);
						cmd.Parameters.AddWithValue("@Unity", this.Unity);
						cmd.Parameters.AddWithValue("@Popularity", this.Popularity);
						cmd.Parameters.AddWithValue("@Aggressiveness", this.Aggressiveness);
						cmd.Parameters.AddWithValue("@InventoryItems", String.Join("|", this.InventoryItems.ToArray<string>()));
						cmd.Parameters.AddWithValue("@Skills", String.Join("|", this.Skills.ToArray<string>()));

						cmd.CommandText = commandText;
						cmd.CommandType = CommandType.Text;
						cmd.ExecuteNonQuery();
					}
				}

			}
			catch (Exception ex)
			{
				System.Windows.Forms.MessageBox.Show(ex.ToString());
				throw;
			}
		}

		public void getHero(string heroName)
		{
			try
			{
				using (SQLiteConnection conn = new SQLiteConnection(@"Data Source=" + dbPath + @"\gv.db;Version=3;New=False;Compress=True;"))
				{
					conn.Open();
					using (SQLiteCommand cmd = conn.CreateCommand())
					{
						string commandText = "select * from Hero where Name=@HeroName order by id desc limit 1";
						cmd.Parameters.AddWithValue("@HeroName", !String.IsNullOrEmpty(heroName) ? heroName : this.Name);
						cmd.CommandType = CommandType.Text;
						cmd.CommandText = commandText;

						SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
						DataSet ds = new DataSet();
						da.Fill(ds);

						if (ds.Tables.Count > 0)
						{
							if (ds.Tables[0].Rows.Count > 0)
							{
								DataRow row = ds.Tables[0].Rows[0];

								this.Updated = DateTime.Parse(row["Updated"].ToString());
								this.Name = row["Name"].ToString();
								this.Motto = row["Motto"].ToString();
								this.Personality = row["Personality"].ToString();
								this.Guild = row["Guild"].ToString();
								this.GuildRank = row["GuildRank"].ToString();
								this.Level = int.Parse(row["Level"].ToString());
								this.Inventory = int.Parse(row["Inventory"].ToString());
								this.MaxInventory = int.Parse(row["MaxInventory"].ToString());
								this.Quest = row["Quest"].ToString();
								this.QuestPercent = int.Parse(row["QuestPercent"].ToString());
								this.Gold = int.Parse(row["Gold"].ToString());
								this.MonstersKilled = int.Parse(row["MonstersKilled"].ToString());
								this.DeathCount = int.Parse(row["DeathCount"].ToString());
								this.Wins = int.Parse(row["Wins"].ToString());
								this.Losses = int.Parse(row["Losses"].ToString());
								this.Bricks = row["Bricks"].ToString();
								this.TownName = row["TownName"].ToString();
								this.MilestonesPassed = int.Parse(row["MilestonesPassed"].ToString());
								this.GodPower = int.Parse(row["GodPower"].ToString());
								this.Weapon = row["Weapon"].ToString();
								this.Shield = row["Shield"].ToString();
								this.Head = row["Head"].ToString();
								this.Body = row["Body"].ToString();
								this.Arms = row["Arms"].ToString();
								this.Legs = row["Legs"].ToString();
								this.Talisman = row["Talisman"].ToString();

								this.Gratitude = int.Parse(row["Gratitude"].ToString());
								this.Unity = int.Parse(row["Unity"].ToString());
								this.Might = int.Parse(row["Might"].ToString());
								this.Greed = int.Parse(row["Greed"].ToString());
								this.Construction = int.Parse(row["Construction"].ToString());
								this.Taming = int.Parse(row["Taming"].ToString());
								this.Gladiatorship = int.Parse(row["Gladiatorship"].ToString());
								this.Creation = int.Parse(row["Creation"].ToString());
								this.Destruction = int.Parse(row["Destruction"].ToString());
							}
						}
						//and Updated >= @Updated

						cmd.Parameters.Clear();
						cmd.CommandText = "select * from Diary where HeroName=@HeroName order by Diary_ID limit 10";
						cmd.Parameters.AddWithValue("@HeroName", this.Name);
						//cmd.Parameters.AddWithValue("@Updated", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

						da = new SQLiteDataAdapter(cmd);
						ds = new DataSet();
						da.Fill(ds);

						if (ds.Tables.Count > 0)
						{
							foreach (DataRow row in ds.Tables[0].Rows)
							{
								HeroDiaryEntry entry = new HeroDiaryEntry();
								entry.TimeStamp = row["EntryTime"].ToString();
								entry.Content = row["Entry"].ToString();
								entry.Saved = true;
								this.DiaryEntries.Insert(0, entry);
							}
						}
					}
				}
			}
			catch (Exception ex)
			{
				System.Windows.Forms.MessageBox.Show(ex.ToString());
				throw;
			}
		}

		public void executeRules(System.Windows.Forms.HtmlElement lnkEncourage, System.Windows.Forms.HtmlElement lnkPunish)
		{
			using (SQLiteConnection conn = new SQLiteConnection(@"Data Source=" + dbPath + @"\gv.db;Version=3;New=False;Compress=True;"))
			{
				conn.Open();
				using (SQLiteCommand cmd = conn.CreateCommand())
				{
					/*, 'localtime'*/
					string query = "select HeroName,Name,Active,Action,Minutes,Condition,Comparison,Value,";
					query += " (select datetime(max(ActivityDate)) as ActivityDate from RuleAction where RuleName=rd.Name and HeroName=rd.HeroName) as ActivityDate";
					query += " from RuleDefinition rd";
					query += " where Active='T' and HeroName=@HeroName";

					cmd.CommandText = query;
					cmd.Parameters.AddWithValue("@HeroName", this.Name);
					cmd.CommandType = CommandType.Text;

					SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
					DataSet ds = new DataSet();
					da.Fill(ds);

					if (ds.Tables.Count > 0)
					{
						foreach (DataRow row in ds.Tables[0].Rows)
						{
							DateTime dt1 = DateTime.Parse(String.IsNullOrEmpty(row["ActivityDate"].ToString()) ? DateTime.Now.ToString() : row["ActivityDate"].ToString());
							//dt1 = dt1.AddMinutes(-30);
							DateTime dt2 = DateTime.Now;
							TimeSpan ts = dt2 - dt1;

							int minutes = int.Parse(String.IsNullOrEmpty(row["Minutes"].ToString()) ? "0" : row["Minutes"].ToString());
							int value = int.Parse(String.IsNullOrEmpty(row["Value"].ToString()) ? "25" : row["Value"].ToString());
							if (ts.TotalMinutes >= minutes)
							{
								string ruleDesc = String.Format("{0} every {1} minutes if {2} {3} {4}", row["Action"], row["Minutes"], row["Condition"], row["Comparison"], row["Value"]);
								if (System.Windows.Forms.MessageBox.Show(String.Format("Execute '{0}' ?", ruleDesc), "Execute Rules...", System.Windows.Forms.MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
								{
									int heroValue = this.GodPower;
									if (row["Condition"].ToString() == "Current Health (%)")
									{
										heroValue = (this.Health * 100 / this.MaxHealth);
									}

									if (getComparison(row["Comparison"].ToString(), heroValue, value))
									{
										if (row["Action"].ToString() == "Encourage")
										{
											if (lnkEncourage != null)
												lnkEncourage.InvokeMember("click");
										}
										else if (row["Action"].ToString() == "Punish")
										{
											if (lnkPunish != null)
												lnkPunish.InvokeMember("click");
										}

										using (SQLiteCommand cmd2 = conn.CreateCommand())
										{
											string command2Text = "insert into RuleAction (HeroName, RuleName, Action, ActivityDate) values (@HeroName, @RuleName, @Action, @ActivityDate)";
											cmd.Parameters.AddWithValue("@HeroName", this.Name);
											cmd.Parameters.AddWithValue("@RuleName", row["Name"].ToString());
											cmd.Parameters.AddWithValue("@Action", row["Action"].ToString());
											cmd.Parameters.AddWithValue("@ActivityDate", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
											cmd.CommandText = command2Text;
											cmd.CommandType = CommandType.Text;
											cmd.ExecuteNonQuery();
										}
									}
								}
							}
						}
					}
				}
			}
		}

		private bool getComparison(string Comparison, int Condition, int Value)
		{
			bool comparison = false;
			if (Comparison == ">")
			{
				return Condition > Value;
			}
			else if (Comparison == "<")
			{
				return Condition < Value;
			}
			else if (Comparison == ">=")
			{
				return Condition >= Value;
			}
			else if (Comparison == "<=")
			{
				return Condition <= Value;
			}
			else if (Comparison == "=")
			{
				return Condition == Value;
			}

			return comparison;
		}
	}
}
