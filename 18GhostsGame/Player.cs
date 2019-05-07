using System;
using System.Collections.Generic;
using System.Text;

namespace _18GhostsGame
{
    class Player
    {
        private Ghosts ghosts;

        private byte playerNum;

        public byte[,] EnemyGhosts { set; get; }

        // Constructor
        public Player(byte playerNum)
        {
            ghosts = new Ghosts();
            this.playerNum = playerNum == 1 ? (byte)(1) : (byte)(2);
            EnemyGhosts =
            new byte[3, 3] { { 0, 2, 0 }, { 0, 0, 0 }, { 0, 0, 0 } };
        }

        public void ResetGhosts()
        {
            ghosts.ResetGhosts();
        }

        public void Action()
        {
            ghosts.Move(EnemyGhosts);
        }


        public byte GetPlayerNum() => playerNum;

        public byte[,] GetGhosts() => ghosts.AllGhosts;


    }
}
