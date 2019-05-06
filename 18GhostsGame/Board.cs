using System;
using System.Collections.Generic;
using System.Text;


/* TO-DO
 * 1.Improve the overall performace of this class as well as organizing it
 * 2.XML documentation
 */

// DONT FORGET XML DOCUMENTATION!!!!!!!

namespace _18GhostsGame
{
    /// <summary>
    /// W.
    /// </summary>
    class Board
    {
        Portal portal = new Portal();
        // Variables

        private readonly Symbols[] ghostSymsP1, ghostSymsP2;

        public Board()
        {
            BoardRenderer.SetConsoleEncoding();            

            // Getting the player symbols (ghost symbols from each player)
            ghostSymsP1 = new Symbols[3]
                {Symbols.ghosts1P1, Symbols.ghosts2P1, Symbols.ghosts3P1};

            ghostSymsP2 = new Symbols[3]
                {Symbols.ghosts1P2, Symbols.ghosts2P2, Symbols.ghosts3P2};
        }

        public void Draw(byte[,] p1Ghosts, byte[,] p2Ghosts)
        {
            // Temporary method variables
            byte line = 0;
            byte[] ghostPos;
            // Used to not print carpets when a ghost is there
            Symbols symbol = Symbols.blank;

            // Printing starts
            // Print the first horizontal lines
            BoardRenderer.PrintHorizontalLines();

            // Print all the upcoming lines to make a 5x5 board
            for (byte i = 0; i < 5; i++)
            {
                // Increment current line
                line++;

                // Print vertical lines
                BoardRenderer.PrintVerticalLines();

                // Printing middle lines
                for (byte j = 0; j < 31; j++)
                {
                    // Not a column space (Middle Spaces)
                    if (!BoardChecker.CheckInBoard("column", line, j) &&
                        BoardChecker.CheckInBoard("middle", line, j))
                        // Red Portal place
                        if (BoardChecker.CheckInBoard("red", line, j))
                        {
                            BoardRenderer.SetConsoleColor('R');
                            BoardRenderer.PrintPortalSymbol(portal.RedPortalState);
                            j++;
                        }
                        // Yellow Portal place
                        else if (BoardChecker.CheckInBoard("yellow", line, j))
                        {
                            BoardRenderer.SetConsoleColor('Y');
                            BoardRenderer.PrintPortalSymbol
                                (portal.YellowPortalState);
                            j++;
                        }
                        // Blue Portal place
                        else if (BoardChecker.CheckInBoard("blue", line, j))
                        {
                            BoardRenderer.SetConsoleColor('C');
                            BoardRenderer.PrintPortalSymbol(portal.BluePortalState);
                            j++;
                        }

                        // Place carpets / ghosts (empty middle spaces)
                        // Keep in mind: Player 1 ghosts will allways be on top
                        else if (BoardChecker.CheckInBoard("middle", line, j))
                        {
                            // Player 1 ghosts
                            foreach (byte ghost in p1Ghosts)
                            {
                                ghostPos =
                                    Convertions.NormalizePositions(ghost);
                                if (BoardChecker.CheckInBoard(ghostPos, line, j))
                                {
                                    BoardRenderer.PrintSymbol
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
                                if (BoardChecker.CheckInBoard(ghostPos, line, j))
                                {
                                    BoardRenderer.PrintSymbol
                                        (ghostSymsP2, ghost, p2Ghosts);
                                    j++;
                                    break;
                                }
                            }
                            // Carpets if there is no ghost there
                            if (BoardChecker.CheckInBoard("middle", line, j))
                            {
                                symbol = Symbols.carpet;
                                BoardRenderer.SetCarpetColor(line, j);
                            }

                            // Mirrors if there is no ghost there
                            if (BoardChecker.CheckInBoard("mirror", line, j))
                                symbol = Symbols.mirrors;
                        }

                        // Ret symbol to blank Spaces in line
                        else
                            symbol = Symbols.blank;

                    // Vertical line space
                    else if (BoardChecker.CheckInBoard("column", line, j))
                        symbol = Symbols.column;

                    // Empty spot
                    else
                        symbol = Symbols.blank;

                    BoardRenderer.PrintSymbol(symbol);
                    BoardRenderer.ResetConsoleColor();
                    Console.ResetColor();

                }

                // Print cell bottom lines
                BoardRenderer.PrintBottomLines();
            }
            // Print the Dungeon
            BoardRenderer.DrawDungeon(p1Ghosts, ghostSymsP1, p2Ghosts, ghostSymsP2);
        }        

        public void GhostDead(string color)
        {
            portal.Rotate(color);
        }
    }
}