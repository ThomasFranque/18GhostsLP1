using System;
using System.Collections.Generic;
using System.Text;

namespace _18GhostsGame
{
    static class GameLoop
    {
        public static void Run(string[] userArgs)
        {
            GameMode gamemode = new GameMode(userArgs);

            Board board = new Board();
            Player player1 = new Player(1);
            Player player2 = new Player(2);

            // Placing Ghosts
            // Draw the board
            board.Draw(player1.GetGhosts(), player2.GetGhosts());
            Render.PrintText("Player 1 place your ghost.\n");
            player1.ForcePlace();

            Render.PrintText("Player 2 place your ghost.\n");
            player2.ForcePlace();
            player2.ForcePlace();

            for (byte i = 0; i <= 15; i++)
            {
                // Player 1 turn
                // Draw the board
                board.Draw(player1.GetGhosts(), player2.GetGhosts());
                Render.PrintText("Player 1 place your ghost.\n");
                player1.ForcePlace();

                // Player 2 turn
                board.Draw(player1.GetGhosts(), player2.GetGhosts());
                Render.PrintText("Player 1 place your ghost.\n");
                player2.ForcePlace();
            }

            while (!Portal.PlayerWon(gamemode.ToWin))
            {
                // Updating player enemy ghosts
                player1.EnemyGhosts = player2.GetGhosts();

                player2.EnemyGhosts = player1.GetGhosts();

                // Player 1 Turn
                Render.PrintText("Player 1 Turn!\n");
                player1.Action();

                // Check if any ghosts left the castle
                Portal.GhostsOutCheck(player1.GetGhosts(),
                    player2.GetGhosts());
                
                // Draw the board
                board.Draw(player1.GetGhosts(), player2.GetGhosts());

                // Check if game is over
                if (!Portal.PlayerWon(gamemode.ToWin))
                {
                    // Player 2 Turn
                    Render.PrintText("Player 2 Turn!\n");
                    player2.Action();

                    // Check if any ghosts left the castle
                    Portal.GhostsOutCheck(player1.GetGhosts(),
                        player2.GetGhosts());

                    // Draw the board
                    board.Draw(player1.GetGhosts(), player2.GetGhosts());
                }
            }
        }
    }
}
