using System;
using System.Collections.Generic;
using System.Text;

namespace _18GhostsGame
{
    static class Portal
    {
        public static string RedPortalState { get; private set; }

        public static string BluePortalState { get; private set; }

        public static string YellowPortalState { get; private set; }

        // Player 1 = ghostsOut[0]
        // Player 2 = ghostsOut[1]
        public static byte[,] ghostsOut { get; private set; }

        static Portal()
        {
            // Initializing Portals with default positions
            RedPortalState = "up";
            BluePortalState = "down";
            YellowPortalState = "right";
            ghostsOut = new byte[2, 3] { { 0, 0, 0 }, { 0, 0, 0 } };
        }

        // Used outside of class to know what ghost died
        public static void Rotate(byte color)
        {
            switch (color)
            {
                case 0:
                    RedPortalState = NewRotation(RedPortalState);
                    break;
                case 1:
                    BluePortalState = NewRotation(BluePortalState);
                    break;
                case 2:
                    YellowPortalState = NewRotation(YellowPortalState);
                    break;
            }
        }

        // Returns the new rotation, clockwise, of the given portal
        private static string NewRotation(string portal)
        {
            string newPosition = "";
            switch (portal)
            {
                case "up":
                    newPosition = "right";
                    break;

                case "down":
                    newPosition = "left";
                    break;

                case "right":
                    newPosition = "down";
                    break;

                case "left":
                    newPosition = "up";
                    break;
            }
            return newPosition;
        }

        public static void GhostsOutCheck(byte[,] ghostsP1, byte[,] ghostsP2)
        {
            CheckPlayerGhosts(ghostsP1);
            CheckPlayerGhosts(ghostsP2);
        }

        private static bool CheckEscape(byte[,] ghosts, byte pos)
        {
            bool escape = false;
            foreach (byte ghost in ghosts)
                if (ghost == pos)
                {
                    escape = true;
                    break;
                }
            return escape;
        }

        private static void GhostEscape(ref byte ghost)
        {
            ghost = 26;
        }

        private static void CheckPlayerGhosts(byte[,] playerGhosts)
        {
            byte color = 0;
            byte letter = 0;

            foreach (byte ghost in playerGhosts)
            {
                if (color == 0)
                    switch (RedPortalState)
                    {
                        case "down":
                            if (CheckEscape(playerGhosts, 8))
                            {
                                GhostEscape(ref playerGhosts[color, letter]);
                                ghostsOut[0, 0]++;
                            }

                            break;

                        case "right":
                            if (CheckEscape(playerGhosts, 4))
                            {
                                GhostEscape(ref playerGhosts[color, letter]);
                                ghostsOut[0, 0]++;
                            }
                            break;

                        case "left":
                            if (CheckEscape(playerGhosts, 2))
                            {
                                GhostEscape(ref playerGhosts[color, letter]);
                                ghostsOut[0, 0]++;
                            }
                            break;
                    }
                else if (color == 1)
                    switch (BluePortalState)
                    {
                        case "up":
                            if (CheckEscape(playerGhosts, 18))
                            {
                                GhostEscape(ref playerGhosts[color, letter]);
                                ghostsOut[1, 0]++;
                            }
                            break;

                        case "right":
                            if (CheckEscape(playerGhosts, 24))
                            {
                                GhostEscape(ref playerGhosts[color, letter]);
                                ghostsOut[1, 0]++;
                            }
                            break;

                        case "left":
                            if (CheckEscape(playerGhosts, 22))
                            {
                                GhostEscape(ref playerGhosts[color, letter]);
                                ghostsOut[1, 0]++;
                            }
                            break;
                    }
                else
                    switch (YellowPortalState)
                    {
                        case "down":
                            if (CheckEscape(playerGhosts, 20))
                            {
                                GhostEscape(ref playerGhosts[color, letter]);
                                ghostsOut[2, 0]++;
                            }
                            break;

                        case "left":
                            {
                                if (CheckEscape(playerGhosts, 14))
                                    GhostEscape(ref playerGhosts[color, letter]);
                                ghostsOut[2, 0]++;
                            }
                            break;

                        case "up":
                            if (CheckEscape(playerGhosts, 10))
                            {
                                GhostEscape(ref playerGhosts[color, letter]);
                                ghostsOut[2, 0]++;
                            }
                            break;
                    }

                letter++;
                if (letter == 3)
                {
                    letter = 0;
                    color++;
                }
            }
        }

        public static bool PlayerWon(byte toWin)
        {
            bool won = false;

            foreach (byte score in ghostsOut)
                if (score == toWin)
                    won = true;

            return won;
        }

        public static char CheckWinner(byte toWin)
        {
            char won = '1';
            byte counter = 0;

            foreach (byte score in ghostsOut)
            {
                counter++;

                if (score == toWin && counter <= 3)
                {
                    won = '1';
                    break;
                }
                else
                {
                    won = '2';
                }

            }

            return won;
        }
    }
}
