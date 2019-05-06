using System;
using System.Collections.Generic;
using System.Text;

namespace _18GhostsGame
{
    class Ghosts
    {

        /* Variable ghosts
         Red Ghosts = ghosts[0,~]; 
         Blue Ghosts = ghosts[2,~];
         Yellow Ghosts = ghosts[1,~];
        */
        private byte[,] ghosts;

        public byte[,] AllGhosts
        {
            get
            {
                return ghosts;
            }

            set
            {
                ghosts = value;
            }

        }

        // Constructor
        public Ghosts()
        {
            ghosts = new byte[3, 3] { { 0, 2, 0 }, { 0, 0, 0 }, { 0, 0, 0 } };
        }

        public void ResetGhosts()
        {
            ghosts = new byte[3, 3] { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } };
        }

        public void Move()
        {
            char direction = ' ';
            ConsoleKeyInfo input;
            byte[] ghostToMove = new byte[2] { 0, 0 };


            //Receive the ghost's color
            PlayerRenderer.PrintText("What color?\n" +
                "Red ...... <R> or <1>\n" +
                "Blue ..... <B> or <2>\n" +
                "Yellow ... <Y> or <3>\n");

            input = Console.ReadKey();

            PlayerRenderer.PrintText();
            switch (input.Key)
            {

                case ConsoleKey.R:
                case ConsoleKey.D1:
                    ghostToMove[0] = 0;
                    break;

                case ConsoleKey.B:
                case ConsoleKey.D2:
                    ghostToMove[0] = 1;
                    break;

                case ConsoleKey.C:
                case ConsoleKey.D3:
                    ghostToMove[0] = 2;
                    break;
            }


            // ###### TO-DO LATER ######
            // Separate switches in private methods
            
            //Receive wich ghost is
            PlayerRenderer.PrintText("Wich ghost do you want to move?\n");

            input = Console.ReadKey();

            PlayerRenderer.PrintText();

            switch (input.Key)
            {

                case ConsoleKey.A:
                case ConsoleKey.D1:
                    ghostToMove[1] = 0;
                    break;

                case ConsoleKey.B:
                case ConsoleKey.D2:
                    ghostToMove[1] = 1;
                    break;

                case ConsoleKey.C:
                case ConsoleKey.D3:
                    ghostToMove[1] = 2;
                    break;
            }

            //Receive the direction
            PlayerRenderer.PrintText("In which direction?\n");

            input = Console.ReadKey();

            PlayerRenderer.PrintText();

            switch (input.Key)
            {
                case ConsoleKey.A:
                case ConsoleKey.UpArrow:
                    direction = 'u';
                    break;

                case ConsoleKey.S:
                case ConsoleKey.DownArrow:
                    direction = 'd';
                    break;

                case ConsoleKey.L:
                case ConsoleKey.LeftArrow:
                    direction = 'l';
                    break;

                case ConsoleKey.D:
                case ConsoleKey.RightArrow:
                    direction = 'r';
                    break;
            }

            ChangeGhostPos(ref ghosts[ghostToMove[0], ghostToMove[1]], direction);
        }

        private void ChangeGhostPos(ref byte targetGhost, char direction)
        {
            switch (direction)
            {
                case 'u':
                    targetGhost -= 5;
                    break;
                case 'd':
                    targetGhost += 5;
                    break;
                case 'l':
                    if ((targetGhost != 1) && (targetGhost != 6) &&
                       (targetGhost != 11) && (targetGhost != 16) &&
                       (targetGhost != 21))
                        targetGhost -= 1;
                    break;
                case 'r':
                    if ((targetGhost != 5) && (targetGhost != 10) &&
                    (targetGhost != 15) && (targetGhost != 20) &&
                    (targetGhost != 25))
                        targetGhost += 1;
                    break;
            }
        }
    }
}

// #### OLD MOVEMENT REMOVE WHEN NOT NECESSARY ANYMORE ####
//Check the color, letter (ghost) and direction
/*
switch (ghostColor)
{
    case "red":
        switch (whichGhost)
        {
            case "a":
                switch (direction)
                {
                    case 'u':

                        //Check it's position,
                        //so it doesn´t move to where it shouldn't

                        if (ghosts[0, 0] > 5)
                        {
                            //Move the ghost
                            ghosts[0, 0] -= 5;
                        }
                        break;
                    case 'd':
                        if (ghosts[0, 0] < 21)
                        {
                            ghosts[0, 0] += 5;
                        }
                        break;
                    case 'l':
                        if ((ghosts[0, 0] != 1) && (ghosts[0, 0] != 6) &&
                           (ghosts[0, 0] != 11) && (ghosts[0, 0] != 16) &&
                           (ghosts[0, 0] != 21))
                        {
                            ghosts[0, 0] -= 1;
                        }
                        break;
                    case 'r':
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
                    case 'u':
                        if (ghosts[0, 0] > 5)
                        {
                            ghosts[0, 0] -= 5;
                        }
                        break;
                    case 'd':
                        if (ghosts[0, 0] < 21)
                        {
                            ghosts[0, 0] += 5;
                        }
                        break;
                    case 'l':
                        if ((ghosts[0, 0] != 1) && (ghosts[0, 0] != 6) &&
                           (ghosts[0, 0] != 11) && (ghosts[0, 0] != 16) &&
                           (ghosts[0, 0] != 21))
                        {
                            ghosts[0, 0] -= 1;
                        }
                        break;
                    case 'r':
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
                    case 'u':
                        if (ghosts[0, 0] > 5)
                        {
                            ghosts[0, 0] -= 5;
                        }
                        break;
                    case 'd':
                        if (ghosts[0, 0] < 21)
                        {
                            ghosts[0, 0] += 5;
                        }
                        break;
                    case 'l':
                        if ((ghosts[0, 0] != 1) && (ghosts[0, 0] != 6) &&
                           (ghosts[0, 0] != 11) && (ghosts[0, 0] != 16) &&
                           (ghosts[0, 0] != 21))
                        {
                            ghosts[0, 0] -= 1;
                        }
                        break;
                    case 'r':
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
        switch (whichGhost)
        {
            case "a":
                switch (direction)
                {
                    case 'u':
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
        switch (whichGhost)
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
*/
