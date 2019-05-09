using System;
namespace _18GhostsGame
{
    /// <summary>
    /// Will initialize all necessary objects, 
    /// contains the game loop and calls necessary methods.
    /// </summary>
    static class GameLoop
    {
        /// <summary>
        /// Run the game loop and call necessary methods to do so.
        /// </summary>
        /// <param name="userArgs">
        /// Command-line arguments for the desired game mode
        /// </param>
        public static void Run(string[] userArgs)
        {
            // Initializing objects
            GameMode gamemode = new GameMode(userArgs);
            TurnManager turnManager = new TurnManager();
            
            
            // Initial placing ghosts
            turnManager.forcePlacePlayer(1);

            turnManager.forcePlacePlayer(2);

            // Force place until there are no more ghosts in the dungeon
            for (byte i = 0; i <= 7; i++)
            {
                turnManager.forcePlacePlayer(2);

                turnManager.forcePlacePlayer(1);
            }

            // While game is not over
            while (!Portal.PlayerWon(gamemode.ToWin))
            {
                // Check if any ghosts left the castle
                Portal.GhostsOutCheck(turnManager.GetPlayer(1).GetGhosts(),
                    turnManager.GetPlayer(2).GetGhosts());

                // Player 1 turn
                turnManager.turnPlayer(1);

                // Check if any ghosts left the castle
                Portal.GhostsOutCheck(turnManager.GetPlayer(1).GetGhosts(),
                    turnManager.GetPlayer(2).GetGhosts());

                // Check if game is over
                if (!Portal.PlayerWon(gamemode.ToWin))
                    // Player 2 turn
                    turnManager.turnPlayer(2);
            }

            // Winning message
            Render.Clear();
            Render.PrintText("PLAYER " + Portal.CheckWinner(gamemode.ToWin) +
                " WINS!\n press any key to end the program...");
            Console.ReadKey();
        }
    }
}
