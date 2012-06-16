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

namespace GodvilleAutoPlayer
{
	public partial class frmGodville : Form
	{
		// Setup some timers, globals, and place holder objects
		System.Windows.Forms.Timer _timer = new Timer();
		Hero hero = new Hero();
		Hero oldHero = new Hero();
		bool isSmall = true;

		string godName = "";
		string godPassword = "";

		Size panelSize = new Size();
		Size formSize = new Size();
		Point formLocation = new Point();

		HtmlElement lnkEncourage;
		HtmlElement lnkPunish;
		HtmlElement lnkRestoreGodPower;
		HtmlElement lnkSendToArena;
		HtmlElement lnkMakeMiracle;
		HtmlElement lnkChallengeFriend;

		public frmGodville()
		{
			InitializeComponent();
			InitializeForm();

            webBrowser1.ScriptErrorsSuppressed = true;
            
			Microsoft.Win32.RegistryKey key = null;
			try
			{
				string appName = System.AppDomain.CurrentDomain.FriendlyName;
				//// This may only be needed for WinXP...
				//// Reference: http://msdn.microsoft.com/en-us/library/ee330730(v=vs.85).aspx
				//// Force internal IE Browser to display in IE8 Standards mode, 8888h or 34952 (DWORD)
				//key = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Internet Explorer\\Main\\FeatureControl\\FEATURE_BROWSER_EMULATION", true);
				//if (key != null)
				//{
				//    if (key.GetValue(appName) == null)
				//    {
				//        key.SetValue(appName, 34952);
				//    }
				//    key.Close();
				//}
			}
			catch (Exception ex)
			{
				if (key != null)
					key.Close();
			}

			panelSize = pnlMain.Size;
			formSize = this.Size;
		}

		private void frmGodville_Load(object sender, EventArgs e)
		{
			lblHero.Text = "";
			lblEncourage.Visible = false;
			lblPunish.Visible = false;

			pnlMain.Visible = false;
			pnlLogin.Location = new Point(0, 0);
		}

		private void btnLogIn_Click(object sender, EventArgs e)
		{
			godName = tbxGodName.Text;
			godPassword = tbxGodPassword.Text;

			webBrowser1.Navigate("http://www.godvillegame.com");

			_timer.Interval = 5 * 1000;
			_timer.Stop();
			_timer.Enabled = false;
		}

		private void frmGodville_Resize(object sender, EventArgs e)
		{
			if (this.WindowState.Equals(FormWindowState.Maximized))
			{
				this.WindowState = FormWindowState.Normal;
				showHideIE();
			}
			else if (this.WindowState.Equals(FormWindowState.Minimized))
			{
				this.WindowState = FormWindowState.Normal;
				showHideIE();
			}
		}

		void _timer_Tick(object sender, EventArgs e)
		{
			// The timer should only be active on the superhero page
			try
			{
				switch (webBrowser1.Document.Url.ToString())
				{
					case "http://godvillegame.com/superhero":
					case "http://godvillegame.com/superhero/":
						heroUpdates();
						break;
				}
			}
			catch (Exception ex)
			{
				if (ex.ToString().IndexOf("WebBrowser") < 0)
				{
					MessageBox.Show(ex.ToString());
					throw;
				}
			}
		}

		private void webBrowser1_DocumentCompleted(object sender, EventArgs e)
		{
			// Decide where to go based on URL
			switch (webBrowser1.Document.Url.ToString())
			{
				case "http://godvillegame.com/":
				case "http://godvillegame.com/login":
				case "http://godvillegame.com/login/":
				case "http://godvillegame.com/login/login":
					welcome();
					break;
				case "http://godvillegame.com/searching":
				case "http://godvillegame.com/searching/":
					this.Text = webBrowser1.DocumentTitle + " Searching...";
					break;
				case "http://godvillegame.com/superhero":
				case "http://godvillegame.com/superhero/":
					heroUpdates();

					//if (_timer.Enabled == false)
					//{
					//    _timer.Tick += new EventHandler(_timer_Tick);
					//    _timer.Enabled = true;
					//    _timer.Start();
					//}

					break;
			}
		}
		
		private void lblEncourage_Click(object sender, EventArgs e)
		{
			if (webBrowser1.Document != null)
			{
				if (lnkEncourage != null)
					lnkEncourage.InvokeMember("click");
			}
		}

		private void lblPunish_Click(object sender, EventArgs e)
		{
			if (webBrowser1.Document != null)
			{
				if (lnkPunish != null)
					lnkPunish.InvokeMember("click");
			}
		}

		private void lblDiary_Click(object sender, EventArgs e)
		{
			frmDiary form = new frmDiary();
			form.HeroName = hero.Name;
			form.Show();
		}

		private void lblRules_Click(object sender, EventArgs e)
		{
			frmRules form = new frmRules();
			form.HeroName = hero.Name;
			form.Show();
		}

