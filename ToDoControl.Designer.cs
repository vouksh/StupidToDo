
namespace StupidToDo
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
			this.editEnabled = new System.Windows.Forms.CheckBox();
			this.label1 = new System.Windows.Forms.Label();
			this.titleBox = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.BodyBox = new System.Windows.Forms.TextBox();
			this.remindDate = new System.Windows.Forms.DateTimePicker();
			this.reminderBox = new System.Windows.Forms.CheckBox();
			this.CompleteButton = new System.Windows.Forms.Button();
			this.remindTime = new System.Windows.Forms.DateTimePicker();
			this.RepeatBox = new System.Windows.Forms.CheckBox();
			this.RepeatsOnBox = new System.Windows.Forms.ComboBox();
			this.DayOfWeekBox = new System.Windows.Forms.ComboBox();
			this.EveryBox = new System.Windows.Forms.NumericUpDown();
			this.label3 = new System.Windows.Forms.Label();
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
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(8, 45);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(34, 15);
			this.label2.TabIndex = 3;
			this.label2.Text = "Body";
			// 
			// BodyBox
			// 
			this.BodyBox.AcceptsReturn = true;
			this.BodyBox.Location = new System.Drawing.Point(48, 45);
			this.BodyBox.Multiline = true;
			this.BodyBox.Name = "BodyBox";
			this.BodyBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.BodyBox.Size = new System.Drawing.Size(276, 98);
			this.BodyBox.TabIndex = 4;
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
			// 
			// CompleteButton
			// 
			this.CompleteButton.Location = new System.Drawing.Point(89, 255);
			this.CompleteButton.Name = "CompleteButton";
			this.CompleteButton.Size = new System.Drawing.Size(75, 23);
			this.CompleteButton.TabIndex = 7;
			this.CompleteButton.Text = "Completed";
			this.CompleteButton.UseVisualStyleBackColor = true;
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
			// 
			// RepeatsOnBox
			// 
			this.RepeatsOnBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.RepeatsOnBox.FormattingEnabled = true;
			this.RepeatsOnBox.Items.AddRange(new object[] {
            "Day Of Week",
            "Weeks",
            "Days",
            "Hours"});
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
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(11, 214);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(35, 15);
			this.label3.TabIndex = 13;
			this.label3.Text = "Every";
			// 
			// ToDoControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.Controls.Add(this.label3);
			this.Controls.Add(this.EveryBox);
			this.Controls.Add(this.DayOfWeekBox);
			this.Controls.Add(this.RepeatsOnBox);
			this.Controls.Add(this.RepeatBox);
			this.Controls.Add(this.remindTime);
			this.Controls.Add(this.CompleteButton);
			this.Controls.Add(this.reminderBox);
			this.Controls.Add(this.remindDate);
			this.Controls.Add(this.BodyBox);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.titleBox);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.editEnabled);
			this.Name = "ToDoControl";
			this.Size = new System.Drawing.Size(330, 285);
			((System.ComponentModel.ISupportInitialize)(this.EveryBox)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.CheckBox editEnabled;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox titleBox;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox BodyBox;
		private System.Windows.Forms.DateTimePicker remindDate;
		private System.Windows.Forms.CheckBox reminderBox;
		private System.Windows.Forms.Button CompleteButton;
		private System.Windows.Forms.DateTimePicker remindTime;
		private System.Windows.Forms.CheckBox RepeatBox;
		private System.Windows.Forms.ComboBox RepeatsOnBox;
		private System.Windows.Forms.ComboBox DayOfWeekBox;
		private System.Windows.Forms.NumericUpDown EveryBox;
		private System.Windows.Forms.Label label3;
	}
}
