namespace _18GhostsGame
{
    /// <summary>
    /// Static class that controls the portals, free ghosts and winner
    /// </summary>
    static class Portal
    {
        // Initializing auto-properties
        public static string RedPortalState { get; private set; }

        public static string BluePortalState { get; private set; }

        public static string YellowPortalState { get; private set; }

        // Initializing bi-dimentional 
        // auto-property that holds the free ghosts as:
        // Player 1 free ghosts = ghostsOut[0]
        // Player 1 free ghosts = ghostsOut[1]
        // The remaining indexes are for the colors: Red Blue Yellow.
        public static byte[,] ghostsOut { get; private set; }

        /// <summary>
        /// Constructor Portal assigns properties with default values
        /// </summary>
        static Portal()
        {
            // Initializing Portals with default positions
            RedPortalState = "up";
            BluePortalState = "down";
            YellowPortalState = "right";
            ghostsOut = new byte[2, 3] { { 0, 0, 0 }, { 0, 0, 0 } };
        }

        /// <summary>
        /// Receives the dead ghost color 
        /// and rotates the portal of the same color
        /// </summary>
        /// <param name="color">Dead ghost color</param>
        public static void Rotate(byte color)
        {
            switch (color)
            {
                // Red
                case 0:
                    RedPortalState = NewRotation(RedPortalState);
                    break;
                // Blue
                case 1:
                    BluePortalState = NewRotation(BluePortalState);
                    break;
                // Yellow
                case 2:
                    YellowPortalState = NewRotation(YellowPortalState);
                    break;
            }
        }

        /// <summary>
        /// Aids Rotate method, returning the next portal rotation (clockwise)
        /// </summary>
        /// <param name="portal">Target portal</param>
        /// <returns>New portal rotation</returns>
        private static string NewRotation(string portal)
        {
            // Temporary method variable
            string newPosition = "";

            // Check current portal rotation
            switch (portal)
            {
                // Current position Up
                case "up":
                    newPosition = "right";
                    break;

                // Current position Down
                case "down":
                    newPosition = "left";
                    break;

                // Current position Right
                case "right":
                    newPosition = "down";
                    break;

                // Current position left
                case "left":
                    newPosition = "up";
                    break;
            }
            return newPosition;
        }

        /// <summary>
        /// Checks if any of the player 1 ghosts and player 2 ghosts 
        /// are next to the open side of the portal
        /// </summary>
        /// <param name="ghostsP1">Every Player 1 ghosts</param>
        /// <param name="ghostsP2">Every Player 2 ghosts</param>
        public static void GhostsOutCheck(byte[,] ghostsP1, byte[,] ghostsP2)
        {
            // Check player 1
            CheckPlayerGhosts(ghostsP1);
            
            // Check player 2
            CheckPlayerGhosts(ghostsP2);
        }

        /// <summary>
        /// Will check if any ghost of the target player can leave
        /// </summary>
        /// <param name="playerGhosts">Target player</param>
        private static void CheckPlayerGhosts(byte[,] playerGhosts)
        {
            // Temporary method variables representing indexes
            byte color = 0;
            byte letter = 0;

            // Check if the position of every ghost is 
            // equal to the open side of the portal
            foreach (byte ghost in playerGhosts)
            {
                // Check if the ghost is a red ghost
                if (color == 0)
                    // Check in Red portal open space
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
                // Check if the ghost is a blue ghost
                else if (color == 1)
                    // Check in Blue portal open space
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
                // Yellow ghost
                else
                    // Check in Yellow portal open space
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

                // Increment ghost color and ghost indexes
                letter++;
                if (letter == 3)
                {
                    letter = 0;
                    color++;
                }
            }
        }

        /// <summary>
        /// Aids CheckPlayerGhosts method, returning if a ghost should escape
        /// </summary>
        /// <param name="ghosts">Target player ghosts</param>
        /// <param name="pos">Numerical Portal position</param>
        /// <returns>If a ghost escaped</returns>
        private static bool CheckEscape(byte[,] ghosts, byte pos)
        {
            // Temporary method variable
            bool escape = false;

            // Check all the ghosts
            foreach (byte ghost in ghosts)
                if (ghost == pos)
                {
                    escape = true;
                    break;
                }

            return escape;
        }

        /// <summary>
        /// Assigns the free ghost position to 26 (out of bounds)
        /// </summary>
        /// <param name="ghost">Target free ghost</param>
        private static void GhostEscape(ref byte ghost)
        {
            ghost = 26;
        }

        /// <summary>
        /// Is used to know if any of the players reached the game final goal
        /// of free ghosts
        /// </summary>
        /// <param name="toWin">Ghosts of the same color needed to win</param>
        /// <returns>True if a player won</returns>
        public static bool PlayerWon(byte toWin)
        {
            bool won = false;

            foreach (byte score in ghostsOut)
                if (score == toWin)
                    won = true;

            return won;
        }

        /// <summary>
        /// Is used to know which of the players won
        /// </summary>
        /// <param name="toWin">Ghosts of the same color needed to win</param>
        /// <returns>The winning player</returns>
        public static string CheckWinner(byte toWin)
        {
            string won = "1";
            byte counter = 0;

            foreach (byte score in ghostsOut)
            {
                counter++;

                if (score == toWin && counter <= 3)
                {
                    won = "1";
                    break;
                }
                else
                {
                    won = "2";
                }

            }
            return won;
        }
    }
}
