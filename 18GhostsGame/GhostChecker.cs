namespace _18GhostsGame
{
    /// <summary>
    /// Will check for obstacles, positions and ghosts 
    /// </summary>
    class GhostChecker
    {
        /// <summary>
        /// This method is for knowing if there is a ghost 
        /// in the target location
        /// if enemy ghost is {4,0}, there is no ghost there
        /// </summary>
        /// <param name="direction">Up, Down, Left, Right</param>
        /// <param name="targetGhost">Moving ghost</param>
        /// <param name="enemyGhosts">Target player ghosts</param>
        /// <returns>Ghost in the target location</returns>
        public byte[] CheckAdjacentPos
            (char direction, byte targetGhost, byte[,] enemyGhosts)
        {
            // finalGhost[0] = Which ghost: first, second or third
            // finalGhost[1] = Color of the ghost: red, blue, yellow

            //Temporary variables
            byte[] enemyGhost = new byte[2] { 4, 0 };
            byte targetPos;

            // Know where it is going to move to
            targetPos = DesiredPosition(direction, targetGhost);

            // Check if there is the target position there
            if (CheckAllForEqual(targetPos, enemyGhosts))
                enemyGhost = FindGhost(targetPos, enemyGhosts);

            return enemyGhost;
        }

        /// <summary>
        /// Find the enemy ghost color and letter
        /// </summary>
        /// <param name="targetGhost">Ghost to find</param>
        /// <param name="allGhosts">Target player ghosts</param>
        /// <returns>Final ghost color and letter</returns>
        public byte[] FindGhost(byte targetGhost, byte[,] allGhosts)
        {
            //Temporary variables
            byte[] finalGhost = new byte[2] { 0, 0 };
            byte counter = 0;

            foreach (byte ghost in allGhosts)
            {
                if (finalGhost[0] == 0)
                    counter++;
                else
                    break;

                // Check for the same target ghost number on player ghosts
                if (ghost == targetGhost)
                    switch (counter)
                    {
                        // Ghost 1
                        case 1:
                        case 4:
                        case 7:
                            finalGhost[0] = 0;
                            break;
                        // Ghost 2
                        case 2:
                        case 5:
                        case 8:
                            finalGhost[0] = 1;
                            break;
                        // Ghost 3
                        case 3:
                        case 6:
                        case 9:
                            finalGhost[0] = 2;
                            break;
                    }
            }
            // Check corresponding ghost color
            // Red ghosts
            if (counter <= 3)
                finalGhost[1] = 0;
            // Blue ghosts
            else if (counter <= 6)
                finalGhost[1] = 1;
            // Yellow ghosts
            else
                finalGhost[1] = 2;

            return finalGhost;
        }

        /// <summary>
        /// Check if there is a ghost in the target position
        /// </summary>
        /// <param name="targetPos">Target position</param>
        /// <param name="allGhosts">Target player ghosts</param>
        /// <returns>True if the ghost is in the target position</returns>
        private bool CheckAllForEqual(byte targetPos, byte[,] allGhosts)
        {
            //Temporary variable
            bool isEqual = false;

            foreach (byte ghost in allGhosts)
            {
                if (targetPos == ghost)
                {
                    isEqual = true;
                    break;
                }
            }
            return isEqual;
        }

        /// <summary>
        /// Used for checking if there are obstacles in the target position
        /// </summary>
        /// <param name="pos">Target position</param>
        /// <param name="obstacles">Obstacles to check for</param>
        /// <returns>True if there is an obstacle there</returns>
        private bool CheckAllForEqual(byte pos, byte[] obstacles)
        {
            //Temporary variable
            bool obstacle = false;

            // Is in dungeon?
            if (pos == 0)
                obstacle = true;
            // If not, check given obstacles
            else
                foreach (byte position in obstacles)
                    if (position == pos)
                    {
                        obstacle = true;
                        break;
                    }

            return obstacle;
        }

        /// <summary>
        /// Check where the ghost will end up
        /// </summary>
        /// <param name="direction">Up, Down, Left, Right</param>
        /// <param name="targetGhost">Target ghost position</param>
        /// <returns>Desired position</returns>
        public byte DesiredPosition(char direction, byte targetGhost)
        {
            //Temporary variable
            byte targetPos = 0;

            // Check direction
            switch (direction)
            {
                // Up
                case 'u':
                    targetPos = (byte)(targetGhost - 5);
                    break;
                // Down
                case 'd':
                    targetPos = (byte)(targetGhost + 5);
                    break;
                // Left
                case 'l':
                    targetPos = (byte)(targetGhost - 1);
                    break;
                // Right
                case 'r':
                    targetPos = (byte)(targetGhost + 1);
                    break;
            }

            return targetPos;
        }

        /// <summary>
        /// Check if there is and obstacle in the desired position tile
        /// </summary>
        /// <param name="direction">Up, Down, Left, Right</param>
        /// <param name="pos">Target position</param>
        /// <returns>True if there is no obstacle</returns>
        public bool NoObstacle(char direction, byte pos)
        {
            bool canMove = false;

            // Check direction
            switch (direction)
            {
                // Moving Up
                case 'u':
                    if (pos > 5 &&
                        !CheckAllForEqual(pos, new byte[] { 8, 20 }))
                        canMove = true;
                    break;
                // Moving Down
                case 'd':
                    if (pos <= 21 &&
                        !CheckAllForEqual(pos, new byte[] { 10, 18 }))
                        canMove = true;
                    break;
                // Moving Left
                case 'l':
                    if (!CheckAllForEqual(pos,
                        new byte[] { 1, 4, 6, 11, 16, 21, 24 }))
                        canMove = true;
                    break;
                // Moving Right
                case 'r':
                    if (!CheckAllForEqual(pos,
                        new byte[] { 2, 5, 10, 14, 15, 20, 22, 25 }))
                        canMove = true;
                    break;
            }

            return canMove;
        }
    }
}
