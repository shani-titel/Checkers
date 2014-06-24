using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace CheckersProject
{
    class Pawn
    {
        internal readonly int Id;
        internal static int idCounter = 0;
       
        internal bool IsSelected { get; set; }
        internal bool IsPainted;
        internal bool IsFaded; //?
        internal int Alpha { get; set; } //?

        internal SetOfPawns Set { get; set; }       

        internal Color PawnColor
        {
            get
            {
                return Set.PawnsColor;
            }
            
        }

        internal Shape PawnShape
        {
            get
            {
                return Set.PawnsShape;
            }
        }

        internal bool IsFilled
        {
            get
            {
                return Set.IsShapeFilled;
            }
        }
        internal int EdgeSize
        {
            get
            {
                return Set.PawnEdgeSize;
            }
        }

        public Pawn(SetOfPawns s)
        {
            //default constractor initilized all arguments with default values
            idCounter++;
            Id = idCounter;
            IsSelected = false;
            IsPainted = true;
            IsFaded = false;
            Alpha = 0;

            Set = s;
        }

        public Pawn(Pawn copy)
        {
            this.Id = idCounter++;
            this.IsSelected = copy.IsSelected;
            this.IsPainted = copy.IsPainted;
            this.IsFaded = copy.IsFaded;
            this.Alpha = copy.Alpha;
            this.Set = copy.Set;
        }

        private void PaintElipse(Graphics g, Brush brush, Pen pen, Point location)
        {
            if (this.IsFilled)
            {
                g.FillEllipse(brush, location.X, location.Y, this.EdgeSize, this.EdgeSize);
            }
            else
            {
                g.DrawEllipse(pen, location.X, location.Y, this.EdgeSize, this.EdgeSize);
            }
        }

        private void PaintSquare(Graphics g, Brush brush, Pen pen, Point location)
        {
            if (this.IsFilled)
            {
                g.FillRectangle(brush, location.X, location.Y, this.EdgeSize, this.EdgeSize);
            }
            else
            {
                g.DrawRectangle(pen, location.X, location.Y, this.EdgeSize, this.EdgeSize);
            }
        }

        private void PaintTriangle(Graphics g, Brush brush, Pen pen, Point location)
        {
            Point[] trianglePoints = { new Point(location.X,location.Y),
                                    new Point( location.X, location.Y+this.EdgeSize),
                                    new Point( location.X+this.EdgeSize, location.Y+this.EdgeSize)
                                    };
            if (this.IsFilled)
            {
                g.FillPolygon(brush, trianglePoints);
            }
            else
            {
                g.DrawPolygon(pen, trianglePoints);
            }
        }

        private void PaintRectangle(Graphics g, Brush brush, Pen pen, Point location)
        {
            if (this.IsFilled)
            {
                g.FillRectangle(brush, location.X, location.Y + (EdgeSize / 3), this.EdgeSize, this.EdgeSize / 3);
            }
            else
            {
                g.DrawRectangle(pen, location.X, location.Y + (EdgeSize / 3), this.EdgeSize, this.EdgeSize / 3);
            }
        }

        private void PaintHexagon(Graphics g, Brush brush, Pen pen, Point location)
        {
            int addConst = EdgeSize/3;
            Point[] hexagonPoints = { new Point(location.X+addConst,location.Y),
                                    new Point( location.X, location.Y+EdgeSize/2),
                                    new Point( location.X+addConst, location.Y+EdgeSize),
                                    new Point( location.X+addConst*2, location.Y+EdgeSize),
                                    new Point( location.X+EdgeSize, location.Y+EdgeSize/2),
                                    new Point( location.X+addConst*2, location.Y)
                                    };
            if (this.IsFilled)
            {
                g.FillPolygon(brush, hexagonPoints);
            }
            else
            {
                g.DrawPolygon(pen, hexagonPoints);
            }
        }


        internal void Paint(Graphics g, Point location)
        {
            Color currentColor;
            SolidBrush SelectedPawnBrush=null;
            if (Alpha != 0 && Alpha != 255 && IsFaded)//involve alpha 
            {
                if (this.IsSelected)//fade out
                {
                    currentColor = Color.FromArgb(Alpha, this.Set.SelectedPawnColor);
                    SelectedPawnBrush = new SolidBrush(currentColor);
                }
                else//fade in
                {
                    currentColor = Color.FromArgb(Alpha, this.PawnColor);
                }
            }
            else
            {
                currentColor = this.PawnColor;
                SelectedPawnBrush = new SolidBrush(this.Set.SelectedPawnColor);
            }
            SolidBrush pawnColorBrush = new SolidBrush(currentColor);

            Pen pen = new Pen(pawnColorBrush, 3);
            Pen SelectedPawnPen = new Pen(SelectedPawnBrush, 3);
            
            switch (this.PawnShape)
            {
                case (Shape.Elipse):
                    if (this.IsSelected)//---> change it into if on brush and not so much ifs here
                        PaintElipse(g, SelectedPawnBrush, SelectedPawnPen, location);
                    else
                        PaintElipse(g, pawnColorBrush, pen, location);
                    break;
                    
                case (Shape.Rectangle):
                    if (this.IsSelected)//---> change it into if on brush and not so much ifs here
                        PaintRectangle(g, SelectedPawnBrush, SelectedPawnPen, location);
                    else
                        PaintRectangle(g, pawnColorBrush, pen, location);
                    break;

                case (Shape.Square):
                    if (this.IsSelected)//---> change it into if on brush and not so much ifs here
                        PaintSquare(g, SelectedPawnBrush, SelectedPawnPen, location);
                    else
                         PaintSquare(g, pawnColorBrush, pen, location);
                    break;

                case (Shape.Triangle):
                    if (this.IsSelected)//---> change it into if on brush and not so much ifs here
                        PaintTriangle(g, SelectedPawnBrush, SelectedPawnPen, location);
                    else
                        PaintTriangle(g, pawnColorBrush, pen, location);
                    break;

                case (Shape.Hexagon):
                    if (this.IsSelected)//---> change it into if on brush and not so much ifs here
                        PaintHexagon(g, SelectedPawnBrush, SelectedPawnPen, location);
                    else
                        PaintHexagon(g, pawnColorBrush, pen, location);
                    break;
            }

            pawnColorBrush.Dispose();
            pen.Dispose();
            SelectedPawnPen.Dispose();
            if(SelectedPawnBrush != null)
                SelectedPawnBrush.Dispose();
        }
    }

    public enum Shape
    {
        Elipse,
        Triangle,
        Square,
        Rectangle,
        Hexagon
    };
}
