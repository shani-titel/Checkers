using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CheckersProject
{
    class Path
    {
        public Move First { get; set; }
        Move Second;
        Move Third;

        public Path()
        {
            First = Second = Third = null;
        }
        public Path(Move move1, Move move2, Move move3)
        {
            First = move1;
            Second = move2;
            Third = move3;
        }

        public int PathValue()
        {
            return (2 * First.value + Second.value + Third.value);
        }
    }
}
