using System;
using System.Collections.Generic;
using System.Text;

namespace _18GhostsGame
{
    class GhostChecker
    {
        // This method is for returning the ghost in the target location
        // (target is for the single ghost and allGhosts is for 
        // where it is contained)
        // finalGhost is the ghost in the target location if it returns
        // 0,0 there is no ghost there
        // finalGhost[0] = Which ghost: first, second or third
        // finalGhost[1] = Color of the ghost: red, blue, yellow
        public static byte[] CheckAdjacentPos
            (char direction, byte targetGhost, byte[,] enemyGhosts)
        {
            // occupied = Ghost There
            byte[] enemyGhost = new byte[2] { 0, 0 };
            byte targetPos;
            targetPos = DesiredPosition(direction, targetGhost);

            if (CheckAllForEqual(targetPos, enemyGhosts))
                enemyGhost = FindGhost(targetPos, enemyGhosts);

            return enemyGhost;
        }

        public static byte[] FindGhost(byte targetGhost, byte[,] allGhosts)
        {
            // enemyGhost
            byte[] finalGhost = new byte[2] { 0, 0 };
            byte counter = 0;

            foreach (byte ghost in allGhosts)
            {
                if (finalGhost[0] == 0)
                    counter++;
                else
                    break;

                // Check for the same target ghost number on player ghosts
                if (ghost == targetGhost)
                    switch (counter)
                    {
                        // Ghost 1
                        case 1:
                        case 4:
                        case 7:
                            finalGhost[0] = 1;
                            break;
                        // Ghost 2
                        case 2:
                        case 5:
                        case 8:
                            finalGhost[0] = 2;
                            break;
                        // Ghost 3
                        case 3:
                        case 6:
                        case 9:
                            finalGhost[0] = 3;
                            break;
                    }
            }
            // Check corresponding ghost color
            // Red ghosts
            if (counter <= 3)
                finalGhost[1] = 1;
            // Blue ghosts
            else if (counter <= 6)
                finalGhost[1] = 2;
            // Yellow ghosts
            else
                finalGhost[1] = 3;

            return finalGhost;
        }

        private static bool CheckAllForEqual(byte targetPos, byte[,] allGhosts)
        {
            bool isEqual = false;

            foreach (byte ghost in allGhosts)
            {
                if (targetPos == ghost)
                {
                    isEqual = true;
                    break;
                }
            }
            return isEqual;
        }

        private static byte DesiredPosition(char direction, byte targetGhost)
        {
            byte targetPos = 0;

            switch (direction)
            {
                // Up
                case 'u':
                    targetPos = (byte)(targetGhost - 5);
                    break;
                // Down
                case 'd':
                    targetPos = (byte)(targetGhost + 5);
                    break;
                // Left
                case 'l':
                    targetPos = (byte)(targetGhost - 1);
                    break;
                // Right
                case 'r':
                    targetPos = (byte)(targetGhost + 1);
                    break;
            }

            return targetPos;
        }

    }
}
