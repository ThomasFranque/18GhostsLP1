namespace _18GhostsGame
{
    /// <summary>
    /// Handles Conflicts, ghost deaths and wall checks
    /// </summary>
    class GhostInteractions
    {
        /// <summary>
        /// Resolves conflicts between ghosts
        /// </summary>
        /// <param name="attacker">Attacker ghost</param>
        /// <param name="victim">Victim ghost</param>
        /// <param name="allGhosts">Attacker ghost team</param>
        /// <param name="enemyGhosts">Victim ghost team</param>
        public void Conflict(byte[] attacker, byte[] victim,
            byte[,] allGhosts, byte[,] enemyGhosts)
        {
            // Temporary variables
            bool attackerWins = false;
            byte attackerColor = attacker[0];
            byte victimColor = victim[0];

            // Increment attacker color for easier check
            attackerColor++;

            // Check if the attacker doesn't win
            if (attackerColor > victimColor ||
                (attackerColor == 1 && victimColor == 2))
                attackerWins = false;
            // Attacker wins
            else
                attackerWins = true;

            // Not allowing to kill ghosts through walls
            // If not through wall and attacker wins
            if (attackerWins &&
                !ThroughWall(allGhosts[attacker[0], attacker[1]],
                enemyGhosts[victim[0], victim[1]]))
            {
                // Kill the victim
                KillGhost(ref enemyGhosts[victim[0], victim[1]]);
                // Rotate the portal of the respective color
                Portal.Rotate(victim[0]);
            }
            // If not through wall and victim wins
            else if (!ThroughWall(allGhosts[attacker[0], attacker[1]],
                enemyGhosts[victim[0], victim[1]]))
            {
                // Kill the attacker
                KillGhost(ref allGhosts[attacker[0], attacker[1]]);
                // Rotate the portal of the respective color
                Portal.Rotate(attacker[0]);
            }
        }

        /// <summary>
        /// Send target ghost to the dungeon
        /// </summary>
        /// <param name="targetGhost">Target ghost to kill</param>
        private void KillGhost(ref byte targetGhost)
        {
            // Set the ghost to 0 (dungeon)
            targetGhost = 0;
        }

        /// <summary>
        /// Check if attacking through wall
        /// </summary>
        /// <param name="attackerGhost">Attacker ghost</param>
        /// <param name="victimGhost">Victim ghost</param>
        /// <returns>True if attacking through wall</returns>
        private bool ThroughWall(byte attackerGhost, byte victimGhost)
        {
            // Temporary variables
            bool throughWall = false;
            bool leftWall = false;
            bool rightWall = false;

            // Check if the attacker is on a wall
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

            // If attacker is on the left wall
            if (leftWall)
                // Check if victim is on right wall
                switch (victimGhost)
                {
                    case 5:
                    case 10:
                    case 15:
                    case 20:
                        throughWall = true;
                        break;
                }
            // If attacker is on the right wall
            else if (rightWall)
            {
                // Check if victim is on left wall
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
