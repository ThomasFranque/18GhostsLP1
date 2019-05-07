using System;
using System.Collections.Generic;
using System.Text;

namespace _18GhostsGame
{
    static class GameLoop
    {
        public static void Run()
        {

            Board board = new Board();
            Player player1 = new Player(1);
            Player player2 = new Player(2);

            player2.ResetGhosts();
            board.Draw(player1.GetGhosts(), player2.GetGhosts());

            // TEMP GAMELOOP
            while (true)
            {
                player1.EnemyGhosts = player2.GetGhosts();

                player2.EnemyGhosts = player1.GetGhosts();

                player1.Action();

                //player1.SetGhostPosToZero();
                board.Draw(player1.GetGhosts(), player2.GetGhosts());
            }
        }
        //TRYING TO MAKE A GAME LOOP, ask for some help
        /*public void Loop()
        {
            while (victory == false)
            {
                Player1turn();
                Player2turn();
            }
        }

        public void Player1turn()
        {
            string option;

            option = Inputs.PlayerInput
            ("What do you want to do? \nMove or Atack");

            switch (option)
            {
                case "Move":
                case "move":
                case "M":
                case "m":

                    //Player1 moves
                    player1.Move();
                    break;
            
                case "Atack":
                case "atack":
                case "A":
                case "a":
                
                    break;
            }
        }*/


        // GAME LOOP STARTS

        // Player 1
        // What do you want to do?
        // Move / Attack
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
