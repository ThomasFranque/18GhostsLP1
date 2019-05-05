using System;
using System.Collections.Generic;
using System.Text;

namespace _18GhostsGame
{
    static class GameSettings
    {
        public static byte ToWin
        {
            get => ToWin;
            set { if (value <= 3) ToWin = value; }
        }

        public static bool Teams { get; set; }

        public static byte Rounds { get; set; }

        // If max rounds == null there is no round limit
        public static byte MaxRounds
        {
            get => MaxRounds;
            set { if (value >= 7) MaxRounds = value; }
        }
    }
}
