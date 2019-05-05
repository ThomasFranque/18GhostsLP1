using System;
using System.Collections.Generic;
using System.Text;

namespace _18GhostsGame
{
    class GameMode
    {
        // How many ghosts of the same color need to leave to win
        private byte toWin;
        public byte ToWin
        { get => toWin; private set { if (value <= 3) toWin = value; } }

        // Number of complete games to play
        public byte Rounds { get; private set; }

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
                    Rounds = 1;
                    ToWin = 1;
                    break;

                // Standard gamemode
                case "":
                case " ":
                case null:
                    Rounds = 1;
                    ToWin = 3;
                    break;

                // Personalized gamemode
                case "personalized":
                case "Personalized":
                case "p":
                case "P":
                    SetRounds();
                    break;
            }
        }
        // Personalized
        private void SetRounds()
        {
            // Ask how many rounds
            Rounds = 2;
            // Ask how many ghosts of the same color need to leave to win
            toWin = 2;
        }
    }
}
