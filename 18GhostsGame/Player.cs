using System;

namespace _18GhostsGame
{
    /// <summary>
    /// Determines player intentions and ghosts
    /// </summary>
    class Player
    {
        // Variables
        private Ghosts ghosts;
        public byte[,] EnemyGhosts { set; get; }

        /// <summary>
        /// Constructor Player creates player ghosts and sets to default 
        /// values
        /// </summary>
        public Player()
        {
            ghosts = new Ghosts();
            EnemyGhosts =
            new byte[3, 3] { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } };
        }

        /// <summary>
        /// Determine what the player wants to do
        /// </summary>
        public void Action()
        {
            // Temporary variables
            ConsoleKeyInfo input;
            bool chosen = false;

            // If not a valid option
            while (!chosen)
            {
                // Show menu
                Render.ActionMenu();
                // Read player intention
                input = Console.ReadKey();
                // Print gap
                Render.Line();

                // Check option
                switch (input.Key)
                {
                    // Player wants to Move
                    case ConsoleKey.M:
                    case ConsoleKey.D1:
                        chosen = !chosen;
                        ghosts.Move(EnemyGhosts);
                        break;

                    // Player wants to Place
                    case ConsoleKey.P:
                    case ConsoleKey.D2:
                        chosen = !chosen;
                        Render.PrintText
                            ("\nLet your opponent choose where!\n");
                        ghosts.Place(EnemyGhosts);
                        break;

                    // Player wants Help
                    case ConsoleKey.H:
                    case ConsoleKey.D3:
                        Render.HelpAction();
                        break;
                    
                    // Unknown input
                    default:
                        Render.PrintText("Please insert a valid option.");
                        break;
                }
            }
        }

        /// <summary>
        /// Force the placing of ghosts
        /// </summary>
        public void ForcePlace()
        {
            ghosts.Place(EnemyGhosts);
        }

        /// <summary>
        /// Will return the player ghosts
        /// </summary>
        /// <returns>All the player ghosts</returns>
        public byte[,] GetGhosts() => ghosts.AllGhosts;


    }
}
