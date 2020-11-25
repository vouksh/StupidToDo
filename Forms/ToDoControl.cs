using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using System.IO;
using StupidToDo.Services;

namespace StupidToDo.Forms
{
	public partial class ToDoControl : UserControl
	{
		public Records.ToDo assignedToDo;
		public Guid ControlGUID { get; set; } = Guid.NewGuid();
		private readonly DataAccess dataAccess;
		public ToDoControl()
		{
			InitializeComponent();
			editEnabled.Checked = true;
		}

		public ToDoControl(ref DataAccess _dataAccess)
		{
			dataAccess = _dataAccess;
			InitializeComponent();
			editEnabled.Checked = true;
			SwapLocations();
			ToggleReminderControls();
			assignedToDo = dataAccess.AddNewToDo().Result;
			timer1.Start();
		}

		public ToDoControl(Records.ToDo toDo, ref DataAccess _dataAccess)
		{
			assignedToDo = toDo;
			dataAccess = _dataAccess;
			InitializeComponent();
			if (assignedToDo is not null)
			{
				titleBox.Text = assignedToDo.Title;
				if (!Directory.Exists("./tmp"))
					Directory.CreateDirectory("./tmp");
				try
				{
					string filePath = $"./tmp/{assignedToDo.ID}.rtf";
					File.WriteAllText(filePath, assignedToDo.Body);
					BodyBox.LoadFile(filePath);
					File.Delete(filePath);
				}
				catch { }
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
					remindDate.Value = assignedToDo.RemindDate.Value.Date;
					remindTime.Value = assignedToDo.RemindTime.Value;
				}
				if (assignedToDo.Completed)
				{
					CompleteButton.Visible = false;
				}
				ToggleReminderControls();
				DisableEdit();
			}
			else
			{
				editEnabled.Checked = true;
			}
		}

		private void DisableEdit()
		{
			foreach (Control control in Controls)
			{
				if (control is not Label and not Button and not RichTextBox)
				{
					control.Enabled = false;
				}
			}
			SwapLocations();
			timer1.Stop();
			BodyBox.ReadOnly = true;
			editEnabled.Enabled = true;
			BoldBtn.Visible = false;
			ItalicBtn.Visible = false;
			UnderlineBtn.Visible = false;
			ColorBtn.Visible = false;
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
			if (Height == 287)
			{
				Height = 175;
				remindTime.Visible = false;
			}
			else
			{
				Height = 287;
			}
		}

		private void EditEnabled_CheckedChanged(object sender, EventArgs e)
		{
			if (editEnabled.Checked)
			{
				foreach (var control in Controls)
				{
					(control as Control).Enabled = true;
				}
				ToggleReminderControls();
				SwapLocations();
				timer1.Start();
				BodyBox.ReadOnly = false;
				BoldBtn.Visible = true;
				ItalicBtn.Visible = true;
				UnderlineBtn.Visible = true;
				ColorBtn.Visible = true;
			}
			else
			{
				if (!Directory.Exists("./tmp"))
					Directory.CreateDirectory("./tmp");

				string filePath = $"./tmp/{assignedToDo.ID}.rtf";
				BodyBox.SaveFile(filePath);
				assignedToDo.Body = File.ReadAllText(filePath);
				File.Delete(filePath);

				assignedToDo.Title = titleBox.Text;
				assignedToDo.Edited = DateTime.Now;
				assignedToDo.DoReminder = reminderBox.Checked;
				if (reminderBox.Checked)
				{
					if (RepeatBox.Checked)
					{
						assignedToDo.Repeats = RepeatBox.Checked;
						assignedToDo.RepeatOnDay = (DayOfWeek)DayOfWeekBox.SelectedIndex;
						assignedToDo.RepeatEvery = EveryBox.Value;
						assignedToDo.Frequency = (Records.RepeatFrequency)RepeatsOnBox.SelectedIndex;
					}
					assignedToDo.RemindDate = remindDate.Value;
					assignedToDo.RemindTime = remindTime.Value;
				}
				dataAccess.UpdateToDo(assignedToDo);
				DisableEdit();
			}
		}

		private void ToggleRepeatBoxes()
		{
			if (RepeatsOnBox.SelectedIndex == (int)Records.RepeatFrequency.DayOfWeek)
			{
				DayOfWeekBox.Visible = true;
				EveryBox.Visible = false;
				remindTime.Visible = true;
			}
			else if (RepeatsOnBox.SelectedIndex == (int)Records.RepeatFrequency.Daily)
			{
				DayOfWeekBox.Visible = false;
				EveryBox.Visible = true;
				remindTime.Visible = true;
			}
			else
			{
				DayOfWeekBox.Visible = false;
				EveryBox.Visible = true;
				remindTime.Visible = false;
			}
		}

