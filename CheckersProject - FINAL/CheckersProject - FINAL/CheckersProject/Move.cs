using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CheckersProject
{
    class Move
    {
        public Cell origin;
        public Cell target;
        public Cell eaten;
        public int value = 0; //for AI

        public Move()
        {
            origin = null;
            target = null;
            eaten = null;
            value = 0;
        }
        public Move(Cell o, Cell t)
        {
            origin = o;
            target = t;
        }
        public Move(Cell o, Cell t, Cell e)
        {
            origin = o;
            target = t;
            eaten = e;
        }

        public void Execute()
        {
            if (origin != null && origin.PawnInCell != null && target != null)
            {
                target.PawnInCell = origin.PawnInCell;
                origin.PawnInCell = null;
            }
        }
    }
}
