namespace CheckersProject
{
    partial class SelectBoardSize
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.ExtendedBoard = new System.Windows.Forms.RadioButton();
            this.SmallBoard = new System.Windows.Forms.RadioButton();
            this.ClassicBoard = new System.Windows.Forms.RadioButton();
            this.OkBtn = new System.Windows.Forms.Button();
            this.PlayerColorLable = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Modern No. 20", 14.25F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(57, 95);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(238, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Please select game board size:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ExtendedBoard);
            this.panel1.Controls.Add(this.SmallBoard);
            this.panel1.Controls.Add(this.ClassicBoard);
            this.panel1.Font = new System.Drawing.Font("Modern No. 20", 14.25F);
            this.panel1.Location = new System.Drawing.Point(73, 133);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(187, 176);
            this.panel1.TabIndex = 1;
            // 
            // ExtendedBoard
            // 
            this.ExtendedBoard.AutoSize = true;
            this.ExtendedBoard.Location = new System.Drawing.Point(22, 110);
            this.ExtendedBoard.Name = "ExtendedBoard";
            this.ExtendedBoard.Size = new System.Drawing.Size(160, 25);
            this.ExtendedBoard.TabIndex = 2;
            this.ExtendedBoard.Text = "Extended 10 x 10";
            this.ExtendedBoard.UseVisualStyleBackColor = true;
            // 
            // SmallBoard
            // 
            this.SmallBoard.AutoSize = true;
            this.SmallBoard.Location = new System.Drawing.Point(22, 31);
            this.SmallBoard.Name = "SmallBoard";
            this.SmallBoard.Size = new System.Drawing.Size(115, 25);
            this.SmallBoard.TabIndex = 1;
            this.SmallBoard.Text = "Small 4 x 4";
            this.SmallBoard.UseVisualStyleBackColor = true;
            // 
            // ClassicBoard
            // 
            this.ClassicBoard.AutoSize = true;
            this.ClassicBoard.Checked = true;
            this.ClassicBoard.Location = new System.Drawing.Point(22, 72);
            this.ClassicBoard.Name = "ClassicBoard";
            this.ClassicBoard.Size = new System.Drawing.Size(123, 25);
            this.ClassicBoard.TabIndex = 0;
            this.ClassicBoard.TabStop = true;
            this.ClassicBoard.Text = "Classic 8 x 8";
            this.ClassicBoard.UseVisualStyleBackColor = true;
            // 
            // OkBtn
            // 
            this.OkBtn.BackColor = System.Drawing.Color.White;
            this.OkBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.OkBtn.Font = new System.Drawing.Font("Modern No. 20", 14.25F);
            this.OkBtn.Location = new System.Drawing.Point(132, 327);
            this.OkBtn.Name = "OkBtn";
            this.OkBtn.Size = new System.Drawing.Size(69, 32);
            this.OkBtn.TabIndex = 2;
            this.OkBtn.Text = "OK";
            this.OkBtn.UseVisualStyleBackColor = false;
            this.OkBtn.Click += new System.EventHandler(this.OkBtn_Click);
            // 
            // PlayerColorLable
            // 
            this.PlayerColorLable.AutoSize = true;
            this.PlayerColorLable.Font = new System.Drawing.Font("Monotype Corsiva", 26.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PlayerColorLable.Location = new System.Drawing.Point(87, 26);
            this.PlayerColorLable.Name = "PlayerColorLable";
            this.PlayerColorLable.Size = new System.Drawing.Size(163, 43);
            this.PlayerColorLable.TabIndex = 6;
            this.PlayerColorLable.Text = "Board Size";
            // 
            // SelectBoardSize
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Crimson;
            this.ClientSize = new System.Drawing.Size(354, 371);
            this.Controls.Add(this.PlayerColorLable);
            this.Controls.Add(this.OkBtn);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "SelectBoardSize";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Select Board Size";
            this.Load += new System.EventHandler(this.SelectBoardSize_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton ExtendedBoard;
        private System.Windows.Forms.RadioButton SmallBoard;
        private System.Windows.Forms.RadioButton ClassicBoard;
        private System.Windows.Forms.Button OkBtn;
        private System.Windows.Forms.Label PlayerColorLable;
    }
}