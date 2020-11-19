using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StupidToDo.Records
{
	public record ToDo
	{
		public int ID { get; init; }
		public ToDoList AssignedList { get; set; }
		public int AssignedListID { get; set; }
		public string Title { get; set; }
		public string Body { get; set; }
		public bool Completed { get; set; } = false;
		public bool DoReminder { get; set; } = false;
		public bool Repeats { get; set; } = false;
		public DateTime? RemindDate { get; set; }
		public DateTime? RemindTime { get; set; }
		public RepeatFrequency Frequency { get; set; } = RepeatFrequency.Never;
		public decimal? RepeatEvery { get; set; }
		public DayOfWeek RepeatOnDay { get; set; }
		public DateTime? LastRepeat { get; set; }
		public DateTime Created { get; set; } = DateTime.Now;
		public DateTime? Edited { get; set; }
	}
	public enum RepeatFrequency
	{
		DayOfWeek,
		Weekly,
		Daily,
		Hourly,
		Minutely,
		Never
	}
}
