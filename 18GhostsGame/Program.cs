using System;

namespace _18GhostsGame
{
    /// <summary>
    /// Will run the game
    /// </summary>
    class Program
    {
        /// <summary>
        /// Will set the window size and start the game loop
        /// </summary>
        /// <param name="args">
        /// Command-line arguments for the desired game mode
        /// </param>
        static void Main(string[] args)
        {
            // Start game loop
            GameLoop.Run(args);
        }
    }
}
