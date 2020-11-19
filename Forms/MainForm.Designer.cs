
namespace StupidToDo.Forms
{
	partial class MainForm
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
			this.notifyIconStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.ShowWindowBtn = new FontAwesome.Sharp.IconMenuItem();
			this.ExitStripBtn = new FontAwesome.Sharp.IconMenuItem();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new FontAwesome.Sharp.IconMenuItem();
			this.newItemMenuItem = new FontAwesome.Sharp.IconMenuItem();
			this.DeleteList = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.ExitMenuBtn = new FontAwesome.Sharp.IconMenuItem();
			this.OptionsStripMenu = new FontAwesome.Sharp.IconMenuItem();
			this.ToggleMinimizeToTray = new System.Windows.Forms.ToolStripMenuItem();
			this.ToggleCompletedTasks = new System.Windows.Forms.ToolStripMenuItem();
			this.ToggleListReminders = new System.Windows.Forms.ToolStripMenuItem();
			this.listMenuCollection = new FontAwesome.Sharp.IconMenuItem();
			this.NewListBox = new System.Windows.Forms.ToolStripTextBox();
			this.reminderTimer = new System.Windows.Forms.Timer(this.components);
			this.FlowPanel = new System.Windows.Forms.FlowLayoutPanel();
			this.notifyIconStrip.SuspendLayout();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// notifyIcon
			// 
			this.notifyIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
			this.notifyIcon.ContextMenuStrip = this.notifyIconStrip;
			this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
			this.notifyIcon.Text = "Stupid ToDo";
			this.notifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.NotifyIcon_MouseDoubleClick);
			// 
			// notifyIconStrip
			// 
			this.notifyIconStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ShowWindowBtn,
            this.ExitStripBtn});
			this.notifyIconStrip.Name = "notifyIconStrip";
			this.notifyIconStrip.ShowCheckMargin = true;
			this.notifyIconStrip.ShowImageMargin = false;
			this.notifyIconStrip.Size = new System.Drawing.Size(104, 48);
			// 
			// ShowWindowBtn
			// 
			this.ShowWindowBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.ShowWindowBtn.IconChar = FontAwesome.Sharp.IconChar.WindowRestore;
			this.ShowWindowBtn.IconColor = System.Drawing.Color.Black;
			this.ShowWindowBtn.IconFont = FontAwesome.Sharp.IconFont.Auto;
			this.ShowWindowBtn.Name = "ShowWindowBtn";
			this.ShowWindowBtn.Size = new System.Drawing.Size(103, 22);
			this.ShowWindowBtn.Text = "Show";
			// 
			// ExitStripBtn
			// 
			this.ExitStripBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.ExitStripBtn.IconChar = FontAwesome.Sharp.IconChar.Times;
			this.ExitStripBtn.IconColor = System.Drawing.Color.Red;
			this.ExitStripBtn.IconFont = FontAwesome.Sharp.IconFont.Auto;
			this.ExitStripBtn.Name = "ExitStripBtn";
			this.ExitStripBtn.Size = new System.Drawing.Size(103, 22);
			this.ExitStripBtn.Text = "Exit";
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.OptionsStripMenu,
            this.listMenuCollection});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(337, 24);
			this.menuStrip1.TabIndex = 0;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newItemMenuItem,
            this.DeleteList,
            this.toolStripSeparator3,
            this.ExitMenuBtn});
			this.fileToolStripMenuItem.IconChar = FontAwesome.Sharp.IconChar.Save;
			this.fileToolStripMenuItem.IconColor = System.Drawing.Color.Black;
			this.fileToolStripMenuItem.IconFont = FontAwesome.Sharp.IconFont.Auto;
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
			this.fileToolStripMenuItem.Text = "&File";
			// 
			// newItemMenuItem
			// 
			this.newItemMenuItem.IconChar = FontAwesome.Sharp.IconChar.Plus;
			this.newItemMenuItem.IconColor = System.Drawing.Color.ForestGreen;
			this.newItemMenuItem.IconFont = FontAwesome.Sharp.IconFont.Auto;
			this.newItemMenuItem.Name = "newItemMenuItem";
			this.newItemMenuItem.Size = new System.Drawing.Size(171, 22);
			this.newItemMenuItem.Text = "New Item";
			// 
			// DeleteList
			// 
			this.DeleteList.Name = "DeleteList";
			this.DeleteList.Size = new System.Drawing.Size(171, 22);
			this.DeleteList.Text = "Delete Current List";
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(168, 6);
			// 
			// ExitMenuBtn
			// 
			this.ExitMenuBtn.IconChar = FontAwesome.Sharp.IconChar.Times;
			this.ExitMenuBtn.IconColor = System.Drawing.Color.Red;
			this.ExitMenuBtn.IconFont = FontAwesome.Sharp.IconFont.Auto;
			this.ExitMenuBtn.Name = "ExitMenuBtn";
			this.ExitMenuBtn.Size = new System.Drawing.Size(171, 22);
			this.ExitMenuBtn.Text = "Exit";
			// 
			// OptionsStripMenu
			// 
			this.OptionsStripMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToggleMinimizeToTray,
            this.ToggleCompletedTasks,
            this.ToggleListReminders});
			this.OptionsStripMenu.IconChar = FontAwesome.Sharp.IconChar.Cogs;
			this.OptionsStripMenu.IconColor = System.Drawing.Color.Black;
			this.OptionsStripMenu.IconFont = FontAwesome.Sharp.IconFont.Auto;
			this.OptionsStripMenu.Name = "OptionsStripMenu";
			this.OptionsStripMenu.Size = new System.Drawing.Size(77, 20);
			this.OptionsStripMenu.Text = "Options";
			// 
			// ToggleMinimizeToTray
			// 
			this.ToggleMinimizeToTray.CheckOnClick = true;
			this.ToggleMinimizeToTray.Name = "ToggleMinimizeToTray";
			this.ToggleMinimizeToTray.Size = new System.Drawing.Size(227, 22);
			this.ToggleMinimizeToTray.Text = "Minimize To Tray";
			// 
			// ToggleCompletedTasks
			// 
			this.ToggleCompletedTasks.CheckOnClick = true;
			this.ToggleCompletedTasks.Name = "ToggleCompletedTasks";
			this.ToggleCompletedTasks.Size = new System.Drawing.Size(227, 22);
			this.ToggleCompletedTasks.Text = "Show Completed Tasks";
			// 
			// ToggleListReminders
			// 
			this.ToggleListReminders.CheckOnClick = true;
			this.ToggleListReminders.Name = "ToggleListReminders";
			this.ToggleListReminders.Size = new System.Drawing.Size(227, 22);
			this.ToggleListReminders.Text = "Only Remind For Current List";
			// 
			// listMenuCollection
			// 
			this.listMenuCollection.IconChar = FontAwesome.Sharp.IconChar.ListAlt;
			this.listMenuCollection.IconColor = System.Drawing.Color.Black;
			this.listMenuCollection.IconFont = FontAwesome.Sharp.IconFont.Auto;
			this.listMenuCollection.Name = "listMenuCollection";
			this.listMenuCollection.Size = new System.Drawing.Size(58, 20);
			this.listMenuCollection.Text = "Lists";
			// 
			// NewListBox
			// 
			this.NewListBox.MaxLength = 64;
			this.NewListBox.Name = "NewListBox";
			this.NewListBox.Size = new System.Drawing.Size(100, 23);
			this.NewListBox.ToolTipText = "Type name of new list and press Enter/Return";
			// 
			// reminderTimer
			// 
			this.reminderTimer.Interval = 1000;
			this.reminderTimer.Tick += new System.EventHandler(this.ReminderTimer_Tick);
			// 
			// FlowPanel
			// 
			this.FlowPanel.AutoScroll = true;
			this.FlowPanel.AutoSize = true;
			this.FlowPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.FlowPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.FlowPanel.Location = new System.Drawing.Point(0, 24);
			this.FlowPanel.Name = "FlowPanel";
			this.FlowPanel.Size = new System.Drawing.Size(337, 537);
			this.FlowPanel.TabIndex = 1;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.ClientSize = new System.Drawing.Size(337, 561);
			this.Controls.Add(this.FlowPanel);
			this.Controls.Add(this.menuStrip1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.menuStrip1;
			this.MaximizeBox = false;
			this.MaximumSize = new System.Drawing.Size(378, 600);
			this.MinimumSize = new System.Drawing.Size(353, 600);
			this.Name = "MainForm";
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.Text = "Stupid ToDo";
			this.Load += new System.EventHandler(this.MainForm_Load);
			this.Resize += new System.EventHandler(this.MainForm_Resize);
			this.notifyIconStrip.ResumeLayout(false);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.NotifyIcon notifyIcon;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private FontAwesome.Sharp.IconMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.Timer reminderTimer;
		private System.Windows.Forms.FlowLayoutPanel FlowPanel;
		private System.Windows.Forms.ContextMenuStrip notifyIconStrip;
		private FontAwesome.Sharp.IconMenuItem ShowWindowBtn;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private FontAwesome.Sharp.IconMenuItem OptionsStripMenu;
		private System.Windows.Forms.ToolStripMenuItem ToggleMinimizeToTray;
		private System.Windows.Forms.ToolStripTextBox NewListBox;
		private System.Windows.Forms.ToolStripMenuItem ToggleCompletedTasks;
		private System.Windows.Forms.ToolStripMenuItem DeleteList;
		private System.Windows.Forms.ToolStripMenuItem ToggleListReminders;
		private FontAwesome.Sharp.IconMenuItem newItemMenuItem;
		private FontAwesome.Sharp.IconMenuItem ExitStripBtn;
		private FontAwesome.Sharp.IconMenuItem ExitMenuBtn;
		private FontAwesome.Sharp.IconMenuItem listMenuCollection;
	}
}

