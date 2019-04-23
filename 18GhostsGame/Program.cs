using System;

namespace _18GhostsGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Board board = new Board();

            board.Draw();

            board.GhostDead("yellow");
            board.Draw();


            /* TO READ ACTIONS WITHOUT PRESSING ENTER
            switch (Console.ReadKey())
            {

            }
            */

            // PLACE GHOSTS LOOP

            // Player 1
            // Choose wich color of ghost
            // Choose wich number of ghost

            //Player 2
            // Choose wich color of ghost
            // Choose wich number of ghost

            // If all 18 placed, move on

            // GAME LOOP STARTS

            // Player 1
            // What do you want to do?
            // Move / attack
            // Choose what color of ghost to move
            // Choose wich ghost of that color to move
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
            // Choose wich ghost of that color to move
            // Move
            // Check who wins or nothing

            // Rotate portals
            // Check adjacent
            // Excapes if yes
        }
    }
}
