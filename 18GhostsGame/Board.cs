using System;
using System.Collections.Generic;
using System.Text;


/* TO-DO
 * 1.Create method for error message (maybe not in this class?)
 * 2.Improve the overall performace of this class as well as organizing it
 * 2.1.Stop foreach loops when done with 'break;'!
 * 3.XML documentation
 * 4.Change console color in Renderer
 */

// DONT FORGET XML DOCUMENTATION!!!!!!!

namespace _18GhostsGame
{
    /// <summary>
    /// Will only print elements in the console, making the required math to 
    /// do so, control the state and rotation of portals and mirrors.
    /// </summary>
    class Board
    {
        // Variables

        public string RedPortalState { get; private set; }

        public string BluePortalState { get; private set; }

        public string YellowPortalState { get; private set; }

        private readonly Symbols[] ghostSymsP1, ghostSymsP2;

        public Board()
        {
            Renderer.SetConsoleEncoding();
            
            // Portals default positions
            RedPortalState = "up";
            BluePortalState = "down";
            YellowPortalState = "right";

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
            Renderer.PrintHorizontalLines();

            // Print all the upcoming lines to make a 5x5 board
            for (byte i = 0; i < 5; i++)
            {
                // Increment current line
                line++;

                // Print vertical lines
                Renderer.PrintVerticalLines();

                // Printing middle lines
                for (byte j = 0; j < 31; j++)
                {
                    // Not a column space (Middle Spaces)
                    if (j % 6 != 0)
                        // Red Portal place
                        if (Checker.CheckInBoard("red", line, j))
                        {
                            Renderer.SetConsoleColor('R');
                            symbol = GetPortalSymbol(RedPortalState);
                        }
                        // Yellow Portal place
                        else if (Checker.CheckInBoard("yellow", line, j))
                        {
                            Renderer.SetConsoleColor('Y');
                            symbol = GetPortalSymbol(YellowPortalState);
                        }
                        // Blue Portal place
                        else if (Checker.CheckInBoard("blue", line, j))
                        {
                            Renderer.SetConsoleColor('C');
                            symbol = GetPortalSymbol(BluePortalState);
                        }

                        // Place carpets / ghosts (empty middle spaces)
                        // Keep in mind: Player 1 ghosts will allways be on top
                        else if (Checker.CheckInBoard("middle", line, j))
                        {
                            // Player 1 ghosts
                            foreach (byte ghost in p1Ghosts)
                            {
                                ghostPos = 
                                    Convertions.NormalizePositions(ghost);
                                if (Checker.CheckInBoard(ghostPos, line, j))
                                {
                                    Renderer.PrintSymbol
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
                                if (Checker.CheckInBoard(ghostPos, line, j))
                                {
                                    Renderer.PrintSymbol
                                        (ghostSymsP2, ghost, p2Ghosts);
                                    j++;
                                    break;
                                }
                            }
                            // Print carpet if there is no ghost there
                            if (Checker.CheckInBoard("middle", line, j))
                            {
                                symbol = Symbols.carpet;
                                Renderer.SetCarpetColor(line, j);
                            }

                            // Mirrors
                            if (Checker.CheckInBoard("mirror", line, j))
                                symbol = Symbols.mirrors;
                        }

                        // Fill blank Spaces in line
                        else
                            symbol = Symbols.blank;

                    // Vertical line space
                    else
                        symbol = Symbols.column;

                    Renderer.PrintSymbol(symbol);
                    Renderer.ResetConsoleColor();
                    Console.ResetColor();

                }

                // Print cell bottom lines
                Renderer.PrintBottomLines();


            }
            // Print the Dungeon
            Renderer.DrawDungeon(p1Ghosts, ghostSymsP1, p2Ghosts, ghostSymsP2);
        }        

        /// Returns the new rotation, clockwise, of the given portal
        private string PortalRotate(string portal)
        {
            string newPosition = "";
            switch (portal)
            {
                case "up":
                    newPosition = "right";
                    break;

                case "down":
                    newPosition = "left";
                    break;

                case "right":
                    newPosition = "down";
                    break;

                case "left":
                    newPosition = "up";
                    break;

                default:
                    Renderer.Error("PortalRotate() in Board.cs", 
                        "Given rotation doesn't exist");
                    break;
            }
            return newPosition;
        }
        
        // Know wich symbol represents up down left and right
        private Symbols GetPortalSymbol(string portal)
        {
            Symbols symbolToReturn;
            symbolToReturn = Symbols.blank;

            switch (portal)
            {
                case "up":
                    symbolToReturn = Symbols.portalUp;
                    break;
                case "down":
                    symbolToReturn = Symbols.portalDown;
                    break;
                case "right":
                    symbolToReturn = Symbols.portalRight;
                    break;
                case "left":
                    symbolToReturn = Symbols.portalLeft;
                    break;

                default:
                    Renderer.Error("GetPortalSymbol() in Board.cs",
                        "Given rotation doesn't exist");
                    break;
            }
            return symbolToReturn;
        }

        // Used outside of class to know what ghost died
        public void GhostDead(string color)
        {
            switch (color)
            {
                case "red":
                    RedPortalState = PortalRotate(RedPortalState);
                    break;
                case "blue":
                    BluePortalState = PortalRotate(BluePortalState);
                    break;
                case "yellow":
                    YellowPortalState = PortalRotate(YellowPortalState);
                    break;

                default:
                    Renderer.Error("GhostDead() in Board.cs",
                        "Given color doesn't exist");
                    break;
            }
        }
    }
}