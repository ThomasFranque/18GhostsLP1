using System;
using System.Collections.Generic;
using System.Text;

namespace _18GhostsGame
{
    class GameMode
    {
        // How many ghosts of the same color need to leave to win
        public byte ToWin
        { get; private set; }

        // Personalized gamemode
        public GameMode(string[] userArg)
        {
            string gamemode;
            if (userArg.Length < 1)
                gamemode = " ";
            else
                gamemode = userArg[0];

            switch (gamemode)
            {
                // Quick gamemode
                case "quick":
                case "Quick":
                case "q":
                case "Q":
                    ToWin = 1;
                    break;

                // Standard gamemode
                case "":
                case " ":
                case null:
                    ToWin = 3;
                    break;
            }
        }
    }
}
