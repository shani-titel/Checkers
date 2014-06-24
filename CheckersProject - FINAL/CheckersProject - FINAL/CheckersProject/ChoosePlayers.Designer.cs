namespace CheckersProject
{
    partial class ChoosePlayers
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Pl1Combo = new System.Windows.Forms.ComboBox();
            this.Pl2Combo = new System.Windows.Forms.ComboBox();
            this.playerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DoneBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.playerBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Monotype Corsiva", 27.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(119, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(228, 45);
            this.label1.TabIndex = 12;
            this.label1.Text = "Choose Players";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Modern No. 20", 18F);
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(66, 84);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(95, 25);
            this.label8.TabIndex = 13;
            this.label8.Text = "Player 1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Modern No. 20", 18F);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(301, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 25);
            this.label2.TabIndex = 14;
            this.label2.Text = "Player 2";
            // 
            // Pl1Combo
            // 
            this.Pl1Combo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Pl1Combo.Font = new System.Drawing.Font("Modern No. 20", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Pl1Combo.FormattingEnabled = true;
            this.Pl1Combo.Location = new System.Drawing.Point(26, 125);
            this.Pl1Combo.Name = "Pl1Combo";
            this.Pl1Combo.Size = new System.Drawing.Size(171, 29);
            this.Pl1Combo.TabIndex = 15;
            this.Pl1Combo.SelectedIndexChanged += new System.EventHandler(this.Pl1Combo_SelectedIndexChanged);
            // 
            // Pl2Combo
            // 
            this.Pl2Combo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Pl2Combo.Font = new System.Drawing.Font("Modern No. 20", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Pl2Combo.FormattingEnabled = true;
            this.Pl2Combo.Location = new System.Drawing.Point(262, 125);
            this.Pl2Combo.Name = "Pl2Combo";
            this.Pl2Combo.Size = new System.Drawing.Size(171, 29);
            this.Pl2Combo.TabIndex = 16;
            this.Pl2Combo.SelectedIndexChanged += new System.EventHandler(this.Pl1Combo_SelectedIndexChanged);
            // 
            // playerBindingSource
            // 
            this.playerBindingSource.DataSource = typeof(CheckersProject.Player);
            // 
            // groupBindingSource
            // 
            this.groupBindingSource.DataSource = typeof(CheckersProject.Group);
            // 
            // DoneBtn
            // 
            this.DoneBtn.BackColor = System.Drawing.Color.White;
            this.DoneBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.DoneBtn.Font = new System.Drawing.Font("Modern No. 20", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DoneBtn.Location = new System.Drawing.Point(182, 180);
            this.DoneBtn.Name = "DoneBtn";
            this.DoneBtn.Size = new System.Drawing.Size(96, 39);
            this.DoneBtn.TabIndex = 18;
            this.DoneBtn.Text = "Done";
            this.DoneBtn.UseVisualStyleBackColor = false;
            this.DoneBtn.Click += new System.EventHandler(this.DoneBtn_Click);
            // 
            // ChoosePlayers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Crimson;
            this.ClientSize = new System.Drawing.Size(466, 231);
            this.Controls.Add(this.DoneBtn);
            this.Controls.Add(this.Pl2Combo);
            this.Controls.Add(this.Pl1Combo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ChoosePlayers";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Choose Players";
            this.Load += new System.EventHandler(this.ChoosePlayers_Load);
            ((System.ComponentModel.ISupportInitialize)(this.playerBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox Pl1Combo;
        private System.Windows.Forms.ComboBox Pl2Combo;
        private System.Windows.Forms.BindingSource playerBindingSource;
        private System.Windows.Forms.BindingSource groupBindingSource;
        private System.Windows.Forms.Button DoneBtn;
    }
}