using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StupidToDo.Records
{
	public record ToDoList
	{
		public int ID { get; init; }
		public string Name { get; set; }
		public virtual List<ToDo> ToDos { get; set; }
	}
}
