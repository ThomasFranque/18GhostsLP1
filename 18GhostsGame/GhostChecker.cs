using System;
using System.Collections.Generic;
using System.Text;

namespace _18GhostsGame
{
    class GhostChecker
    {
        //ALTERAR STATICS PARA NAO STATIC

        // This method is for returning the ghost in the target location
        // (target is for the single ghost and allGhosts is for 
        // where it is contained)
        // finalGhost is the ghost in the target location if it returns
        // 4,0 there is no ghost there
        // finalGhost[0] = Which ghost: first, second or third
        // finalGhost[1] = Color of the ghost: red, blue, yellow
        public byte[] CheckAdjacentPos
            (char direction, byte targetGhost, byte[,] enemyGhosts)
        {
            byte[] enemyGhost = new byte[2] { 4, 0 };
            byte targetPos;
            targetPos = DesiredPosition(direction, targetGhost);

            if (CheckAllForEqual(targetPos, enemyGhosts))
                enemyGhost = FindGhost(targetPos, enemyGhosts);

            return enemyGhost;
        }
        public byte[] FindGhost(byte targetGhost, byte[,] allGhosts)
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
                            finalGhost[0] = 0;
                            break;
                        // Ghost 2
                        case 2:
                        case 5:
                        case 8:
                            finalGhost[0] = 1;
                            break;
                        // Ghost 3
                        case 3:
                        case 6:
                        case 9:
                            finalGhost[0] = 2;
                            break;
                    }
            }
            // Check corresponding ghost color
            // Red ghosts
            if (counter <= 3)
                finalGhost[1] = 0;
            // Blue ghosts
            else if (counter <= 6)
                finalGhost[1] = 1;
            // Yellow ghosts
            else
                finalGhost[1] = 2;

            return finalGhost;
        }

        // Used for checking ghosts
        private bool CheckAllForEqual(byte targetPos, byte[,] allGhosts)
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

        // Used for checking obstacles (Portals)
        private bool CheckAllForEqual(byte pos, byte[] obstacles)
        {
            bool obstacle = false;

            // Is in dungeon?
            if (pos == 0)
                obstacle = true;
            // If not, check given obstacles
            else
            foreach (byte position in obstacles)
                if (position == pos)
                {
                    obstacle = true;
                    break;
                }

            return obstacle;
        }

        // Where it will end up
        public byte DesiredPosition(char direction, byte targetGhost)
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

        public bool NoObstacle(char direction, byte pos)
        {
            bool canMove = false;

            switch (direction)
            {
                // Moving Up
                case 'u':                    
                    if (pos > 5 && 
                        !CheckAllForEqual(pos, new byte[] { 8, 20 }))
                        canMove = true;
                    break;
                // Moving Down
                case 'd':
                    if (pos <= 21 && 
                        !CheckAllForEqual(pos, new byte[] { 10, 18 }))
                        canMove = true;
                    break;
                // Moving Left
                case 'l':
                    if (!CheckAllForEqual(pos, 
                        new byte[] { 1, 4, 6, 11, 16, 21, 24 }))
                        canMove = true;
                    break;
                // Moving Right
                case 'r':
                    if (!CheckAllForEqual(pos,
                        new byte[] { 2, 5, 10, 14, 15, 20, 22, 25}))
                        canMove = true;
                    break;
            }

            return canMove;
        }

    }
}
