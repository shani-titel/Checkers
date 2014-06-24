using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CheckersProject
{
    class Node
    {
        public List<Move> PotentialMoves;
        public List<Node> sons;
        public Cell[,] currGameBoard;

        public Node(Cell[,] gameb)
        {
            PotentialMoves = new List<Move>();
            sons = new List<Node>();
            currGameBoard = gameb;
        }

        public void AddSon(Node n)
        {
            sons.Add(n);
        }
        public void AddValueToMove(Move m, int val)
        {
            Move k = PotentialMoves.Find(mv => mv == m);
            k.value += val;//add value to potenial given move
        }
    }
}
