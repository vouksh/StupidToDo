using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;

namespace StupidToDo.Services
{
	public static class Config
	{
		private static Records.AppOptions Options;
		private static readonly object saveLock = new object();

		public static int SelectedListID
		{
			get
			{
				return Options.SelectedListID;
			}
			set
			{
				Options.SelectedListID = value;
				SaveConfig();
			}
		}

		public static bool ShowCompleted
		{
			get
			{
				return Options.ShowCompleted;
			}
			set
			{
				Options.ShowCompleted = value;
				SaveConfig();
			}
		}

		public static bool MinimizeToTray
		{
			get
			{
				return Options.MinimizeToTray;
			}
			set
			{
				Options.MinimizeToTray = value;
				SaveConfig();
			}
		}

		public static bool OnlyRemindForActiveList
		{
			get
			{
				return Options.OnlyRemindForActiveList;
			}
			set
			{
				Options.OnlyRemindForActiveList = value;
				SaveConfig();
			}
		}

		public static bool LoadWithWindows
		{
			get
			{
				return Options.LoadWithWindows;
			}
			set
			{
				Options.LoadWithWindows = value;
				SaveConfig();
			}
		}

		public static bool MinimizeOnStart
		{
			get
			{
				return Options.MinimizeOnStart;
			}
			set
			{
				Options.MinimizeOnStart = value;
				SaveConfig();
			}
		}

		static Config()
		{
			if (Options is null)
			{
				LoadConfig();
			}
		}

		private static void LoadConfig()
		{
			lock (saveLock)
			{
				if (File.Exists($"{AppContext.BaseDirectory}StupidToDo.config.json"))
				{
					Options = JsonSerializer.Deserialize<Records.AppOptions>(File.ReadAllText($"{AppContext.BaseDirectory}StupidToDo.config.json"));
				}
				else
				{
					Options = new Records.AppOptions();
					File.WriteAllText($"{AppContext.BaseDirectory}StupidToDo.config.json", JsonSerializer.Serialize(Options, new JsonSerializerOptions { WriteIndented = true }));
				}
			}
		}

		private static void SaveConfig()
		{
			lock (saveLock)
			{
				File.WriteAllText($"{AppContext.BaseDirectory}StupidToDo.config.json", JsonSerializer.Serialize(Options, new JsonSerializerOptions { WriteIndented = true }));
			}
		}
	}
}
