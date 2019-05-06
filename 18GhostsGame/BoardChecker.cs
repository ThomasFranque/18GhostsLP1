using System;
using System.Collections.Generic;
using System.Text;

namespace _18GhostsGame
{
    class BoardChecker
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

        // ######PLAYER######

    }
}
