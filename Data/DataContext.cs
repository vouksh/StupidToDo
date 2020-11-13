using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.IO;

namespace StupidToDo.Data
{
	public class DataContext : DbContext
	{
		public DataContext()
		{
			if(!File.Exists($"{AppContext.BaseDirectory}todo.db"))
			{
				this.Database.Migrate();
			}
		}
		protected override void OnConfiguring(DbContextOptionsBuilder builder)
		{
			builder.UseSqlite($"Data Source={AppContext.BaseDirectory}todo.db;");
		}

		protected override void OnModelCreating(ModelBuilder builder)
		{
			builder.Entity<Records.ToDoList>().HasData(new Records.ToDoList
			{
				ID = 1,
				Name = "Default"
			});
			builder.Entity<Records.ToDo>().HasData(new Records.ToDo
			{
				ID = 1,
				AssignedListID = 1,
				Title = "Do something",
				Body = "Blah blah blah",
				Created = DateTime.Now,
				DoReminder = false
			});
		}

		public DbSet<Records.ToDo> Items { get; set; }
		public DbSet<Records.ToDoList> Lists { get; set; }
	}
}
