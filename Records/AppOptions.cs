using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StupidToDo.Records
{
	public record AppOptions
	{
		public int SelectedListID { get; set; } = 1;
		public bool ShowCompleted { get; set; } = false;
		public bool MinimizeToTray { get; set; } = true;
		public bool OnlyRemindForActiveList { get; set; } = false;
		public bool LoadWithWindows { get; set; } = false;
		public bool MinimizeOnStart { get; set; } = false;
	}
}
