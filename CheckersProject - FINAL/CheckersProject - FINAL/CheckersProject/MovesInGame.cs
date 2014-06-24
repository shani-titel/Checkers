using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace CheckersProject
{
    partial class MovesInGame
    {
        internal MovesInGame(int gameID, int sideID, Move move, bool isFaded, bool isDragMode, SetOfPawns pl1Pawns, SetOfPawns pl2Pawns)
            : this()
        {
            this.move_GameID = gameID;
            this.move_SideID = sideID;
            this.move_Origin_I = move.origin.LocationInMatrix.X;
            this.move_Origin_J = move.origin.LocationInMatrix.Y;
            this.move_Target_I = move.target.LocationInMatrix.X;
            this.move_Target_J = move.target.LocationInMatrix.Y;
            if (move.eaten != null)
            {
                this.move_Eaten_I = move.eaten.LocationInMatrix.X;
                this.move_Eaten_J = move.eaten.LocationInMatrix.Y;
            }
            //game graphic settings
            this.move_IsFaded = isFaded;
            this.move_IsDragMode = isDragMode;
            //player1 graphic settings
            this.move_P1_PawnShape = pl1Pawns.PawnsShape.ToString();
            this.move_P1_IsShapeFilled = pl1Pawns.IsShapeFilled;
            this.move_P1_PawnColor_R = pl1Pawns.PawnsColor.R;
            this.move_P1_PawnColor_B = pl1Pawns.PawnsColor.B;
            this.move_P1_PawnColor_G = pl1Pawns.PawnsColor.G;
            //player2 graphic settings
            this.move_P2_PawnShape = pl2Pawns.PawnsShape.ToString();
            this.move_P2_IsShapeFilled = pl2Pawns.IsShapeFilled;
            this.move_P2_PawnColor_R = pl2Pawns.PawnsColor.R;
            this.move_P2_PawnColor_B = pl2Pawns.PawnsColor.B;
            this.move_P2_PawnColor_G = pl2Pawns.PawnsColor.G;
        }
    }
}
