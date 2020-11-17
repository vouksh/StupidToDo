using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StupidToDo
{
	public partial class MainForm : Form
	{
		private Services.DataAccess dataAccess;
		public MainForm()
		{
			dataAccess = new Services.DataAccess();
			InitializeComponent();
			newItemMenuItem.Click += NewItemMenuItem_Click;
		}

		private void NewItemMenuItem_Click(object sender, EventArgs e)
		{
			FlowPanel.Controls.Add(new ToDoControl(ref dataAccess));
		}
		private bool remindersShown = false;
		private async void ReminderTimer_Tick(object sender, EventArgs e)
		{
			if (!remindersShown)
			{
				List<Records.ToDo> dueTasks = await dataAccess.ItemsDueNow();
				if (dueTasks.Count > 0)
				{
					remindersShown = true;
					foreach (var task in dueTasks)
					{
						var dialog = new Forms.ReminderDialog(ref dataAccess, task);
						while (dialog.ShowDialog() != DialogResult.OK) { }
						if (!task.Repeats)
						{
							var ctrl = FlowPanel.Controls.Cast<ToDoControl>().FirstOrDefault(f => f.assignedToDo.ID == task.ID);
							if (ctrl is not null)
							{
								RemoveToDo(ctrl.ControlGUID);
							}
						}
					}
				}
				remindersShown = false;
			}
		}

		private async void ResetChildren()
		{
			if(FlowPanel.Controls.Count > 0)
			{
				FlowPanel.Controls.Clear();
			}
			foreach (var item in await dataAccess.GetCurrentListItems())
			{
				if (!item.Completed)
					FlowPanel.Controls.Add(new ToDoControl(item, ref dataAccess));
			}
		}

		private async void MainForm_Load(object sender, EventArgs e)
		{
			foreach(var list in await dataAccess.GetLists())
			{
				listMenuCollection.DropDownItems.Add(list.Name);
			}
			listMenuCollection.DropDownItemClicked += ListMenuCollection_DropDownItemClicked;
			ResetChildren();
			reminderTimer.Start();
		}

		private void ListMenuCollection_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
		{
			dataAccess.SwitchList(e.ClickedItem.Text);
		}

		public void RemoveToDo(Guid controlGUID)
		{
			foreach(ToDoControl toDo in FlowPanel.Controls)
			{
				if(toDo.ControlGUID == controlGUID)
				{
					dataAccess.RemoveToDo(toDo.assignedToDo.ID);
					FlowPanel.Controls.Remove(toDo);
					return;
				}
			}
		}
	}
}
