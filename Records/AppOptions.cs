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
	}
}
