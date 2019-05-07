using System;
using System.Collections.Generic;
using System.Text;

namespace _18GhostsGame
{
    class Ghosts
    {
        GhostInteractions interactions = new GhostInteractions();

        /* Variable ghosts
         Red Ghosts = ghosts[0,~]; 
         Blue Ghosts = ghosts[2,~];
         Yellow Ghosts = ghosts[1,~];
        */
        private byte[,] ghosts;

        private byte[] enemyTarget;

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
            ghosts = new byte[3, 3] { { 0, 1, 0 }, { 0, 0, 0 }, { 0, 0, 0 } };
            enemyTarget = new byte[2] { 4, 0 };
            interactions = new GhostInteractions();
        }

        public void ResetGhosts()
        {
            ghosts = new byte[3, 3] { { 0, 0, 0 }, { 0, 6, 0 }, { 0, 0, 0 } };
        }

        public void Move(byte[,] enemyGhosts)
        {
            char direction = ' ';
            ConsoleKeyInfo input;
            byte[] ghostToMove = new byte[2] { 0, 0 };


            //Receive the ghost's color
            PlayerRenderer.PrintColoredText("What color? \n" +
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

                case ConsoleKey.Y:
                case ConsoleKey.D3:
                    ghostToMove[0] = 2;
                    break;
            }


            // ###### TO-DO LATER ######
            // Separate switches in private methods
            
            //Receive wich ghost is
            PlayerRenderer.PrintText("Wich ghost do you want to move? \n" +
                "a .... <A> or <1>\n" +
                "b .... <B> or <2>\n" +
                "c .... <C> or <3>\n");


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
            PlayerRenderer.PrintText("In which direction? \n" +
                "Up ....... <W> or <Up Arrow>\n" +
                "Down ..... <S> or <Down Arrow>\n" +
                "Left ..... <A> or <Left Arrow>\n" +
                "Right .... <D> or <Right Arrow>\n");

            input = Console.ReadKey();

            PlayerRenderer.PrintText();

            switch (input.Key)
            {
                case ConsoleKey.W:
                case ConsoleKey.UpArrow:
                    direction = 'u';
                    break;

                case ConsoleKey.S:
                case ConsoleKey.DownArrow:
                    direction = 'd';
                    break;

                case ConsoleKey.A:
                case ConsoleKey.LeftArrow:
                    direction = 'l';
                    break;

                case ConsoleKey.D:
                case ConsoleKey.RightArrow:
                    direction = 'r';
                    break;
            }
            enemyTarget = GhostChecker.CheckAdjacentPos
                (direction, ghosts[ghostToMove[0], ghostToMove[1]], 
                enemyGhosts);

            if (enemyTarget[0] == 4)
                ChangeGhostPos
                    (ref ghosts[ghostToMove[0], ghostToMove[1]], direction);
            else
            {
                // Check if color between ghosts are not equal to run conflict
                // KILLING GHOSTS OCCURS HERE (THE ONLY METHOD THAT CONTROLLS 
                //GHOSTS BESIDES THE PLAYER HIMSELF)

                if (ghostToMove[0] != enemyTarget[0])
                    if (!interactions.Conflict(ghostToMove, enemyTarget))
                        KillGhost(ref ghosts[ghostToMove[0], ghostToMove[1]]);
                    else
                    {
                        KillGhost
                            (ref enemyGhosts[enemyTarget[0], enemyTarget[1]]);
                        ChangeGhostPos
                            (ref ghosts[ghostToMove[0], ghostToMove[1]], 
                            direction);

                    }


            }
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

        private static void KillGhost(ref byte targetGhost)
        {
            targetGhost = 0;
        }
    }
}