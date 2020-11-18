using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StupidToDo.Forms
{
	public partial class ReminderDialog : Form
	{
		private readonly Services.DataAccess dataAccess;
		private readonly Records.ToDo assignedTask;
		public bool Snoozed = false;
		public ReminderDialog()
		{
			InitializeComponent();
		}

		public ReminderDialog(ref Services.DataAccess _dataAccess, Records.ToDo task)
		{
			dataAccess = _dataAccess;
			assignedTask = task;
			InitializeComponent();
		}

		private void ReminderDialog_Load(object sender, EventArgs e)
		{
			if (!Directory.Exists("./tmp"))
				Directory.CreateDirectory("./tmp");
			string filePath = $"./tmp/{assignedTask.ID}.rtf";
			File.WriteAllText(filePath, assignedTask.Body);

			BodyRTF.LoadFile(filePath);
			File.Delete(filePath);
			Text = assignedTask.Title;
			if(assignedTask.Repeats)
			{
				SnoozeBtn.Visible = false;
				CountBox.Visible = false;
				IntervalBox.Visible = false;
				MarkCompleteBtn.Dock = DockStyle.Bottom;
			}
		}

		private void MarkCompleteBtn_Click(object sender, EventArgs e)
		{
			if (!assignedTask.Repeats)
			{
				assignedTask.Completed = true;
			} else
			{
				assignedTask.LastRepeat = DateTime.Now;
			}
			dataAccess.UpdateToDo(assignedTask);
			this.DialogResult = DialogResult.OK;
			Close();
		}

		private void SnoozeBtn_Click(object sender, EventArgs e)
		{
			if(!assignedTask.Repeats)
			{
				switch((string)IntervalBox.SelectedItem)
				{
					case "Minutes":
						assignedTask.RemindTime = assignedTask.RemindTime.Value.AddMinutes(Convert.ToDouble(CountBox.Value));
						break;
					case "Hours":
						assignedTask.RemindTime = assignedTask.RemindTime.Value.AddHours(Convert.ToDouble(CountBox.Value));
						break;
					default:
						MessageBox.Show("Must choose hours or minutes", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
						break;
				}
				dataAccess.UpdateToDo(assignedTask);
			}
			Snoozed = true;
			DialogResult = DialogResult.OK;
			Close();
		}

		private void BodyRTF_LinkClicked(object sender, LinkClickedEventArgs e)
		{
			string url = e.LinkText.Replace("&", "^&");
			System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo("cmd", $"/c start {url}") { CreateNoWindow = true });
		}
	}
}
