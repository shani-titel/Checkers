using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CheckersProject
{
    public partial class StatisticsView : Form
    {
        CheckersDataClassesDataContext db = new CheckersDataClassesDataContext();
        InsertDataBox dataBox = new InsertDataBox();

        public StatisticsView()
        {
            InitializeComponent();
            ClearAll();
        }

        private void ClearAll()
        {
            PlayerComboBox.Visible = false;
            GameComboBox.Visible = false;
            GamePPlyrBox.Visible = false;
            PlayerDataGridView.Visible = false;
            GameDataGridView.Visible = false;
        }

        private void BWinChart_Click_1(object sender, EventArgs e)
        {
            ClearAll();
            playerBindingSource.DataSource =
                from p in db.Players
                where p.player_Wins != null
                orderby p.player_Wins descending
                select p;
            PlayerDataGridView.Visible = true;


        }

        private void BCity_Click(object sender, EventArgs e)
        {
            ClearAll();

            //playerBindingSource.DataSource =
            //    from p in db.Players
            //    where p.player_City != null
            //    orderby p.player_City
            //    select p;

            var groups =
            from p in db.Players
            where p.player_City != null
            group p by p.player_City into g
            select g;

            List <Player> players_by_city = new List<Player>();

            foreach (var g in groups)
            {
                foreach (var p in g)
                    players_by_city.Add(p);
            }

            playerBindingSource.DataSource = players_by_city;
            PlayerDataGridView.Visible = true;
        }

        private void BPlayers_Click(object sender, EventArgs e)
        {
            ClearAll();
            InitializePlayerCombo(PlayerComboBox);
        }

        private void PlayerComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedPlayer = PlayerComboBox.SelectedItem.ToString();
            int ID = selectedPlayer[3] - 48;

            playerBindingSource.DataSource =
                from p in db.Players
                where p.player_ID == ID
                select p;

            PlayerDataGridView.Visible = true;            
        }

        private void BPlayersPGame_Click(object sender, EventArgs e)
        {
            ClearAll();
            InitializeGameCombo();
        }

        private void GameComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedGame = GameComboBox.SelectedItem.ToString();
            int ID = selectedGame[3] - 48;

            //playerBindingSource.DataSource =
            //    (from p in db.Players
            //    from pig in db.PlayersInGroups
            //    from s in db.SidesInGames
            //    where (s.side_GameID == ID && s.side_PlayerId != 1 && s.side_PlayerId == p.player_ID) //no group, yes player
            //        || (s.side_GameID == ID && s.side_GroupId != 1 && s.side_GroupId == pig.playerInGroup_GroupID && pig.playerInGroup_PlayerID == p.player_ID)
            //    //yes group, no player
            //    select p).Distinct();
            playerBindingSource.DataSource =
                (from p in db.Players
                 from pig in db.PlayersInGroups
                 from sid in db.SidesInGames
                 where (sid.side_GameID == ID && sid.side_GroupId == pig.playerInGroup_GroupID && pig.playerInGroup_GroupID != 1 && pig.playerInGroup_PlayerID == p.player_ID)
                 || (sid.side_GameID == ID && sid.side_PlayerId == p.player_ID && p.player_ID != 1)
                 select p).Distinct();     

            PlayerDataGridView.Visible = true;           
        }

        private void GamePPlyrBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedPlayer = GamePPlyrBox.SelectedItem.ToString();
            int ID = selectedPlayer[3] - 48;

            gameBindingSource.DataSource =
                (from pig in db.PlayersInGroups
                from s in db.SidesInGames
                from g in db.Games
                where (s.side_PlayerId == ID && s.side_GameID==g.game_ID)
                    || (s.side_GroupId == pig.playerInGroup_GroupID && pig.playerInGroup_PlayerID == ID && s.side_GameID == g.game_ID)
                select g).Distinct();

            GameDataGridView.Visible = true;        
        }

        private void BGamePPlayer_Click(object sender, EventArgs e)
        {
            ClearAll();
            InitializePlayerCombo(GamePPlyrBox);
        }

        private void InitializePlayerCombo(ComboBox combo)
        {
            combo.Visible = true;
            combo.Items.Clear();
            var values =
                from p in db.Players
                where p.player_FirstName != "None" 
                select "ID:" + p.player_ID + ", " + p.player_FirstName + " " + p.player_LastName + ", " + p.player_City;
            combo.Items.AddRange(values.ToArray());
        }

        private void InitializeGameCombo()
        {
            GameComboBox.Visible = true;
            GameComboBox.Items.Clear();
            var values =
                from g in db.Games
                select "ID:" + g.game_ID + ", " + g.game_Date;
            GameComboBox.Items.AddRange(values.ToArray());
        }
    }
}
