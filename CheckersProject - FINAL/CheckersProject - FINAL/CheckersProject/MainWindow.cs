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
    public partial class MainWindow : Form
    {
        bool IsSinglePlayerMode = false;
        SelectBoardSize SelectBoardSizeWindow;
        GameBoard GameBoardWindow;
        ChoosePlayers ChoosePlayersWindow;
        ChooseGameForReplay chooseGameForReplayWindow;
        CheckersDataClassesDataContext db = new CheckersDataClassesDataContext();

        //game components
        Game newGame;
        SidesInGame side1;
        SidesInGame side2;

        private Random rand = new Random();

        public MainWindow()
        {
            InitializeComponent();

            SelectBoardSizeWindow = new SelectBoardSize();
            GameBoardWindow = new GameBoard();

            this.DoubleBuffered = true;
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (AboutBox ab = new AboutBox())
            {
                ab.ShowDialog();
            }
        }

        private void SaveSidesInGame(int gameID)
        {
            if (ChoosePlayersWindow.player1_ID != 0)
            {
                side1 = new SidesInGame(gameID, 0, ChoosePlayersWindow.player1_ID);
            }
            else if (ChoosePlayersWindow.group1_ID != 0)
            {
                side1 = new SidesInGame(gameID, ChoosePlayersWindow.group1_ID, 0);

            }
            db.SidesInGames.InsertOnSubmit(side1);
            if (!IsSinglePlayerMode)
            {
                if (ChoosePlayersWindow.player2_ID != 0)
                {
                    side2 = new SidesInGame(gameID, 0, ChoosePlayersWindow.player2_ID);
                }
                else if (ChoosePlayersWindow.group2_ID != 0)
                {
                    side2 = new SidesInGame(gameID, ChoosePlayersWindow.group2_ID, 0);
                }
                db.SidesInGames.InsertOnSubmit(side2);
            }
            db.SubmitChanges();
        }

        private string GetSideName(SidesInGame side)
        {
            string label="";
            if (side.side_GameID != 0)//if we have game...
            {
                if (side.side_GroupId != 1)//side 1  = group
                {
                    var group =
                        from g in db.Groups
                        where g.group_ID == side.side_GroupId
                        select g.group_Name;
                    label = group.First();
                }
                if (side.side_PlayerId != 1)//side 1  = player
                {
                    var player =
                       from p in db.Players
                       where p.player_ID == side.side_PlayerId
                       select p.player_FirstName + " " + p.player_LastName;
                    label = player.First();
                }
            }
            return label;
        }

        private void OpenGameBoard(bool isComputerSmart)
        {
            //user chooses board size
            if (ChoosePlayersWindow.ifChose)
            {
                SelectBoardSizeWindow.ShowDialog();
                int size = SelectBoardSizeWindow.BoardSize;
                //show game board
                if (SelectBoardSizeWindow.ifStartGame)
                {
                    //save game and sides to db
                    newGame = new Game(size, IsSinglePlayerMode, isComputerSmart);
                    db.Games.InsertOnSubmit(newGame);
                    db.SubmitChanges();

                    SaveSidesInGame(newGame.game_ID);

                    GameBoardWindow = new GameBoard(newGame);
                    GameBoardWindow.isSmartComputer = isComputerSmart;
                    //update names of sides in game board
                    GameBoardWindow.LowerLabel2.Text = GetSideName(side1);
                    if(!IsSinglePlayerMode)
                        GameBoardWindow.UpperLabel1.Text = GetSideName(side2);

                    //build board according to selected size
                    GameBoardWindow.BuildBoardBySize(size, IsSinglePlayerMode);
                    GameBoardWindow.ShowDialog();
                    if (GameBoardWindow.IsReplayChosenInGameBoardMenu)
                        PrepareReplay();
                    else if (GameBoardWindow.IsNewSingleGame)
                        PrepareNewSingleGame();
                    else if (GameBoardWindow.IsNewMultiGame)
                        PrepareNewMultiGame();
                }
            }
        }
       
        private void MainWindow_Load(object sender, EventArgs e)
        {

        }

        private void BNewSingle_Click(object sender, EventArgs e)
        {
            PrepareNewSingleGame();
        }

        private void BNewMulti_Click(object sender, EventArgs e)
        {
            PrepareNewMultiGame();
        }

        private void PrepareNewSingleGame()
        {
            IsSinglePlayerMode = true;
            ChoosePlayersWindow = new ChoosePlayers(IsSinglePlayerMode);
            ChoosePlayersWindow.ShowDialog();

            OpenGameBoard(ChoosePlayersWindow.isComputerSmart);
        }

        private void PrepareNewMultiGame()
        {
            IsSinglePlayerMode = false;
            ChoosePlayersWindow = new ChoosePlayers(IsSinglePlayerMode);
            ChoosePlayersWindow.ShowDialog();

            OpenGameBoard(false);
        }

        private void BStatistics_Click(object sender, EventArgs e)
        {
            StatisticsView stats = new StatisticsView();
            stats.ShowDialog(); //open new stats form
        }

        private void BExit_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Are You Sure?", "EXIT", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (res == DialogResult.Yes) //player wants to exit
                Application.Exit();
        }

        private void BAbout_Click(object sender, EventArgs e)
        {
            using (AboutBox aboutBox = new AboutBox()) //create aboutbox instance
            {
                aboutBox.ShowDialog(); //show aboutbox
            } //dispose aboutbox
        }

        private void BReplay_Click(object sender, EventArgs e)
        {
            PrepareReplay();
        }

        private void PrepareReplay()
        {
            chooseGameForReplayWindow = new ChooseGameForReplay();
            chooseGameForReplayWindow.ShowDialog();

            if (chooseGameForReplayWindow.ifChose)//if user chose game
            {
                Game GameForReplay = new Game();
                GameForReplay = chooseGameForReplayWindow.gameForReplay;
                //start new game in replay
                IsSinglePlayerMode = GameForReplay.game_IsSinglePlayer;
                OpenReplayedGame(GameForReplay);
            }      
        }

        private void OpenReplayedGame(Game replayedGame)
        {
            //open gameboard according to the replayed game size, players and so on..
            int board_size = replayedGame.game_BoardSize;
            int ID = replayedGame.game_ID;
            GameBoardWindow = new GameBoard(replayedGame);
            string side1name;
            string side2name;

            if (IsSinglePlayerMode)
                GameBoardWindow.isSmartComputer = (bool)replayedGame.game_IsSmartComputer;
            var sidesInReplayedGame =
                from s in db.SidesInGames
                where s.side_GameID == replayedGame.game_ID
                select s;

            side1name = GetSideName(sidesInReplayedGame.ToArray()[0]);
            GameBoardWindow.LowerLabel2.Text = side1name;
            if (!IsSinglePlayerMode)
            {
                side2name = GetSideName(sidesInReplayedGame.ToArray()[1]);
                GameBoardWindow.UpperLabel1.Text = side2name;
            }
            //build board according to selected size
            GameBoardWindow.BuildBoardBySize(board_size, IsSinglePlayerMode);
            GameBoardWindow.IsReplayMode = true;
            GameBoardWindow.ShowDialog();
        }
        
    }
}
