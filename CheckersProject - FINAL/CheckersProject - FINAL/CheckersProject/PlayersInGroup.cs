using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CheckersProject
{
    partial class PlayersInGroup
    {
        public PlayersInGroup(int groupId, int playerId)
            : this()
        {
            this.playerInGroup_GroupID = groupId;
            this.playerInGroup_PlayerID = playerId;
        }
    }
}
