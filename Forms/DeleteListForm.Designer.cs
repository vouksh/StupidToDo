
namespace StupidToDo.Forms
{
	partial class DeleteListForm
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
			this.label1 = new System.Windows.Forms.Label();
			this.YesBtn = new System.Windows.Forms.Button();
			this.NoBtn = new System.Windows.Forms.Button();
			this.MigrateCheckBox = new System.Windows.Forms.CheckBox();
			this.NewListBox = new System.Windows.Forms.ComboBox();
			this.NewListLabel = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(27, 28);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(243, 15);
			this.label1.TabIndex = 0;
			this.label1.Text = "Are you sure that you want to delete this list?";
			// 
			// YesBtn
			// 
			this.YesBtn.Location = new System.Drawing.Point(27, 111);
			this.YesBtn.Name = "YesBtn";
			this.YesBtn.Size = new System.Drawing.Size(76, 45);
			this.YesBtn.TabIndex = 1;
			this.YesBtn.Text = "Yes";
			this.YesBtn.UseVisualStyleBackColor = true;
			this.YesBtn.Click += new System.EventHandler(this.YesBtn_Click);
			// 
			// NoBtn
			// 
			this.NoBtn.Location = new System.Drawing.Point(190, 111);
			this.NoBtn.Name = "NoBtn";
			this.NoBtn.Size = new System.Drawing.Size(80, 45);
			this.NoBtn.TabIndex = 2;
			this.NoBtn.Text = "No/Cancel";
			this.NoBtn.UseVisualStyleBackColor = true;
			this.NoBtn.Click += new System.EventHandler(this.NoBtn_Click);
			// 
			// MigrateCheckBox
			// 
			this.MigrateCheckBox.AutoSize = true;
			this.MigrateCheckBox.Location = new System.Drawing.Point(32, 46);
			this.MigrateCheckBox.Name = "MigrateCheckBox";
			this.MigrateCheckBox.Size = new System.Drawing.Size(226, 19);
			this.MigrateCheckBox.TabIndex = 3;
			this.MigrateCheckBox.Text = "I want to move items to a different list";
			this.MigrateCheckBox.UseVisualStyleBackColor = true;
			this.MigrateCheckBox.CheckedChanged += new System.EventHandler(this.MigrateCheckBox_CheckedChanged);
			// 
			// NewListBox
			// 
			this.NewListBox.FormattingEnabled = true;
			this.NewListBox.Location = new System.Drawing.Point(90, 71);
			this.NewListBox.Name = "NewListBox";
			this.NewListBox.Size = new System.Drawing.Size(168, 23);
			this.NewListBox.TabIndex = 4;
			this.NewListBox.Visible = false;
			// 
			// NewListLabel
			// 
			this.NewListLabel.AutoSize = true;
			this.NewListLabel.Location = new System.Drawing.Point(32, 74);
			this.NewListLabel.Name = "NewListLabel";
			this.NewListLabel.Size = new System.Drawing.Size(55, 15);
			this.NewListLabel.TabIndex = 5;
			this.NewListLabel.Text = "New List:";
			this.NewListLabel.Visible = false;
			// 
			// DeleteListForm
			// 
			this.AcceptButton = this.YesBtn;
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.NoBtn;
			this.ClientSize = new System.Drawing.Size(299, 168);
			this.Controls.Add(this.NewListLabel);
			this.Controls.Add(this.NewListBox);
			this.Controls.Add(this.MigrateCheckBox);
			this.Controls.Add(this.NoBtn);
			this.Controls.Add(this.YesBtn);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "DeleteListForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Are you sure?";
			this.TopMost = true;
			this.Load += new System.EventHandler(this.DeleteListForm_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button YesBtn;
		private System.Windows.Forms.Button NoBtn;
		private System.Windows.Forms.CheckBox MigrateCheckBox;
		private System.Windows.Forms.ComboBox NewListBox;
		private System.Windows.Forms.Label NewListLabel;
	}
}