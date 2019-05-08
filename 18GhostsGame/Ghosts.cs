using System;
using System.Collections.Generic;
using System.Text;

namespace _18GhostsGame
{
    class Ghosts
    {
        GhostInteractions interactions;
        GhostChecker checker;

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
            AllGhosts = 
                new byte[3, 3] { { 2, 1, 0 }, { 0, 0, 0 }, { 0, 0, 0 } };
            enemyTarget = new byte[2] { 4, 0 };
            interactions = new GhostInteractions();
            checker = new GhostChecker();
        }

        public void ResetGhosts()
        {
            AllGhosts = 
                new byte[3, 3] { { 0, 0, 0 }, { 0, 6, 0 }, { 0, 0, 0 } };
        }

        public void Place(byte[,] enemyGhosts)
        {
            string input;
            byte place;
            byte[] ghostToMove = new byte[2] { 0, 0 };
            bool validInput = false;
            //THE ENEMY IS THE ONE TO PLACE YOUR GHOSTS
            while (true)
            {
                ghostToMove = KnowWhichGhost();

                //Check if ghost to place is in the dungeon
                if (AllGhosts[ghostToMove[0], ghostToMove[1]] != 0)
                    Render.PrintText("\nPlease insert a valid ghost.\n");
                else
                    break;
            }

            // Where?
            Render.ShowPlacingSpots(ghostToMove[0]);
            while (!validInput)
            {
                Render.PrintText(">");
                input = Console.ReadLine();

                validInput= byte.TryParse(input, out place);
                Console.WriteLine(place);
                input = Console.ReadLine();

                if (validInput) {
                    if (FreeSpot(place, enemyGhosts))
                        ChangeGhostPos(ref AllGhosts[ghostToMove[0], 
                            ghostToMove[1]], place);
                }
                else
                    Console.WriteLine("Please choose a valid number.");
            }
        }

        public void Move(byte[,] enemyGhosts)
        {
            ConsoleKeyInfo input;

            char direction = ' ';
            byte[] ghostToMove = new byte[2] { 0, 0 };

            bool canMove = true;
            byte desiredPosition;

            byte allyColor = 0;
            byte allyGhost = 0;

            ghostToMove = KnowWhichGhost();

            //Receive the direction
            Render.PrintText("In which direction? \n" +
                "Up ....... <W> or <Up Arrow>\n" +
                "Down ..... <S> or <Down Arrow>\n" +
                "Left ..... <A> or <Left Arrow>\n" +
                "Right .... <D> or <Right Arrow>\n");

            input = Console.ReadKey();

            Render.Line();

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

            enemyTarget = checker.CheckAdjacentPos
                (direction, AllGhosts[ghostToMove[0], ghostToMove[1]],
                enemyGhosts);

            desiredPosition = checker.DesiredPosition
                (direction, AllGhosts[ghostToMove[0], ghostToMove[1]]);

            //CHECK FOR CONFLICS
            // Check if color between ghosts are not equal to run conflict
            // KILLING GHOSTS OCCURS HERE (THE ONLY METHOD THAT CONTROLLS 
            //GHOSTS POSITION BESIDES THE PLAYER HIMSELF)
            // In case there is no enemy ghost there
            if (enemyTarget[0] == 4) // Checks if there is a enemy there
            {
                // Check if ally ghost is there and color color
                foreach (byte ghost in AllGhosts)
                {
                    if (ghost == desiredPosition &&
                        ghostToMove[0] == allyColor)
                    {
                        canMove = !canMove;
                        break;
                    }
                    else if (ghost == desiredPosition && canMove)
                    {
                        interactions.Conflict(ghostToMove,
                            new byte[2] { allyColor, allyGhost },
                            ghosts, enemyGhosts);

                        break;
                    }

                    // Incremente current ghost
                    allyGhost++;

                    // If it is in ghost C, increment color and go back to 
                    // ghost A
                    if (allyGhost == 2)
                    {
                        allyGhost = 0;
                        allyColor++;
                    }
                }
            }
            // In case there is a enemy ghost there
            else if (ghostToMove[0] != enemyTarget[0])
            {
                interactions.Conflict(ghostToMove, enemyTarget,
                    AllGhosts, enemyGhosts);
            }
            else
                canMove = !canMove;

            if (canMove)
            {
                ChangeGhostPos
                   (ref AllGhosts[ghostToMove[0], ghostToMove[1]],
                   direction);
            }
        }

        // Used in moving ghost
        private void ChangeGhostPos(ref byte targetGhost, char direction)
        {
            switch (direction)
            {
                case 'u':
                    if (checker.NoObstacle(direction, targetGhost))
                        targetGhost -= 5;
                    break;
                case 'd':
                    if (checker.NoObstacle(direction, targetGhost))
                        targetGhost += 5;
                    break;
                case 'l':
                    if (checker.NoObstacle(direction, targetGhost))
                        targetGhost -= 1;
                    break;
                case 'r':
                    if (checker.NoObstacle(direction, targetGhost))
                        targetGhost += 1;
                    break;
            }
        }

        // Used in placing ghost
        private void ChangeGhostPos(ref byte targetGhost, byte newPos)
        {
            byte desiredPos = 0;
            
            if (newPos >= 3  && newPos <= 5)
                desiredPos = (byte)(newPos + 1);
            else if (newPos == 6)
                desiredPos = (byte)(newPos + 2);
            else if (newPos >= 7 && newPos <= 11)
                desiredPos = (byte)(newPos + 3);
            else if (newPos == 12)
                desiredPos = (byte)(newPos + 4);
            else if (newPos == 13)
                desiredPos = (byte)(newPos + 5);
            else if (newPos >= 14 && newPos <= 16)
                desiredPos = (byte)(newPos + 6);
            else
                desiredPos = (byte)(newPos + 7);


            targetGhost = desiredPos;
        }

        // Used to know if there is a ghost on the position that the 
        //player wants to place its ghost
        private bool FreeSpot(byte desiredPos, byte [,] enemyGhosts)
        {
            bool freeSpot = true;
            if (desiredPos != 0 || desiredPos != 3 || desiredPos != 15 ||
                desiredPos != 23 || desiredPos != 7 || desiredPos != 9 ||
                desiredPos != 17 || desiredPos != 19)
            {

                foreach (byte ghost in enemyGhosts)
                    if (desiredPos == ghost)
                    {
                        freeSpot = false;
                        break;
                    }
                if (freeSpot)
                {
                    foreach (byte ghost in AllGhosts)
                        if (desiredPos == ghost)
                        {
                            freeSpot = false;
                            break;
                        }
                }
            }
            else
                freeSpot = false;

            return freeSpot;
        }
        
        //
        private byte[] KnowWhichGhost()
        {
            byte[] ghostToMove = new byte[2] { 0, 0 };
            ConsoleKeyInfo input;

            //Receive the ghost's color
            Render.PrintColoredText("What color? \n" +
                "Red ...... <R> or <1>\n" +
                "Blue ..... <B> or <2>\n" +
                "Yellow ... <Y> or <3>\n");

            input = Console.ReadKey();

            Render.Line();
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
                default:
                    ghostToMove[0] = 0;
                    break;
            }


            //Receive wich ghost is
            Render.PrintText("Which ghost? \n" +
                "a .... <A> or <1>\n" +
                "b .... <B> or <2>\n" +
                "c .... <C> or <3>\n");

            input = Console.ReadKey();

            Render.Line();

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

                default:
                    ghostToMove[0] = 0;
                    break;
            }

            return ghostToMove;
        }
    }
}