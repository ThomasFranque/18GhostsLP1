namespace _18GhostsGame
{
    /// <summary>
    /// Controls how many ghosts are necessary to win the game, assigning it
    /// using command-line arguments
    /// </summary>
    class GameMode
    {
        // Property holds how many ghosts 
        // of the same color need to leave to win the game
        public byte ToWin
        { get; private set; }

        /// <summary>
        /// Will read the console arguments and assign a game mode
        /// </summary>
        /// <param name="userArg">
        /// Command-line arguments for the desired game mode
        /// </param>
        public GameMode(string[] userArg)
        {
            string gamemode;

            // Checking if arguments were given
            // Sets to default value if not
            if (userArg.Length < 1)
                gamemode = " ";
            else
                gamemode = userArg[0];

            // Read the console argument and assign respective game settings
            switch (gamemode)
            {
                // Quick game mode
                case "quick":
                case "Quick":
                case "q":
                case "Q":
                    ToWin = 1;
                    break;

                // Standard game mode
                case "":
                case " ":
                case null:
                    ToWin = 3;
                    break;
            }
        }
    }
}
