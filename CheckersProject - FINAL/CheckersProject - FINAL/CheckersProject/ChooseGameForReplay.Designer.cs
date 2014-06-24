namespace CheckersProject
{
    partial class ChooseGameForReplay
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
            this.DoneBtn = new System.Windows.Forms.Button();
            this.GameCombo = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Monotype Corsiva", 27.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(103, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(230, 45);
            this.label1.TabIndex = 13;
            this.label1.Text = "Choose a Game";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DoneBtn
            // 
            this.DoneBtn.BackColor = System.Drawing.Color.White;
            this.DoneBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.DoneBtn.Font = new System.Drawing.Font("Modern No. 20", 14.25F);
            this.DoneBtn.Location = new System.Drawing.Point(169, 186);
            this.DoneBtn.Name = "DoneBtn";
            this.DoneBtn.Size = new System.Drawing.Size(96, 39);
            this.DoneBtn.TabIndex = 20;
            this.DoneBtn.Text = "Done";
            this.DoneBtn.UseVisualStyleBackColor = false;
            this.DoneBtn.Click += new System.EventHandler(this.DoneBtn_Click);
            // 
            // GameCombo
            // 
            this.GameCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.GameCombo.Font = new System.Drawing.Font("Modern No. 20", 14.25F);
            this.GameCombo.FormattingEnabled = true;
            this.GameCombo.Location = new System.Drawing.Point(81, 114);
            this.GameCombo.Name = "GameCombo";
            this.GameCombo.Size = new System.Drawing.Size(270, 29);
            this.GameCombo.TabIndex = 19;
            // 
            // ChooseGameForReplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Crimson;
            this.ClientSize = new System.Drawing.Size(434, 237);
            this.Controls.Add(this.DoneBtn);
            this.Controls.Add(this.GameCombo);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ChooseGameForReplay";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Choose Game For Replay";
            this.Load += new System.EventHandler(this.ChooseGameForReplay_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button DoneBtn;
        private System.Windows.Forms.ComboBox GameCombo;

    }
}