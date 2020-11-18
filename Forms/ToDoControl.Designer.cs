
namespace StupidToDo.Forms
{
	partial class ToDoControl
	{
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary> 
		/// Clean up any resources being used.
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.editEnabled = new System.Windows.Forms.CheckBox();
			this.label1 = new System.Windows.Forms.Label();
			this.titleBox = new System.Windows.Forms.TextBox();
			this.remindDate = new System.Windows.Forms.DateTimePicker();
			this.reminderBox = new System.Windows.Forms.CheckBox();
			this.CompleteButton = new System.Windows.Forms.Button();
			this.remindTime = new System.Windows.Forms.DateTimePicker();
			this.RepeatBox = new System.Windows.Forms.CheckBox();
			this.RepeatsOnBox = new System.Windows.Forms.ComboBox();
			this.DayOfWeekBox = new System.Windows.Forms.ComboBox();
			this.EveryBox = new System.Windows.Forms.NumericUpDown();
			this.everyLabel = new System.Windows.Forms.Label();
			this.deleteBtn = new System.Windows.Forms.Button();
			this.BodyBox = new System.Windows.Forms.RichTextBox();
			this.ColorPicker = new System.Windows.Forms.ColorDialog();
			this.BoldBtn = new System.Windows.Forms.Button();
			this.ItalicBtn = new System.Windows.Forms.Button();
			this.UnderlineBtn = new System.Windows.Forms.Button();
			this.ColorBtn = new System.Windows.Forms.Button();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			((System.ComponentModel.ISupportInitialize)(this.EveryBox)).BeginInit();
			this.SuspendLayout();
			// 
			// editEnabled
			// 
			this.editEnabled.AutoSize = true;
			this.editEnabled.Location = new System.Drawing.Point(3, 255);
			this.editEnabled.Name = "editEnabled";
			this.editEnabled.Size = new System.Drawing.Size(80, 19);
			this.editEnabled.TabIndex = 0;
			this.editEnabled.Text = "Edit Mode";
			this.editEnabled.UseVisualStyleBackColor = true;
			this.editEnabled.CheckedChanged += new System.EventHandler(this.EditEnabled_CheckedChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(8, 18);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(29, 15);
			this.label1.TabIndex = 1;
			this.label1.Text = "Title";
			// 
			// titleBox
			// 
			this.titleBox.Location = new System.Drawing.Point(48, 15);
			this.titleBox.Name = "titleBox";
			this.titleBox.PlaceholderText = "Some clever title...";
			this.titleBox.Size = new System.Drawing.Size(276, 23);
			this.titleBox.TabIndex = 2;
			// 
			// remindDate
			// 
			this.remindDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.remindDate.Location = new System.Drawing.Point(100, 149);
			this.remindDate.Name = "remindDate";
			this.remindDate.Size = new System.Drawing.Size(107, 23);
			this.remindDate.TabIndex = 5;
			// 
			// reminderBox
			// 
			this.reminderBox.AutoSize = true;
			this.reminderBox.Location = new System.Drawing.Point(8, 152);
			this.reminderBox.Name = "reminderBox";
			this.reminderBox.Size = new System.Drawing.Size(87, 19);
			this.reminderBox.TabIndex = 6;
			this.reminderBox.Text = "Remind Me";
			this.reminderBox.UseVisualStyleBackColor = true;
			this.reminderBox.CheckedChanged += new System.EventHandler(this.ReminderBox_CheckedChanged);
			// 
			// CompleteButton
			// 
			this.CompleteButton.Location = new System.Drawing.Point(89, 255);
			this.CompleteButton.Name = "CompleteButton";
			this.CompleteButton.Size = new System.Drawing.Size(75, 23);
			this.CompleteButton.TabIndex = 7;
			this.CompleteButton.Text = "Completed";
			this.CompleteButton.UseVisualStyleBackColor = true;
			this.CompleteButton.Click += new System.EventHandler(this.CompleteButton_Click);
			// 
			// remindTime
			// 
			this.remindTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
			this.remindTime.Location = new System.Drawing.Point(219, 149);
			this.remindTime.Name = "remindTime";
			this.remindTime.Size = new System.Drawing.Size(105, 23);
			this.remindTime.TabIndex = 8;
			// 
			// RepeatBox
			// 
			this.RepeatBox.AutoSize = true;
			this.RepeatBox.Location = new System.Drawing.Point(8, 179);
			this.RepeatBox.Name = "RepeatBox";
			this.RepeatBox.Size = new System.Drawing.Size(67, 19);
			this.RepeatBox.TabIndex = 9;
			this.RepeatBox.Text = "Repeats";
			this.RepeatBox.UseVisualStyleBackColor = true;
			this.RepeatBox.CheckedChanged += new System.EventHandler(this.RepeatBox_CheckedChanged);
			// 
			// RepeatsOnBox
			// 
			this.RepeatsOnBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.RepeatsOnBox.FormattingEnabled = true;
			this.RepeatsOnBox.Items.AddRange(new object[] {
            "Day Of Week",
            "Weeks",
            "Days",
            "Hours",
            "Minutes"});
			this.RepeatsOnBox.Location = new System.Drawing.Point(106, 210);
			this.RepeatsOnBox.Name = "RepeatsOnBox";
			this.RepeatsOnBox.Size = new System.Drawing.Size(107, 23);
			this.RepeatsOnBox.TabIndex = 10;
			this.RepeatsOnBox.SelectedIndexChanged += new System.EventHandler(this.RepeatsOnBox_SelectedIndexChanged);
			// 
			// DayOfWeekBox
			// 
			this.DayOfWeekBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.DayOfWeekBox.FormattingEnabled = true;
			this.DayOfWeekBox.Items.AddRange(new object[] {
            "Sunday",
            "Monday",
            "Tuesday",
            "Wednesday",
            "Thursday",
            "Friday",
            "Saturday"});
			this.DayOfWeekBox.Location = new System.Drawing.Point(219, 210);
			this.DayOfWeekBox.Name = "DayOfWeekBox";
			this.DayOfWeekBox.Size = new System.Drawing.Size(105, 23);
			this.DayOfWeekBox.TabIndex = 11;
			// 
			// EveryBox
			// 
			this.EveryBox.Location = new System.Drawing.Point(57, 210);
			this.EveryBox.Name = "EveryBox";
			this.EveryBox.Size = new System.Drawing.Size(38, 23);
			this.EveryBox.TabIndex = 12;
			// 
			// everyLabel
			// 
			this.everyLabel.AutoSize = true;
			this.everyLabel.Location = new System.Drawing.Point(11, 214);
			this.everyLabel.Name = "everyLabel";
			this.everyLabel.Size = new System.Drawing.Size(35, 15);
			this.everyLabel.TabIndex = 13;
			this.everyLabel.Text = "Every";
			// 
			// deleteBtn
			// 
			this.deleteBtn.Location = new System.Drawing.Point(274, 254);
			this.deleteBtn.Name = "deleteBtn";
			this.deleteBtn.Size = new System.Drawing.Size(49, 23);
			this.deleteBtn.TabIndex = 14;
			this.deleteBtn.Text = "Delete";
			this.deleteBtn.UseVisualStyleBackColor = true;
			this.deleteBtn.Click += new System.EventHandler(this.DeleteBtn_Click);
			// 
			// BodyBox
			// 
			this.BodyBox.BackColor = System.Drawing.SystemColors.Window;
			this.BodyBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.BodyBox.Location = new System.Drawing.Point(48, 45);
			this.BodyBox.Name = "BodyBox";
			this.BodyBox.Size = new System.Drawing.Size(275, 96);
			this.BodyBox.TabIndex = 3;
			this.BodyBox.Text = "";
			this.BodyBox.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.BodyBox_LinkClicked);
			this.BodyBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BodyBox_KeyDown);
			// 
			// BoldBtn
			// 
			this.BoldBtn.BackColor = System.Drawing.SystemColors.Control;
			this.BoldBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.BoldBtn.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.BoldBtn.Location = new System.Drawing.Point(11, 45);
			this.BoldBtn.Margin = new System.Windows.Forms.Padding(0);
			this.BoldBtn.Name = "BoldBtn";
			this.BoldBtn.Size = new System.Drawing.Size(26, 23);
			this.BoldBtn.TabIndex = 15;
			this.BoldBtn.Text = "B";
			this.BoldBtn.UseVisualStyleBackColor = false;
			this.BoldBtn.Click += new System.EventHandler(this.BoldBtn_Click);
			// 
			// ItalicBtn
			// 
			this.ItalicBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.ItalicBtn.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
			this.ItalicBtn.Location = new System.Drawing.Point(11, 69);
			this.ItalicBtn.Name = "ItalicBtn";
			this.ItalicBtn.Size = new System.Drawing.Size(26, 23);
			this.ItalicBtn.TabIndex = 16;
			this.ItalicBtn.Text = "I";
			this.ItalicBtn.UseVisualStyleBackColor = true;
			this.ItalicBtn.Click += new System.EventHandler(this.ItalicBtn_Click);
			// 
			// UnderlineBtn
			// 
			this.UnderlineBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.UnderlineBtn.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point);
			this.UnderlineBtn.Location = new System.Drawing.Point(11, 93);
			this.UnderlineBtn.Name = "UnderlineBtn";
			this.UnderlineBtn.Size = new System.Drawing.Size(26, 23);
			this.UnderlineBtn.TabIndex = 17;
			this.UnderlineBtn.Text = "U";
			this.UnderlineBtn.UseVisualStyleBackColor = true;
			this.UnderlineBtn.Click += new System.EventHandler(this.UnderlineBtn_Click);
			// 
			// ColorBtn
			// 
			this.ColorBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.ColorBtn.Location = new System.Drawing.Point(11, 118);
			this.ColorBtn.Name = "ColorBtn";
			this.ColorBtn.Size = new System.Drawing.Size(26, 23);
			this.ColorBtn.TabIndex = 18;
			this.ColorBtn.UseVisualStyleBackColor = true;
			this.ColorBtn.Click += new System.EventHandler(this.ColorBtn_Click);
			// 
			// timer1
			// 
			this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
			// 
			// ToDoControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.ColorBtn);
			this.Controls.Add(this.UnderlineBtn);
			this.Controls.Add(this.ItalicBtn);
			this.Controls.Add(this.BoldBtn);
			this.Controls.Add(this.BodyBox);
			this.Controls.Add(this.deleteBtn);
			this.Controls.Add(this.everyLabel);
			this.Controls.Add(this.EveryBox);
			this.Controls.Add(this.DayOfWeekBox);
			this.Controls.Add(this.RepeatsOnBox);
			this.Controls.Add(this.RepeatBox);
			this.Controls.Add(this.remindTime);
			this.Controls.Add(this.CompleteButton);
			this.Controls.Add(this.reminderBox);
			this.Controls.Add(this.remindDate);
			this.Controls.Add(this.titleBox);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.editEnabled);
			this.Name = "ToDoControl";
			this.Size = new System.Drawing.Size(332, 287);
			((System.ComponentModel.ISupportInitialize)(this.EveryBox)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.CheckBox editEnabled;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox titleBox;
		private System.Windows.Forms.DateTimePicker remindDate;
		private System.Windows.Forms.CheckBox reminderBox;
		private System.Windows.Forms.Button CompleteButton;
		private System.Windows.Forms.DateTimePicker remindTime;
		private System.Windows.Forms.CheckBox RepeatBox;
		private System.Windows.Forms.ComboBox RepeatsOnBox;
		private System.Windows.Forms.ComboBox DayOfWeekBox;
		private System.Windows.Forms.NumericUpDown EveryBox;
		private System.Windows.Forms.Label everyLabel;
		private System.Windows.Forms.Button deleteBtn;
		private System.Windows.Forms.RichTextBox BodyBox;
		private System.Windows.Forms.ColorDialog ColorPicker;
		private System.Windows.Forms.Button BoldBtn;
		private System.Windows.Forms.Button ItalicBtn;
		private System.Windows.Forms.Button UnderlineBtn;
		private System.Windows.Forms.Button ColorBtn;
		private System.Windows.Forms.Timer timer1;
	}
}
