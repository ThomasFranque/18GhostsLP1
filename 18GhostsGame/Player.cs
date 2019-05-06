using System;
using System.Collections.Generic;
using System.Text;

namespace _18GhostsGame
{
    class Player
    {
        Ghosts ghosts;
        byte playerNum;
        
        // Constructor
        public Player(byte playerNum)
        {
            ghosts = new Ghosts();
            this.playerNum = playerNum == 1 ? (byte)(1) : (byte)(2);
        }

        public void Action()
        {
            ghosts.Move();
        }

        public byte GetPlayerNum() => playerNum;

        public byte[,] GetGhosts() => ghosts.AllGhosts;
    }
}
