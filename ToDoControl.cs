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
		public ToDoControl()
		{
			InitializeComponent();
		}

		public ToDoControl(Records.ToDo toDo)
		{
			assignedToDo = toDo;
			InitializeComponent();
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
				foreach (var control in Controls)
				{
					if (control is not Label and not Button and Control c)
					{
						c.Enabled = false;
						//(control as Control).Enabled = false;
					}
				}
				editEnabled.Enabled = true;
			}
		}

		private void ToDoControl_Load(object sender, EventArgs e)
		{
			if (assignedToDo is not null)
			{
				titleBox.Text = assignedToDo.Title;
				BodyBox.Text = assignedToDo.Body;
				reminderBox.Checked = assignedToDo.DoReminder;
				if (assignedToDo.DoReminder)
				{
					remindDate.Value = assignedToDo.RemindDate.Value.Date;
					remindTime.Value = assignedToDo.RemindTime.Value.ToLocalTime();
				}
			}
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
	}
}
