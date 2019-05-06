using System;

namespace _18GhostsGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Board board = new Board();
            Player player1 = new Player(1);
            Player player2 = new Player(2);

            board.Draw(player1.GetGhosts(), player2.GetGhosts());

            while (true)
            {
                player1.Action();

                //player1.SetGhostPosToZero();
                board.GhostDead("yellow");
                board.Draw(player1.GetGhosts(), player2.GetGhosts());

            }

            

            /* TO READ ACTIONS WITHOUT PRESSING ENTER
            switch (Console.ReadKey())
            {

            }
            */

            // PLACE GHOSTS LOOP

            // Player 1
            // Choose which color of ghost
            // Choose which number of ghost

            //Player 2
            // Choose which color of ghost
            // Choose which number of ghost

            // If all 18 placed, move on

            // GAME LOOP STARTS

            // Player 1
            // What do you want to do?
            // Move / attack
            // Choose what color of ghost to move
            // Choose which ghost of that color to move
            // Move
            // up down left or right (u,d,l,r / w,a,s,d)
            // Check who wins or nothing

            // Rotate portals
            // Check adjacent
            // Excapes if yes

            // Player 2
            // What do you want to do?
            // Move / attack
            // Choose what color of ghost to move
            // Choose which ghost of that color to move
            // Move
            // Check who wins or nothing

            // Rotate portals
            // Check adjacent
            // Excapes if yes
        }
    }
}
