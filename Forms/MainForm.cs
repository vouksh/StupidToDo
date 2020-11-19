using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using StupidToDo.Services;
using FontAwesome.Sharp;
using System.Drawing;

namespace StupidToDo.Forms
{
	public partial class MainForm : Form
	{
		private DataAccess dataAccess;
		public MainForm()
		{
			dataAccess = new DataAccess();
			InitializeComponent();
			InitializeActions();
		}

		private void InitializeActions()
		{
			newItemMenuItem.Click += NewItemMenuItem_Click;

			ExitStripBtn.Image = IconChar.Times.ToBitmap(Color.Red, 18);
			ExitStripBtn.ImageAlign = ContentAlignment.MiddleCenter;
			ExitStripBtn.Click += (object s, EventArgs e) => Close();

			ShowWindowBtn.Image = IconChar.WindowRestore.ToBitmap(Color.Blue, 18);
			ShowWindowBtn.ImageAlign = ContentAlignment.MiddleCenter;
			ShowWindowBtn.Click += (object s, EventArgs e) => RestoreFromMinimize();

			ExitMenuBtn.Click += (object s, EventArgs e) => Close();

			NewListBox.KeyDown += NewListBox_KeyDown;

			ToggleMinimizeToTray.Checked = Config.MinimizeToTray;
			ToggleMinimizeToTray.CheckedChanged += (object s, EventArgs e) =>
			{
				Config.MinimizeToTray = ToggleMinimizeToTray.Checked;
			};

			ToggleCompletedTasks.Checked = Config.ShowCompleted;
			ToggleCompletedTasks.CheckedChanged += (object s, EventArgs e) =>
			{
				Config.ShowCompleted = ToggleCompletedTasks.Checked;
				ResetChildren();
			};

			DeleteList.Click += (object s, EventArgs e) =>
			{
				new DeleteListForm(ref dataAccess).ShowDialog();
				ResetChildren();
			};
			ToggleListReminders.Checked = Config.OnlyRemindForActiveList;
			ToggleListReminders.CheckedChanged += (object s, EventArgs e) =>
			{
				Config.OnlyRemindForActiveList = ToggleListReminders.Checked;
			};
		}

		private async void NewListBox_KeyDown(object sender, KeyEventArgs e)
		{
			if(e.KeyCode == Keys.Enter)
			{
				try
				{
					await dataAccess.AddNewList(NewListBox.Text);
					ResetChildren();
					fileToolStripMenuItem.DropDown.Close();
				} 
				catch(ArgumentException ex)
				{
					MessageBox.Show(ex.Message, "Couldn't add new list", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				catch(InvalidOperationException oex)
				{
					MessageBox.Show(oex.Message, "Couldn't add new list", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}

				NewListBox.Text = "";
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
			NewListBox.TextBox.PlaceholderText = "New list name";
			NewListBox.Width = listMenuCollection.DropDown.Width;
			listMenuCollection.DropDownItems.Add(NewListBox);
			var listCollection = await dataAccess.GetLists();
			if(listCollection.Count == 1)
			{
				DeleteList.Enabled = false;
				DeleteList.Visible = false;
			} else
			{
				DeleteList.Enabled = true;
				DeleteList.Visible = true;
			}
			foreach (var list in listCollection)
			{
				var newItem = new IconMenuItem()
				{
					Text = list.Name,
					IconChar = list.ID == Config.SelectedListID ? IconChar.Check : IconChar.ExchangeAlt,
					Checked = list.ID == Config.SelectedListID
				};

				listMenuCollection.DropDownItems.Add(newItem);
			}
			foreach (var item in await dataAccess.GetCurrentListItems())
			{
				if (!item.Completed || Config.ShowCompleted)
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