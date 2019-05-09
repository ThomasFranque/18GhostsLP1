namespace _18GhostsGame
{
    /// <summary>
    /// Draws the board, dungeon and score
    /// </summary>
    class Board
    {
        // Variables
        BoardChecker checker;
        // Read-only variable
        private readonly Symbols[] ghostSymsP1, ghostSymsP2;

        /// <summary>
        /// Constructor Board sets default values and prepares console for 
        /// unicode
        /// </summary>
        public Board()
        {
            checker = new BoardChecker();
            // Prepare for unicode encoding
            Render.SetConsoleEncoding();

            // Getting the player symbols (ghost symbols from each player)
            ghostSymsP1 = new Symbols[3]
                {Symbols.ghosts1P1, Symbols.ghosts2P1, Symbols.ghosts3P1};

            ghostSymsP2 = new Symbols[3]
                {Symbols.ghosts1P2, Symbols.ghosts2P2, Symbols.ghosts3P2};
        }

        /// <summary>
        /// Will draw the board, calling necessary methods to do so
        /// </summary>
        /// <param name="p1Ghosts">Every Player 1 ghosts</param>
        /// <param name="p2Ghosts">Every Player 2 ghosts</param>
        public void Draw(byte[,] p1Ghosts, byte[,] p2Ghosts)
        {
            Render.Clear();

            // Temporary method variables
            byte line = 0;
            byte[] ghostPos;
            Symbols symbol = Symbols.blank;

            // Printing starts

            // Print the first horizontal lines
            Render.PrintScoreTable();
            Render.PrintHorizontalLines();

            // Print all the upcoming lines to make a 5x5 board
            for (byte i = 0; i < 5; i++)
            {
                // Increment current line
                line++;

                // Print vertical lines
                Render.PrintVerticalLines();

                // Printing middle lines
                for (byte j = 0; j < 31; j++)
                {
                    // Not a column space (Middle Spaces)
                    if (!checker.CheckInBoard("column", line, j) &&
                        checker.CheckInBoard("middle", line, j))
                        // Red Portal place
                        if (checker.CheckInBoard("red", line, j))
                        {
                            Render.SetConsoleColor('R');
                            Render.PrintPortalSymbol
                                (Portal.RedPortalState);
                            j++;
                        }
                        // Yellow Portal place
                        else if (checker.CheckInBoard("yellow", line, j))
                        {
                            Render.SetConsoleColor('Y');
                            Render.PrintPortalSymbol
                                (Portal.YellowPortalState);
                            j++;
                        }
                        // Blue Portal place
                        else if (checker.CheckInBoard("blue", line, j))
                        {
                            Render.SetConsoleColor('C');
                            Render.PrintPortalSymbol
                                (Portal.BluePortalState);
                            j++;
                        }

                        // Place carpets / ghosts (empty middle spaces)
                        else if (checker.CheckInBoard("middle", line, j)
                            || (line == 3 && j == 16))
                        {
                            // Player 1 ghosts
                            foreach (byte ghost in p1Ghosts)
                            {
                                ghostPos =
                                    Convertions.NormalizePositions(ghost);
                                if (checker.CheckInBoard
                                    (ghostPos, line, j))
                                {
                                    Render.PrintSymbol
                                        (ghostSymsP1, ghost, p1Ghosts);
                                    j++;
                                    break;
                                }
                            }
                            // Player 2 Ghosts
                            foreach (byte ghost in p2Ghosts)
                            {
                                symbol = Symbols.blank;

                                ghostPos =
                                    Convertions.NormalizePositions(ghost);
                                if (checker.CheckInBoard
                                    (ghostPos, line, j))
                                {
                                    Render.PrintSymbol
                                        (ghostSymsP2, ghost, p2Ghosts);
                                    j++;
                                    break;
                                }
                            }
                            // Carpets if there is no ghost there
                            if (checker.CheckInBoard("middle", line, j))
                            {
                                symbol = Symbols.carpet;
                                Render.SetCarpetColor(line, j);
                            }

                            // Mirrors if there is no ghost there
                            if (checker.CheckInBoard("mirror", line, j))
                                symbol = Symbols.mirrors;
                        }

                        // Revert symbol to blank Spaces in line
                        else
                            symbol = Symbols.blank;

                    // Vertical line space
                    else if (checker.CheckInBoard("column", line, j))
                        symbol = Symbols.column;

                    // Empty spot
                    else
                        symbol = Symbols.blank;

                    Render.PrintSymbol(symbol);
                    Render.ResetConsoleColor();

                }

                // Print cell bottom lines
                Render.PrintBottomLines();
            }
            // Print the Dungeon
            Render.DrawDungeon
                (p1Ghosts, ghostSymsP1, p2Ghosts, ghostSymsP2);

            // Print conflict colors
            Render.ColorConflics();
        }
    }
}