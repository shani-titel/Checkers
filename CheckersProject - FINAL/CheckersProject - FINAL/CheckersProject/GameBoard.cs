using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace CheckersProject
{
    public partial class GameBoard : Form
    {
        //build board properties
        public const int BOARD_SIZE_DEFAULT = 8;
        public readonly Color DEFAULT_RED = Color.Red;
        public readonly Color DEFAULT_WHITE = Color.White;
        public const int PAWNS_AMOUNT_DEFAULT = 12;

        private int BoardSize;
        private Cell[,] CellMatrixBoard;
        private Point BoardUpperLeftPoint;

        private SetOfPawns Player1Pawns;
        private SetOfPawns Player2Pawns;

        private bool IsPlayer1Turn;
        private bool WasDown;
        private Point MouseLocation;
        private Point LocationRatio;

        //movement style - indicate in which style the user can move the pawns
        bool IsDragMode;
        //painting style
        bool IsPawnFaded;

        //bitmaps
        private Bitmap cleanBoard;
        private Bitmap PaintedBitmap;
        private Graphics gr;

        //while game running
        private Cell previousSelectedCell;
        private bool gameFinished;
        private bool isSinglePlayerMode;
        internal bool isSmartComputer;


        //menu options
        GameSettings GameSettingsWindow;
        internal bool IsNewSingleGame;
        internal bool IsNewMultiGame;
        
        internal bool IsReplayChosenInGameBoardMenu;
        internal bool IsStatistics;

        //game components
        Game currentGame;

        //db handling
        CheckersDataClassesDataContext db = new CheckersDataClassesDataContext();
        
        //replay mode
        internal bool IsReplayMode;

        public GameBoard()
        {
            InitializeComponent();
            InitializeNewGame();
        }

        public GameBoard(Game newGame)
        {
            InitializeComponent();
            InitializeNewGame();
            this.currentGame = newGame;
        }

        private void RandomizeColors()
        {
            Random rand = new Random();
            int res = rand.Next(0,11);//returns number between 0 and 10
            if (res%2 == 0)
            {
                Player1Pawns.PawnsColor = DEFAULT_RED;
                Player2Pawns.PawnsColor = DEFAULT_WHITE;
            }
            else 
            {
                Player1Pawns.PawnsColor = DEFAULT_WHITE;
                Player2Pawns.PawnsColor = DEFAULT_RED;
            }
            UpperLabel1.ForeColor = Player1Pawns.PawnsColor;
            LowerLabel2.ForeColor = Player2Pawns.PawnsColor;
            Player1Pawns.UpdateSelectedPawnColor();
            Player2Pawns.UpdateSelectedPawnColor();
        }

        private void GameBoard_Load(object sender, EventArgs e)
        {

            if (isSinglePlayerMode)
                UpperLabel1.Text = "Computer";
            
            previousSelectedCell = null;
            gameFinished = false;
            if (!IsReplayMode)
            {
                IsPlayer1Turn = false;
                WasDown = false;
                RandomizeColors();
            }
            
        }

        private void ReplayGame()
        {
            Move currentMove = new Move();
            var movesToReplay =
                from m in db.MovesInGames
                where m.move_GameID == currentGame.game_ID
                select m;
            if(movesToReplay.Count() != 0)
                IsPlayer1Turn = (movesToReplay.First().move_SideID == 1) ? true : false; //determine turn
            UpperLabel1.ForeColor = Player1Pawns.PawnsColor;
            LowerLabel2.ForeColor = Player2Pawns.PawnsColor;
            foreach (var replayMove in movesToReplay)
            {
                Application.DoEvents();
                currentMove = CreateMoveForReplay(replayMove);
                //GraphicSettingsFromDB(replayMove); //first time with default
                
                //select cell
                currentMove.origin.SelectPawnInCell();
                RefreshBoard();
                Thread.Sleep(1000);

                if (currentMove.eaten != null)//if the move is eating move
                {
                    EatLeftOrRight(currentMove.origin, currentMove.target);//include fades
                }
                else //movement move
                {
                    if (IsPawnFaded)
                    {
                        FadeOut(currentMove.origin);
                        currentMove.Execute();
                        FadeIn(currentMove.target);
                    }
                    else
                        currentMove.Execute();
                }
                currentMove.target.UnselectPawnInCell();
                RefreshBoard();
                Thread.Sleep(1000); //slows down the replay
                IsPlayer1Turn = (replayMove.move_SideID == 1) ? true : false; //determine turn
            }

            //is game stuck / finished
            if (!gameFinished)
            {
                IsGameStuck();
            }
        }

        //private void GraphicSettingsFromDB(MovesInGame replayMove)
        //{
        //    //visual settings
        //    this.IsPawnFaded = replayMove.move_IsFaded;
        //    //player 1
        //    this.Player1Pawns.PawnsShape = StringToShape(replayMove.move_P1_PawnShape);
        //    this.Player1Pawns.IsShapeFilled = replayMove.move_P1_IsShapeFilled;
        //    this.Player1Pawns.PawnsColor = Color.FromArgb(replayMove.move_P1_PawnColor_R, replayMove.move_P1_PawnColor_G, replayMove.move_P1_PawnColor_B);
        //    this.Player1Pawns.UpdateSelectedPawnColor();
        //    UpperLabel1.ForeColor = Player1Pawns.PawnsColor;
        //    //player 2
        //    this.Player2Pawns.PawnsShape = StringToShape(replayMove.move_P2_PawnShape);
        //    this.Player2Pawns.IsShapeFilled = replayMove.move_P2_IsShapeFilled;
        //    this.Player2Pawns.PawnsColor = Color.FromArgb(replayMove.move_P2_PawnColor_R, replayMove.move_P2_PawnColor_G, replayMove.move_P2_PawnColor_B);
        //    this.Player2Pawns.UpdateSelectedPawnColor();
        //    LowerLabel2.ForeColor = Player2Pawns.PawnsColor;
        //}

        private Move CreateMoveForReplay(MovesInGame replayMove)
        {
            Cell origin = new Cell();
            Cell target = new Cell();
            Cell eaten = new Cell();

            //create cells for creating move
            origin = CellMatrixBoard[replayMove.move_Origin_I, replayMove.move_Origin_J];
            target = CellMatrixBoard[replayMove.move_Target_I, replayMove.move_Target_J];
            if (replayMove.move_Eaten_I != null)
                eaten = CellMatrixBoard[(int)replayMove.move_Eaten_I, (int)replayMove.move_Eaten_J];
            else
                eaten = null;

            Move newMove = new Move(origin, target, eaten);
            return newMove;

        }

        private Cell CreateCellForReplay(int i, int j)
        {
            Pawn p = CellMatrixBoard[i, j].PawnInCell;
            bool active = CellMatrixBoard[i, j].IsActive;
            Cell newCell = new Cell(active, p, new Point(i, j));
            return newCell;
        }

        private void FirstGameMove()
        {
            if (Player1Pawns.PawnsColor == Color.White)
            {
                IsPlayer1Turn = true;
                if (isSinglePlayerMode)
                {
                    if (isSmartComputer)
                        SmartComputerPlay();
                    else
                        //DumbCompPlay();
                        DumbComputerPlay();
                    //change turn
                    IsPlayer1Turn = false;
                }
                
            }
            else if (Player2Pawns.PawnsColor == Color.White)
            {
                IsPlayer1Turn = false;
            }
        }

        private void InitializeNewGame()
        {
            BoardSize = BOARD_SIZE_DEFAULT; //default           

            //calc starting point of board (upper left)
            BoardUpperLeftPoint = new Point();

            previousSelectedCell = null;

            IsDragMode = false;
            Player1Pawns = new SetOfPawns(PAWNS_AMOUNT_DEFAULT, DEFAULT_RED); //default
            Player2Pawns = new SetOfPawns(PAWNS_AMOUNT_DEFAULT, DEFAULT_WHITE); //default

            //RandomizeColors();

            IsPlayer1Turn = false;
            WasDown = false;
            IsReplayMode = false;

            DoubleBuffered = true;
            cleanBoard = new Bitmap(ClientRectangle.Width, ClientRectangle.Height - menuStrip1.Height);
            PaintedBitmap = new Bitmap(ClientRectangle.Width, ClientRectangle.Height - menuStrip1.Height);
            MouseLocation = new Point();
            LocationRatio = new Point();

            IsPawnFaded = false;
            gameFinished = false;
            gr = Graphics.FromImage(PaintedBitmap);

            //consider change the size of bitmap (height) by the actual height (without bars)
            UpdateUpperLeftCornerOfBoard();

            GameSettingsWindow = new GameSettings();

            //game components
            currentGame = new Game();

            //menu items
            IsReplayChosenInGameBoardMenu = false;
            IsNewSingleGame = false;
            IsNewMultiGame = false;
            IsStatistics = false;
            
            FirstGameMove();
        }

        private void UpdateUpperLeftCornerOfBoard()
        {
            //in order to paint the board in the middle of the window
            BoardUpperLeftPoint.X = (PaintedBitmap.Width / 2) - (BoardSize * Cell.CELL_SIZE / 2);
            BoardUpperLeftPoint.Y = (PaintedBitmap.Height / 2) - (BoardSize * Cell.CELL_SIZE / 2);
        }

        internal void BuildBoardBySize(int size, bool IsSinglePlayerMode)
        {
            this.BoardSize = size; //save size
            this.isSinglePlayerMode = IsSinglePlayerMode; //save game mode
            
            UpdateUpperLeftCornerOfBoard();
            
            //update pawns collections with the updated amount
            int rowsWithPlayerPawns = (BoardSize - 2) / 2;
            int amountOfPawns = rowsWithPlayerPawns * BoardSize / 2;
            Player1Pawns.SetAmountOfPawns(amountOfPawns);
            Player2Pawns.SetAmountOfPawns(amountOfPawns);

            BuildRectMatrix(BoardSize, rowsWithPlayerPawns); //build cell matrix with pawns 
           
            //create the root node for the AI
            root = new Node(CellMatrixBoard);
        }

        private void BuildRectMatrix(int rows, int rowsWithPlayerPawns)
        {
            Cell[,] mat = new Cell[rows, rows];
            int c1 =0 , c2=0;

            //build mat, set each cell if active or not + if has pawn
            for (int i = 0; i < mat.GetLength(0); i++) //run on all rows 
            {
                for (int j = 0; j < mat.GetLength(1); j++) //run on all cols 
                {
                    if (((i % 2) == 0 && (j % 2) == 0) || ((i % 2) != 0 && (j % 2) != 0)) //if row and col are both even/uneven number --> white cell
                    {
                        mat[i, j] = new Cell(false, new Point(i,j));
                    }
                    else if (i < rowsWithPlayerPawns && j < mat.GetLength(1)) //case rows of player1
                    {
                        mat[i, j] = new Cell(true, Player1Pawns.Pawns[c1], new Point(i, j));
                        c1++;
                    }
                    else if (((BoardSize - rowsWithPlayerPawns) <= i) && (i < BoardSize) && (j < mat.GetLength(1))) //case rows of player2
                    {
                        mat[i, j] = new Cell(true, Player2Pawns.Pawns[c2], new Point(i, j));
                        c2++;
                    }
                    else //case 2 centered empty rows
                    {
                        mat[i, j] = new Cell(true, new Point(i, j));
                    }
                }    
            }

            CellMatrixBoard = mat;
        }

        //find coordinates in cuurent game board (cause the game board's size changes)
        public Point CellToCoordinates(int i, int j)
        {
            int x = BoardUpperLeftPoint.X + Cell.CELL_SIZE * (j) + Cell.PADDING_IN_CELL;
            int y = BoardUpperLeftPoint.Y + Cell.CELL_SIZE * (i) + Cell.PADDING_IN_CELL;
            return new Point(x, y);
        }
        
        //the opposite one
        private Cell CoordinatesToCell(Point p)
        {
            //to make sure we're inside the board bounds
            if ((p.X >= BoardUpperLeftPoint.X || p.X <= (BoardUpperLeftPoint.X + BoardSize * Cell.CELL_SIZE)) && (p.Y >= BoardUpperLeftPoint.Y || p.Y <= (BoardUpperLeftPoint.Y + BoardSize * Cell.CELL_SIZE)))
            {
                int i = ((p.Y - BoardUpperLeftPoint.Y) / Cell.CELL_SIZE);
                int j = (p.X - BoardUpperLeftPoint.X) / Cell.CELL_SIZE;

                //verify inside the board            
                if (i == CellMatrixBoard.GetLength(0))
                    i--;
                if (j == CellMatrixBoard.GetLength(1))
                    j--;
                if (i == -1)
                    i++;
                if (j == -1)
                    j++;

                return CellMatrixBoard[i, j];
            }
            return null;

        }

        private void GameBoard_Paint(object sender, PaintEventArgs e)
        {
            PaintedBitmap = (Bitmap)cleanBoard.Clone();
            gr = Graphics.FromImage(PaintedBitmap);

            //paint the board only
            int y = BoardUpperLeftPoint.Y;
            for (int i = 0; i < CellMatrixBoard.GetLength(0); i++)
            {
                int x = BoardUpperLeftPoint.X;
                for (int j = 0; j < CellMatrixBoard.GetLength(1); j++)
                {
                    CellMatrixBoard[i, j].PaintCell(gr, new Point(x, y));
                    x += Cell.CELL_SIZE;
                }
                y += Cell.CELL_SIZE;
            }
            
            //for dragging movement style
            if (IsDragMode && WasDown && !previousSelectedCell.PawnInCell.IsPainted)//after mouse move event
            {
                previousSelectedCell.PawnInCell.IsPainted = true;
                Point paintPawnPoint = new Point(MouseLocation.X - LocationRatio.X, MouseLocation.Y - LocationRatio.Y);
                previousSelectedCell.PawnInCell.Paint(gr, paintPawnPoint);
            }
            e.Graphics.DrawImage(PaintedBitmap, 0, menuStrip1.Height);
        }

        private void RefreshBoard()
        {
            Invalidate();
            Update();
        }

        private void FadeIn(Cell c)
        {
            c.PawnInCell.IsFaded = true;
            for (int a=0; a < 255; a += 20)
            {
                c.PawnInCell.Alpha = a;
                Refresh();
                //RefreshBoard();//after Alpha changes --> paint
            }
            c.PawnInCell.IsFaded = false;
        }

        private void FadeOut(Cell c)
        {
            c.PawnInCell.IsFaded = true;
            int a = c.PawnInCell.PawnColor.A -5;
            for (; a > 0; a -= 20)
            {
                c.PawnInCell.Alpha = a;
                Refresh();
                //RefreshBoard();//after Alpha changes --> paint
            }
            c.PawnInCell.IsFaded = false;
        }

        private void GameBoard_MouseDown(object sender, MouseEventArgs e)
        {
            if (IsDragMode && !IsReplayMode)
            {
                Cell cellClicked = ChoosePawn(e.Location); //choose pawn to move
                if (cellClicked != null)
                {
                    WasDown = true;
                    CalcLocationRatio(e.Location);                            
                    Cursor = Cursors.Hand;
                    RefreshBoard();
                }     
            }
        }

        private void CalcLocationRatio(Point location)
        {
            //save drag ratio for painting the selected pawn
            MouseLocation = new Point(location.X, location.Y);
            LocationRatio.X = MouseLocation.X - CellToCoordinates(previousSelectedCell.LocationInMatrix.X, previousSelectedCell.LocationInMatrix.Y).X - Cell.PADDING_IN_CELL;
            LocationRatio.Y = MouseLocation.Y - CellToCoordinates(previousSelectedCell.LocationInMatrix.X, previousSelectedCell.LocationInMatrix.Y).Y - Cell.PADDING_IN_CELL;
        }

        private void GameBoard_MouseMove(object sender, MouseEventArgs e)
        {
            if (WasDown)
            {
                MouseLocation = new Point(e.X, e.Y);
                previousSelectedCell.PawnInCell.IsPainted = false; //don't paint the pawn in origin cell
                
                RefreshBoard();
            }
        }

        private void SaveMoveToDB(Move game_move)
        {
            int sideID;

            if (IsPlayer1Turn)
                sideID = 1;
            else
                sideID = 2;

            MovesInGame moveToDB = new MovesInGame(currentGame.game_ID, sideID, game_move, IsPawnFaded, IsDragMode, Player1Pawns, Player2Pawns);
            db.MovesInGames.InsertOnSubmit(moveToDB);
            db.SubmitChanges();
        }

        private void GameBoard_MouseUp(object sender, MouseEventArgs e)
        {
            if (IsDragMode && WasDown && !IsReplayMode)
            {
                WasDown = false;
                Cell targetCell = CoordinatesToCell(e.Location);
                Move moved = MoveLeftOrRight(previousSelectedCell, targetCell);
                Move eaten = EatLeftOrRight(previousSelectedCell, targetCell);
                if (moved != null) //if moved
                {
                    targetCell.UnselectPawnInCell();
                    SaveMoveToDB(moved);
                    IsPlayer1Turn = (IsPlayer1Turn == true) ? false : true;
                }
                else if(eaten != null) //if eaten
                {
                    targetCell.UnselectPawnInCell();
                    SaveMoveToDB(eaten);
                    IsPlayer1Turn = (IsPlayer1Turn == true) ? false : true;
                }
                else //if not moved
                {
                    previousSelectedCell.UnselectPawnInCell();
                    previousSelectedCell = null;
                }
                
                WasDown = false;
                this.Cursor = Cursors.Default;
                RefreshBoard();
                //check if game is stuck
                if (!gameFinished)
                    IsGameStuck();
                if (isSinglePlayerMode && IsPlayer1Turn)//computer's turn
                {
                    Thread.Sleep(1000);
                    if (isSmartComputer)
                        SmartComputerPlay();
                    else
                        //DumbCompPlay();
                        DumbComputerPlay();
                    IsPlayer1Turn = (IsPlayer1Turn == true) ? false : true;
                    RefreshBoard();
                    if (!gameFinished)
                        IsGameStuck();
                }
            }
        }

        private Cell ChoosePawn(Point location)
        {                
            Cell cellClicked = CoordinatesToCell(location);
            if (IsValidTurn(cellClicked))//if it is the turn of the player who clicked
            {
                if (cellClicked != null && cellClicked.IsActive)//verify we clicked on valid cell
                {
                    if (cellClicked.PawnInCell != null)//verify cell has pawn in it --> choose it
                    {
                        if (previousSelectedCell != null) //if choose different pawn to move
                        {
                            if (!(previousSelectedCell.Equals(cellClicked)))//regret, choose different pawn
                            {
                                previousSelectedCell.UnselectPawnInCell();
                                cellClicked.SelectPawnInCell();
                                previousSelectedCell = cellClicked;//save cell clicked when chose pawn
                                return cellClicked;
                            }
                            else//cell clicked = previous
                            {
                                return cellClicked;
                            }

                        }
                        else
                        {
                            cellClicked.SelectPawnInCell();
                            previousSelectedCell = cellClicked;//save cell clicked when chose pawn
                            return cellClicked;//for the first time we choose pawn, no regret
                        }
                    }
                    return null;
                }
                return null;
            }
            return null;
        }

        private void GameBoard_MouseClick(object sender, MouseEventArgs e)
        {
            if (!IsDragMode && !IsReplayMode)
            {
                Cell cellClicked = ChoosePawn(e.Location); //choose pawn to move
                if (cellClicked != null)
                {
                    RefreshBoard(); 
                }
                
                else if (cellClicked == null && previousSelectedCell != null)//we already chose pawn --> now choose empty cell to put pawn down 
                {
                    Move eaten = new Move();
                    cellClicked = CoordinatesToCell(e.Location);
                    //check if can place pawn according to game rules
                    Move moved = MoveLeftOrRight(previousSelectedCell, cellClicked);
                    if(moved == null)
                        eaten = EatLeftOrRight(previousSelectedCell, cellClicked);
                    if (moved != null || eaten != null)
                    {
                        cellClicked.UnselectPawnInCell();
                        RefreshBoard();
                        IsPlayer1Turn = (IsPlayer1Turn == true) ? false : true;
                        if (moved != null)
                            SaveMoveToDB(moved);
                        else
                            SaveMoveToDB(eaten);
                    }
                    
                }
                //check if game is stuck
                if (!gameFinished)
                    IsGameStuck();
                if (isSinglePlayerMode && IsPlayer1Turn)//computer's turn
                {
                    Thread.Sleep(1000);
                    if (isSmartComputer)
                        SmartComputerPlay();
                    else
                        //DumbCompPlay();
                        DumbComputerPlay();
                    IsPlayer1Turn = (IsPlayer1Turn == true) ? false : true;
                    RefreshBoard();
                    //check if game is stuck
                    if (!gameFinished)
                        IsGameStuck();
                }
            }
        }

        //executive function!!
        private Move MoveLeftOrRight(Cell originCell, Cell targetCell)
        {
            if(IsValidTurn(originCell))
            {
                Move moveRight = CanMoveRight(originCell, this.CellMatrixBoard);
                Move moveLeft = CanMoveLeft(originCell, this.CellMatrixBoard);

                if (moveRight != null && moveRight.target == targetCell)
                {
                    if (IsPawnFaded)
                    {
                        if (!IsDragMode)
                        {
                            FadeOut(moveRight.origin);
                        }
                        moveRight.Execute();
                        FadeIn(moveRight.target);
                    }
                    else
                    {
                        moveRight.Execute();
                    }
                    return moveRight;
                }
                else if (moveLeft != null && moveLeft.target == targetCell)
                {
                    if (IsPawnFaded)
                    {
                        if (!IsDragMode)
                        {
                            FadeOut(moveLeft.origin);
                        }
                        moveLeft.Execute();
                        FadeIn(moveLeft.target);
                    }
                    else
                    {
                        moveLeft.Execute();
                    }
                    //IsPlayer1Turn = (IsPlayer1Turn == true) ? false : true;
                    return moveLeft;
                }
            }
            return null;
        }

        private bool IsValidTurn(Cell originCell)
        {
            if (originCell.PawnInCell != null && originCell.PawnInCell.Set == Player1Pawns && IsPlayer1Turn)
            {
                return true;
            }
            else if (originCell.PawnInCell != null && originCell.PawnInCell.Set == Player2Pawns && !IsPlayer1Turn)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
        //executive function!!
        private Move EatLeftOrRight(Cell originCell, Cell targetCell)
        {
            SetOfPawns wasEatenSet;
            if (IsValidTurn(originCell))
            {
                Move moveRight = CanEatRight(originCell, this.CellMatrixBoard);
                Move moveLeft = CanEatLeft(originCell, this.CellMatrixBoard);

                if (moveRight != null && moveRight.target == targetCell)
                {
                    if (IsPawnFaded)
                    {
                        if (IsDragMode)
                            moveRight.origin.PawnInCell.IsPainted = false;
                        FadeOut(moveRight.eaten);
                        moveRight.eaten.PawnInCell.Set.Pawns.Remove(moveRight.eaten.PawnInCell);
                        wasEatenSet = moveRight.eaten.PawnInCell.Set;
                        moveRight.eaten.PawnInCell = null;
                        if (!IsDragMode)
                        {
                            FadeOut(moveRight.origin);
                        }
                        else
                            moveRight.origin.PawnInCell.IsPainted = true;
                        moveRight.Execute();
                        FadeIn(moveRight.target);
                    }
                    else
                    {
                        moveRight.Execute();//move pawn only
                        moveRight.eaten.PawnInCell.Set.Pawns.Remove(moveRight.eaten.PawnInCell);
                        wasEatenSet = moveRight.eaten.PawnInCell.Set;
                        moveRight.eaten.PawnInCell = null;

                    }
                    if (wasEatenSet.Pawns.Count == 0)
                    {
                        Victory(wasEatenSet);
                    }
                    return moveRight;
                }
                else if (moveLeft != null && moveLeft.target == targetCell)
                {
                    if (IsPawnFaded)
                    {
                        if(IsDragMode)
                            moveLeft.origin.PawnInCell.IsPainted = false;
                        FadeOut(moveLeft.eaten);
                        moveLeft.eaten.PawnInCell.Set.Pawns.Remove(moveLeft.eaten.PawnInCell);
                        wasEatenSet = moveLeft.eaten.PawnInCell.Set;
                        moveLeft.eaten.PawnInCell = null;
                        if (!IsDragMode)//click --> fade out
                        {
                            FadeOut(moveLeft.origin);
                        }
                        else
                            moveLeft.origin.PawnInCell.IsPainted = true;
                        moveLeft.Execute();
                        FadeIn(moveLeft.target);
                    }
                    else
                    {
                        moveLeft.Execute();
                        moveLeft.eaten.PawnInCell.Set.Pawns.Remove(moveLeft.eaten.PawnInCell);
                        wasEatenSet = moveLeft.eaten.PawnInCell.Set;
                        moveLeft.eaten.PawnInCell = null;
                    }
                    if (wasEatenSet.Pawns.Count == 0)
                    {
                        Victory(wasEatenSet);
                    }
                    return moveLeft;
                }
            }
            return null;
        }

        private void Victory(SetOfPawns set)
        {
            RefreshBoard();
            DialogResult res;
            string winner="";
            gameFinished = true;
            if (set == Player1Pawns)//player 1 lost --> player 2 wins!
            {
                res = MessageBox.Show(LowerLabel2.Text + " won the game!", "Congratulations!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                winner = LowerLabel2.Text;
            }
            else//player 2 lost --> player 1 wins!
            {
                res = MessageBox.Show(UpperLabel1.Text + " won the game!", "Congratulations!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                winner = UpperLabel1.Text;
            }
            if (res == System.Windows.Forms.DialogResult.OK)
            {
                UpdateWinnerInDb(winner);
                this.Close();
            }
        }

        private void UpdateWinnerInDb(string winner)
        {
            //save to db who wins + add to the winning player one more win in table
            //case the winner is player
            var w =
                from p in db.Players
                where winner == p.player_FirstName + " " + p.player_LastName
                select p;
            if (w.Count() != 0)
            {
                ((Player)w.First()).player_Wins++;
                db.SubmitChanges();
            }
            else//case the winner is a group
            {
                //find all players in the winning group
                var winningPlayersInGroup =
                    from g in db.Groups
                    from pig in db.PlayersInGroups
                    where winner == g.group_Name
                    where g.group_ID == pig.playerInGroup_GroupID
                    select pig;

                if (winningPlayersInGroup.Count() != 0)
                {
                    foreach (PlayersInGroup pl in winningPlayersInGroup)
                    {
                        //find the player and update his wins
                        var wp =
                            from p in db.Players
                            where pl.playerInGroup_PlayerID == p.player_ID
                            select p;
                        ((Player)wp.First()).player_Wins++;
                    }
                    db.SubmitChanges();
                }
            }
        }
        private bool IsGameStuck()
        {
            if (IsPlayerStuck(Player1Pawns) && IsPlayer1Turn || IsPlayerStuck(Player2Pawns) && !IsPlayer1Turn || IsPlayerStuck(Player1Pawns) && IsPlayerStuck(Player2Pawns))
            {
                DialogResult res = MessageBox.Show("No More Moves! \nGame Over!", "Out of moves!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                if (res == DialogResult.OK)
                {
                    gameFinished = true;
                    Close();
                    return true;
                }
            }
            return false;
        }

        private bool IsPlayerStuck(SetOfPawns playerPawns)
        {
            for (int i = 0; i < BoardSize; i++)
            {
                for (int j = 0; j < BoardSize; j++)
                {
                    Cell current = CellMatrixBoard[i, j];
                    if (CellMatrixBoard[i, j].PawnInCell != null && CellMatrixBoard[i, j].PawnInCell.Set == playerPawns)
                    {
                        if (CanMoveLeft(current, CellMatrixBoard) != null || CanMoveRight(current, CellMatrixBoard) != null)
                            return false;
                        if (CanEatLeft(current, CellMatrixBoard) != null || CanEatRight(current, CellMatrixBoard) != null)
                            return false;
                        //if (CanBeEaten(current, CellMatrixBoard))//if can be eaten the game is not stuck!
                        //    return false;
                    }
                }
            }
            return true;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            ColorDialog c = new ColorDialog();
            c.ShowDialog();
        }


        /***************examination functions!***********************************/
        private Move CanMoveLeft(Cell c, Cell[,] gameb)
        {
            Cell targetCell = new Cell();
            
            if(c.PawnInCell.Set == Player1Pawns)//computer/player1
            {
                //check not out of matrix
                if (c.LocationInMatrix.X + 1 > BoardSize - 1 || c.LocationInMatrix.Y - 1 < 0)
                {
                    return null;
                }
                targetCell = gameb[c.LocationInMatrix.X + 1, c.LocationInMatrix.Y - 1];   
            }
            else//player2
            {
                if (c.LocationInMatrix.X - 1 < 0 || c.LocationInMatrix.Y - 1 < 0)
                {
                    return null;
                }
                targetCell = gameb[c.LocationInMatrix.X - 1, c.LocationInMatrix.Y - 1];
            }
            if (targetCell.IsActive && targetCell.PawnInCell == null)
            {
                return new Move(c, targetCell);
            }
            else
            {
                return null;
            }
        }

        private Move CanMoveRight(Cell c, Cell[,] gameb)
        {
            Cell targetCell = new Cell();
            
            if(c.PawnInCell.Set == Player1Pawns)//computer/player1
            {
                //check not out of matrix
                if (c.LocationInMatrix.X + 1 > BoardSize - 1 || c.LocationInMatrix.Y + 1 > BoardSize - 1)
                {
                    return null;
                }
                targetCell = gameb[c.LocationInMatrix.X + 1, c.LocationInMatrix.Y + 1];
            }
            else//player2
            {
                if (c.LocationInMatrix.X - 1 < 0 || c.LocationInMatrix.Y + 1 > BoardSize - 1)
                {
                    return null;
                }
                targetCell = gameb[c.LocationInMatrix.X - 1, c.LocationInMatrix.Y + 1];
            }
             
            if (targetCell.IsActive && targetCell.PawnInCell == null)
            {
                return new Move(c, targetCell);
            }
            else
            {
                return null;
            }
        }

        private Move CanEatLeft(Cell c, Cell[,] gameb)
        {
            Cell targetCell = new Cell();
            Cell wasEaten = new Cell();

            if(c.PawnInCell.Set == Player1Pawns)//computer/player1
            {
                //check not out of matrix
                if (c.LocationInMatrix.X + 1 > (BoardSize - 1) || c.LocationInMatrix.Y - 1 < 0 || c.LocationInMatrix.X + 2 > (BoardSize - 1) || c.LocationInMatrix.Y - 2 < 0)
                {
                    return null;
                }
                targetCell = gameb[c.LocationInMatrix.X + 2, c.LocationInMatrix.Y - 2];
                wasEaten = gameb[c.LocationInMatrix.X + 1, c.LocationInMatrix.Y - 1];
                if (targetCell.IsActive && targetCell.PawnInCell == null && wasEaten.PawnInCell != null && wasEaten.PawnInCell.Set == Player2Pawns)
                {
                    return new Move(c, targetCell, wasEaten);
                }
            }
            else//player2
            {
                //check not out of matrix
                if (c.LocationInMatrix.X - 1 < 0 || c.LocationInMatrix.Y - 1 < 0 || c.LocationInMatrix.X - 2 < 0 || c.LocationInMatrix.Y - 2 < 0)
                {
                    return null;
                }
                targetCell = gameb[c.LocationInMatrix.X - 2, c.LocationInMatrix.Y - 2];
                wasEaten = gameb[c.LocationInMatrix.X - 1, c.LocationInMatrix.Y - 1];
                if (targetCell.IsActive && targetCell.PawnInCell == null && wasEaten.PawnInCell != null && wasEaten.PawnInCell.Set == Player1Pawns)
                {
                    return new Move(c, targetCell, wasEaten);
                }
            }
            
            return null;
        }

        private Move CanEatRight(Cell c, Cell[,] gameb)
        {
            Cell targetCell = new Cell();
            Cell wasEaten = new Cell();
            
            if(c.PawnInCell.Set == Player1Pawns)//computer/player1
            {
                //check not out of matrix
                if (c.LocationInMatrix.X + 1 > (BoardSize - 1) || c.LocationInMatrix.Y + 1 > (BoardSize - 1) || c.LocationInMatrix.X + 2 > (BoardSize - 1) || c.LocationInMatrix.Y + 2 > (BoardSize - 1))
                {
                    return null;
                }
                targetCell = gameb[c.LocationInMatrix.X + 2, c.LocationInMatrix.Y + 2];
                wasEaten = gameb[c.LocationInMatrix.X + 1, c.LocationInMatrix.Y + 1];
                if (targetCell.IsActive && targetCell.PawnInCell == null && wasEaten.PawnInCell != null && wasEaten.PawnInCell.Set == Player2Pawns)
                {
                    return new Move(c, targetCell, wasEaten);
                }
            }
            else//player2
            {
                //check not out of matrix
                if (c.LocationInMatrix.X - 1 < 0 || c.LocationInMatrix.Y + 1 > (BoardSize - 1) || c.LocationInMatrix.X - 2 < 0 || c.LocationInMatrix.Y + 2 > (BoardSize - 1))
                {
                    return null;
                }
                targetCell = gameb[c.LocationInMatrix.X - 2, c.LocationInMatrix.Y + 2];
                wasEaten = gameb[c.LocationInMatrix.X - 1, c.LocationInMatrix.Y + 1];
                if (targetCell.IsActive && targetCell.PawnInCell == null && wasEaten.PawnInCell != null && wasEaten.PawnInCell.Set == Player1Pawns)
                {
                    return new Move(c, targetCell, wasEaten);
                }
            }
            
            return null;
        }

        private void GameBoard_FormClosing(object sender, FormClosingEventArgs e)
        {
            gr.Dispose();
        }

        private bool DumbCompPlay() //true- made a move
        {
            Move currentMove = new Move();
            for (int i = 0; i < BoardSize; i++)
            {
                for (int j = 0; j < BoardSize; j++)
                {
                    Cell current = CellMatrixBoard[i, j];
                    if (CellMatrixBoard[i, j].PawnInCell != null && CellMatrixBoard[i, j].PawnInCell.Set == Player1Pawns)
                    {
                        //check right & left of the current cell
                        if (i + 1 < BoardSize)
                        {
                            //the is priority to moving to the right if possible
                            if (j + 1 < BoardSize && (currentMove = MoveLeftOrRight(current, CellMatrixBoard[i + 1, j + 1])) != null)
                            {
                                SaveMoveToDB(currentMove);
                                return true;
                            }
                            if (j - 1 > 0 && (currentMove = MoveLeftOrRight(current, CellMatrixBoard[i + 1, j - 1])) != null)
                            {
                                SaveMoveToDB(currentMove);
                                return true;
                            }
                        }
                        if(i + 2 < BoardSize)
                        {
                            if (j + 2 < BoardSize && (currentMove = EatLeftOrRight(current, CellMatrixBoard[i + 2, j + 2])) != null)
                            {
                                SaveMoveToDB(currentMove);
                                return true;
                            }
                            if (j - 2 > 0 && (currentMove = EatLeftOrRight(current, CellMatrixBoard[i + 2, j - 2])) != null)
                            {
                                SaveMoveToDB(currentMove);
                                return true;
                            }
                        }
                    }
                }
            }
            return false;
        }

        private void DumbComputerPlay()
        {
            List<Move> possibleMoves = new List<Move>();
            Random rand = new Random();
            foreach (Cell c in CellMatrixBoard)
            {
                if (c.PawnInCell != null && c.PawnInCell.Set == Player1Pawns)//for each pawn of the computer
                {
                    Move right = CanMoveRight(c, this.CellMatrixBoard);
                    Move left = CanMoveLeft(c, CellMatrixBoard);
                    Move eatRight = CanEatRight(c, CellMatrixBoard);
                    Move eatLeft = CanEatLeft(c, CellMatrixBoard);
                    if (right != null)
                        possibleMoves.Add(right);
                    if (left != null)
                        possibleMoves.Add(left);
                    if (eatRight != null)
                        possibleMoves.Add(eatRight);
                    if (eatLeft != null)
                        possibleMoves.Add(eatLeft);
                }
            }

            if (possibleMoves.Count != 0)
            {
                Move randomMove = possibleMoves[rand.Next(possibleMoves.Count)];
                if (randomMove.eaten != null)//if the move is eating move
                {
                    EatLeftOrRight(randomMove.origin, randomMove.target);
                }
                else //movement move
                {
                    randomMove.Execute();
                }
                SaveMoveToDB(randomMove);
            }
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GameSettingsWindow.player1color = Player1Pawns.PawnsColor;
            GameSettingsWindow.player2color = Player2Pawns.PawnsColor;

            DialogResult res =  GameSettingsWindow.ShowDialog();
            if (res == System.Windows.Forms.DialogResult.OK)
            {
                //update movement and animation style
                IsDragMode = GameSettingsWindow.isDrag;
                IsPawnFaded = GameSettingsWindow.isFade;

                //update colors
                Player1Pawns.PawnsColor = GameSettingsWindow.player1color;
                Player2Pawns.PawnsColor = GameSettingsWindow.player2color;
                Player1Pawns.UpdateSelectedPawnColor();
                Player2Pawns.UpdateSelectedPawnColor();
                UpperLabel1.ForeColor = GameSettingsWindow.player1color;
                LowerLabel2.ForeColor = GameSettingsWindow.player2color;
                
                //update shapes
                Player1Pawns.PawnsShape = StringToShape(GameSettingsWindow.player1shape);
                Player2Pawns.PawnsShape = StringToShape(GameSettingsWindow.player2shape);
                Player1Pawns.IsShapeFilled = GameSettingsWindow.isPlayer1shapeFilled;
                Player2Pawns.IsShapeFilled = GameSettingsWindow.isPlayer2shapeFilled;
                
                RefreshBoard();
            }

        }

        private Shape StringToShape(string s)
        {
            Shape result = Shape.Elipse;
            switch (s)
            {
                case("Elipse (Default)"):
                    result = Shape.Elipse;
                    break;
                case ("Rectangle"):
                    result = Shape.Rectangle;
                    break;
                case ("Triangle"):
                    result = Shape.Triangle;
                    break;
                case ("Square"):
                    result = Shape.Square;
                    break;
                case ("Hexagon"):
                    result = Shape.Hexagon;
                    break;    
            }
            return result;
        }

        /***************AI functions!***********************************/

        Node root;

        private void CalculatePotentialMoves(Node node)
        {
            foreach (Cell c in node.currGameBoard)
            {
                if (c.IsActive && c.PawnInCell != null && c.PawnInCell.Set == Player1Pawns)
                {
                    Move right = CanMoveRight(c, node.currGameBoard);
                    Move left = CanMoveLeft(c, node.currGameBoard);
                    Move eatRight = CanEatRight(c, node.currGameBoard);
                    Move eatLeft = CanEatLeft(c, node.currGameBoard);
                    Cell[,] newMat = new Cell[BoardSize, BoardSize];

                    if (right != null)
                    {
                        //create new copy of the cuurent game board
                        CopyCellMatrix(node.currGameBoard, newMat);
                        //add potential move to the node list, with relevent grade
                        right.value += 1;
                        node.PotentialMoves.Add(right);
                        //move pawn in newMat (execute move)
                        newMat[right.target.LocationInMatrix.X, right.target.LocationInMatrix.Y].PawnInCell = newMat[c.LocationInMatrix.X, c.LocationInMatrix.Y].PawnInCell;
                        newMat[c.LocationInMatrix.X, c.LocationInMatrix.Y].PawnInCell = null;
                        //add son (represent new game board) to node's list
                        node.AddSon(new Node(newMat));
                    }
                    if (left != null)
                    {
                        //create new copy of the cuurent game board
                        CopyCellMatrix(node.currGameBoard, newMat);
                        //add potential move to the node list, with relevent grade
                        left.value += 1;
                        node.PotentialMoves.Add(left);
                        //in order to save into new node the new game board matrix after the move has been done
                        newMat[left.target.LocationInMatrix.X, left.target.LocationInMatrix.Y].PawnInCell = newMat[c.LocationInMatrix.X, c.LocationInMatrix.Y].PawnInCell;
                        newMat[c.LocationInMatrix.X, c.LocationInMatrix.Y].PawnInCell = null;
                        node.AddSon(new Node(newMat));
                    }
                    if (eatRight != null)
                    {
                        CopyCellMatrix(node.currGameBoard, newMat);
                        eatRight.value += 5;
                        node.PotentialMoves.Add(eatRight);
                        newMat[eatRight.target.LocationInMatrix.X, eatRight.target.LocationInMatrix.Y].PawnInCell = node.currGameBoard[c.LocationInMatrix.X, c.LocationInMatrix.Y].PawnInCell;
                        newMat[c.LocationInMatrix.X, c.LocationInMatrix.Y].PawnInCell = null;
                        node.AddSon(new Node(newMat));
                    }
                    if (eatLeft != null)
                    {
                        CopyCellMatrix(node.currGameBoard, newMat);
                        eatLeft.value += 5;
                        node.PotentialMoves.Add(eatLeft);
                        newMat[eatLeft.target.LocationInMatrix.X, eatLeft.target.LocationInMatrix.Y].PawnInCell = node.currGameBoard[c.LocationInMatrix.X, c.LocationInMatrix.Y].PawnInCell;
                        newMat[c.LocationInMatrix.X, c.LocationInMatrix.Y].PawnInCell = null;
                        node.AddSon(new Node(newMat));
                    }
                    if (CanBeEaten(c, node.currGameBoard))
                    {
                        if (right != null)
                            node.AddValueToMove(right, 3);
                        if (left != null)
                            node.AddValueToMove(left, 3);
                    }
                }
            }
        }


        private void SmartComputerPlay()
        {
            root.sons.Clear();
            root.PotentialMoves.Clear();
            //calc all root sons
            CalculatePotentialMoves(root);

            List<Path> posibblePaths = new List<Path>();
            int i = 0, j = 0, k = 0;//foreach loop, add 2 index, one running on sons and the second running on posential moves amount
            foreach (Node firstgen in root.sons) //Check all sons of root
            {
                CalculatePotentialMoves(firstgen);
                foreach (Node secondgen in firstgen.sons)//Check all grandsons of root
                {
                    CalculatePotentialMoves(secondgen);
                    foreach (Node thirdgen in secondgen.sons)//Check all Great-grandchildren of root 
                    {
                        CalculatePotentialMoves(thirdgen);
                        if (k <= secondgen.PotentialMoves.Count)
                        {
                            //assign Path  
                            Path rout = new Path(root.PotentialMoves[i], firstgen.PotentialMoves[j], secondgen.PotentialMoves[k]);
                            posibblePaths.Add(rout); //all 
                        }
                        k++;
                    }
                    k = 0;
                    j++;
                }
                j = 0;
                i++;
            }
            
            Move best = new Move();
            if (posibblePaths.Count != 0)
            {
                best = FindBestMove(posibblePaths); 
            }
            else//for game stuck possibility
            {
                if(root.PotentialMoves.Count != 0)
                    best = root.PotentialMoves.First();
            }
            if (best.eaten != null)//if the move is eating move
            {
                EatLeftOrRight(best.origin, best.target);
            }
            else //movement move
            {
                best.Execute();
            }
            SaveMoveToDB(best);
        }

        //finds the best move from potentioal moves list :)    
        private Move FindBestMove(List<Path> list)
        {
            List<int> grades = new List<int>();
            Path bestPath = new Path();
            int maxGrade = 0;

            if (list.Count != 0)
            {
                maxGrade = list.First().PathValue();
            }
            else
            {
                return null;

            }
            Random rand = new Random();
            foreach (Path p in list)
            {
                if (p.PathValue() > maxGrade)
                {
                    maxGrade = p.PathValue();
                    bestPath = p;
                }
            }

            if (bestPath.First != null)
            {
                return bestPath.First;
            }
            else /*if (list.Count != 0)*/
            {
                //if didn't find best path --> choose random path and return his first move
                return list[rand.Next(list.Count)].First;
            }
        }

        private void CopyCellMatrix(Cell[,] source, Cell[,] destination)
        {
            for (int i = 0; i < source.GetLength(0); i++)
            {
                for (int j = 0; j < source.GetLength(1); j++)
                {
                    destination[i, j] = new Cell(source[i, j]);
                }
            }
        }
        private bool CanBeEaten(Cell c, Cell[,] gameb)
        { 
            //check not out of matrix
            if (c.LocationInMatrix.X + 1 > BoardSize - 1 || c.LocationInMatrix.Y - 1 < 0 || c.LocationInMatrix.Y + 1 > BoardSize - 1 || c.LocationInMatrix.X - 1 < 0)
            {
                return false;
            }
            if (c.PawnInCell.Set == Player1Pawns)//computer/player1
            {
                //can be eaten by left enemy
                Cell enemyLeft = gameb[c.LocationInMatrix.X + 1, c.LocationInMatrix.Y - 1];
                Cell protectingLeftCell = gameb[c.LocationInMatrix.X - 1, c.LocationInMatrix.Y + 1];
                if (enemyLeft.PawnInCell != null && enemyLeft.PawnInCell.Set == Player2Pawns && protectingLeftCell.PawnInCell == null)
                {
                    return true;
                }
                //can be eaten by right enemy
                Cell enemyRight = gameb[c.LocationInMatrix.X + 1, c.LocationInMatrix.Y + 1];
                Cell protectingRightCell = gameb[c.LocationInMatrix.X - 1, c.LocationInMatrix.Y - 1];
                if (enemyRight.PawnInCell != null && enemyRight.PawnInCell.Set == Player2Pawns && protectingRightCell.PawnInCell == null)
                {
                    return true;
                }
            }
            else//player 2
            {
                Cell enemyLeft = gameb[c.LocationInMatrix.X - 1, c.LocationInMatrix.Y - 1];
                Cell protectingLeftCell = gameb[c.LocationInMatrix.X + 1, c.LocationInMatrix.Y + 1];
                if (enemyLeft.PawnInCell != null && enemyLeft.PawnInCell.Set == Player2Pawns && protectingLeftCell.PawnInCell == null)
                {
                    return true;
                }
                //can be eaten by right enemy
                Cell enemyRight = gameb[c.LocationInMatrix.X - 1, c.LocationInMatrix.Y + 1];
                Cell protectingRightCell = gameb[c.LocationInMatrix.X + 1, c.LocationInMatrix.Y - 1];
                if (enemyRight.PawnInCell != null && enemyRight.PawnInCell.Set == Player2Pawns && protectingRightCell.PawnInCell == null)
                {
                    return true;
                }
            }
            
            return false;
        }

        private void GameBoard_Shown(object sender, EventArgs e)
        {
            if (IsReplayMode)
            {
                ReplayGame();
            }
            else
            {
                FirstGameMove();
            }
        }

        private void statisticsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StatisticsView stats = new StatisticsView();
            stats.ShowDialog();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Are You Sure?", "EXIT", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (res == DialogResult.Yes) //player wants to exit
                Application.Exit();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Are You Sure?\nThis will close the game board...", "Replay Game", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (res == DialogResult.Yes) //player wants to exit
            {
                IsReplayChosenInGameBoardMenu = true;
                Close();
            }
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void onePlayerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Are You Sure?\nThis will close the game board...", "New Game", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (res == DialogResult.Yes) //player wants to exit
            {
                IsNewSingleGame = true;
                Close();
            }
        }

        private void multiPlayersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Are You Sure?\nThis will close the game board...", "New Game", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (res == DialogResult.Yes) //player wants to exit
            {
                IsNewMultiGame = true;
                Close();
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (AboutBox ab = new AboutBox())
            {
                ab.ShowDialog();
            }
        }

        
    }
}
