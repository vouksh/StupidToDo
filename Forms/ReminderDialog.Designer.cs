
namespace StupidToDo.Forms
{
	partial class ReminderDialog
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

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.BodyRTF = new System.Windows.Forms.RichTextBox();
			this.MarkCompleteBtn = new System.Windows.Forms.Button();
			this.SnoozeBtn = new System.Windows.Forms.Button();
			this.CountBox = new System.Windows.Forms.NumericUpDown();
			this.IntervalBox = new System.Windows.Forms.ComboBox();
			((System.ComponentModel.ISupportInitialize)(this.CountBox)).BeginInit();
			this.SuspendLayout();
			// 
			// BodyRTF
			// 
			this.BodyRTF.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.BodyRTF.Location = new System.Drawing.Point(12, 12);
			this.BodyRTF.Name = "BodyRTF";
			this.BodyRTF.ReadOnly = true;
			this.BodyRTF.Size = new System.Drawing.Size(313, 250);
			this.BodyRTF.TabIndex = 0;
			this.BodyRTF.Text = "";
			this.BodyRTF.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.BodyRTF_LinkClicked);
			// 
			// MarkCompleteBtn
			// 
			this.MarkCompleteBtn.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.MarkCompleteBtn.Location = new System.Drawing.Point(12, 268);
			this.MarkCompleteBtn.Name = "MarkCompleteBtn";
			this.MarkCompleteBtn.Size = new System.Drawing.Size(75, 48);
			this.MarkCompleteBtn.TabIndex = 1;
			this.MarkCompleteBtn.Text = "Mark Completed";
			this.MarkCompleteBtn.UseVisualStyleBackColor = true;
			this.MarkCompleteBtn.Click += new System.EventHandler(this.MarkCompleteBtn_Click);
			// 
			// SnoozeBtn
			// 
			this.SnoozeBtn.Location = new System.Drawing.Point(93, 268);
			this.SnoozeBtn.Name = "SnoozeBtn";
			this.SnoozeBtn.Size = new System.Drawing.Size(73, 47);
			this.SnoozeBtn.TabIndex = 2;
			this.SnoozeBtn.Text = "Snooze For:";
			this.SnoozeBtn.UseVisualStyleBackColor = true;
			this.SnoozeBtn.Click += new System.EventHandler(this.SnoozeBtn_Click);
			// 
			// CountBox
			// 
			this.CountBox.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.CountBox.Location = new System.Drawing.Point(172, 274);
			this.CountBox.Name = "CountBox";
			this.CountBox.Size = new System.Drawing.Size(46, 32);
			this.CountBox.TabIndex = 3;
			// 
			// IntervalBox
			// 
			this.IntervalBox.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.IntervalBox.FormattingEnabled = true;
			this.IntervalBox.Items.AddRange(new object[] {
            "Minutes",
            "Hours"});
			this.IntervalBox.Location = new System.Drawing.Point(224, 274);
			this.IntervalBox.Name = "IntervalBox";
			this.IntervalBox.Size = new System.Drawing.Size(101, 33);
			this.IntervalBox.TabIndex = 4;
			this.IntervalBox.Text = "Minutes";
			// 
			// ReminderDialog
			// 
			this.AcceptButton = this.MarkCompleteBtn;
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.SnoozeBtn;
			this.ClientSize = new System.Drawing.Size(337, 328);
			this.ControlBox = false;
			this.Controls.Add(this.IntervalBox);
			this.Controls.Add(this.CountBox);
			this.Controls.Add(this.SnoozeBtn);
			this.Controls.Add(this.MarkCompleteBtn);
			this.Controls.Add(this.BodyRTF);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "ReminderDialog";
			this.ShowIcon = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "ReminderDialog";
			this.TopMost = true;
			this.Load += new System.EventHandler(this.ReminderDialog_Load);
			((System.ComponentModel.ISupportInitialize)(this.CountBox)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.RichTextBox BodyRTF;
		private System.Windows.Forms.Button MarkCompleteBtn;
		private System.Windows.Forms.Button SnoozeBtn;
		private System.Windows.Forms.NumericUpDown CountBox;
		private System.Windows.Forms.ComboBox IntervalBox;
	}
}