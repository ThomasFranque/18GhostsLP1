namespace _18GhostsGame
{
    /// <summary>
    /// Contains the players and board objects, used to for the player turns
    /// </summary>
    class TurnManager
    {
        // Declaring variables
        Board board;
        Player player1;
        Player player2;

        /// <summary>
        /// Constructor TurnManager assigns new objects
        /// </summary>
        public TurnManager()
        {
            // Assingning objects
            board = new Board();

            player1 = new Player();
            player2 = new Player();
        }

        /// <summary>
        /// Will execute the turn of the given player
        /// </summary>
        /// <param name="playerNum">Target player number</param>
        public void turnPlayer(byte playerNum)
        {
            // Draw the board
            board.Draw(player1.GetGhosts(), player2.GetGhosts());
            switch (playerNum)
            {
                case 1:
                    // Updating Player 1 enemy ghosts
                    player1.EnemyGhosts = player2.GetGhosts();
                    // Printing feedback message
                    Render.PrintText("Player 1 Turn!\n");
                    // Player 1 action
                    player1.Action();
                    break;
                case 2:
                    // Updating Player 1 enemy ghosts
                    player2.EnemyGhosts = player1.GetGhosts();
                    //Printing feedback message
                    Render.PrintText("Player 2 Turn!\n");
                    // Player 2 action
                    player2.Action();
                    break;
            }
        }

        /// <summary>
        /// Forces a the placement of ghosts of the target player
        /// </summary>
        /// <param name="playerNum">Target player number</param>
        public void forcePlacePlayer(byte playerNum)
        {
            // Draw the board
            board.Draw(player1.GetGhosts(), player2.GetGhosts());
            switch (playerNum)
            {
                case 1:
                    // Placing Ghosts
                    Render.PrintText("Player 1 place your ghost.\n");
                    player1.ForcePlace();
                    break;
                case 2:
                    Render.PrintText("Player 2 place your ghost.\n");
                    player2.ForcePlace();
                    break;
            }
        }

        /// <summary>
        /// Gives out the asked target player
        /// </summary>
        /// <param name="playerNum">Target player number</param>
        /// <returns>Returns the target player object</returns>
        public Player GetPlayer(byte playerNum)
        {
            // Temporary method object player
            Player desiredPlayer = player1;

            // Check for the asked player
            switch (playerNum)
            {
                case 1:
                    break;
                case 2:
                    desiredPlayer = player2;
                    break;
            }

            return desiredPlayer;
        }
    }
}
