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
			if(!File.Exists($"{AppContext.BaseDirectory}StupidToDo.db"))
			{
				this.Database.Migrate();
			}
		}
		protected override void OnConfiguring(DbContextOptionsBuilder builder)
		{
			builder.UseSqlite($"Data Source={AppContext.BaseDirectory}StupidToDo.db;");
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
				Title = "First example!",
				Body = "{\\rtf1\\ansi\\ansicpg1252\\deff0\\nouicompat\\deflang1033{\\fonttbl{\\f0\\fnil\\fcharset0 Segoe UI;}{\\f1\\fnil Segoe UI;}}\r\n{\\colortbl ;\\red255\\green128\\blue0;\\red0\\green128\\blue0;\\red0\\green0\\blue255;\\red255\\green0\\blue128;\\red255\\green0\\blue0;\\red128\\green0\\blue255;\\red0\\green0\\blue0;}\r\n{\\*\\generator Riched20 10.0.19041}\\viewkind4\\uc1 \r\n\\pard\\b\\f0\\fs18 Bold\\par\r\n\\b0\\i Italic\\par\r\n\\ul\\i0 Underline\\par\r\n\\b Bold Underline\\par\r\n\\i Bold Underline Italic\\par\r\n\\cf1\\ulnone\\b0\\i0 P\\cf2 r\\cf3 et\\cf4 t\\cf5 y \\cf6\\b COLORS\\par\r\n{\\cf7\\b0{\\field{\\*\\fldinst{HYPERLINK http://www.google.com/ }}{\\fldrslt{http://www.google.com/\\ul0\\cf0}}}}\\cf7\\b0\\f0\\fs18  Even hyperlinks!\\cf0\\f1\\par\r\n}\r\n",
				Created = DateTime.Now,
				DoReminder = false
			});
		}

		public DbSet<Records.ToDo> Items { get; set; }
		public DbSet<Records.ToDoList> Lists { get; set; }
	}
}