		private void welcome()
		{
			// Attempt to log the user into the game
			bool errorOnLogin = false;
			HtmlElement username = null;
			HtmlElement password = null;
			HtmlElement commit = null;

			if (webBrowser1.Document != null)
			{
				foreach (HtmlElement divError in webBrowser1.Document.GetElementsByTagName("DIV"))
				{
					if (divError.ClassName() == "error")
					{
						if (!String.IsNullOrEmpty(divError.InnerHtml))
							errorOnLogin = true;
						break;
					}
				}

				// Check for the error div and deal with it
				// TODO: A new Captcha has been added that has not been addressed!
				if (!errorOnLogin)
				{
					HtmlElementCollection elems = webBrowser1.Document.GetElementsByTagName("INPUT");
					username = webBrowser1.Document.GetElementById("username");
					password = webBrowser1.Document.GetElementById("password");

					username.SetAttribute("value", godName);
					password.SetAttribute("value", godPassword);

					commit = elems[3];
					commit.InvokeMember("click");

					pnlMain.Visible = true;
					pnlLogin.Visible = false;
					this.MaximizeBox = true;
				}
				else
				{
					this.Text = "Godville: Error logging in...";
					pnlLogin.Visible = true;
					pnlMain.Visible = false;
					this.MaximizeBox = false;
				}

				lblEncourage.Visible = pnlMain.Visible;
				lblPunish.Visible = pnlMain.Visible;
			}
		}

		private void getTurboLight(string Url)
		{
			// TODO: The turbo light was changed from an image to an HTML element
			try
			{
				WebRequest req = WebRequest.Create(Url);
				WebResponse response = req.GetResponse();
				Stream stream = response.GetResponseStream();
				Image img = Image.FromStream(stream);
				if (img != null)
				{
					//picTurbo.Image = img;
					//this.Icon = Icon.FromHandle(new Bitmap(picTurbo.Image).GetHicon());

					using (Bitmap large = new Bitmap(16, 16, PixelFormat.Format32bppArgb))
					{
						using (Graphics largeGraphics = Graphics.FromImage(large))
						{
							largeGraphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
							largeGraphics.DrawEllipse(new Pen(Color.White, 2.0f), 1, 1, 12, 11);
							largeGraphics.DrawImage(img, 2, 2);
						}
						this.Icon = Icon.FromHandle(large.GetHicon());
					}
				}
				stream.Close();
			}
			catch (Exception)
			{
				MessageBox.Show("There was a problem downloading the file");
			}
		}

