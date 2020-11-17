using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;

namespace StupidToDo.Forms
{
	public partial class ToDoControl : UserControl
	{
		public Records.ToDo assignedToDo;
		public Guid ControlGUID { get; set; } = Guid.NewGuid();
		private readonly Services.DataAccess dataAccess;
		public ToDoControl()
		{
			InitializeComponent();
			editEnabled.Checked = true;
		}

		public ToDoControl(ref Services.DataAccess _dataAccess)
		{
			dataAccess = _dataAccess;
			InitializeComponent();
			editEnabled.Checked = true;
			SwapLocations();
			assignedToDo = dataAccess.AddNewToDo().Result;
		}

		public ToDoControl(Records.ToDo toDo, ref Services.DataAccess _dataAccess)
		{
			assignedToDo = toDo;
			dataAccess = _dataAccess;
			InitializeComponent();
			if (assignedToDo is not null)
			{
				titleBox.Text = assignedToDo.Title;
				BodyBox.Text = assignedToDo.Body;
				reminderBox.Checked = assignedToDo.DoReminder;
				if (assignedToDo.DoReminder)
				{
					if (assignedToDo.Repeats)
					{
						RepeatBox.Checked = assignedToDo.Repeats;
						DayOfWeekBox.SelectedIndex = (int)assignedToDo.RepeatOnDay;
						EveryBox.Value = assignedToDo.RepeatEvery.Value;
						RepeatsOnBox.SelectedIndex = (int)assignedToDo.Frequency;
					}
					else
					{
						remindDate.Value = assignedToDo.RemindDate.Value.Date;
						remindTime.Value = assignedToDo.RemindTime.Value;
					}
				}
				ToggleReminderControls();
				DisableEdit();
			} else
			{
				editEnabled.Checked = true;
			}
		}

		private void DisableEdit()
		{
			foreach (Control control in Controls)
			{
				if (control is not Label and not Button)
				{
					control.Enabled = false;
				}
			}
			SwapLocations();
			editEnabled.Enabled = true;
		}

		private void SwapLocations()
		{
			var newCheckLoc = reminderBox.Location;
			var oldCheckLoc = editEnabled.Location;
			editEnabled.Location = newCheckLoc;
			reminderBox.Location = oldCheckLoc;
			var oldBtnLoc = CompleteButton.Location;
			var newBtnLoc = remindDate.Location;
			remindDate.Location = oldBtnLoc;
			CompleteButton.Location = newBtnLoc;
			Point delBtnPt = new Point(deleteBtn.Location.X, CompleteButton.Location.Y);
			deleteBtn.Location = delBtnPt;
			if (Height == 285)
			{
				Height = 175;
				remindTime.Visible = false;
			} else
			{
				Height = 285;
			}
		}

		private void EditEnabled_CheckedChanged(object sender, EventArgs e)
		{
			if(editEnabled.Checked)
			{
				foreach(var control in Controls)
				{
					(control as Control).Enabled = true;
				}
				SwapLocations();
				ToggleReminderControls();
			} else
			{
				assignedToDo.Title = titleBox.Text;
				assignedToDo.Body = BodyBox.Text;
				assignedToDo.Edited = DateTime.Now;
				assignedToDo.DoReminder = reminderBox.Checked;
				if (reminderBox.Checked)
				{
					if (RepeatBox.Checked)
					{
						assignedToDo.Repeats = RepeatBox.Checked;
						assignedToDo.RepeatOnDay = (Records.DayOfWeek)DayOfWeekBox.SelectedIndex;
						assignedToDo.RepeatEvery = Convert.ToInt32(EveryBox.Value);
						assignedToDo.Frequency = (Records.RepeatFrequency)RepeatsOnBox.SelectedIndex;
					}
					else
					{
						assignedToDo.RemindDate = remindDate.Value;
						assignedToDo.RemindTime = remindTime.Value;
					}
				}
				dataAccess.UpdateToDo(assignedToDo);
				DisableEdit();
			}
		}

		private void ToDoControl_Load(object sender, EventArgs e)
		{

		}

		private void RepeatsOnBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			if(RepeatsOnBox.SelectedIndex == (int)Records.RepeatFrequency.DayOfWeek)
			{
				DayOfWeekBox.Visible = true;
				EveryBox.Visible = false;
			} else
			{
				DayOfWeekBox.Visible = false;
				EveryBox.Visible = true;
			}
		}

		private void DeleteBtn_Click(object sender, EventArgs e)
		{
			(Parent.Parent as MainForm).RemoveToDo(ControlGUID);
		}

		private void ToggleReminderControls()
		{
			if (reminderBox.Checked)
			{
				RepeatBox.Visible = true;
				if (RepeatBox.Checked)
				{
					everyLabel.Visible = true;
					remindDate.Visible = false;
					remindTime.Visible = false;
					RepeatsOnBox.Visible = true;
					DayOfWeekBox.Visible = true;
					EveryBox.Visible = true;
				}
				else
				{
					everyLabel.Visible = false;
					remindDate.Visible = true;
					remindTime.Visible = true;
					RepeatsOnBox.Visible = false;
					DayOfWeekBox.Visible = false;
					EveryBox.Visible = false;
				}
			}
			else
			{
				everyLabel.Visible = false;
				RepeatBox.Visible = false;
				remindDate.Visible = false;
				remindTime.Visible = false;
				RepeatsOnBox.Visible = false;
				DayOfWeekBox.Visible = false;
				EveryBox.Visible = false;
			}
		}

		private void ReminderBox_CheckedChanged(object sender, EventArgs e)
		{
			ToggleReminderControls();
		}

		private void RepeatBox_CheckedChanged(object sender, EventArgs e)
		{
			if(RepeatBox.Checked)
			{
				everyLabel.Visible = true;
				remindDate.Visible = false;
				remindTime.Visible = false;
				RepeatsOnBox.Visible = true;
				DayOfWeekBox.Visible = true;
				EveryBox.Visible = true;
			} else
			{
				everyLabel.Visible = false;
				remindDate.Visible = true;
				remindTime.Visible = true;
				RepeatsOnBox.Visible = false;
				DayOfWeekBox.Visible = false;
				EveryBox.Visible = false;
			}
		}
	}
}
