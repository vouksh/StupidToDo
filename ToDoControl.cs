using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;

namespace StupidToDo
{
	public partial class ToDoControl : UserControl
	{
		public Records.ToDo assignedToDo;
		public Guid ControlGUID { get; set; } = Guid.NewGuid();
		private Services.DataAccess dataAccess;
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
						remindTime.Value = assignedToDo.RemindTime.Value.ToLocalTime();
					}
				}
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
					//(control as Control).Enabled = false;
				}
			}
			editEnabled.Enabled = true;
		}

		private void EditEnabled_CheckedChanged(object sender, EventArgs e)
		{
			if(editEnabled.Checked)
			{
				foreach(var control in Controls)
				{
					(control as Control).Enabled = true;
				}
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
	}
}
