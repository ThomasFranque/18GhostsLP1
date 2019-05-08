using System;
using System.Collections.Generic;
using System.Text;

namespace _18GhostsGame
{
    class GhostInteractions
    {
        // victim 1
        // attacker 0
        public void Conflict(byte[] attacker, byte[] victim,
            byte[,] allGhosts, byte[,] enemyGhosts)
        {
            bool attackerWins = false;
            byte attackerColor = attacker[0];
            byte victimColor = victim[0];

            attackerColor++;

            if (attackerColor > victimColor ||
                (attackerColor == 1 && victimColor == 2))
                attackerWins = false;
            else
                attackerWins = true;

            if (attackerWins &&
                !ThroughWall(allGhosts[attacker[0], attacker[1]],
                enemyGhosts[victim[0], victim[1]]))
            {
                KillGhost(ref enemyGhosts[victim[0], victim[1]]);
                Portal.Rotate(victim[0]);
            }
            else if (!ThroughWall(allGhosts[attacker[0], attacker[1]],
                enemyGhosts[victim[0], victim[1]]))
            {
                KillGhost(ref allGhosts[attacker[0], attacker[1]]);
                Portal.Rotate(attacker[0]);
            }
        }

        private void KillGhost(ref byte targetGhost)
        {
            targetGhost = 0;
        }

        private bool ThroughWall(byte attackerGhost, byte victimGhost)
        {
            bool throughWall = false;
            bool leftWall = false;
            bool rightWall = false;

            switch (attackerGhost)
            {
                // Check left wall
                case 1:
                case 6:
                case 11:
                case 16:
                case 21:
                    leftWall = true;
                    break;

                // Check right wall
                case 5:
                case 10:
                case 15:
                case 20:
                case 25:
                    rightWall = true;
                    break;
            }

            // Check if victim is on the other wall
            if (leftWall)
                // Check right wall
                switch (victimGhost)
                {
                    case 5:
                    case 10:
                    case 15:
                    case 20:
                        throughWall = true;
                        break;
                }
            else if (rightWall)
            {
                // Check right wall
                switch (victimGhost)
                {
                    case 6:
                    case 11:
                    case 16:
                    case 21:
                        throughWall = true;
                        break;
                }
            }
            return throughWall;
        }
    }
}
