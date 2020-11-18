using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace StupidToDo.Forms
{
	public partial class MainForm : Form
	{
		private Services.DataAccess dataAccess;
		public MainForm()
		{
			dataAccess = new Services.DataAccess();
			InitializeComponent();
			newItemMenuItem.Click += NewItemMenuItem_Click;
			ExitStripBtn.Click += (object s, EventArgs e) => Close();
			ShowWindowBtn.Click += (object s, EventArgs e) => RestoreFromMinimize();
			ExitMenuBtn.Click += (object s, EventArgs e) => Close();
			NewListBox.KeyDown += NewListBox_KeyDown;
		}

		private void NewListBox_KeyDown(object sender, KeyEventArgs e)
		{
			if(e.KeyCode == Keys.Enter)
			{
				dataAccess.AddNewList(NewListBox.Text);
				NewListBox.Text = "";
				ResetChildren();
			}
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
						var dialog = new ReminderDialog(ref dataAccess, task);
						while (dialog.ShowDialog() != DialogResult.OK) { }
						if (!task.Repeats && !dialog.Snoozed)
						{
							var ctrl = FlowPanel.Controls.Cast<ToDoControl>().FirstOrDefault(f => f.assignedToDo.ID == task.ID);
							if (ctrl is not null)
							{
								RemoveToDo(ctrl.ControlGUID, false);
							}
						}
					}
				}
				remindersShown = false;
			}
		}

		private async void ResetChildren()
		{
			if (FlowPanel.Controls.Count > 0)
			{
				FlowPanel.Controls.Clear();
			}
			listMenuCollection.DropDownItems.Clear();
			foreach (var list in await dataAccess.GetLists())
			{
				var newItem = new ToolStripMenuItem(list.Name);
				if (list.ID == Services.Config.SelectedListID)
				{
					newItem.Checked = true;
				}
				listMenuCollection.DropDownItems.Add(newItem);
			}
			foreach (var item in await dataAccess.GetCurrentListItems())
			{
				if (!item.Completed)
					FlowPanel.Controls.Add(new ToDoControl(item, ref dataAccess));
			}
		}

		private void MainForm_Load(object sender, EventArgs e)
		{
			listMenuCollection.DropDownItemClicked += ListMenuCollection_DropDownItemClicked;
			ResetChildren();
			reminderTimer.Start();
		}

		private void ListMenuCollection_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
		{
			dataAccess.SwitchList(e.ClickedItem.Text);
			ResetChildren();
		}

		public void RemoveToDo(Guid controlGUID, bool delete = true)
		{
			foreach (ToDoControl toDo in FlowPanel.Controls)
			{
				if (toDo.ControlGUID == controlGUID)
				{
					if(delete)
						dataAccess.RemoveToDo(toDo.assignedToDo.ID);

					FlowPanel.Controls.Remove(toDo);
					return;
				}
			}
		}

		private void NotifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			RestoreFromMinimize();
		}

		private void RestoreFromMinimize()
		{
			Show();
			WindowState = FormWindowState.Normal;
			notifyIcon.Visible = false;
		}

		private void MainForm_Resize(object sender, EventArgs e)
		{
			if (WindowState == FormWindowState.Minimized)
			{
				Hide();
				notifyIcon.Visible = true;
			}
		}
	}
}