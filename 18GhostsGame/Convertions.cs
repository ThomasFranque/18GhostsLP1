namespace _18GhostsGame
{
    /// <summary>
    /// Normalizes positions to be used on board methods
    /// </summary>
    class Convertions
    {
        /// <summary>
        /// Finds the line and character of the ghost
        /// </summary>
        /// <param name="ghost">Target ghost</param>
        /// <returns>Line and character of the target ghost</returns>
        public static byte[] NormalizePositions(byte ghost)
        {
            //  normalizedPos = { line, character spot};
            byte[] normalizedPos = new byte[] { 0, 0 };
            byte line = 0;

            // Find line and character spot
            for (byte i = 0; i <= ghost; i += 1)
                if (ghost == i)
                {
                    normalizedPos[0] = line;
                    normalizedPos[1] = FindCharacterInLine(ghost);
                }
                else if (i % 5 == 0)
                    line++;

            return normalizedPos;
        }

        /// <summary>
        /// Finds ghost character number
        /// </summary>
        /// <param name="ghost">Target ghost</param>
        /// <returns>Number of the character space</returns>
        private static byte FindCharacterInLine(byte ghost)
        {
            // Temporary variable
            byte finalCharacter = 0;

            switch (ghost)
            {
                // In dungeon
                case 0:
                    break;

                // In first column
                case 1:
                case 6:
                case 11:
                case 16:
                case 21:
                    finalCharacter = 3;
                    break;

                // In second column
                case 2:
                case 7:
                case 12:
                case 17:
                case 22:
                    finalCharacter = 9;
                    break;

                // In third column
                case 3:
                case 8:
                case 13:
                case 18:
                case 23:
                    finalCharacter = 15;
                    break;

                // In fourth column
                case 4:
                case 9:
                case 14:
                case 19:
                case 24:
                    finalCharacter = 21; 
                    break;

                // In fifth column
                case 5:
                case 10:
                case 15:
                case 20:
                case 25:
                    finalCharacter = 27;
                    break;
            }
            return finalCharacter;
        }
    }
}
