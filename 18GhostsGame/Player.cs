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




        public byte [,]Ghosts
        {
            get
            {
                return  ghosts;
            }

            set
            {
                ghosts = value;
            }
            
        }

        // Constructor
        public Player(byte playerNum)
        {
            ghosts = new byte[3, 3] { { 1, 0, 0 }, { 2, 0, 0 }, { 4, 0, 0 } };
            this.playerNum = playerNum == 1 ? "Player 1" : "Player 2";
        }

        public void Move()
        {
            string ghostColor;
            string wichGhost;
            string direction;

            //
            //
            //DEPOIS ALTERAR PARA A CLASSE RENDERER
            Console.WriteLine("Wich color?");

            //Receive the ghost's color
            ghostColor = Console.ReadLine();

            //
            //
            //DEPOIS ALTERAR PARA A CLASSE RENDERER
            Console.WriteLine("Wich ghost do you want to move?");

            //Receive wich ghost is
            wichGhost = Console.ReadLine();

            Console.WriteLine("In witch direction?");

            //Receive the direction
            direction = Console.ReadLine();


            //Check the color, letter (ghost) and direction
            switch (ghostColor)
            {
            case "red":
                    switch (wichGhost)
                    {
                        case "a":
                            switch (direction)
                            {
                                case "up":

                                    //Check it's position,
                                    //so it doesn´t move to where it shouldn't

                                    if (ghosts[0, 0] > 5)
                                    {
                                        //Move the ghost
                                        ghosts[0, 0] -= 5;
                                    }
                                    break;
                                case "down":
                                    if (ghosts[0, 0] < 21)
                                    {
                                        ghosts[0, 0] += 5;
                                    }
                                    break;
                                case "left":
                                    if ((ghosts[0, 0] != 1) && (ghosts[0, 0] != 6) && 
                                       (ghosts[0, 0] != 11) && (ghosts[0, 0] != 16) && 
                                       (ghosts[0, 0] != 21))
                                    {
                                        ghosts[0, 0] -= 1;
                                    }
                                    break;
                                case "right":
                                    if ((ghosts[0, 0] != 5) && (ghosts[0, 0] != 10) &&
                                    (ghosts[0, 0] != 15) && (ghosts[0, 0] != 20) &&
                                    (ghosts[0, 0] != 25))
                                    {
                                        ghosts[0, 0] += 1;
                                    }
                                    break;
                            }
                            break;

                        case "b":
                            switch (direction)
                            {
                                case "up":
                                    if (ghosts[0, 0] > 5)
                                    {
                                        ghosts[0, 0] -= 5;
                                    }
                                    break;
                                case "down":
                                    if (ghosts[0, 0] < 21)
                                    {
                                        ghosts[0, 0] += 5;
                                    }
                                    break;
                                case "left":
                                    if ((ghosts[0, 0] != 1) && (ghosts[0, 0] != 6) &&
                                       (ghosts[0, 0] != 11) && (ghosts[0, 0] != 16) &&
                                       (ghosts[0, 0] != 21))
                                    {
                                        ghosts[0, 0] -= 1;
                                    }
                                    break;
                                case "right":
                                    if ((ghosts[0, 0] != 5) && (ghosts[0, 0] != 10) &&
                                    (ghosts[0, 0] != 15) && (ghosts[0, 0] != 20) &&
                                    (ghosts[0, 0] != 25))
                                    {
                                        ghosts[0, 0] += 1;
                                    }
                                    break;
                            }
                            break;

                        case "c":
                            switch (direction)
                            {
                                case "up":
                                    if (ghosts[0, 0] > 5)
                                    {
                                        ghosts[0, 0] -= 5;
                                    }
                                    break;
                                case "down":
                                    if (ghosts[0, 0] < 21)
                                    {
                                        ghosts[0, 0] += 5;
                                    }
                                    break;
                                case "left":
                                    if ((ghosts[0, 0] != 1) && (ghosts[0, 0] != 6) &&
                                       (ghosts[0, 0] != 11) && (ghosts[0, 0] != 16) &&
                                       (ghosts[0, 0] != 21))
                                    {
                                        ghosts[0, 0] -= 1;
                                    }
                                    break;
                                case "right":
                                    if ((ghosts[0, 0] != 5) && (ghosts[0, 0] != 10) &&
                                    (ghosts[0, 0] != 15) && (ghosts[0, 0] != 20) &&
                                    (ghosts[0, 0] != 25))
                                    {
                                        ghosts[0, 0] += 1;
                                    }
                                    break;
                            }
                            break;
                    }
                    break;
            case "blue":
                    switch (wichGhost)
                    {
                        case "a":
                            switch (direction)
                            {
                                case "up":
                                    if (ghosts[1, 0] > 5)
                                    {
                                        ghosts[1, 0] -= 5;
                                    }
                                    break;
                                case "down":
                                    if (ghosts[1, 0] < 21)
                                    {
                                        ghosts[1, 0] += 5;
                                    }
                                    break;
                                case "left":
                                    if ((ghosts[1, 0] != 1) && (ghosts[1, 0] != 6) &&
                                       (ghosts[1, 0] != 11) && (ghosts[1, 0] != 16) &&
                                       (ghosts[1, 0] != 21))
                                    {
                                        ghosts[1, 0] -= 1;
                                    }
                                    break;
                                case "right":
                                    if ((ghosts[1, 0] != 5) && (ghosts[1, 0] != 10) &&
                                    (ghosts[1, 0] != 15) && (ghosts[1, 0] != 20) &&
                                    (ghosts[1, 0] != 25))
                                    {
                                        ghosts[1, 0] += 1;
                                    }
                                    break;
                            }
                            break;

                        case "b":
                            switch (direction)
                            {
                                case "up":
                                    if (ghosts[1, 0] > 5)
                                    {
                                        ghosts[1, 0] -= 5;
                                    }
                                    break;
                                case "down":
                                    if (ghosts[1, 0] < 21)
                                    {
                                        ghosts[1, 0] += 5;
                                    }
                                    break;
                                case "left":
                                    if ((ghosts[1, 0] != 1) && (ghosts[1, 0] != 6) &&
                                       (ghosts[1, 0] != 11) && (ghosts[1, 0] != 16) &&
                                       (ghosts[1, 0] != 21))
                                    {
                                        ghosts[1, 0] -= 1;
                                    }
                                    break;
                                case "right":
                                    if ((ghosts[1, 0] != 5) && (ghosts[1, 0] != 10) &&
                                    (ghosts[1, 0] != 15) && (ghosts[1, 0] != 20) &&
                                    (ghosts[1, 0] != 25))
                                    {
                                        ghosts[1, 0] += 1;
                                    }
                                    break;
                            }
                            break;

                        case "c":
                            switch (direction)
                            {
                                case "up":
                                    if (ghosts[1, 0] > 5)
                                    {
                                        ghosts[1, 0] -= 5;
                                    }
                                    break;
                                case "down":
                                    if (ghosts[1, 0] < 21)
                                    {
                                        ghosts[1, 0] += 5;
                                    }
                                    break;
                                case "left":
                                    if ((ghosts[1, 0] != 1) && (ghosts[1, 0] != 6) &&
                                       (ghosts[1, 0] != 11) && (ghosts[1, 0] != 16) &&
                                       (ghosts[1, 0] != 21))
                                    {
                                        ghosts[1, 0] -= 1;
                                    }
                                    break;
                                case "right":
                                    if ((ghosts[1, 0] != 5) && (ghosts[1, 0] != 10) &&
                                    (ghosts[1, 0] != 15) && (ghosts[1, 0] != 20) &&
                                    (ghosts[1, 0] != 25))
                                    {
                                        ghosts[1, 0] += 1;
                                    }
                                    break;
                            }
                            break;
                    }
                    break;


            case "yellow":
                    switch (wichGhost)
                    {
                        case "a":
                            switch (direction)
                            {
                                case "up":
                                    if (ghosts[2, 0] > 5)
                                    {
                                        ghosts[2, 0] -= 5;
                                    }
                                    break;
                                case "down":
                                    if (ghosts[2, 0] < 21)
                                    {
                                        ghosts[2, 0] += 5;
                                    }
                                    break;
                                case "left":
                                    if ((ghosts[2, 0] != 1) && (ghosts[2, 0] != 6) &&
                                       (ghosts[2, 0] != 11) && (ghosts[2, 0] != 16) &&
                                       (ghosts[2, 0] != 21))
                                    {
                                        ghosts[2, 0] -= 1;
                                    }
                                    break;
                                case "right":
                                    if ((ghosts[2, 0] != 5) && (ghosts[2, 0] != 10) &&
                                    (ghosts[2, 0] != 15) && (ghosts[2, 0] != 20) &&
                                    (ghosts[2, 0] != 25))
                                    {
                                        ghosts[2, 0] += 1;
                                    }
                                    break;
                            }
                            break;

                        case "b":
                            switch (direction)
                            {
                                case "up":
                                    if (ghosts[2, 0] > 5)
                                    {
                                        ghosts[2, 0] -= 5;
                                    }
                                    break;
                                case "down":
                                    if (ghosts[2, 0] < 21)
                                    {
                                        ghosts[2, 0] += 5;
                                    }
                                    break;
                                case "left":
                                    if ((ghosts[2, 0] != 1) && (ghosts[2, 0] != 6) &&
                                       (ghosts[2, 0] != 11) && (ghosts[2, 0] != 16) &&
                                       (ghosts[2, 0] != 21))
                                    {
                                        ghosts[2, 0] -= 1;
                                    }
                                    break;
                                case "right":
                                    if ((ghosts[2, 0] != 5) && (ghosts[2, 0] != 10) &&
                                    (ghosts[2, 0] != 15) && (ghosts[2, 0] != 20) &&
                                    (ghosts[2, 0] != 25))
                                    {
                                        ghosts[2, 0] += 1;
                                    }
                                    break;
                            }
                            break;

                        case "c":
                            switch (direction)
                            {
                                case "up":
                                    if (ghosts[2, 0] > 5)
                                    {
                                        ghosts[2, 0] -= 5;
                                    }
                                    break;
                                case "down":
                                    if (ghosts[2, 0] < 21)
                                    {
                                        ghosts[2, 0] += 5;
                                    }
                                    break;
                                case "left":
                                    if ((ghosts[2, 0] != 1) && (ghosts[2, 0] != 6) &&
                                       (ghosts[2, 0] != 11) && (ghosts[2, 0] != 16) &&
                                       (ghosts[2, 0] != 21))
                                    {
                                        ghosts[2, 0] -= 1;
                                    }
                                    break;
                                case "right":
                                    if ((ghosts[2, 0] != 5) && (ghosts[2, 0] != 10) &&
                                    (ghosts[2, 0] != 15) && (ghosts[2, 0] != 20) &&
                                    (ghosts[2, 0] != 25))
                                    {
                                        ghosts[2, 0] += 1;
                                    }

                                    break;
                            }
                            break;
                    }
                    break;

            }

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
