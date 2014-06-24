using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace CheckersProject
{
    class Cell
    {
        public const int CELL_SIZE = 60;
        public const int PADDING_IN_CELL = 10;

        internal bool IsActive { get; set; }
        internal Pawn PawnInCell { get; set; }
        internal Point LocationInMatrix { get; private set; }

        public Cell()
        {
        }
        public Cell(bool active, Point location)
        {
            IsActive = active;
            LocationInMatrix = location;
            PawnInCell = null;
        }
        public Cell(bool active, Pawn p, Point location)
        {
            IsActive = active;
            LocationInMatrix = location;
            PawnInCell = p;
        }

        public Cell(Cell copy)
        {
            this.IsActive = copy.IsActive;
            if (copy.PawnInCell != null)
                this.PawnInCell = new Pawn(copy.PawnInCell);
            this.LocationInMatrix = new Point(copy.LocationInMatrix.X, copy.LocationInMatrix.Y);
        }

        internal void PaintCell(Graphics g, Point location)
        {
            using (SolidBrush brush = new SolidBrush(Color.Black))
            {
                if (IsActive)
                {
                    brush.Color = Color.Black;
                    g.FillRectangle(brush, location.X, location.Y, CELL_SIZE, CELL_SIZE);
                    if (PawnInCell != null && PawnInCell.IsPainted) //if cell has pawn, draw it!
                    {
                        location.X += Cell.PADDING_IN_CELL;
                        location.Y += Cell.PADDING_IN_CELL;
                        PawnInCell.Paint(g, location);
                    }
                }
                else
                {
                    brush.Color = Color.BurlyWood;
                    g.FillRectangle(brush, location.X, location.Y, CELL_SIZE, CELL_SIZE);
                }
            }
           
        }

        internal void SelectPawnInCell()
        {
            if (PawnInCell != null)
            {
                PawnInCell.IsSelected = true;
            }
        }

        internal void UnselectPawnInCell()
        {
            if (PawnInCell != null)
                PawnInCell.IsSelected = false;
        }
    }
}
