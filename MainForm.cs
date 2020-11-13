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
			FlowPanel.Controls.Add(new Splitter());
			FlowPanel.Controls.Add(new ToDoControl());
		}

		private void ReminderTimer_Tick(object sender, EventArgs e)
		{

		}

		private async void MainForm_Load(object sender, EventArgs e)
		{
			foreach(var list in await dataAccess.GetLists())
			{
				listMenuCollection.DropDownItems.Add(list.Name);
			}
			listMenuCollection.DropDownItemClicked += ListMenuCollection_DropDownItemClicked;
			foreach(var item in await dataAccess.GetCurrentListItems())
			{
				FlowPanel.Controls.Add(new ToDoControl(item));
			}
		}

		private void ListMenuCollection_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
		{
			dataAccess.SwitchList(e.ClickedItem.Text);
		}
	}
}
