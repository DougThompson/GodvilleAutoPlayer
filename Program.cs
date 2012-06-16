using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace GodvilleAutoPlayer
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new frmGodville());
			//Application.Run(new frmD20Scraper());
			//Application.Run(new frmTest());
		}
	}
}
