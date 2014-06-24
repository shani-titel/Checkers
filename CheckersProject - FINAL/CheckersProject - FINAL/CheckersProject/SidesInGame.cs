using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CheckersProject
{
    partial class SidesInGame
    {
        public SidesInGame(int gameId, int groupId, int playerId)
            : this()
        {
            this.side_GameID = gameId;
            
            if(groupId != 0)
                this.side_GroupId = groupId;
            else
                this.side_GroupId = 1;
            
            if (playerId != 0)
                this.side_PlayerId = playerId;
            else
                this.side_PlayerId = 1;
            
        }
    }
}
