namespace CheckersProject
{
    partial class MainWindow
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
            this.BNewMulti = new System.Windows.Forms.Button();
            this.BExit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.BStatistics = new System.Windows.Forms.Button();
            this.BReplay = new System.Windows.Forms.Button();
            this.BAbout = new System.Windows.Forms.Button();
            this.BNewSingle = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BNewMulti
            // 
            this.BNewMulti.BackColor = System.Drawing.Color.Black;
            this.BNewMulti.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BNewMulti.Font = new System.Drawing.Font("Modern No. 20", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BNewMulti.ForeColor = System.Drawing.Color.White;
            this.BNewMulti.Location = new System.Drawing.Point(97, 197);
            this.BNewMulti.Name = "BNewMulti";
            this.BNewMulti.Size = new System.Drawing.Size(209, 38);
            this.BNewMulti.TabIndex = 13;
            this.BNewMulti.Text = "New Multiplayer Game";
            this.BNewMulti.UseVisualStyleBackColor = false;
            this.BNewMulti.Click += new System.EventHandler(this.BNewMulti_Click);
            // 
            // BExit
            // 
            this.BExit.BackColor = System.Drawing.Color.Black;
            this.BExit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BExit.Font = new System.Drawing.Font("Modern No. 20", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BExit.ForeColor = System.Drawing.Color.White;
            this.BExit.Location = new System.Drawing.Point(97, 427);
            this.BExit.Name = "BExit";
            this.BExit.Size = new System.Drawing.Size(209, 38);
            this.BExit.TabIndex = 12;
            this.BExit.Text = "Exit";
            this.BExit.UseVisualStyleBackColor = false;
            this.BExit.Click += new System.EventHandler(this.BExit_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Monotype Corsiva", 48F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(83, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(236, 79);
            this.label1.TabIndex = 11;
            this.label1.Text = "Checkers";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BStatistics
            // 
            this.BStatistics.BackColor = System.Drawing.Color.Black;
            this.BStatistics.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BStatistics.Font = new System.Drawing.Font("Modern No. 20", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BStatistics.ForeColor = System.Drawing.Color.White;
            this.BStatistics.Location = new System.Drawing.Point(97, 310);
            this.BStatistics.Name = "BStatistics";
            this.BStatistics.Size = new System.Drawing.Size(209, 38);
            this.BStatistics.TabIndex = 10;
            this.BStatistics.Text = "Statistics";
            this.BStatistics.UseVisualStyleBackColor = false;
            this.BStatistics.Click += new System.EventHandler(this.BStatistics_Click);
            // 
            // BReplay
            // 
            this.BReplay.BackColor = System.Drawing.Color.White;
            this.BReplay.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BReplay.Font = new System.Drawing.Font("Modern No. 20", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BReplay.ForeColor = System.Drawing.Color.Black;
            this.BReplay.Location = new System.Drawing.Point(97, 253);
            this.BReplay.Name = "BReplay";
            this.BReplay.Size = new System.Drawing.Size(209, 38);
            this.BReplay.TabIndex = 9;
            this.BReplay.Text = "Replay Game";
            this.BReplay.UseVisualStyleBackColor = false;
            this.BReplay.Click += new System.EventHandler(this.BReplay_Click);
            // 
            // BAbout
            // 
            this.BAbout.BackColor = System.Drawing.Color.White;
            this.BAbout.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BAbout.Font = new System.Drawing.Font("Modern No. 20", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BAbout.ForeColor = System.Drawing.Color.Black;
            this.BAbout.Location = new System.Drawing.Point(97, 368);
            this.BAbout.Name = "BAbout";
            this.BAbout.Size = new System.Drawing.Size(209, 38);
            this.BAbout.TabIndex = 8;
            this.BAbout.Text = "About";
            this.BAbout.UseVisualStyleBackColor = false;
            this.BAbout.Click += new System.EventHandler(this.BAbout_Click);
            // 
            // BNewSingle
            // 
            this.BNewSingle.BackColor = System.Drawing.Color.White;
            this.BNewSingle.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BNewSingle.Font = new System.Drawing.Font("Modern No. 20", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BNewSingle.Location = new System.Drawing.Point(97, 140);
            this.BNewSingle.Name = "BNewSingle";
            this.BNewSingle.Size = new System.Drawing.Size(209, 38);
            this.BNewSingle.TabIndex = 7;
            this.BNewSingle.Text = "New Singleplayer Game";
            this.BNewSingle.UseVisualStyleBackColor = false;
            this.BNewSingle.Click += new System.EventHandler(this.BNewSingle_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Crimson;
            this.ClientSize = new System.Drawing.Size(417, 513);
            this.Controls.Add(this.BNewMulti);
            this.Controls.Add(this.BExit);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BStatistics);
            this.Controls.Add(this.BReplay);
            this.Controls.Add(this.BAbout);
            this.Controls.Add(this.BNewSingle);
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Checkers";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BNewMulti;
        private System.Windows.Forms.Button BExit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BStatistics;
        private System.Windows.Forms.Button BReplay;
        private System.Windows.Forms.Button BAbout;
        private System.Windows.Forms.Button BNewSingle;

    }
}