		private void heroUpdates()
		{
			// Stop the timer while updates are being parsed
			bool statsAndInfoLoaded = false;
			_timer.Stop();
			_timer.Enabled = false;

			try
			{
				if (webBrowser1.Document != null)
				{
					if (isSmall)
					{
						lblEncourage.Visible = true;
						lblPunish.Visible = true;
					}
					else
					{
						lblEncourage.Visible = false;
						lblPunish.Visible = false;
					}

					// Try to make sure the whole page is loaded... there is probably a much better way,
					// but this seems to work for the most part.
					if (webBrowser1.Document.Body.InnerHtml.IndexOf("Remote Control", StringComparison.InvariantCultureIgnoreCase) > 0
						& webBrowser1.Document.Body.InnerHtml.IndexOf("Hero's Diary", StringComparison.InvariantCultureIgnoreCase) > 0
						)
					{
						//GetTurboLight(webBrowser1.Document.All["turbo_icon"].GetAttribute("class"));

						int start = webBrowser1.Document.Body.InnerHtml.IndexOf("Greetings, ", StringComparison.InvariantCultureIgnoreCase) + 11;
						int end = webBrowser1.Document.Body.InnerHtml.IndexOf("</b>", start, StringComparison.InvariantCultureIgnoreCase) - 1;
						hero.GodName = webBrowser1.Document.Body.InnerHtml.Substring(start, end - start);

						foreach (HtmlElement item in webBrowser1.Document.GetElementsByTagName("DIV"))
						{
							if (item.ClassName() == "gp_val")
							{
								hero.GodPower = int.Parse(item.InnerText.Replace("%", "").Replace("Nan", "0"));
								break;
							}
						}

						foreach (HtmlElement tag in webBrowser1.Document.GetElementsByTagName("SPAN"))
						{
							if (tag.InnerText != null)
							{
								if (tag.InnerText.Equals("Encourage", StringComparison.InvariantCultureIgnoreCase))
								{
									lnkEncourage = tag;
									lblEncourage.Enabled = true;
								}
								else if (tag.InnerText.Equals("Punish", StringComparison.InvariantCultureIgnoreCase))
								{
									lnkPunish = tag;
									lblPunish.Enabled = true;
								}
								else if (tag.InnerText.Equals("Restore", StringComparison.InvariantCultureIgnoreCase))
								{
									lnkRestoreGodPower = tag;
								}
								else if (tag.InnerText.Equals("Send to Arena", StringComparison.InvariantCultureIgnoreCase))
								{
									lnkSendToArena = tag;
								}
								else if (tag.InnerText.Equals("Make a Miracle", StringComparison.InvariantCultureIgnoreCase))
								{
									lnkMakeMiracle = tag;
								}
								else if (tag.InnerText.Equals("Challenge Friend", StringComparison.InvariantCultureIgnoreCase))
								{
									lnkChallengeFriend = tag;
								}
								if (tag.ClassName() == "acc_val")
								{
									hero.Charges = int.Parse((tag.InnerText ?? "").Trim() == "" ? "0" : tag.InnerText);
								}
							}
						}

						statsAndInfoLoaded = heroInfo();

						petInfo();
						Application.DoEvents();
						
						pantheonStatus();
						Application.DoEvents();

						earthlyNews();
						Application.DoEvents();

						heroDiary();
						Application.DoEvents();

						heroInventory();
						Application.DoEvents();

						heroEquipment();
						Application.DoEvents();

						heroSkills();
						Application.DoEvents();

						if (statsAndInfoLoaded)
						{
							// Update the miniature Summary UI
							if (!String.IsNullOrEmpty(hero.TownName))
								this.Text = String.Format("Godville: {0} - {1} ({2})", hero.GodName, hero.Name, hero.TownName);
							else
								this.Text = String.Format("Godville: {0} - {1} (Adventuring)", hero.GodName, hero.Name);
							lblHero.Text = String.Format("H: {0}%  GP: {1}%  G: {2} coins  Q: {3}%  Mi: {4}", (hero.Health * 100 / hero.MaxHealth), hero.GodPower, hero.Gold, hero.QuestPercent, hero.MilestonesPassed);
							lblHero.Refresh();
							lblDiary.Enabled = true;
							lblRules.Enabled = true;
							Application.DoEvents();

							// If the hero has any updated info, then update the db and clone the current copy
							if (!hero.compare(oldHero))
							{
								oldHero = hero.clone();
								hero.saveHero();
							}
							executeRules();
						}
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString());
				throw;
			}
			finally
			{
				// Start the timer backup.  If the stats have not been loaded,
				// then the page is still loading via AJAX, so keep the timer going
				// at 5 seconds, otherwise switch to 30 seconds
				if (!_timer.Enabled)
				{
					_timer.Enabled = true;
					_timer.Tick += new EventHandler(_timer_Tick);
					_timer.Interval = (statsAndInfoLoaded ? 30 : 5) * 1000;
					_timer.Start();
				}
			}
		}

		private bool heroInfo()
		{
			try
			{
				// Parse the basic Hero info details
				hero.Name = webBrowser1.Document.GetElementById("hk_name").Children[1].Children[0].InnerText;

				// Grab the latest hero entry from the db to setup hero comparisons
				if (String.IsNullOrEmpty(oldHero.Name))
					oldHero.getHero(hero.Name);
				syncDiaryAndNews();

				hero.Motto = webBrowser1.Document.GetElementById("hk_motto").Children[1].InnerText;
				hero.Personality = webBrowser1.Document.GetElementById("hk_alignment").Children[1].InnerText;

				HtmlElement elem = webBrowser1.Document.GetElementById("hk_clan");
				hero.Guild = elem.Children[1].Children[0].InnerText;
				hero.GuildRank = elem.Children[1].InnerText.Split('(')[1].Replace(")", "");
				
				elem = webBrowser1.Document.GetElementById("hk_level");
				hero.Level = int.Parse(elem.Children[1].InnerText);
				hero.LevelPercent = int.Parse(elem.Children[2].Title().Replace("%", ""));

				elem = webBrowser1.Document.GetElementById("hk_inventory_num");
				hero.Inventory = int.Parse(elem.Children[1].InnerText.Split('/')[0].Trim());
				hero.MaxInventory = int.Parse(elem.Children[1].InnerText.Split('/')[1].Trim());

				elem = webBrowser1.Document.GetElementById("hk_health");
				hero.Health = int.Parse(elem.Children[1].InnerText.Split('/')[0].Trim());
				hero.MaxHealth = int.Parse(elem.Children[1].InnerText.Split('/')[1].Trim());

				elem = webBrowser1.Document.GetElementById("hk_quests_completed");
				hero.Quest = elem.Children[2].InnerText;
				hero.QuestNumber = int.Parse(elem.Children[1].InnerText.Replace("#", ""));
				hero.QuestPercent = int.Parse(elem.Children[3].Title().Replace("%", ""));

				hero.Gold = int.Parse(webBrowser1.Document.GetElementById("hk_gold_we").Children[1].InnerText.Replace("coins", ""));
				hero.MonstersKilled = int.Parse(webBrowser1.Document.GetElementById("hk_monsters_killed").Children[1].InnerText);
				hero.DeathCount = int.Parse(webBrowser1.Document.GetElementById("hk_death_count").Children[1].InnerText);

				elem = webBrowser1.Document.GetElementById("hk_arena_won");
				hero.Wins = int.Parse(elem.Children[1].InnerText.Split('/')[0].Trim());
				hero.Losses = int.Parse(elem.Children[1].InnerText.Split('/')[1].Trim());

				hero.Bricks = webBrowser1.Document.GetElementById("hk_bricks_cnt").Children[1].InnerText;
				if (isInteger(webBrowser1.Document.GetElementById("hk_distance").Children[1].InnerText))
				{
					hero.MilestonesPassed = int.Parse(webBrowser1.Document.GetElementById("hk_distance").Children[1].InnerText);
				}
				else
				{
					hero.TownName = webBrowser1.Document.GetElementById("hk_distance").Children[1].InnerText;
				}

				elem = webBrowser1.Document.GetElementById("stats");
				foreach (HtmlElement child in elem.Children[1].Children)
				{
					if ((child.InnerHtml ?? "").ToLower().IndexOf("aura</div>") > 0)
					{
						if (!String.IsNullOrEmpty(child.Children[1].InnerText))
						{
							hero.Aura = child.Children[1].InnerText.Split('(')[0].Trim();
							hero.AuraDuration = child.Children[1].InnerText.Split('(')[1].Replace(")", "").Trim();
						}
					}
				}

				// Not sure what this tag is...
				//hero.Retirement = webBrowser1.Document.GetElementById("hk_level").Children[1].InnerText;

				return true;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString());
				throw;
			}
		}

