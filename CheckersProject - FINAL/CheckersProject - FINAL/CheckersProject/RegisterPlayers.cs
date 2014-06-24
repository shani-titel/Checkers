using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace CheckersProject
{
    public partial class RegisterPlayers : Form
    {
        CheckersDataClassesDataContext db = new CheckersDataClassesDataContext();
                
        bool allFieldsFilledProperly = false;
       
        public RegisterPlayers()
        {
            InitializeComponent();
            playerBindingSource.DataSource = db.Players;
            InitializeGroupsCombo();
        }

        private void DoneBtn_Click(object sender, EventArgs e)
        {
            if (allFieldsFilledProperly)
            {
                Player newPlayer = new Player(FirstNameTextBox.Text, LastNameTextBox.Text, PhoneTextBox.Text.ToString(), CityTextBox.Text, StreetTextBox.Text, StNumberTextBox.Text, EmailTextBox.Text);
                
                //check if player exists
                var pl_exist =
                    from pl in db.Players
                    where pl.player_FirstName == newPlayer.player_FirstName && 
                        pl.player_LastName == newPlayer.player_LastName && 
                        pl.player_CellNumber == newPlayer.player_CellNumber
                    select pl.player_FirstName; //not all record -> for efficiency

                //insert new player to db
                if (pl_exist.Count() == 0)
                    db.Players.InsertOnSubmit(newPlayer);
                 
                db.SubmitChanges();

                //if chose group - update db
                if (GroupsComboBox.SelectedItem != null)
                {
                    string selectedGroup = GroupsComboBox.SelectedItem.ToString();
                    int ID = selectedGroup[3] - 48;
                    PlayersInGroup pig = new PlayersInGroup(ID, newPlayer.player_ID);
                    db.PlayersInGroups.InsertOnSubmit(pig);
                }
                db.SubmitChanges();
                this.Close();
            }
            else
            {
                MessageBox.Show("Not all Fields are filled properly!", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FirstNameTextBox_TextChanged(object sender, EventArgs e)
        {
            CheckInput();
        }

        bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return true;
            }
            catch
            {
                return false;
            }
        }

        void CheckInput()
        {
            if (FirstNameTextBox.Text != "" && LastNameTextBox.Text != "")
                allFieldsFilledProperly = true;
        }

        private void EmailTextBox_Validating(object sender, CancelEventArgs e)
        {
            if (EmailTextBox.Text!= "" && !IsValidEmail(EmailTextBox.Text))
            {
                MessageBox.Show("Email address is not valid!", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                EmailTextBox.Focus();
            }
        }

        private void RegisterPlayers_FormClosing(object sender, FormClosingEventArgs e)
        {
           //when closing registration- continues to game
        }

        private void RegisterPlayers_Load(object sender, EventArgs e)
        {
            //clear all fields
            StNumberTextBox.Clear();
            StreetTextBox.Clear();
            CityTextBox.Clear();
            PhoneTextBox.Clear();
            EmailTextBox.Clear();
            FirstNameTextBox.Clear();
            LastNameTextBox.Clear();
            InitializeGroupsCombo();
        }
        private void InitializeGroupsCombo()
        {
            GroupsComboBox.Items.Clear();
            var values =
                from g in db.Groups
                where g.group_Name != "None"
                select "ID:" + g.group_ID + ", " + g.group_Name;
            GroupsComboBox.Items.AddRange(values.ToArray());
        }
    }
}
