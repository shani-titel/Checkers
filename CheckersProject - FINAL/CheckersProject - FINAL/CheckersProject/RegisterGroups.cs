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
    public partial class RegisterGroups : Form
    {
        CheckersDataClassesDataContext db = new CheckersDataClassesDataContext();
        
        public RegisterGroups()
        {
            InitializeComponent();
        }

        private void RegisterGroups_Load(object sender, EventArgs e)
        {
            var players =
                from p in db.Players
                where p.player_FirstName != "None"
                select p.player_FirstName + " " + p.player_LastName;

            MembersBox.Items.AddRange(players.ToArray());
        }

        private void DoneBtn_Click(object sender, EventArgs e)
        {
            if (GroupNameTextBox.Text != "" && !GroupNameTextBox.Text.Contains(" "))
            {
                Group newGroup = new Group(GroupNameTextBox.Text);

                var gr_exist =
                    from g in db.Groups
                    where g.group_Name == newGroup.group_Name
                    select g.group_Name;

                if (gr_exist.Count() == 0)
                {
                    db.Groups.InsertOnSubmit(newGroup);
                    db.SubmitChanges();

                    List<PlayersInGroup> pigList = new List<PlayersInGroup>();

                    foreach (var p in MembersBox.CheckedItems)//insert new record to playersInGroup table, for each player chosen
                    {
                        PlayersInGroup pig = new PlayersInGroup();
                        pig.playerInGroup_GroupID = newGroup.group_ID;
                        var q =
                            from pl in db.Players
                            where p as string == pl.player_FirstName + " " + pl.player_LastName
                            select pl.player_ID;

                        pig.playerInGroup_PlayerID = (int)q.First();
                        pigList.Add(pig);
                        
                    }
                    db.PlayersInGroups.InsertAllOnSubmit(pigList);
                }

                db.SubmitChanges();
                this.Close();
            }
            else
            {
                MessageBox.Show("Not all Fields are filled properly!", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
