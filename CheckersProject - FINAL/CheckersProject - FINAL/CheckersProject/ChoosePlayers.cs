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
    public partial class ChoosePlayers : Form
    {
        CheckersDataClassesDataContext db = new CheckersDataClassesDataContext();
        bool isSinglePlayerMode;
        internal bool ifChose;
        internal bool isComputerSmart;
        internal int player1_ID;
        internal int player2_ID;
        internal int group1_ID;
        internal int group2_ID;

        public ChoosePlayers(bool IsSinglePlayerMode)
        {
            InitializeComponent();
            playerBindingSource.DataSource = db.Players; //link for comboBoxes
            groupBindingSource.DataSource = db.Groups;
            this.isSinglePlayerMode = IsSinglePlayerMode;
            ifChose = false;
        }

        private void ChoosePlayers_Load(object sender, EventArgs e)
        {
            ifChose = false;
            if (isSinglePlayerMode)
                label2.Text = "Computer";
            else
                label2.Text = "Player2";
            Initialize_Combos();
        }

        private void Pl1Combo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (((ComboBox)sender).SelectedItem.ToString() == "New Player")
            {
                //register player
                using (RegisterPlayers register = new RegisterPlayers())
                {
                    register.ShowDialog();
                }
                Initialize_Combos();
            }
            else if (((ComboBox)sender).SelectedItem.ToString() == "New Group")
            {
                //register group
                using (RegisterGroups register = new RegisterGroups())
                {
                    register.ShowDialog();
                }
                Initialize_Combos();
            }
            
        }

        private void DoneBtn_Click(object sender, EventArgs e)
        {
            bool valid = true; 

            //verify valid input
            if (Pl1Combo.SelectedItem != null && Pl2Combo.SelectedItem != null && Pl1Combo.SelectedItem.ToString() != Pl2Combo.SelectedItem.ToString() )
            {
                ifChose = true;
                if (Pl2Combo.SelectedItem.ToString() == "Easy")
                    isComputerSmart = false;
                else if (Pl2Combo.SelectedItem.ToString() == "Hard")
                    isComputerSmart = true;

                if (!SaveGroup(out group1_ID, Pl1Combo)) //try to save a group
                    SavePlayer(out player1_ID, Pl1Combo); //not group -> save player
                if (!isSinglePlayerMode) //multiplayer mode
                {
                    if (!SaveGroup(out group2_ID, Pl2Combo))
                        SavePlayer(out player2_ID, Pl2Combo);
                    
                    valid = CheckOpponents();
                }

                if (valid)
                    this.Close();
                else
                    NotifyNotValid();
            }
            else
                NotifyNotValid();
        }

        private void NotifyNotValid()
        {
            MessageBox.Show("Players not Valid!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private bool CheckOpponents()
        {
            //case: 1 group, 1 player
            if (group1_ID == 0 || group2_ID == 0)
            {
                //side1Players contains all players in chosen group
                var side1Players =
                    from pig in db.PlayersInGroups
                    where (group1_ID != 0 && pig.playerInGroup_GroupID == group1_ID)
                        || (group2_ID != 0 && pig.playerInGroup_GroupID == group2_ID)
                    select pig.playerInGroup_PlayerID;

                if (player1_ID != 0 && side1Players.Contains(player1_ID)) //not valid
                    return false;
                if (player2_ID != 0 && side1Players.Contains(player2_ID)) //not valid
                    return false;
            }

            //case: 2 groups
            else
            {
                var side1Players =
                    from pig in db.PlayersInGroups
                    where pig.playerInGroup_GroupID == group1_ID
                    select pig.playerInGroup_PlayerID;

                var side2Players =
                    from pig in db.PlayersInGroups
                    where pig.playerInGroup_GroupID == group2_ID && group2_ID != 0
                    select pig.playerInGroup_PlayerID;

                foreach (var player in side1Players) //if player from g1 is in g2
                {
                    if (side2Players.Contains(player))
                        return false;
                }
                foreach (var player in side2Players) //if player from g2 is in g1
                {
                    if (side1Players.Contains(player))
                        return false;
                }
            }
            return true;

        }

        private bool SavePlayer(out int player, ComboBox combo)
        {
            string selectedPlayer = combo.SelectedItem.ToString();
            string[] selectedPlayerNames = selectedPlayer.Split(' ');

            var pl_ID =
                from p in db.Players
                where (p.player_FirstName == selectedPlayerNames[0])
                    && (p.player_LastName == selectedPlayerNames[1])
                select p.player_ID;

            if (pl_ID.Count() != 0)
            {
                player = pl_ID.First();
                return true;
            }
            else
            {
                player = 0;
                return false;
            }
        }

        private bool SaveGroup(out int group_res, ComboBox combo)
        {
            var gr_ID =
                from g in db.Groups
                where g.group_Name == combo.SelectedItem.ToString()
                select g.group_ID;

            if (gr_ID.Count() != 0)
            {
                group_res = gr_ID.First();
                var check_empty =
                    from pig in db.PlayersInGroups
                    where pig.playerInGroup_GroupID == gr_ID.First()
                    select pig;
                if (check_empty.Count() > 0)
                    return true;
                else
                {
                    group_res = 0;
                    return false;
                }
            }
            else
            {
                group_res = 0;
                return false;
            }
        }

        private void Initialize_Combos()
        {
            Pl1Combo.Items.Clear();
            Pl2Combo.Items.Clear();
            var groups =
                from g in db.Groups
                where g.group_Name != "None"
                select g.group_Name;
            var players =
                from p in db.Players
                where p.player_FirstName != "None"
                select p.player_FirstName + " " + p.player_LastName;

            Pl1Combo.Items.Add("New Player");
            Pl1Combo.Items.Add("New Group");

            Pl1Combo.Items.AddRange(players.ToArray());
            Pl1Combo.Items.AddRange(groups.ToArray());
            if (!isSinglePlayerMode)//multi mode
            {
                Pl2Combo.Items.Add("New Player");
                Pl2Combo.Items.Add("New Group");
                Pl2Combo.Items.AddRange(players.ToArray());
                Pl2Combo.Items.AddRange(groups.ToArray());
            }
            else //computer mode
            {
                Pl2Combo.Items.Add("Easy");
                Pl2Combo.Items.Add("Hard");
            }
        }
    }
}