		private bool petInfo()
		{
			// Parse the Pet info (if there is one)
			try
			{
				HtmlElement elem = webBrowser1.Document.GetElementById("pet");
				if (elem != null)
				{
					if (elem.Children.Count > 1)
					{
						hero.PetName = elem.Children[1].Children[0].Children[1].InnerText.Split(' ')[0].Trim();
						hero.PetPersonality = elem.Children[1].Children[0].Children[1].InnerText.Split(' ')[1].Trim();
						hero.PetSpecies = elem.Children[1].Children[1].Children[1].Children[0].InnerText.Trim();
						hero.PetLevel = elem.Children[1].Children[2].Children[1].InnerText.Trim();
						hero.PetAge = elem.Children[1].Children[3].Children[1].InnerText.Trim();
						hero.PetStatus = (elem.Children[1].Children[4].Children[1].InnerText ?? "").Trim();
					}
				}

				return true;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString());
				throw;
			}
		}

		private bool pantheonStatus()
		{
			// Parse any Pantheon info
			try
			{
				HtmlElement elem = webBrowser1.Document.GetElementById("pantheons");
				if (elem != null)
				{
					if (elem.Children.Count > 1)
					{
						int startBlock = 2;
						if (elem.Children[1].Children[1].ClassName() == "p_group p_group_sep")
							startBlock = 1;

						for (int i = startBlock; i < elem.Children[1].Children.Count; i++)
						{
							for (int j = 0; j < elem.Children[1].Children[i].Children.Count; j++)
							{
								string pantheon = elem.Children[1].Children[i].Children[j].Children[0].InnerText;
								string val = elem.Children[1].Children[i].Children[j].Children[2].InnerText.Trim();
								if (!isInteger(val))
									val = "0";
								int iVal = int.Parse(val);

								switch (pantheon)
								{
									case "Gratitude":
										hero.Gratitude = iVal;
										break;
									case "Might":
										hero.Might = iVal;
										break;
									case "Templehood":
										hero.Templehood = iVal;
										break;
									case "Gladiatorship":
										hero.Gladiatorship = iVal;
										break;
									case "Storytelling":
										hero.Storytelling = iVal;
										break;
									case "Mastery":
										hero.Mastery = iVal;
										break;
									case "Construction":
										hero.Construction = iVal;
										break;
									case "Taming":
										hero.Taming = iVal;
										break;
									case "Survival":
										hero.Survival = iVal;
										break;
									case "Greed":
										hero.Greed = iVal;
										break;
									case "Creation":
										hero.Creation = iVal;
										break;
									case "Destruction":
										hero.Destruction = iVal;
										break;
									case "Unity":
										hero.Unity = iVal;
										break;
									case "Popularity":
										hero.Popularity = iVal;
										break;
									case "Aggressiveness":
										hero.Aggressiveness = iVal;
										break;
								}
							}
						}
					}
				}

				return true;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString());
				throw;
			}
		}

		private bool earthlyNews()
		{
			// Parse the rotating Earthly News section
			try
			{
				HtmlElement elem = webBrowser1.Document.GetElementById("news");
				if (elem != null)
				{
					if (elem.Children.Count > 1)
					{
						bool itemAdded = false;
						HtmlElementCollection items = elem.Children[1].Children[0].Children;

						HeroDetailsEntry details = new HeroDetailsEntry();
						details.TopMessage = items[0].Children[0].InnerText;
						details.Enemy = items[0].Children[1].InnerText;
						string progress = items[0].Children[2].Title().Replace("%", "").Replace("NaN", "0");
						details.Progress = int.Parse(progress);
						details.BottomMessage = items[1].InnerText;

						progress = items[2].Title().Replace("%", "").Replace("NaN", "0");
						details.Progress2 = int.Parse(progress);
						itemAdded = true;

						if (itemAdded)
						{
							if (!hero.DetailsEntries.Contains(details))
							{
								hero.DetailsEntries.Add(details);
								hero.saveDetailEntry(details);
							}
						}

						if (hero.DetailsEntries.Count > 0)
							tbxNews.Text = String.Format("{0}\r\n{1}",
								String.IsNullOrEmpty(hero.DetailsEntries[hero.DetailsEntries.Count - 1].Enemy) ?
									hero.DetailsEntries[hero.DetailsEntries.Count - 1].TopMessage :
									hero.DetailsEntries[hero.DetailsEntries.Count - 1].Enemy,
								hero.DetailsEntries[hero.DetailsEntries.Count - 1].BottomMessage);
					}
				}
				return true;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString());
				throw;
			}
		}

		private bool heroDiary()
		{
			// Parse the Hero's diary
			bool newestAtTop = false;

			try
			{
				HtmlElement elem = webBrowser1.Document.GetElementById("news");
				if (elem != null)
				{
					if (elem.Children.Count > 1)
					{

						HtmlElementCollection spans = webBrowser1.Document.GetElementsByTagName("SPAN");
						foreach (HtmlElement span in spans)
						{
							if (span.Title().Equals("Change diary sort order", StringComparison.InvariantCultureIgnoreCase))
							{
								string temp = span.InnerText;
								newestAtTop = (temp == "▼");
								break;
							}
						}

						HtmlElementCollection items = webBrowser1.Document.GetElementById("diary").Children[1].Children[0].Children[0].Children;
						bool itemAdded = false;
						int insertionPoint = hero.DiaryEntries.Count;
						foreach (HtmlElement item in items)
						{
							HeroDiaryEntry entry = new HeroDiaryEntry();
							entry.TimeStamp =item.Children[0].InnerText;
							entry.Content = item.Children[1].InnerText;
							entry.Saved = true;
							if (!hero.DiaryEntries.Contains(entry))
							{
								entry.Saved = false;
								if (newestAtTop)
									hero.DiaryEntries.Insert(insertionPoint, entry);
								else
									hero.DiaryEntries.Add(entry);

								itemAdded = true;
							}
						}

						if (itemAdded)
						{
							for (int i = 0; i < hero.DiaryEntries.Count; i++)
							{
								HeroDiaryEntry diaryItem = hero.DiaryEntries[i];
								if (!diaryItem.Saved)
								{
									hero.saveDiaryEntry(diaryItem);
									diaryItem.Saved = true;
									hero.DiaryEntries[i] = diaryItem;
								}
							}
						}
						if (hero.DiaryEntries.Count > 0)
							tbxDiary.Text = hero.DiaryEntries[hero.DiaryEntries.Count - 1].Content;
					}
				}

				return true;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString());
				throw;
			}
		}

		private bool heroInventory()
		{
			// Parse the Hero's inventory and as a List and later store as | delimited
			try
			{
				HtmlElement elem = webBrowser1.Document.GetElementById("inv_block_content");
				if (elem != null)
				{
					if (elem.Children.Count > 1)
					{
						hero.InventoryItems.Clear();
						foreach (HtmlElement li in elem.Children[1].Children)
						{
							hero.InventoryItems.Add(li.InnerText);
						}
					}
				}

				return true;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString());
				throw;
			}
		}

		private bool heroEquipment()
		{
			// Parse the Hero's Equipment
			try
			{
				HtmlElement elem = webBrowser1.Document.GetElementById("equipment");
				if (elem != null)
				{
					if (elem.Children.Count > 1)
					{
						for (int i = 0; i < elem.Children[1].Children.Count; i++)
						{
							if (elem.Children[1].Children[i].Children.Count > 1)
							{
								string type = elem.Children[1].Children[i].Children[0].InnerText;
								string level = elem.Children[1].Children[i].Children[1].InnerText;
								string name = elem.Children[1].Children[i].Children[2].InnerText;
								string formatted = String.Format("{0} ({1})", name, level);
								switch (type)
								{
									case "Weapon":
										hero.Weapon = formatted;
										break;
									case "Shield":
										hero.Shield = formatted;
										break;
									case "Head":
										hero.Head = formatted;
										break;
									case "Body":
										hero.Body = formatted;
										break;
									case "Arms":
										hero.Arms = formatted;
										break;
									case "Legs":
										hero.Legs = formatted;
										break;
									case "Talisman":
										hero.Talisman = formatted;
										break;
								}
							}
						}
					}
				}

				return true;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString());
				throw;
			}

		}

		private bool heroSkills()
		{
			try
			{
				// Parse the Hero's Skills and as a List and later store as | delimited

				string skill = "";
				HtmlElement elem = webBrowser1.Document.GetElementById("s_b_id");
				if (elem != null)
				{
					if (elem.Children.Count > 1)
					{
						hero.Skills.Clear();
						foreach (HtmlElement li in elem.Children[1].Children)
						{
							skill = String.Format("{0} - {1}", li.Children[0].InnerText, li.Children[1].InnerText);
							hero.Skills.Add(skill);
						}
					}
				}

				return true;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString());
				throw;
			}
		}

		private void syncDiaryAndNews()
		{
			// Sync the existing diary entries from the Old Hero to the current hero
			if (hero.DiaryEntries.Count == 0)
			{
				foreach (HeroDiaryEntry oldEntry in oldHero.DiaryEntries)
				{
					HeroDiaryEntry newEntry = new HeroDiaryEntry();
					newEntry.Content = oldEntry.Content;
					newEntry.Saved = true;
					newEntry.TimeStamp = oldEntry.TimeStamp;
					hero.DiaryEntries.Add(newEntry);
				}
			}
		}

		private void executeRules()
		{
			hero.executeRules(lnkEncourage, lnkPunish);
		}

		private void showHideIE()
		{
			// Normally the default frame is very small, and only shows the abbreviated
			// stats and the recent updates.  Maximising will show different summary
			// and also enlarge IE to be visible.
			if (isSmall)
			{
				formLocation = this.Location;
				this.Location = new Point(this.Location.X, 10);
				isSmall = !isSmall;
				this.MinimizeBox = true;
				this.MaximizeBox = false;
				this.FormBorderStyle = FormBorderStyle.Sizable;

				this.Size = new Size(1000, 800);
				pnlMain.Size = new Size(74, 20);
				webBrowser1.Dock = DockStyle.Fill;
				pnlMain.Visible = false;
				lblEncourage.Visible = pnlMain.Visible;
				lblPunish.Visible = pnlMain.Visible;
			}
			else
			{
				isSmall = !isSmall;
				this.MinimizeBox = false;
				this.MaximizeBox = true;
				this.FormBorderStyle = FormBorderStyle.FixedSingle;

				this.Size = formSize; //new Size(283, 47);
				pnlMain.Size = panelSize; // new Size(277, 20);
				this.Location = formLocation;

				webBrowser1.Dock = DockStyle.None;
				webBrowser1.Location = new Point(2, 27);
				webBrowser1.Size = new Size(75, 20);
				pnlMain.Visible = true;
				lblEncourage.Visible = pnlMain.Visible;
				lblPunish.Visible = pnlMain.Visible;
			}
		}

		private void showHand(object sender, EventArgs e)
		{
			this.Cursor = Cursors.Hand;
		}

		private void resetHand(object sender, EventArgs e)
		{
			this.Cursor = Cursors.Default;
		}

		private bool isInteger(string input)
		{
			int results = 0;
			bool isInt = false;
			isInt = int.TryParse(input, out results);

			return isInt;
		}

		#region WebBrowser and Support
		// Updates the URL in TextBoxAddress upon navigation.
		private void webBrowser1_Navigated(object sender, WebBrowserNavigatedEventArgs e)
		{
			toolStripTextBox1.Text = webBrowser1.Url.ToString();
		}

		// Displays the Save dialog box.
		private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			webBrowser1.ShowSaveAsDialog();
		}

		// Displays the Page Setup dialog box.
		private void pageSetupToolStripMenuItem_Click(object sender, EventArgs e)
		{
			webBrowser1.ShowPageSetupDialog();
		}

		// Displays the Print dialog box.
		private void printToolStripMenuItem_Click(object sender, EventArgs e)
		{
			webBrowser1.ShowPrintDialog();
		}

		// Displays the Print Preview dialog box.
		private void printPreviewToolStripMenuItem_Click(
			object sender, EventArgs e)
		{
			webBrowser1.ShowPrintPreviewDialog();
		}

		// Displays the Properties dialog box.
		private void propertiesToolStripMenuItem_Click(
			object sender, EventArgs e)
		{
			webBrowser1.ShowPropertiesDialog();
		}

		// Selects all the text in the text box when the user clicks it. 
		private void toolStripTextBox1_Click(object sender, EventArgs e)
		{
			toolStripTextBox1.SelectAll();
		}

		// Navigates to the URL in the address box when 
		// the ENTER key is pressed while the ToolStripTextBox has focus.
		private void toolStripTextBox1_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				Navigate(toolStripTextBox1.Text);
			}
		}

		// Navigates to the URL in the address box when 
		// the Go button is clicked.
		private void goButton_Click(object sender, EventArgs e)
		{
			Navigate(toolStripTextBox1.Text);
		}

		// Navigates to the given URL if it is valid.
		private void Navigate(String address)
		{
			if (String.IsNullOrEmpty(address)) return;
			if (address.Equals("about:blank")) return;
			if (!address.StartsWith("http://") &&
				!address.StartsWith("https://"))
			{
				address = "http://" + address;
			}
			try
			{
				webBrowser1.Navigate(new Uri(address));
			}
			catch (System.UriFormatException)
			{
				return;
			}
		}

		// Navigates webBrowser1 to the previous page in the history.
		private void backButton_Click(object sender, EventArgs e)
		{
			webBrowser1.GoBack();
		}

		// Disables the Back button at the beginning of the navigation history.
		private void webBrowser1_CanGoBackChanged(object sender, EventArgs e)
		{
			backButton.Enabled = webBrowser1.CanGoBack;
		}

		// Navigates webBrowser1 to the next page in history.
		private void forwardButton_Click(object sender, EventArgs e)
		{
			webBrowser1.GoForward();
		}

		// Disables the Forward button at the end of navigation history.
		private void webBrowser1_CanGoForwardChanged(object sender, EventArgs e)
		{
			forwardButton.Enabled = webBrowser1.CanGoForward;
		}

		// Halts the current navigation and any sounds or animations on 
		// the page.
		private void stopButton_Click(object sender, EventArgs e)
		{
			webBrowser1.Stop();
		}

		// Reloads the current page.
		private void refreshButton_Click(object sender, EventArgs e)
		{
			// Skip refresh if about:blank is loaded to avoid removing
			// content specified by the DocumentText property.
			if (!webBrowser1.Url.Equals("about:blank"))
			{
				webBrowser1.Refresh();
			}
		}

		// Navigates webBrowser1 to the home page of the current user.
		private void homeButton_Click(object sender, EventArgs e)
		{
			webBrowser1.GoHome();
		}

		// Navigates webBrowser1 to the search page of the current user.
		private void searchButton_Click(object sender, EventArgs e)
		{
			webBrowser1.GoSearch();
		}

		// Prints the current document using the current print settings.
		private void printButton_Click(object sender, EventArgs e)
		{
			webBrowser1.Print();
		}

		// Updates the status bar with the current browser status text.
		private void webBrowser1_StatusTextChanged(object sender, EventArgs e)
		{
			toolStripStatusLabel1.Text = webBrowser1.StatusText;
		}

		// Updates the title bar with the current document title.
		private void webBrowser1_DocumentTitleChanged(object sender, EventArgs e)
		{
			this.Text = webBrowser1.DocumentTitle;
		}

		// Exits the application.
		private void exitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		// The remaining code in this file provides basic form initialization and 
		// includes a Main method. If you use the Visual Studio designer to create
		// your form, you can use the designer generated code instead of this code, 
		// but be sure to use the names shown in the variable declarations here,
		// and be sure to attach the event handlers to the associated events. 

		private MenuStrip menuStrip1;
		private ToolStripMenuItem fileToolStripMenuItem, showHideToolStripMenuItem,
			saveAsToolStripMenuItem, printToolStripMenuItem,
			printPreviewToolStripMenuItem, exitToolStripMenuItem,
			pageSetupToolStripMenuItem, propertiesToolStripMenuItem;
		private ToolStripSeparator toolStripSeparator1, toolStripSeparator2;

		private ToolStrip toolStrip1, toolStrip2;
		private ToolStripTextBox toolStripTextBox1;
		private ToolStripButton goButton, backButton,
			forwardButton, stopButton, refreshButton,
			homeButton, searchButton, printButton;

		private StatusStrip statusStrip1;
		private ToolStripStatusLabel toolStripStatusLabel1;

		private void InitializeForm()
		{
			menuStrip1 = new MenuStrip();
			fileToolStripMenuItem = new ToolStripMenuItem();
			showHideToolStripMenuItem = new ToolStripMenuItem();

			saveAsToolStripMenuItem = new ToolStripMenuItem();
			toolStripSeparator1 = new ToolStripSeparator();
			printToolStripMenuItem = new ToolStripMenuItem();
			printPreviewToolStripMenuItem = new ToolStripMenuItem();
			toolStripSeparator2 = new ToolStripSeparator();
			exitToolStripMenuItem = new ToolStripMenuItem();
			pageSetupToolStripMenuItem = new ToolStripMenuItem();
			propertiesToolStripMenuItem = new ToolStripMenuItem();

			menuStrip1.Items.Add(fileToolStripMenuItem);
			menuStrip1.Items.Add(showHideToolStripMenuItem);

			fileToolStripMenuItem.DropDownItems.AddRange(
				new ToolStripItem[] {
				saveAsToolStripMenuItem, toolStripSeparator1, 
				pageSetupToolStripMenuItem, printToolStripMenuItem, 
				printPreviewToolStripMenuItem, toolStripSeparator2,
				propertiesToolStripMenuItem, exitToolStripMenuItem
			});

			fileToolStripMenuItem.Text = "&File";
			showHideToolStripMenuItem.Text = "&Minimize";

			saveAsToolStripMenuItem.Text = "Save &As...";
			pageSetupToolStripMenuItem.Text = "Page Set&up...";
			printToolStripMenuItem.Text = "&Print...";
			printPreviewToolStripMenuItem.Text = "Print Pre&view...";
			propertiesToolStripMenuItem.Text = "Properties";
			exitToolStripMenuItem.Text = "E&xit";

			printToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.P;

			showHideToolStripMenuItem.Click +=
				new EventHandler(showHideToolStripMenuItem_Click);
			saveAsToolStripMenuItem.Click +=
				new System.EventHandler(saveAsToolStripMenuItem_Click);
			pageSetupToolStripMenuItem.Click +=
				new System.EventHandler(pageSetupToolStripMenuItem_Click);
			printToolStripMenuItem.Click +=
				new System.EventHandler(printToolStripMenuItem_Click);
			printPreviewToolStripMenuItem.Click +=
				new System.EventHandler(printPreviewToolStripMenuItem_Click);
			propertiesToolStripMenuItem.Click +=
				new System.EventHandler(propertiesToolStripMenuItem_Click);
			exitToolStripMenuItem.Click +=
				new System.EventHandler(exitToolStripMenuItem_Click);

			toolStrip1 = new ToolStrip();
			goButton = new ToolStripButton();
			backButton = new ToolStripButton();
			forwardButton = new ToolStripButton();
			stopButton = new ToolStripButton();
			refreshButton = new ToolStripButton();
			homeButton = new ToolStripButton();
			searchButton = new ToolStripButton();
			printButton = new ToolStripButton();

			toolStrip2 = new ToolStrip();
			toolStripTextBox1 = new ToolStripTextBox();

			statusStrip1 = new StatusStrip();
			toolStripStatusLabel1 = new ToolStripStatusLabel();

			toolStrip1.Items.AddRange(new ToolStripItem[] {
			goButton, backButton, forwardButton, stopButton,
			refreshButton, homeButton, searchButton, printButton});

			goButton.Text = "Go";
			backButton.Text = "Back";
			forwardButton.Text = "Forward";
			stopButton.Text = "Stop";
			refreshButton.Text = "Refresh";
			homeButton.Text = "Home";
			searchButton.Text = "Search";
			printButton.Text = "Print";

			backButton.Enabled = false;
			forwardButton.Enabled = false;

			goButton.Click += new System.EventHandler(goButton_Click);
			backButton.Click += new System.EventHandler(backButton_Click);
			forwardButton.Click += new System.EventHandler(forwardButton_Click);
			stopButton.Click += new System.EventHandler(stopButton_Click);
			refreshButton.Click += new System.EventHandler(refreshButton_Click);
			homeButton.Click += new System.EventHandler(homeButton_Click);
			searchButton.Click += new System.EventHandler(searchButton_Click);
			printButton.Click += new System.EventHandler(printButton_Click);

			toolStrip2.Items.Add(toolStripTextBox1);
			toolStripTextBox1.Size = new System.Drawing.Size(250, 25);
			toolStripTextBox1.KeyDown +=
				new KeyEventHandler(toolStripTextBox1_KeyDown);
			toolStripTextBox1.Click +=
				new System.EventHandler(toolStripTextBox1_Click);

			statusStrip1.Items.Add(toolStripStatusLabel1);

			webBrowser1.Navigated += new WebBrowserNavigatedEventHandler(webBrowser1_Navigated);
			webBrowser1.CanGoBackChanged += new EventHandler(webBrowser1_CanGoBackChanged);
			webBrowser1.CanGoForwardChanged += new EventHandler(webBrowser1_CanGoForwardChanged);
			webBrowser1.DocumentTitleChanged += new EventHandler(webBrowser1_DocumentTitleChanged);
			webBrowser1.StatusTextChanged += new EventHandler(webBrowser1_StatusTextChanged);
			webBrowser1.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(webBrowser1_DocumentCompleted);

			Controls.AddRange(new Control[] { toolStrip2, toolStrip1, menuStrip1, statusStrip1, menuStrip1 });
		}

		void showHideToolStripMenuItem_Click(object sender, EventArgs e)
		{
			showHideIE();
		}
		#endregion
	}
}
