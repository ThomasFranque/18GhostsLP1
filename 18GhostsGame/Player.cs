using System;
using System.Collections.Generic;
using System.Text;

namespace _18GhostsGame
{
    class Player
    {
        private Ghosts ghosts;

        private byte playerNum;

        public byte[,] EnemyGhosts { get; set; } = new byte[3, 3] { { 0, 2, 0 }, { 0, 0, 0 }, { 0, 0, 0 } };

        // Constructor
        public Player(byte playerNum)
        {
            ghosts = new Ghosts();
            this.playerNum = playerNum == 1 ? (byte)(1) : (byte)(2);
        }

        public void Action()
        {
            ghosts.Move(EnemyGhosts);
        }


        public byte GetPlayerNum() => playerNum;

        public byte[,] GetGhosts() => ghosts.AllGhosts;


    }
}
