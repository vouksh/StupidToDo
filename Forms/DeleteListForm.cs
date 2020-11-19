using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StupidToDo.Services;

namespace StupidToDo.Forms
{
	public partial class DeleteListForm : Form
	{
		private readonly DataAccess dataAccess;
		public DeleteListForm()
		{
			InitializeComponent();
		}

		public DeleteListForm(ref DataAccess _dataAccess)
		{
			dataAccess = _dataAccess;
			InitializeComponent();
			ToggleCheckbox();
		}
		
		private async void ToggleCheckbox()
		{
			if ((await dataAccess.GetCurrentListItems()).Count == 0)
			{
				MigrateCheckBox.Visible = false;
			}
		}

		private void MigrateCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			if (MigrateCheckBox.Checked)
			{
				NewListLabel.Visible = true;
				NewListBox.Visible = true;
			} else
			{
				NewListBox.Visible = false;
				NewListLabel.Visible = false;
			}
		}

		private async void DeleteListForm_Load(object sender, EventArgs e)
		{
			foreach(var list in await dataAccess.GetLists())
			{
				if(list.ID != Config.SelectedListID)
				{
					NewListBox.Items.Add(list.Name);
				}
			}
			NewListBox.SelectedIndex = 0;
		}

		private async void YesBtn_Click(object sender, EventArgs e)
		{
			if (MigrateCheckBox.Checked)
			{
				int newListID = await dataAccess.GetListID((string)NewListBox.SelectedItem);
				dataAccess.DeleteList(Config.SelectedListID, true, newListID);
				Config.SelectedListID = newListID;
			}
			else
			{
				dataAccess.DeleteList(Config.SelectedListID, false, null);
				dataAccess.SwitchToFirstList();
			}
			Close();
		}

		private void NoBtn_Click(object sender, EventArgs e)
		{
			Close();
		}
	}
}
