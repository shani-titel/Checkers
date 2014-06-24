using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CheckersProject
{
    partial class Game
    {
        public Game(int boardSize, bool isSinglePlayer, bool isComputerSmart= false)
            :this()
        {
            this.game_BoardSize = boardSize;
            this.game_IsSinglePlayer = isSinglePlayer;
            this.game_Date = DateTime.Now;
            if (isSinglePlayer)
                this.game_IsSmartComputer = isComputerSmart;
        }
    }
}
