using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StupidToDo.Data;
using StupidToDo.Records;

namespace StupidToDo.Services
{
	public class DataAccess
	{
		private readonly DataContext dbContext;
		public DataAccess()
		{
			dbContext = new DataContext();
		}

		public async void SwitchToFirstList()
		{
			var newList = await dbContext.Lists.FirstAsync();
			Config.SelectedListID = newList.ID;
		}

		public async void SwitchList(string listName)
		{
			if (string.IsNullOrWhiteSpace(listName))
				throw new ArgumentException($"Argument cannot be null or empty", nameof(listName));

			var list = await dbContext.Lists.FirstOrDefaultAsync(l => l.Name == listName);
			if (list is not null)
			{
				Config.SelectedListID = list.ID;
			} else
			{
				var newList = new ToDoList
				{
					Name = listName
				};
				dbContext.Lists.Add(newList);
				await dbContext.SaveChangesAsync();
				Config.SelectedListID = newList.ID;
			}
		}

		public async Task<List<ToDo>> GetCurrentListItems()
		{
			return await dbContext.Items.Where(i => i.AssignedListID == Config.SelectedListID).ToListAsync();
		}

		public async void AddNewToDo(ToDo newToDo)
		{
			newToDo.AssignedListID = Config.SelectedListID;
			dbContext.Items.Add(newToDo);
			await dbContext.SaveChangesAsync();
		}

		public async Task<ToDo> AddNewToDo()
		{
			ToDo newToDo = new ToDo
			{
				AssignedListID = Config.SelectedListID,
				Created = DateTime.Now
			};
			dbContext.Items.Add(newToDo);
			await dbContext.SaveChangesAsync();
			return newToDo;
		}

		public async void UpdateToDo(ToDo toDo)
		{
			dbContext.Items.Update(toDo);
			await dbContext.SaveChangesAsync();
		}

		public async void RemoveToDo(int toDoID)
		{
			dbContext.Items.Remove(dbContext.Items.First(t => t.ID == toDoID));
			await dbContext.SaveChangesAsync();
		}

		public async void MarkAsDone(int toDoID)
		{
			var toDoItem = dbContext.Items.First(t => t.ID == toDoID);
			toDoItem.Completed = true;
			await dbContext.SaveChangesAsync();
		}

		public async Task<List<ToDoList>> GetLists()
		{
			return await dbContext.Lists.ToListAsync();
		}

		public async Task AddNewList(string listName)
		{
			if (dbContext.Lists.Any(l => l.Name == listName))
				throw new InvalidOperationException("List with that name already exists");
			if (string.IsNullOrWhiteSpace(listName))
				throw new ArgumentException($"Argument cannot be null or empty", nameof(listName));

			var newList = new ToDoList
			{
				Name = listName
			};
			dbContext.Lists.Add(newList);
			await dbContext.SaveChangesAsync();
			Config.SelectedListID = newList.ID;
		}

		public async Task<int> GetListID(string listName)
		{
			var foundTask = await dbContext.Lists.FirstOrDefaultAsync(l => l.Name == listName);
			if(foundTask is not null)
			{
				return foundTask.ID;
			}
			return -1;
		}
		
		public async void DeleteList(int listID, bool migrate, int? migrateListID)
		{
			if(migrate)
			{
				if(migrateListID is null)
					throw new ArgumentNullException(nameof(migrateListID), "List migration ID cannot be null if choosing to migrate list items!");

				var oldListTodos = await dbContext.Items.Where(t => t.AssignedListID == listID).ToListAsync();
				foreach(var migrateToDo in oldListTodos)
				{
					migrateToDo.AssignedListID = migrateListID.Value;
				}
			}
			dbContext.Lists.Remove(dbContext.Lists.First(l => l.ID == listID));
			await dbContext.SaveChangesAsync();
		}

		public async Task<List<ToDo>> ItemsDueNow()
		{
			List<ToDo> retList = new List<ToDo>();
			List<ToDo> start;
			if (!Config.OnlyRemindForActiveList)
			{
				start = await dbContext.Items.Where(t => t.DoReminder && !t.Completed).ToListAsync();
			} else
			{
				start = await dbContext.Items.Where(t => t.DoReminder && !t.Completed && t.AssignedListID == Config.SelectedListID).ToListAsync();
			}
			foreach(var item in start.Where(t => t.RemindDate.HasValue && DateTime.Today >= t.RemindDate.Value))
			{
				if(DateTime.Now.TimeOfDay >= item.RemindTime.Value.TimeOfDay)
					retList.Add(item);
			}
			foreach(var item in start.Where(t => t.Repeats))
			{
				if (!item.LastRepeat.HasValue)
				{
					switch (item.Frequency)
					{
						case RepeatFrequency.Daily:
							if ((DateTime.Today - item.Created.Date) >= TimeSpan.FromDays(decimal.ToDouble(item.RepeatEvery.Value)) && DateTime.Now.TimeOfDay >= item.RemindTime.Value.TimeOfDay)
							{
								retList.Add(item);
							}
							break;
						case RepeatFrequency.Weekly:
							if ((DateTime.Today - item.Created.Date) >= TimeSpan.FromDays(decimal.ToDouble(item.RepeatEvery.Value * 7)))
							{
								retList.Add(item);
							}
							break;
						case RepeatFrequency.Hourly:
							if ((DateTime.Now - item.Created) >= TimeSpan.FromHours(decimal.ToDouble(item.RepeatEvery.Value)))
							{
								retList.Add(item);
							}
							break;
						case RepeatFrequency.Minutely:
							if ((DateTime.Now - item.Created) >= TimeSpan.FromMinutes(decimal.ToDouble(item.RepeatEvery.Value)))
							{
								retList.Add(item);
							}
							break;
						case RepeatFrequency.DayOfWeek:
							if(item.RepeatOnDay == DateTime.Now.DayOfWeek && item.Created.Date != DateTime.Today && DateTime.Now.TimeOfDay >= item.RemindTime.Value.TimeOfDay)
							{
								retList.Add(item);
							}
							break;
					}
				}
				else
				{
					switch (item.Frequency)
					{
						case RepeatFrequency.Daily:
							if ((DateTime.Today - item.LastRepeat.Value.Date) >= TimeSpan.FromDays(decimal.ToDouble(item.RepeatEvery.Value)) && DateTime.Now.TimeOfDay >= item.RemindTime.Value.TimeOfDay)
							{
								retList.Add(item);
							}
							break;
						case RepeatFrequency.Weekly:
							if ((DateTime.Today - item.LastRepeat.Value.Date) >= TimeSpan.FromDays(decimal.ToDouble(item.RepeatEvery.Value * 7)))
							{
								retList.Add(item);
							}
							break;
						case RepeatFrequency.Hourly:
							if ((DateTime.Now - item.LastRepeat.Value) >= TimeSpan.FromHours(decimal.ToDouble(item.RepeatEvery.Value)))
							{
								retList.Add(item);
							}
							break;
						case RepeatFrequency.Minutely:
							if ((DateTime.Now - item.LastRepeat.Value) >= TimeSpan.FromMinutes(decimal.ToDouble(item.RepeatEvery.Value)))
							{
								retList.Add(item);
							}
							break;
						case RepeatFrequency.DayOfWeek:
							if (item.LastRepeat.Value.DayOfWeek == DateTime.Now.DayOfWeek && item.LastRepeat.Value.Date != DateTime.Today && DateTime.Now.TimeOfDay >= item.RemindTime.Value.TimeOfDay)
							{
								retList.Add(item);
							}
							break;
					}
				}
			}
			return retList;
		}

	}
}
