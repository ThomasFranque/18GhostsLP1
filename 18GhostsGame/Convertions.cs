using System;
using System.Collections.Generic;
using System.Text;

namespace _18GhostsGame
{
    class Convertions
    {
        // Will return the line and character to be printed
        public static byte[] NormalizePositions(byte ghost)
        {
            //  normalizedPos = { line, character };
            byte[] normalizedPos = new byte[] { 0, 0 };
            byte line = 0;

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

        // Will return the character number in a line
        private static byte FindCharacterInLine(byte ghost)
        {
            // ****************************
            // BETTER SOLUTION IN THE WORKS
            // ****************************

            byte finalCharacter = 0;

            switch (ghost)
            {
                case 0:
                    break;

                case 1:
                case 6:
                case 11:
                case 16:
                case 21:
                    finalCharacter = 3;
                    break;

                case 2:
                case 7:
                case 12:
                case 17:
                case 22:
                    finalCharacter = 9;
                    break;

                case 3:
                case 8:
                case 13:
                case 18:
                case 23:
                    finalCharacter = 15;
                    break;

                case 4:
                case 9:
                case 14:
                case 19:
                case 24:
                    finalCharacter = 21; 
                    break;

                case 5:
                case 10:
                case 15:
                case 20:
                case 25:
                    finalCharacter = 27;
                    break;

                default:
                    BoardRenderer.Error("FindCharacterInLine() in Board.cs",
                        "Given Ghost position doesn't exist");
                    break;

            }
            return finalCharacter;

            /* 
             * Will be erased when a better solution is found
             * 
            //bool keepRunning = true;
            if (keepRunning)
                for (byte k = 1; k <= 21; k += 5)
                    if (ghost == k)
                    {
                        finalCharacter = 3;
                        k = 22;
                        keepRunning = false;
                    }
            if (keepRunning)
                for (byte k = 2; k <= 22; k += 5)
                    if (ghost == k)
                    {
                        finalCharacter = 9;
                        k = 23;
                        keepRunning = false;
                    }
            if (keepRunning)
                for (byte k = 3; k <= 23; k += 5)
                    if (ghost == k)
                    {
                        finalCharacter = 15;
                        k = 24;
                        keepRunning = false;
                    }
            if (keepRunning)
                for (byte k = 4; k <= 24; k += 5)
                    if (ghost == k)
                    {
                        finalCharacter = 21;
                        k = 25;
                        keepRunning = false;
                    }
            if (keepRunning)
                for (byte k = 5; k <= 25; k += 5)
                    if (ghost == k)
                    {
                        finalCharacter = 27;
                        k = 26;
                    }
            return finalCharacter;
            */
        }
    }
}
