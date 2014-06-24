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
    public partial class ChooseGameForReplay : Form
    {
        CheckersDataClassesDataContext db = new CheckersDataClassesDataContext();
        internal Game gameForReplay = new Game();
        internal bool ifChose;
        public ChooseGameForReplay()
        {
            InitializeComponent();
            ifChose = false;
        }

        private void ChooseGameForReplay_Load(object sender, EventArgs e)
        {
            var values =
                from g in db.Games
                select "ID: " + g.game_ID + " , " + g.game_Date;
            GameCombo.Items.AddRange(values.ToArray());
            ifChose = false;
        }

        private void DoneBtn_Click(object sender, EventArgs e)
        {
            if (GameCombo.SelectedItem != null)
            {
                DialogResult res = MessageBox.Show("Are You Sure?", "Replay Game", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (res == DialogResult.Yes) //player wants to replay
                {
                    ifChose = true;
                    string selectedGame = GameCombo.SelectedItem.ToString();
                    string[] splitId = selectedGame.Split(' ');
                    int ID = Convert.ToInt32(splitId[1]); //isolate id

                    var game =
                        from g in db.Games
                        where g.game_ID == ID
                        select g;

                    gameForReplay = game.First();
                    this.Close();
                }
                else
                    gameForReplay = null;
            }
            else
                gameForReplay = null;
        }
    }
}
