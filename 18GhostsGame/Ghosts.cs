using System;

namespace _18GhostsGame
{
    /// <summary>
    /// Controls the ghosts positions and conflicts
    /// </summary>
    class Ghosts
    {
        // Variables
        GhostInteractions interactions;
        GhostChecker checker;

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


        /// <summary>
        /// Constructor Ghosts sets variables to default values
        /// </summary>
        public Ghosts()
        {
            AllGhosts =
                new byte[3, 3] { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } };
            enemyTarget = new byte[2] { 4, 0 };
            interactions = new GhostInteractions();
            checker = new GhostChecker();
        }

        /// <summary>
        /// Placing ghosts from dungeon action
        /// </summary>
        /// <param name="enemyGhosts">Enemy ghosts</param>
        public void Place(byte[,] enemyGhosts)
        {
            // Method variables
            string input;
            byte place;
            byte[] ghostToMove = new byte[2] { 0, 0 };
            bool validInput = false;

            // While not a valid ghost
            while (true)
            {
                ghostToMove = KnowWhichGhost();

                //Check if ghost to place is in the dungeon
                if (AllGhosts[ghostToMove[0], ghostToMove[1]] != 0)
                    Render.PrintText("\nPlease insert a valid ghost.\n");
                else
                    break;
            }

            // Where to place it
            Render.ShowPlacingSpots(ghostToMove[0]);
            // While not a valid input
            while (!validInput)
            {
                // Ask for input
                if (!validInput)
                    Render.PrintText("\n>");
                input = Console.ReadLine();

                // Check if it is a valid input
                validInput = byte.TryParse(input, out place);

                if (validInput)
                {
                    // Check if the ghost can be placed there
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

        /// <summary>
        /// Moving ghosts action
        /// </summary>
        /// <param name="enemyGhosts">Enemy ghosts</param>
        public void Move(byte[,] enemyGhosts)
        {
            // Method variables
            ConsoleKeyInfo input;

            char direction = ' ';
            byte[] ghostToMove = new byte[2] { 0, 0 };
            byte desiredPosition;

            // Find out the player target ghost
            ghostToMove = KnowWhichGhost();

            // Receive the direction
            Render.PrintText("In which direction? \n" +
                "Up ....... <W> or <Up Arrow>\n" +
                "Down ..... <S> or <Down Arrow>\n" +
                "Left ..... <A> or <Left Arrow>\n" +
                "Right .... <D> or <Right Arrow>\n");
            // Get player intention
            input = Console.ReadKey();
            // Print gap
            Render.Line();

            // Check desired direction
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

            // Store enemy ghost in the target position
            enemyTarget = checker.CheckAdjacentPos
                (direction, AllGhosts[ghostToMove[0], ghostToMove[1]],
                enemyGhosts);

            // Check desired position number
            desiredPosition = checker.DesiredPosition
                (direction, AllGhosts[ghostToMove[0], ghostToMove[1]]);

            // Check if there is a conflict
            CheckForConflict(ghostToMove, desiredPosition, direction,
                enemyGhosts, false);

            // If the ghost is standing in a mirror
            if (desiredPosition == 7 || desiredPosition == 9 ||
                desiredPosition == 17 || desiredPosition == 19)
            {
                // Call mirror method
                Mirror(ghostToMove, enemyGhosts, desiredPosition);

                // Check if there is a conflict after teleporting
                CheckForConflict(ghostToMove, AllGhosts[ghostToMove[0],
                    ghostToMove[0]], ' ', enemyGhosts, true);
            }
        }

        /// <summary>
        /// Used by the action Move.
        /// Changes the target ghost value to the desired position
        /// </summary>
        /// <param name="targetGhost">Target ghost</param>
        /// <param name="direction">Up, Down, Left, Right</param>
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

        /// <summary>
        /// Used by the Placing action.
        /// Takes ghost from the dungeon to the desired position
        /// </summary>
        /// <param name="targetGhost">Target ghost</param>
        /// <param name="newPos">Desired position</param>
        private void ChangeGhostPos(ref byte targetGhost, byte newPos)
        {
            byte desiredPos = 0;
            if (newPos >= 1 && newPos <= 2)
                desiredPos = newPos;
            else if (newPos >= 3 && newPos <= 5)
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

        /// <summary>
        /// Normalize input number to match asked player inputs
        /// </summary>
        /// <param name="newPos">Inputted position</param>
        /// <returns>Normalized desired position</returns>
        private byte LocateGhostInput(byte newPos)
        {
            byte desiredPos = 0;

            // Check for input numbers
            if (newPos >= 1 && newPos <= 2)
                desiredPos = newPos;
            else if (newPos >= 3 && newPos <= 5)
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

            return desiredPos;
        }

        /// <summary>
        /// Used to know if there is a ghost on the position that the 
        /// player wants to place its ghost
        /// </summary>
        /// <param name="desiredPos">Desired position</param>
        /// <param name="enemyGhosts">Enemy ghosts</param>
        /// <param name="color">Ghost color</param>
        /// <returns>True is the place is valid</returns>
        private bool FreeSpot(byte desiredPos, byte[,] enemyGhosts, byte color)
        {
            // Temporary variable
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
                Console.WriteLine(desiredPos);
                foreach (byte ghost in enemyGhosts)
                    if (LocateGhostInput(desiredPos) == ghost)
                    {
                        validSpot = false;
                        break;
                    }
                if (validSpot)
                {
                    // check ally position
                    foreach (byte ghost in AllGhosts)
                        if (LocateGhostInput(desiredPos) == ghost)
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

        /// <summary>
        ///  Find out what ghost the player wants to target
        /// </summary>
        /// <returns>Target ghost color and letter</returns>
        private byte[] KnowWhichGhost()
        {
            // Temporary method variables
            byte[] ghostToMove = new byte[2] { 0, 0 };
            ConsoleKeyInfo input;

            // Receive the ghost color
            Render.PrintColoredText("What color? \n" +
                "Red ...... <R> or <1>\n" +
                "Blue ..... <B> or <2>\n" +
                "Yellow ... <Y> or <3>\n");
            // Receive player intention
            input = Console.ReadKey();
            // Print gap
            Render.Line();

            // Check inputted key
            switch (input.Key)
            {
                //Red
                case ConsoleKey.R:
                case ConsoleKey.D1:
                    ghostToMove[0] = 0;
                    break;

                // Blue
                case ConsoleKey.B:
                case ConsoleKey.D2:
                    ghostToMove[0] = 1;
                    break;

                // Yellow
                case ConsoleKey.Y:
                case ConsoleKey.D3:
                    ghostToMove[0] = 2;
                    break;

                // Default Red
                default:
                    ghostToMove[0] = 0;
                    break;
            }


            //Receive wich ghost is
            Render.PrintText("Which ghost? \n" +
                "a .... <A> or <1>\n" +
                "b .... <B> or <2>\n" +
                "c .... <C> or <3>\n");
            // Receive player intention
            input = Console.ReadKey();
            // Print gap
            Render.Line();

            // Check inputted key
            switch (input.Key)
            {
                // Ghost a
                case ConsoleKey.A:
                case ConsoleKey.D1:
                    ghostToMove[1] = 0;
                    break;

                // Ghost b
                case ConsoleKey.B:
                case ConsoleKey.D2:
                    ghostToMove[1] = 1;
                    break;

                // Ghost c
                case ConsoleKey.C:
                case ConsoleKey.D3:
                    ghostToMove[1] = 2;
                    break;

                // Default ghost a
                default:
                    ghostToMove[0] = 0;
                    break;
            }

            return ghostToMove;
        }

        /// <summary>
        /// Will check if there are any conflicts between ghosts
        /// </summary>
        /// <param name="ghostToMove">Target ghosts to move</param>
        /// <param name="desiredPosition">New position</param>
        /// <param name="direction">Direction to move</param>
        /// <param name="enemyGhosts">Enemy ghosts</param>
        /// <param name="mirror">Is in mirror</param>
        private void CheckForConflict(byte[] ghostToMove, byte desiredPosition,
           char direction, byte[,] enemyGhosts, bool mirror)
        {
            // Temporary method variables
            byte allyColor = 0;
            byte allyGhost = 0;
            bool ableToMove = true;

            // In case there is no enemy ghost there, check ally
            // Check if there is a enemy there
            if (enemyTarget[0] == 4)
            {
                // Check if ally ghost is there and color color
                foreach (byte ghost in AllGhosts)
                {
                    // Skip the moving ghost
                    if (allyColor == ghostToMove[0] &&
                        allyGhost == ghostToMove[1])
                    {
                        // Increment current ghost
                        allyGhost++;
                        // If counter is in ghost C, increment color and go back to 
                        // ghost A
                        if (allyGhost >= 3)
                        {
                            allyGhost = 0;
                            allyColor++;
                        }
                        continue;
                    }

                    // Check if an ally has the same color
                    if (ghost == desiredPosition &&
                        ghostToMove[0] == allyColor)
                    {
                        // Cannot move
                        ableToMove = false;
                        break;
                    }
                    // If an ally is there and not with the same color
                    else if (ghost == desiredPosition)
                    {
                        // Run conflict
                        interactions.Conflict(ghostToMove,
                            new byte[2] { allyColor, allyGhost },
                            ghosts, enemyGhosts);
                        break;
                    }

                    // Increment current ghost
                    allyGhost++;

                    // If counter is in ghost C, increment color and go back to 
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
                // Run conflict
                interactions.Conflict(ghostToMove, enemyTarget,
                    AllGhosts, enemyGhosts);
            }
            // If the colors are the same
            else
                ableToMove = false;

            // Check if can move after killing
            if (ableToMove && !mirror)
            {
                // Change the ghost position
                ChangeGhostPos
                   (ref AllGhosts[ghostToMove[0], ghostToMove[1]],
                   direction);
            }
        }

        /// <summary>
        /// Used when ghost is on mirror to start the teleport procedure
        /// </summary>
        /// <param name="ghostToMove">Target ghost to teleport</param>
        /// <param name="enemyGhosts">Enemy ghosts</param>
        /// <param name="currentMirror">Current standing mirror</param>
        private void Mirror(byte[] ghostToMove,
            byte[,] enemyGhosts, byte currentMirror)
        {
            // Temporary variables
            string input;
            byte mirror;
            bool validInput = false;
            byte newMirror = 0;

            // Normalize the current mirror to player input
            switch (currentMirror)
            {
                case 7:
                    // Top left mirror
                    currentMirror = 1;
                    break;

                case 9:
                    // Top right mirror
                    currentMirror = 2;
                    break;

                case 17:
                    // Bottom left mirror
                    currentMirror = 3;
                    break;

                case 19:
                    // Bottom right mirror
                    currentMirror = 4;
                    break;
            }

            // Show mirror spots
            Render.ShowPlacingSpots(3);

            // If the inputted value isnt valid
            while (!validInput)
            {
                // Ask for input
                Render.PrintText("\n>");
                input = Console.ReadLine();

                // Check if the input is valid
                validInput = byte.TryParse(input, out mirror);

                // Check inputted value
                if (validInput)
                {
                    switch (mirror)
                    {
                        // Top left mirror
                        case 1:
                            newMirror = 7;
                            break;
                        // Top right mirror
                        case 2:
                            newMirror = 9;
                            break;
                        // Bottom left mirror
                        case 3:
                            newMirror = 17;
                            break;
                        // Bottom right mirror
                        case 4:
                            newMirror = 19;
                            break;
                    }
                    // If the mirror is available
                    if (CheckMirror
                        (enemyGhosts, currentMirror, mirror, ghostToMove,
                        newMirror))
                        // Move ghost to mirror
                        MoveToMirror
                            (ref AllGhosts[ghostToMove[0], ghostToMove[1]],
                            mirror);
                    // Mirror is not available
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

        /// <summary>
        /// Moves the given ghost to the desired mirror
        /// </summary>
        /// <param name="targetGhost">Ghost to be teleported</param>
        /// <param name="mirror">Target mirror</param>
        private void MoveToMirror(ref byte targetGhost, byte mirror)
        {
            // Check target mirror
            switch (mirror)
            {
                case 1:
                    // Top left mirror
                    targetGhost = 7;
                    break;

                case 2:
                    // Top right mirror
                    targetGhost = 9;
                    break;

                case 3:
                    // Bottom left mirror
                    targetGhost = 17;
                    break;

                case 4:
                    // Bottom right mirror
                    targetGhost = 19;
                    break;
            }
        }

        /// <summary>
        /// Check if the given ghost can move to the desired mirror
        /// </summary>
        /// <param name="enemyGhosts">Enemy ghosts</param>
        /// <param name="currentMirror">Current standing mirror</param>
        /// <param name="chosenMirror">Chosen mirror input</param>
        /// <param name="ghostToMove">Target ghost to teleport</param>
        /// <param name="newMirrorPos">New mirror position</param>
        /// <returns>True if it can teleport</returns>
        private bool CheckMirror
            (byte[,] enemyGhosts, byte currentMirror,
            byte chosenMirror, byte[] ghostToMove, byte newMirrorPos)
        {
            // Temporary method variables
            bool ableToMove = true;
            byte counterColor = 0;
            byte counterLetter = 0;

            // Check if inputted value is valid
            if (chosenMirror >= 1 && chosenMirror <= 4 &&
                chosenMirror != currentMirror)
            {
                // Check all the ally ghosts 
                foreach (byte ghost in AllGhosts)
                {
                    // Skip the moving ghost
                    if (counterColor == ghostToMove[0] &&
                        counterLetter == ghostToMove[1])
                    {
                        // Increment letter index
                        counterLetter++;
                        if (counterLetter >= 3)
                        {
                            counterLetter = 0;
                            // Increment color index
                            counterColor++;
                        }
                        continue;
                    }

                    // if there is a ghost with the same color
                    if (ghost == newMirrorPos &&
                    counterColor == ghostToMove[0])
                    {
                        ableToMove = false;
                        break;
                    }

                    // Increment current ghost
                    counterLetter++;

                    // If it is in ghost C, increment color and go back to 
                    // ghost A
                    if (counterLetter >= 3)
                    {
                        counterLetter = 0;
                        counterColor++;
                    }
                }

                // Reset indexes to reuse in enemy ghosts
                counterLetter = 0;
                counterColor = 0;

                // Check all enemy ghosts
                foreach (byte ghost in enemyGhosts)
                {
                    // If there is a ghost with the same color
                    if (ghost == newMirrorPos &&
                        counterColor == ghostToMove[0])
                    {
                        ableToMove = false;
                        break;
                    }

                    // Increment current ghost
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
            // Not a valid input
            else
                ableToMove = false;

            return ableToMove;
        }
    }
}