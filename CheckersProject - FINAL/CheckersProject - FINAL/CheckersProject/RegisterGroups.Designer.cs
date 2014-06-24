namespace CheckersProject
{
    partial class RegisterGroups
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
            this.PlayerColorLable = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.DoneBtn = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.MembersBox = new System.Windows.Forms.CheckedListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.GroupNameTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // PlayerColorLable
            // 
            this.PlayerColorLable.AutoSize = true;
            this.PlayerColorLable.Font = new System.Drawing.Font("Monotype Corsiva", 26.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PlayerColorLable.Location = new System.Drawing.Point(123, 9);
            this.PlayerColorLable.Name = "PlayerColorLable";
            this.PlayerColorLable.Size = new System.Drawing.Size(174, 43);
            this.PlayerColorLable.TabIndex = 9;
            this.PlayerColorLable.Text = "New Group";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(27, 454);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(349, 24);
            this.label8.TabIndex = 8;
            this.label8.Text = "*You must enter group name (one word)";
            // 
            // DoneBtn
            // 
            this.DoneBtn.BackColor = System.Drawing.Color.White;
            this.DoneBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.DoneBtn.Font = new System.Drawing.Font("Modern No. 20", 14.25F);
            this.DoneBtn.Location = new System.Drawing.Point(175, 493);
            this.DoneBtn.Name = "DoneBtn";
            this.DoneBtn.Size = new System.Drawing.Size(96, 39);
            this.DoneBtn.TabIndex = 7;
            this.DoneBtn.Text = "Done";
            this.DoneBtn.UseVisualStyleBackColor = false;
            this.DoneBtn.Click += new System.EventHandler(this.DoneBtn_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.MembersBox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.GroupNameTextBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.groupBox1.Location = new System.Drawing.Point(31, 55);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(345, 384);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            // 
            // MembersBox
            // 
            this.MembersBox.FormattingEnabled = true;
            this.MembersBox.Location = new System.Drawing.Point(148, 110);
            this.MembersBox.Name = "MembersBox";
            this.MembersBox.Size = new System.Drawing.Size(165, 220);
            this.MembersBox.TabIndex = 18;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 106);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 24);
            this.label2.TabIndex = 17;
            this.label2.Text = "Add Players:";
            // 
            // GroupNameTextBox
            // 
            this.GroupNameTextBox.Location = new System.Drawing.Point(146, 40);
            this.GroupNameTextBox.Name = "GroupNameTextBox";
            this.GroupNameTextBox.Size = new System.Drawing.Size(168, 29);
            this.GroupNameTextBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Group Name: *";
            // 
            // RegisterGroups
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Crimson;
            this.ClientSize = new System.Drawing.Size(430, 547);
            this.Controls.Add(this.PlayerColorLable);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.DoneBtn);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "RegisterGroups";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Register New Group";
            this.Load += new System.EventHandler(this.RegisterGroups_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label PlayerColorLable;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button DoneBtn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox GroupNameTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckedListBox MembersBox;
        private System.Windows.Forms.Label label2;
    }
}