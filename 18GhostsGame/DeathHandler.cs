using System;
using System.Collections.Generic;
using System.Text;

namespace _18GhostsGame
{
    class DeathHandler
    {
        Player player1, player2;

        public DeathHandler(Player player1, Player player2)
        {
            this.player1 = player1;
            this.player2 = player2;
        }

        public void UpdateGhosts(Player player1, Player player2)
        {
            this.player1 = player1;
            this.player2 = player2;
        }

        public void KillGhost(byte targetPlayerGhost)
        {
            targetPlayerGhost = 0;
        }

    }
}