		private void RepeatsOnBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			ToggleRepeatBoxes();
		}

		private void DeleteBtn_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("Are you sure you want to delete this task?", "StupidToDo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
			{
				(Parent.Parent as MainForm).RemoveToDo(ControlGUID);
			}
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
			if (RepeatBox.Checked)
			{
				everyLabel.Visible = true;
				remindDate.Visible = false;
				remindTime.Visible = false;
				RepeatsOnBox.Visible = true;
				DayOfWeekBox.Visible = true;
				EveryBox.Visible = true;
				CompleteButton.Visible = false;
				ToggleRepeatBoxes();
			}
			else
			{
				everyLabel.Visible = false;
				remindDate.Visible = true;
				remindTime.Visible = true;
				RepeatsOnBox.Visible = false;
				DayOfWeekBox.Visible = false;
				EveryBox.Visible = false;
				if (!assignedToDo.Completed)
				{
					CompleteButton.Visible = true;
				}
			}
		}

		private void ColorBtn_Click(object sender, EventArgs e)
		{
			ColorPicker.ShowDialog();
			BodyBox.SelectionColor = ColorPicker.Color;
		}

		private void BoldBtn_Click(object sender, EventArgs e)
		{
			ToggleBold();
		}

		private void ToggleBold()
		{
			if (BodyBox.SelectionFont.Bold)
			{
				FontStyle newStyle = FontStyle.Regular;
				if (BodyBox.SelectionFont.Italic)
					newStyle = FontStyle.Italic;
				if (BodyBox.SelectionFont.Underline)
					newStyle |= FontStyle.Underline;

				BodyBox.SelectionFont = new Font(BodyBox.SelectionFont, newStyle);
			}
			else
			{
				FontStyle newStyle = FontStyle.Bold;
				if (BodyBox.SelectionFont.Italic)
					newStyle |= FontStyle.Italic;
				if (BodyBox.SelectionFont.Underline)
					newStyle |= FontStyle.Underline;

				BodyBox.SelectionFont = new Font(BodyBox.SelectionFont, newStyle);
			}
		}

		private void ItalicBtn_Click(object sender, EventArgs e)
		{
			ToggleItalic();
		}

		private void ToggleItalic()
		{
			if (BodyBox.SelectionFont.Italic)
			{
				FontStyle newStyle = FontStyle.Regular;
				if (BodyBox.SelectionFont.Bold)
					newStyle = FontStyle.Bold;
				if (BodyBox.SelectionFont.Underline)
					newStyle |= FontStyle.Underline;

				BodyBox.SelectionFont = new Font(BodyBox.SelectionFont, newStyle);
			}
			else
			{
				FontStyle newStyle = FontStyle.Italic;
				if (BodyBox.SelectionFont.Bold)
					newStyle |= FontStyle.Bold;
				if (BodyBox.SelectionFont.Underline)
					newStyle |= FontStyle.Underline;

				BodyBox.SelectionFont = new Font(BodyBox.SelectionFont, newStyle);
			}
		}

		private void UnderlineBtn_Click(object sender, EventArgs e)
		{
			ToggleUnderline();
		}

		public void ToggleUnderline()
		{
			if (BodyBox.SelectionFont.Underline)
			{
				FontStyle newStyle = FontStyle.Regular;
				if (BodyBox.SelectionFont.Bold)
					newStyle = FontStyle.Bold;
				if (BodyBox.SelectionFont.Italic)
					newStyle |= FontStyle.Italic;

				BodyBox.SelectionFont = new Font(BodyBox.SelectionFont, newStyle);
			}
			else
			{
				FontStyle newStyle = FontStyle.Underline;
				if (BodyBox.SelectionFont.Bold)
					newStyle |= FontStyle.Bold;
				if (BodyBox.SelectionFont.Underline)
					newStyle |= FontStyle.Underline;

				BodyBox.SelectionFont = new Font(BodyBox.SelectionFont, newStyle);
			}
		}

		private void BodyBox_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.Control)
			{
				switch (e.KeyCode)
				{
					case Keys.B:
						ToggleBold();
						break;
					case Keys.I:
						ToggleItalic();
						break;
					case Keys.U:
						ToggleUnderline();
						break;
				}
			}
		}

		private void Timer1_Tick(object sender, EventArgs e)
		{
			if (BodyBox.SelectionFont.Bold)
				BoldBtn.BackColor = SystemColors.ControlDark;
			else
				BoldBtn.BackColor = SystemColors.Control;

			if (BodyBox.SelectionFont.Italic)
				ItalicBtn.BackColor = SystemColors.ControlDark;
			else
				ItalicBtn.BackColor = SystemColors.Control;

			if (BodyBox.SelectionFont.Underline)
				UnderlineBtn.BackColor = SystemColors.ControlDark;
			else
				UnderlineBtn.BackColor = SystemColors.Control;

			ColorBtn.BackColor = BodyBox.SelectionColor;
			if (ColorBtn.BackColor.R * 0.2126 + ColorBtn.BackColor.G * 0.7152 + ColorBtn.BackColor.B * 0.0722 > 255 / 2)
			{
				ColorBtn.IconColor = Color.Black;
				BodyBox.SelectionBackColor = Color.Black;
			}
			else
			{
				ColorBtn.IconColor = Color.White;
				BodyBox.SelectionBackColor = SystemColors.Control;
			}
		}

		private void BodyBox_LinkClicked(object sender, LinkClickedEventArgs e)
		{
			string url = e.LinkText.Replace("&", "^&");
			System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo("cmd", $"/c start {url}") { CreateNoWindow = true });
		}

		private void CompleteButton_Click(object sender, EventArgs e)
		{
			assignedToDo.Completed = true;
			CompleteButton.Visible = false;
			dataAccess.UpdateToDo(assignedToDo);
			if (!Config.ShowCompleted)
				(Parent.Parent as MainForm).RemoveToDo(ControlGUID, false);
		}
	}
}
