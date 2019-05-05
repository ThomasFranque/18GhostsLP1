using System;
using System.Collections.Generic;
using System.Text;

namespace _18GhostsGame
{
    class Checker
    {
        // Used by Board for props
        public static bool CheckInBoard(string target, byte line, byte j)
        {
            bool isHere = false;

            switch (target)
            {
                // mirrors
                case "mirror":
                    if ((j == 9 && line % 2 == 0) ||
                        (j == 21 && line % 2 == 0))
                        isHere = true;
                    break;
                // Red portal
                case "red":
                    if (j == 15 && line == 1)
                        isHere = true;
                    break;
                // Blue portal
                case "blue":
                    if (j == 15 && line == 5)
                        isHere = true;
                    break;
                // Yellow portal
                case "yellow":
                    if (j == 27 && line == 3)
                        isHere = true;
                    break;
                case "column":
                    if (j % 6 == 0)
                        isHere = true;
                    break;
                // Middle spots
                case "middle":
                    if (j % 3 == 0)
                        isHere = true;
                    break;

            }

            return isHere;
        }

        // Used by the Board for ghosts
        public static bool CheckInBoard(byte[] ghostPos, byte line, byte j)
        {
            bool isHere = false;

            if (ghostPos[0] == line && ghostPos[1] == j)
                isHere = true;

            return isHere;
        }


        // Check if given direction has a ally ghost there
        public static bool CheckAdjacentPos
            (char direction, byte targetGhost, byte[,] playerGhosts)
        {
            // occupied = Ghost There
            bool occupied = false;
            byte targetPos;
            targetPos = DesiredPosition(direction, targetGhost);

            if (CheckAllForEqual(targetPos, playerGhosts))
                occupied = true;

            return occupied;
        }

        // Check if given direction has a ally ghost there
        public static byte[] CheckAdjacentPosEnemy
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

        // This method is for returning the given ghost 
        // (target is for the single ghost and allGhosts is for 
        // where it is contained)
        // finalGhost[0] = Wihch ghost: first, second or third
        // finalGhost[1] = Color of the ghost: red, blue, yellow
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
    }
}
