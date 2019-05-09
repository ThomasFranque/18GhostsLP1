namespace _18GhostsGame
{
    /// <summary>
    /// Used by board to check for positions and symbols
    /// </summary>
    class BoardChecker
    {
        /// <summary>
        /// Used to check the location of objects besides ghosts on the board
        /// </summary>
        /// <param name="target">Target object name</param>
        /// <param name="line">Current line</param>
        /// <param name="j">Current character space</param>
        /// <returns></returns>
        public bool CheckInBoard(string target, byte line, byte j)
        {
            // Temporary method variable
            bool isHere = false;

            // Know what object to look for
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

        /// <summary>
        ///  Used to check the location of ghosts on the board
        /// </summary>
        /// <param name="ghostPos">Normalized ghost position</param>
        /// <param name="line">Current line</param>
        /// <param name="j">Current character space</param>
        /// <returns></returns>
        public bool CheckInBoard(byte[] ghostPos, byte line, byte j)
        {
            // Temporary variable
            bool isHere = false;

            // Check if it is the ghost place
            if (ghostPos[0] == line && ghostPos[1] == j)
                isHere = true;

            return isHere;
        }

        /// <summary>
        /// Finds ghost to print symbol
        /// </summary>
        /// <param name="targetGhost">Target ghost position</param>
        /// <param name="allGhosts">Target player ghosts</param>
        /// <returns>Ghost letter and color</returns>
        public byte[] FindGhost(byte targetGhost, byte[,] allGhosts)
        {
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
