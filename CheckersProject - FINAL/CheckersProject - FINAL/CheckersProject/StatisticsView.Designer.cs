namespace CheckersProject
{
    partial class StatisticsView
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
            this.BPlayers = new System.Windows.Forms.Button();
            this.BCity = new System.Windows.Forms.Button();
            this.BWinChart = new System.Windows.Forms.Button();
            this.BPlayersPGame = new System.Windows.Forms.Button();
            this.BGamePPlayer = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.PlayerDataGridView = new System.Windows.Forms.DataGridView();
            this.playerIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.playerFirstNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.playerLastNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.playerCellNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.playerCityDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.playerStreetDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.playerHouseNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.playerRegDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.playerEmailDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.playerWinsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.playerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gameBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.PlayerComboBox = new System.Windows.Forms.ComboBox();
            this.GameComboBox = new System.Windows.Forms.ComboBox();
            this.GamePPlyrBox = new System.Windows.Forms.ComboBox();
            this.GameDataGridView = new System.Windows.Forms.DataGridView();
            this.gameIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gameBoardSizeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gameDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gameIsSinglePlayerDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.PlayerDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.playerBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gameBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GameDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // BPlayers
            // 
            this.BPlayers.BackColor = System.Drawing.Color.White;
            this.BPlayers.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BPlayers.Font = new System.Drawing.Font("Modern No. 20", 14.25F);
            this.BPlayers.Location = new System.Drawing.Point(390, 82);
            this.BPlayers.Name = "BPlayers";
            this.BPlayers.Size = new System.Drawing.Size(170, 31);
            this.BPlayers.TabIndex = 21;
            this.BPlayers.Text = "Search Player";
            this.BPlayers.UseVisualStyleBackColor = false;
            this.BPlayers.Click += new System.EventHandler(this.BPlayers_Click);
            // 
            // BCity
            // 
            this.BCity.BackColor = System.Drawing.Color.Black;
            this.BCity.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BCity.Font = new System.Drawing.Font("Modern No. 20", 14.25F);
            this.BCity.ForeColor = System.Drawing.Color.White;
            this.BCity.Location = new System.Drawing.Point(566, 82);
            this.BCity.Name = "BCity";
            this.BCity.Size = new System.Drawing.Size(170, 31);
            this.BCity.TabIndex = 20;
            this.BCity.Text = "Players per City";
            this.BCity.UseVisualStyleBackColor = false;
            this.BCity.Click += new System.EventHandler(this.BCity_Click);
            // 
            // BWinChart
            // 
            this.BWinChart.BackColor = System.Drawing.Color.White;
            this.BWinChart.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BWinChart.Font = new System.Drawing.Font("Modern No. 20", 14.25F);
            this.BWinChart.Location = new System.Drawing.Point(742, 82);
            this.BWinChart.Name = "BWinChart";
            this.BWinChart.Size = new System.Drawing.Size(170, 31);
            this.BWinChart.TabIndex = 19;
            this.BWinChart.Text = "Win Chart";
            this.BWinChart.UseVisualStyleBackColor = false;
            this.BWinChart.Click += new System.EventHandler(this.BWinChart_Click_1);
            // 
            // BPlayersPGame
            // 
            this.BPlayersPGame.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.BPlayersPGame.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BPlayersPGame.Font = new System.Drawing.Font("Modern No. 20", 14.25F);
            this.BPlayersPGame.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BPlayersPGame.Location = new System.Drawing.Point(214, 82);
            this.BPlayersPGame.Name = "BPlayersPGame";
            this.BPlayersPGame.Size = new System.Drawing.Size(170, 31);
            this.BPlayersPGame.TabIndex = 18;
            this.BPlayersPGame.Text = "Players Per Game";
            this.BPlayersPGame.UseVisualStyleBackColor = false;
            this.BPlayersPGame.Click += new System.EventHandler(this.BPlayersPGame_Click);
            // 
            // BGamePPlayer
            // 
            this.BGamePPlayer.BackColor = System.Drawing.Color.White;
            this.BGamePPlayer.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BGamePPlayer.Font = new System.Drawing.Font("Modern No. 20", 14.25F);
            this.BGamePPlayer.Location = new System.Drawing.Point(38, 82);
            this.BGamePPlayer.Name = "BGamePPlayer";
            this.BGamePPlayer.Size = new System.Drawing.Size(170, 31);
            this.BGamePPlayer.TabIndex = 16;
            this.BGamePPlayer.Text = "Games per Player";
            this.BGamePPlayer.UseVisualStyleBackColor = false;
            this.BGamePPlayer.Click += new System.EventHandler(this.BGamePPlayer_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Monotype Corsiva", 26.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(381, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(143, 43);
            this.label2.TabIndex = 15;
            this.label2.Text = "Statistics";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PlayerDataGridView
            // 
            this.PlayerDataGridView.AllowUserToAddRows = false;
            this.PlayerDataGridView.AllowUserToDeleteRows = false;
            this.PlayerDataGridView.AutoGenerateColumns = false;
            this.PlayerDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.PlayerDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.PlayerDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.playerIDDataGridViewTextBoxColumn,
            this.playerFirstNameDataGridViewTextBoxColumn,
            this.playerLastNameDataGridViewTextBoxColumn,
            this.playerCellNumberDataGridViewTextBoxColumn,
            this.playerCityDataGridViewTextBoxColumn,
            this.playerStreetDataGridViewTextBoxColumn,
            this.playerHouseNumberDataGridViewTextBoxColumn,
            this.playerRegDateDataGridViewTextBoxColumn,
            this.playerEmailDataGridViewTextBoxColumn,
            this.playerWinsDataGridViewTextBoxColumn});
            this.PlayerDataGridView.DataSource = this.playerBindingSource;
            this.PlayerDataGridView.Location = new System.Drawing.Point(3, 179);
            this.PlayerDataGridView.Name = "PlayerDataGridView";
            this.PlayerDataGridView.ReadOnly = true;
            this.PlayerDataGridView.ShowEditingIcon = false;
            this.PlayerDataGridView.Size = new System.Drawing.Size(943, 384);
            this.PlayerDataGridView.TabIndex = 22;
            // 
            // playerIDDataGridViewTextBoxColumn
            // 
            this.playerIDDataGridViewTextBoxColumn.DataPropertyName = "player_ID";
            this.playerIDDataGridViewTextBoxColumn.HeaderText = "player_ID";
            this.playerIDDataGridViewTextBoxColumn.Name = "playerIDDataGridViewTextBoxColumn";
            this.playerIDDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // playerFirstNameDataGridViewTextBoxColumn
            // 
            this.playerFirstNameDataGridViewTextBoxColumn.DataPropertyName = "player_FirstName";
            this.playerFirstNameDataGridViewTextBoxColumn.HeaderText = "player_FirstName";
            this.playerFirstNameDataGridViewTextBoxColumn.Name = "playerFirstNameDataGridViewTextBoxColumn";
            this.playerFirstNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // playerLastNameDataGridViewTextBoxColumn
            // 
            this.playerLastNameDataGridViewTextBoxColumn.DataPropertyName = "player_LastName";
            this.playerLastNameDataGridViewTextBoxColumn.HeaderText = "player_LastName";
            this.playerLastNameDataGridViewTextBoxColumn.Name = "playerLastNameDataGridViewTextBoxColumn";
            this.playerLastNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // playerCellNumberDataGridViewTextBoxColumn
            // 
            this.playerCellNumberDataGridViewTextBoxColumn.DataPropertyName = "player_CellNumber";
            this.playerCellNumberDataGridViewTextBoxColumn.HeaderText = "player_CellNumber";
            this.playerCellNumberDataGridViewTextBoxColumn.Name = "playerCellNumberDataGridViewTextBoxColumn";
            this.playerCellNumberDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // playerCityDataGridViewTextBoxColumn
            // 
            this.playerCityDataGridViewTextBoxColumn.DataPropertyName = "player_City";
            this.playerCityDataGridViewTextBoxColumn.HeaderText = "player_City";
            this.playerCityDataGridViewTextBoxColumn.Name = "playerCityDataGridViewTextBoxColumn";
            this.playerCityDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // playerStreetDataGridViewTextBoxColumn
            // 
            this.playerStreetDataGridViewTextBoxColumn.DataPropertyName = "player_Street";
            this.playerStreetDataGridViewTextBoxColumn.HeaderText = "player_Street";
            this.playerStreetDataGridViewTextBoxColumn.Name = "playerStreetDataGridViewTextBoxColumn";
            this.playerStreetDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // playerHouseNumberDataGridViewTextBoxColumn
            // 
            this.playerHouseNumberDataGridViewTextBoxColumn.DataPropertyName = "player_HouseNumber";
            this.playerHouseNumberDataGridViewTextBoxColumn.HeaderText = "player_HouseNumber";
            this.playerHouseNumberDataGridViewTextBoxColumn.Name = "playerHouseNumberDataGridViewTextBoxColumn";
            this.playerHouseNumberDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // playerRegDateDataGridViewTextBoxColumn
            // 
            this.playerRegDateDataGridViewTextBoxColumn.DataPropertyName = "player_Reg_Date";
            this.playerRegDateDataGridViewTextBoxColumn.HeaderText = "player_Reg_Date";
            this.playerRegDateDataGridViewTextBoxColumn.Name = "playerRegDateDataGridViewTextBoxColumn";
            this.playerRegDateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // playerEmailDataGridViewTextBoxColumn
            // 
            this.playerEmailDataGridViewTextBoxColumn.DataPropertyName = "player_Email";
            this.playerEmailDataGridViewTextBoxColumn.HeaderText = "player_Email";
            this.playerEmailDataGridViewTextBoxColumn.Name = "playerEmailDataGridViewTextBoxColumn";
            this.playerEmailDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // playerWinsDataGridViewTextBoxColumn
            // 
            this.playerWinsDataGridViewTextBoxColumn.DataPropertyName = "player_Wins";
            this.playerWinsDataGridViewTextBoxColumn.HeaderText = "player_Wins";
            this.playerWinsDataGridViewTextBoxColumn.Name = "playerWinsDataGridViewTextBoxColumn";
            this.playerWinsDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // playerBindingSource
            // 
            this.playerBindingSource.DataSource = typeof(CheckersProject.Player);
            // 
            // gameBindingSource
            // 
            this.gameBindingSource.DataSource = typeof(CheckersProject.Game);
            // 
            // PlayerComboBox
            // 
            this.PlayerComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.PlayerComboBox.Font = new System.Drawing.Font("Modern No. 20", 14.25F);
            this.PlayerComboBox.FormattingEnabled = true;
            this.PlayerComboBox.Location = new System.Drawing.Point(38, 135);
            this.PlayerComboBox.Name = "PlayerComboBox";
            this.PlayerComboBox.Size = new System.Drawing.Size(321, 32);
            this.PlayerComboBox.TabIndex = 23;
            this.PlayerComboBox.SelectedIndexChanged += new System.EventHandler(this.PlayerComboBox_SelectedIndexChanged);
            // 
            // GameComboBox
            // 
            this.GameComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.GameComboBox.Font = new System.Drawing.Font("Modern No. 20", 14.25F);
            this.GameComboBox.FormattingEnabled = true;
            this.GameComboBox.Location = new System.Drawing.Point(38, 135);
            this.GameComboBox.Name = "GameComboBox";
            this.GameComboBox.Size = new System.Drawing.Size(321, 32);
            this.GameComboBox.TabIndex = 24;
            this.GameComboBox.SelectedIndexChanged += new System.EventHandler(this.GameComboBox_SelectedIndexChanged);
            // 
            // GamePPlyrBox
            // 
            this.GamePPlyrBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.GamePPlyrBox.Font = new System.Drawing.Font("Modern No. 20", 14.25F);
            this.GamePPlyrBox.FormattingEnabled = true;
            this.GamePPlyrBox.Location = new System.Drawing.Point(39, 136);
            this.GamePPlyrBox.Name = "GamePPlyrBox";
            this.GamePPlyrBox.Size = new System.Drawing.Size(319, 29);
            this.GamePPlyrBox.TabIndex = 25;
            this.GamePPlyrBox.SelectedIndexChanged += new System.EventHandler(this.GamePPlyrBox_SelectedIndexChanged);
            // 
            // GameDataGridView
            // 
            this.GameDataGridView.AllowUserToAddRows = false;
            this.GameDataGridView.AllowUserToDeleteRows = false;
            this.GameDataGridView.AutoGenerateColumns = false;
            this.GameDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.GameDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GameDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.gameIDDataGridViewTextBoxColumn,
            this.gameBoardSizeDataGridViewTextBoxColumn,
            this.gameDateDataGridViewTextBoxColumn,
            this.gameIsSinglePlayerDataGridViewCheckBoxColumn});
            this.GameDataGridView.DataSource = this.gameBindingSource;
            this.GameDataGridView.Location = new System.Drawing.Point(3, 179);
            this.GameDataGridView.Name = "GameDataGridView";
            this.GameDataGridView.ReadOnly = true;
            this.GameDataGridView.ShowEditingIcon = false;
            this.GameDataGridView.Size = new System.Drawing.Size(943, 384);
            this.GameDataGridView.TabIndex = 26;
            // 
            // gameIDDataGridViewTextBoxColumn
            // 
            this.gameIDDataGridViewTextBoxColumn.DataPropertyName = "game_ID";
            this.gameIDDataGridViewTextBoxColumn.HeaderText = "game_ID";
            this.gameIDDataGridViewTextBoxColumn.Name = "gameIDDataGridViewTextBoxColumn";
            this.gameIDDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // gameBoardSizeDataGridViewTextBoxColumn
            // 
            this.gameBoardSizeDataGridViewTextBoxColumn.DataPropertyName = "game_BoardSize";
            this.gameBoardSizeDataGridViewTextBoxColumn.HeaderText = "game_BoardSize";
            this.gameBoardSizeDataGridViewTextBoxColumn.Name = "gameBoardSizeDataGridViewTextBoxColumn";
            this.gameBoardSizeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // gameDateDataGridViewTextBoxColumn
            // 
            this.gameDateDataGridViewTextBoxColumn.DataPropertyName = "game_Date";
            this.gameDateDataGridViewTextBoxColumn.HeaderText = "game_Date";
            this.gameDateDataGridViewTextBoxColumn.Name = "gameDateDataGridViewTextBoxColumn";
            this.gameDateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // gameIsSinglePlayerDataGridViewCheckBoxColumn
            // 
            this.gameIsSinglePlayerDataGridViewCheckBoxColumn.DataPropertyName = "game_IsSinglePlayer";
            this.gameIsSinglePlayerDataGridViewCheckBoxColumn.HeaderText = "game_IsSinglePlayer";
            this.gameIsSinglePlayerDataGridViewCheckBoxColumn.Name = "gameIsSinglePlayerDataGridViewCheckBoxColumn";
            this.gameIsSinglePlayerDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // StatisticsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Crimson;
            this.ClientSize = new System.Drawing.Size(948, 559);
            this.Controls.Add(this.GameDataGridView);
            this.Controls.Add(this.GamePPlyrBox);
            this.Controls.Add(this.GameComboBox);
            this.Controls.Add(this.PlayerComboBox);
            this.Controls.Add(this.PlayerDataGridView);
            this.Controls.Add(this.BPlayers);
            this.Controls.Add(this.BCity);
            this.Controls.Add(this.BWinChart);
            this.Controls.Add(this.BPlayersPGame);
            this.Controls.Add(this.BGamePPlayer);
            this.Controls.Add(this.label2);
            this.Name = "StatisticsView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Statistics";
            ((System.ComponentModel.ISupportInitialize)(this.PlayerDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.playerBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gameBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GameDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BPlayers;
        private System.Windows.Forms.Button BCity;
        private System.Windows.Forms.Button BWinChart;
        private System.Windows.Forms.Button BPlayersPGame;
        private System.Windows.Forms.Button BGamePPlayer;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.BindingSource gameBindingSource;
        private System.Windows.Forms.DataGridView PlayerDataGridView;
        private System.Windows.Forms.BindingSource playerBindingSource;
        private System.Windows.Forms.ComboBox PlayerComboBox;
        private System.Windows.Forms.ComboBox GameComboBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn playerIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn playerFirstNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn playerLastNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn playerCellNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn playerCityDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn playerStreetDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn playerHouseNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn playerRegDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn playerEmailDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn playerWinsDataGridViewTextBoxColumn;
        private System.Windows.Forms.ComboBox GamePPlyrBox;
        private System.Windows.Forms.DataGridView GameDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn gameIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn gameBoardSizeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn gameDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn gameIsSinglePlayerDataGridViewCheckBoxColumn;

    }
}