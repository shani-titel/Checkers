using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace CheckersProject
{
    class SetOfPawns
    {
        //player game properties
        internal List<Pawn> Pawns;
        internal Color PawnsColor { set; get; }
        internal Color SelectedPawnColor { private set; get; }
        internal Shape PawnsShape { set; get; }
        internal bool IsShapeFilled { set; get; }
        internal int PawnEdgeSize = 40;

        public SetOfPawns(int amountOfPawns, Color c)
        {
            Pawns = new List<Pawn>();
            SetAmountOfPawns(amountOfPawns);
            PawnsColor = c;
            SelectedPawnColor = ControlPaint.Dark(c);
            PawnsShape = Shape.Elipse; // default
            IsShapeFilled = true; // default
        }

        internal void SetAmountOfPawns(int amount)
        {
            Pawns.Clear();
            for (int i = 0; i < amount; i++)
            {
                Pawns.Add(new Pawn(this));
            }

        }
        
        internal void UpdateSelectedPawnColor()
        {
            SelectedPawnColor = ControlPaint.Dark(PawnsColor);
        }

    }
}
