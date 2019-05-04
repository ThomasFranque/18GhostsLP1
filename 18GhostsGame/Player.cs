using System;
using System.Collections.Generic;
using System.Text;

namespace _18GhostsGame
{
    class Player
    {
        /* Variable ghosts
         Red Ghosts = ghosts[0,~]; 
         Blue Ghosts = ghosts[2,~];
         Yellow Ghosts = ghosts[1,~];
        */

        // ####### HEY THIS IS YOUR CAPTAIN SPEAKING #######
        // Tenta tornar a variavel ghosts numa propriedade antes de começares

        private byte[,] ghosts;
        private string playerNum;

        // Constructor
        public Player(byte playerNum)
        {
            ghosts = new byte[3, 3] { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } };
            this.playerNum = playerNum == 1 ? "Player 1" : "Player 2";
        }

        public void Move()
        {

        }

        public void Attack()
        {

        }

        // Does what it says
        public void SetGhostPosToZero()
        {
            ghosts = new byte[3, 3] { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } };
        }

        public string GetPlayerNum() => playerNum;

        public byte[,] GetGhosts() => ghosts;
        public byte[] GetGhosts(string wichGhosts)
        {
            byte[] toReturn = new byte[3];
            byte[,] toReturnAll = new byte[3, 3];

            switch (wichGhosts)
            {
                case "red":
                    toReturn =
                        new byte[3] { ghosts[0, 0], ghosts[0, 1], ghosts[0, 2] };
                    break;

                case "blue":
                    toReturn =
                        new byte[3] { ghosts[1, 0], ghosts[1, 1], ghosts[1, 2] };
                    break;

                case "yellow":
                    toReturn =
                        new byte[3] { ghosts[2, 0], ghosts[2, 1], ghosts[2, 2] };
                    break;

                case "all":
                    // Change text color
                    Console.ForegroundColor = ConsoleColor.Red;
                    // Error Message
                    Console.WriteLine($"\nERROR\n " +
                        $"Please use the Overload of GetGhosts() to get " +
                        $"all the ghosts at once.\n");
                    // Reset text color back to white
                    Console.ResetColor();
                    break;

                default:
                    // Change text color
                    Console.ForegroundColor = ConsoleColor.Red;
                    // Error Message
                    Console.WriteLine($"\nERROR\n " +
                        $"{wichGhosts} ghosts Doesn't exist.\n");
                    // Reset text color back to white
                    Console.ResetColor();
                    break;
            }

            return toReturn;
        }
    }
}
