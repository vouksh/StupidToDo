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

		public async void SwitchList(string listName)
		{
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

		public async void AddNewList(string listName)
		{
			if (dbContext.Lists.Any(l => l.Name == listName))
				throw new InvalidOperationException("List with that name already exists");
			var newList = new ToDoList
			{
				Name = listName
			};
			dbContext.Lists.Add(newList);
			await dbContext.SaveChangesAsync();
			Config.SelectedListID = newList.ID;
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
			var start = await dbContext.Items.Where(t => t.DoReminder && !t.Completed).ToListAsync();
			foreach(var item in start.Where(t => t.RemindDate.HasValue && t.RemindDate.Value <= DateTime.Today))
			{
				retList.Add(item);
			}
			foreach(var item in start.Where(t => t.Repeats))
			{
				if (!item.LastRepeat.HasValue)
				{
					switch (item.Frequency)
					{
						case RepeatFrequency.Daily:
							if ((DateTime.Today - item.Created.Date) >= TimeSpan.FromDays(1))
							{
								retList.Add(item);
							}
							break;
						case RepeatFrequency.Weekly:
							if ((DateTime.Today - item.Created.Date) >= TimeSpan.FromDays(7))
							{
								retList.Add(item);
							}
							break;
						case RepeatFrequency.Hourly:
							if ((DateTime.Now - item.Created) >= TimeSpan.FromHours(1))
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
							if ((DateTime.Today - item.LastRepeat.Value.Date) >= TimeSpan.FromDays(1))
							{
								retList.Add(item);
							}
							break;
						case RepeatFrequency.Weekly:
							if ((DateTime.Today - item.LastRepeat.Value.Date) >= TimeSpan.FromDays(7))
							{
								retList.Add(item);
							}
							break;
						case RepeatFrequency.Hourly:
							if ((DateTime.Now - item.LastRepeat.Value) >= TimeSpan.FromHours(1))
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
