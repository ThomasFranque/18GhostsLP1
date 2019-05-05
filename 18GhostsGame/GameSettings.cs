using System;
using System.Collections.Generic;
using System.Text;

namespace _18GhostsGame
{
    static class GameSettings
    {
        private static byte toWin;
        public static byte ToWin
        {
            get => toWin;
            set
            {
                if (value <= 3)
                    toWin = value;
            }
        }

        // Number of complete games to play
        public static byte Rounds { get; set; } = 1;
    }
}
