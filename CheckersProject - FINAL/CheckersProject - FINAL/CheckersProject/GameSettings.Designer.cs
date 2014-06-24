namespace CheckersProject
{
    partial class GameSettings
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
            this.label3 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.Player1ColorBtn = new System.Windows.Forms.Button();
            this.Player2ColorBtn = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.Player2ShapeCombo = new System.Windows.Forms.ComboBox();
            this.Player1ShapeCombo = new System.Windows.Forms.ComboBox();
            this.FilledCheckBox2 = new System.Windows.Forms.CheckBox();
            this.FilledCheckBox1 = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.DragRadio = new System.Windows.Forms.RadioButton();
            this.ClickRadio = new System.Windows.Forms.RadioButton();
            this.panel3 = new System.Windows.Forms.Panel();
            this.FadeRadio = new System.Windows.Forms.RadioButton();
            this.AppearRadio = new System.Windows.Forms.RadioButton();
            this.label6 = new System.Windows.Forms.Label();
            this.DoneBtn = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Monotype Corsiva", 48F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(221, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(223, 79);
            this.label1.TabIndex = 12;
            this.label1.Text = "Settings";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Modern No. 20", 18F);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(468, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 25);
            this.label3.TabIndex = 16;
            this.label3.Text = "Player 2";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Modern No. 20", 18F);
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(224, 21);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(95, 25);
            this.label8.TabIndex = 15;
            this.label8.Text = "Player 1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Modern No. 20", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(9, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(132, 25);
            this.label2.TabIndex = 18;
            this.label2.Text = "Pawn Color:";
            // 
            // Player1ColorBtn
            // 
            this.Player1ColorBtn.BackColor = System.Drawing.Color.Red;
            this.Player1ColorBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Player1ColorBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Player1ColorBtn.Location = new System.Drawing.Point(183, 76);
            this.Player1ColorBtn.Name = "Player1ColorBtn";
            this.Player1ColorBtn.Size = new System.Drawing.Size(170, 31);
            this.Player1ColorBtn.TabIndex = 22;
            this.Player1ColorBtn.UseVisualStyleBackColor = false;
            this.Player1ColorBtn.Click += new System.EventHandler(this.Player1ColorBtn_Click);
            // 
            // Player2ColorBtn
            // 
            this.Player2ColorBtn.BackColor = System.Drawing.Color.White;
            this.Player2ColorBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Player2ColorBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Player2ColorBtn.Location = new System.Drawing.Point(420, 76);
            this.Player2ColorBtn.Name = "Player2ColorBtn";
            this.Player2ColorBtn.Size = new System.Drawing.Size(170, 31);
            this.Player2ColorBtn.TabIndex = 23;
            this.Player2ColorBtn.UseVisualStyleBackColor = false;
            this.Player2ColorBtn.Click += new System.EventHandler(this.Player1ColorBtn_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Modern No. 20", 18F);
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(9, 143);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(139, 25);
            this.label4.TabIndex = 24;
            this.label4.Text = "Pawn Shape:";
            // 
            // Player2ShapeCombo
            // 
            this.Player2ShapeCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Player2ShapeCombo.Font = new System.Drawing.Font("Modern No. 20", 14.25F);
            this.Player2ShapeCombo.FormattingEnabled = true;
            this.Player2ShapeCombo.Location = new System.Drawing.Point(420, 148);
            this.Player2ShapeCombo.Name = "Player2ShapeCombo";
            this.Player2ShapeCombo.Size = new System.Drawing.Size(170, 29);
            this.Player2ShapeCombo.TabIndex = 25;
            // 
            // Player1ShapeCombo
            // 
            this.Player1ShapeCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Player1ShapeCombo.Font = new System.Drawing.Font("Modern No. 20", 14.25F);
            this.Player1ShapeCombo.FormattingEnabled = true;
            this.Player1ShapeCombo.Location = new System.Drawing.Point(183, 148);
            this.Player1ShapeCombo.Name = "Player1ShapeCombo";
            this.Player1ShapeCombo.Size = new System.Drawing.Size(170, 29);
            this.Player1ShapeCombo.TabIndex = 26;
            // 
            // FilledCheckBox2
            // 
            this.FilledCheckBox2.AutoSize = true;
            this.FilledCheckBox2.Checked = true;
            this.FilledCheckBox2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.FilledCheckBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FilledCheckBox2.Location = new System.Drawing.Point(420, 191);
            this.FilledCheckBox2.Name = "FilledCheckBox2";
            this.FilledCheckBox2.Size = new System.Drawing.Size(65, 24);
            this.FilledCheckBox2.TabIndex = 27;
            this.FilledCheckBox2.Text = "Filled";
            this.FilledCheckBox2.UseVisualStyleBackColor = true;
            // 
            // FilledCheckBox1
            // 
            this.FilledCheckBox1.AutoSize = true;
            this.FilledCheckBox1.Checked = true;
            this.FilledCheckBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.FilledCheckBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FilledCheckBox1.Location = new System.Drawing.Point(183, 191);
            this.FilledCheckBox1.Name = "FilledCheckBox1";
            this.FilledCheckBox1.Size = new System.Drawing.Size(65, 24);
            this.FilledCheckBox1.TabIndex = 28;
            this.FilledCheckBox1.Text = "Filled";
            this.FilledCheckBox1.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.FilledCheckBox1);
            this.panel1.Controls.Add(this.FilledCheckBox2);
            this.panel1.Controls.Add(this.Player1ShapeCombo);
            this.panel1.Controls.Add(this.Player2ShapeCombo);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.Player2ColorBtn);
            this.panel1.Controls.Add(this.Player1ColorBtn);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Location = new System.Drawing.Point(22, 129);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(601, 250);
            this.panel1.TabIndex = 29;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(13, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(156, 24);
            this.label5.TabIndex = 30;
            this.label5.Text = "Pawn Movement:";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.DragRadio);
            this.panel2.Controls.Add(this.ClickRadio);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Location = new System.Drawing.Point(18, 410);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(605, 64);
            this.panel2.TabIndex = 31;
            // 
            // DragRadio
            // 
            this.DragRadio.AutoSize = true;
            this.DragRadio.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.DragRadio.Location = new System.Drawing.Point(424, 21);
            this.DragRadio.Name = "DragRadio";
            this.DragRadio.Size = new System.Drawing.Size(62, 24);
            this.DragRadio.TabIndex = 32;
            this.DragRadio.Text = "Drag";
            this.DragRadio.UseVisualStyleBackColor = true;
            // 
            // ClickRadio
            // 
            this.ClickRadio.AutoSize = true;
            this.ClickRadio.Checked = true;
            this.ClickRadio.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.ClickRadio.Location = new System.Drawing.Point(187, 21);
            this.ClickRadio.Name = "ClickRadio";
            this.ClickRadio.Size = new System.Drawing.Size(60, 24);
            this.ClickRadio.TabIndex = 31;
            this.ClickRadio.TabStop = true;
            this.ClickRadio.Text = "Click";
            this.ClickRadio.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.FadeRadio);
            this.panel3.Controls.Add(this.AppearRadio);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Location = new System.Drawing.Point(18, 499);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(605, 64);
            this.panel3.TabIndex = 33;
            // 
            // FadeRadio
            // 
            this.FadeRadio.AutoSize = true;
            this.FadeRadio.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.FadeRadio.Location = new System.Drawing.Point(424, 21);
            this.FadeRadio.Name = "FadeRadio";
            this.FadeRadio.Size = new System.Drawing.Size(64, 24);
            this.FadeRadio.TabIndex = 32;
            this.FadeRadio.Text = "Fade";
            this.FadeRadio.UseVisualStyleBackColor = true;
            // 
            // AppearRadio
            // 
            this.AppearRadio.AutoSize = true;
            this.AppearRadio.Checked = true;
            this.AppearRadio.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.AppearRadio.Location = new System.Drawing.Point(187, 21);
            this.AppearRadio.Name = "AppearRadio";
            this.AppearRadio.Size = new System.Drawing.Size(79, 24);
            this.AppearRadio.TabIndex = 31;
            this.AppearRadio.TabStop = true;
            this.AppearRadio.Text = "Appear";
            this.AppearRadio.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(13, 21);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(151, 24);
            this.label6.TabIndex = 30;
            this.label6.Text = "Pawn Animation:";
            // 
            // DoneBtn
            // 
            this.DoneBtn.BackColor = System.Drawing.Color.White;
            this.DoneBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.DoneBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DoneBtn.Location = new System.Drawing.Point(280, 619);
            this.DoneBtn.Name = "DoneBtn";
            this.DoneBtn.Size = new System.Drawing.Size(96, 39);
            this.DoneBtn.TabIndex = 34;
            this.DoneBtn.Text = "Done";
            this.DoneBtn.UseVisualStyleBackColor = false;
            this.DoneBtn.Click += new System.EventHandler(this.DoneBtn_Click);
            // 
            // GameSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Crimson;
            this.ClientSize = new System.Drawing.Size(645, 670);
            this.Controls.Add(this.DoneBtn);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "GameSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Game Settings";
            this.Load += new System.EventHandler(this.GameSettings_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Button Player1ColorBtn;
        private System.Windows.Forms.Button Player2ColorBtn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox Player2ShapeCombo;
        private System.Windows.Forms.ComboBox Player1ShapeCombo;
        private System.Windows.Forms.CheckBox FilledCheckBox2;
        private System.Windows.Forms.CheckBox FilledCheckBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton DragRadio;
        private System.Windows.Forms.RadioButton ClickRadio;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.RadioButton FadeRadio;
        private System.Windows.Forms.RadioButton AppearRadio;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button DoneBtn;
    }
}