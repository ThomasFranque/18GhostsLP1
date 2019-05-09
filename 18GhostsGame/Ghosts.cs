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
         Blue Ghosts = ghosts[1,~];
         Yellow Ghosts = ghosts[2,~];
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
                new byte[3, 3] { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } };
            enemyTarget = new byte[2] { 4, 0 };
            interactions = new GhostInteractions();
            checker = new GhostChecker();
        }

        public void ResetGhosts()
        {
            AllGhosts =
                new byte[3, 3] { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } };
        }

        public void Place(byte[,] enemyGhosts)
        {
            string input;
            byte place;
            byte[] ghostToMove = new byte[2] { 0, 0 };
            bool validInput = false;
            
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
                if (!validInput)
                    Render.PrintText("\n>");
                input = Console.ReadLine();

                validInput = byte.TryParse(input, out place);

                if (validInput)
                {
                    if (FreeSpot(place, enemyGhosts, ghostToMove[0]))
                        ChangeGhostPos(ref AllGhosts[ghostToMove[0],
                            ghostToMove[1]], place);
                    else
                    {
                        validInput = !validInput;
                        Render.PrintText("\nPlease choose a valid carpet.");
                    }
                }
                else
                {
                    Render.PrintText("Please choose a valid carpet.");
                }
            }
        }

        public void Move(byte[,] enemyGhosts)
        {
            ConsoleKeyInfo input;

            char direction = ' ';
            byte[] ghostToMove = new byte[2] { 0, 0 };
            byte desiredPosition;

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

            CheckForConflict(ghostToMove, desiredPosition, direction,
                enemyGhosts, false);

            if (desiredPosition == 7 || desiredPosition == 9 ||
                desiredPosition == 17 || desiredPosition == 19)
            {
                Mirror(ghostToMove, enemyGhosts, desiredPosition);

                CheckForConflict(ghostToMove, AllGhosts[ghostToMove[0],
                    ghostToMove[0]], ' ', enemyGhosts, true);
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

            if (newPos >= 3 && newPos <= 5)
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
        private bool FreeSpot(byte desiredPos, byte[,] enemyGhosts, byte color)
        {
            bool validSpot = true;
            // Check for static obstacles

            // Check for color carpets
            switch (color)
            {
                // red
                case 0:
                    if (desiredPos == 2 || desiredPos == 4 ||
                        desiredPos == 8 || desiredPos == 10 ||
                        desiredPos == 14 || desiredPos == 16)
                        validSpot = true;
                    else

                        validSpot = false;
                    break;

                // blue
                case 1:
                    if (desiredPos == 1 || desiredPos == 3 ||
                        desiredPos == 9 || desiredPos == 11 ||
                        desiredPos == 12 || desiredPos == 17)
                        validSpot = true;
                    else

                        validSpot = false;
                    break;

                // yellow
                case 2:
                    if (desiredPos == 5 || desiredPos == 6 ||
                        desiredPos == 7 || desiredPos == 13 ||
                        desiredPos == 15 || desiredPos == 18)
                        validSpot = true;
                    else

                        validSpot = false;
                    break;
            }

            // Check ghost and mirrors position
            if (validSpot)
            {
                // check enemy position
                foreach (byte ghost in enemyGhosts)
                    if (desiredPos == ghost)
                    {
                        validSpot = false;
                        break;
                    }
                if (validSpot)
                {
                    // check ally position
                    foreach (byte ghost in AllGhosts)
                        if (desiredPos == ghost)
                        {
                            validSpot = false;
                            break;
                        }
                }
            }
            else
                validSpot = false;

            return validSpot;
        }

        // find out what ghost the player wants
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

        //
        private void CheckForConflict(byte[] ghostToMove, byte desiredPosition,
           char direction, byte[,] enemyGhosts, bool mirror)
        {
            byte allyColor = 0;
            byte allyGhost = 0;
            bool ableToMove = true;

            // CHECK FOR CONFLICS
            // Check if color between ghosts are not equal to run conflict
            // KILLING GHOSTS OCCURS HERE

            // In case there is no enemy ghost there, check ally
            if (enemyTarget[0] == 4) // Checks if there is a enemy there
            {
                // Check if ally ghost is there and color color
                foreach (byte ghost in AllGhosts)
                { 
                    // Skip the moving ghost
                    if (allyColor == ghostToMove[0] &&
                        allyGhost == ghostToMove[1])
                    {
                        allyGhost++;
                        if (allyGhost >= 3)
                        {
                            allyGhost = 0;
                            allyColor++;
                        }
                        continue;
                    }
                    if (ghost == desiredPosition &&
                        ghostToMove[0] == allyColor)
                    {
                        ableToMove = false;
                        break;
                    }
                    else if (ghost == desiredPosition)
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
                ableToMove = false;

            if (ableToMove && !mirror)
            {
                ChangeGhostPos
                   (ref AllGhosts[ghostToMove[0], ghostToMove[1]],
                   direction);
            }
        }

        // Used when ghost is on mirror
        private void Mirror(byte[] ghostToMove, 
            byte[,] enemyGhosts, byte currentMirror)
        {
            string input;
            byte mirror;
            bool validInput = false;
            byte newMirror = 0;

            switch (currentMirror)
            {
                case 7:
                    currentMirror = 1;
                    break;

                case 9:
                    currentMirror = 2;
                    break;

                case 17:
                    currentMirror = 3;
                    break;

                case 19:
                    currentMirror = 4;
                    break;
            }

            Render.ShowPlacingSpots(3);

            while (!validInput)
            {
                if (!validInput)
                    Render.PrintText("\n>");
                input = Console.ReadLine();

                validInput = byte.TryParse(input, out mirror);

                if (validInput)
                {
                    switch (mirror)
                    {
                        case 1:
                            newMirror = 7;
                            break;

                        case 2:
                            newMirror = 9;
                            break;

                        case 3:
                            newMirror = 17;
                            break;

                        case 4:
                            newMirror = 19;
                            break;
                    }
                    if (CheckMirror
                        (enemyGhosts, currentMirror, mirror, ghostToMove,
                        newMirror))
                        MoveToMirror
                            (ref AllGhosts[ghostToMove[0], ghostToMove[1]], 
                            mirror);
                    else
                    {
                        validInput = !validInput;
                        Render.PrintText("\nPlease choose a valid mirror.");
                    }
                }
                else
                {
                    Render.PrintText("Please choose a valid mirror.");
                }
            }
        }

        private void MoveToMirror(ref byte targetGhost, byte mirror)
        {
            switch (mirror)
            {
                case 1:
                    targetGhost = 7;
                    break;

                case 2:
                    targetGhost = 9;
                    break;

                case 3:
                    targetGhost = 17;
                    break;

                case 4:
                    targetGhost = 19;
                    break;
            }
        }

        // Check if can move to mirror
        private bool CheckMirror
            (byte[,] enemyGhosts, byte currentMirror, 
            byte chosenMirror, byte[] ghostToMove, byte newMirrorPos)
        {
            bool ableToMove = true;
            byte counterColor = 0;
            byte counterLetter = 0;

            if (chosenMirror >= 1 && chosenMirror <= 4 && 
                chosenMirror != currentMirror)
            {

                foreach (byte ghost in AllGhosts)
                {
                    // Skip the moving ghost
                    if (counterColor == ghostToMove[0] &&
                        counterLetter == ghostToMove[1])
                    {
                        counterLetter++;
                        if (counterLetter >= 3)
                        {
                            counterLetter = 0;
                            counterColor++;
                        }
                        continue;
                    }
                    if (ghost == newMirrorPos &&
                    counterColor == ghostToMove[0])
                    {
                        ableToMove = false;
                        break;
                    }

                    // Incremente current ghost
                    counterLetter++;

                    // If it is in ghost C, increment color and go back to 
                    // ghost A
                    if (counterLetter >= 3)
                    {
                        counterLetter = 0;
                        counterColor++;
                    }
                }

                counterLetter = 0;
                counterColor = 0;

                foreach (byte ghost in enemyGhosts)
                {
                    if (ghost == newMirrorPos &&
                        counterColor == ghostToMove[0])
                    {
                        ableToMove = false;
                        break;
                    }

                    // Incremente current ghost
                    counterLetter++;

                    // If it is in ghost C, increment color and go back to 
                    // ghost A
                    if (counterLetter >= 3)
                    {
                        counterLetter = 0;
                        counterColor++;
                    }
                }
            }
            else
                ableToMove = false;

            return ableToMove;
        }
    }
}