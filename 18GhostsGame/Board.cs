using System;
using System.Collections.Generic;
using System.Text;

namespace _18GhostsGame
{
    class Board
    {
        // Class Variables
        private string redPortalState, bluePortalState, yellowPortalState;

        public Board()
        {
            // Portals default positions
            redPortalState = "up";
            bluePortalState = "down";
            yellowPortalState = "right";
        }

        public void Draw()
        {
            // Method variables
            int line = 0;
            Symbols symbol = Symbols.blank;

            // Readying the console text for unicode
            Console.OutputEncoding = Encoding.UTF8;

            // Printing starts
            // Print the first horizontal lines
            Console.Write(" _____ _____ _____ _____ _____ _____ \n");

            // Print all the upcoming lines to make a 5x5 board
            for (int i = 0; i < 5; i++)
            {
                // Increment current line
                line++;

                // Print vertical lines
                Console.Write(
                       "|     |     |     |     |     |     |\n");

                // Printing middle lines
                for (int j = 0; j < 38; j++)
                {
                    // Not a column space (Middle Spaces)
                    if (j % 6 != 0)

                        // Mirrors place
                        if ((j == 9 && line % 2 == 0) ||
                            (j == 21 && line % 2 == 0))
                            symbol = Symbols.mirrors;

                        // Red Portal place
                        else if (j == 15 && line == 1)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            symbol = GetPortalSymbol(redPortalState);
                        }
                        // Yellow Portal place
                        else if (j == 27 && line == 3)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            symbol = GetPortalSymbol(yellowPortalState);
                        }
                        // Blue Portal place
                        else if (j == 15 && line == 5)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkCyan;
                            symbol = GetPortalSymbol(bluePortalState);
                        }
                        // Place carpets
                        else if (j % 3 == 0)
                        {
                            symbol = Symbols.carpet;
                            // Red carpets
                            if (line == 1 && (j == 9 || j == 27))
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                            // Blue carpets
                            else if (line == 1 && (j == 3 || j == 21) ||
                                line == 3 && (j == 9 || j == 21) ||
                                line == 4 && j == 3 ||
                                line == 5 && j == 21)
                                Console.ForegroundColor = ConsoleColor.Cyan;
                            // Yellow carpets
                            // tbd

                        }

                        // Fill blank Spaces in line (to be changed)
                        else
                            symbol = Symbols.blank;

                    // Vertical line space
                    else
                        symbol = Symbols.column;

                    Console.Write(((char)symbol).ToString());
                    Console.ResetColor();

                }

                // Print cell bottom lines
                Console.Write("\n|_____|_____|_____|_____|_____|     |\n");
            }

            // Print the dungeon bottom horizontal line
            Console.Write("                               ‾‾‾‾‾ \n\n\n");

            Console.WriteLine("Ghost1:Σ\nGhost2:Φ\nGhost3:Ψ\nMirror:¤");
        }

        /// <summary>
        /// Rotates the given portal
        /// </summary>
        /// <param name="portal">Wich portal to rotate</param>
        private void PortalRotate(ref string portal)
        {
            switch (portal)
            {
                case "up":
                    portal = "right";
                    break;

                case "down":
                    portal = "left";
                    break;

                case "right":
                    portal = "down";
                    break;

                case "left":
                    portal = "up";
                    break;

                default:
                    // Change text color
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"\nERROR\n " +
                        $"Position: {portal} Doesn't exist.\n");
                    // Reset text color back to white
                    Console.ResetColor();
                    break;
            }
        }

        public void GhostDead(string color)
        {
            switch (color)
            {
                case "red":
                    PortalRotate(ref redPortalState);
                    break;
                case "blue":
                    PortalRotate(ref bluePortalState);
                    break;
                case "yellow":
                    PortalRotate(ref yellowPortalState);
                    break;

                default:
                    // Change text color
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"\nERROR\n " +
                        $"Ghost color: {color} Doesn't exist.\n");
                    // Reset text color back to white
                    Console.ResetColor();
                    break;
            }
        }

        /// <summary>
        /// Know wich symbol represents up down left and right
        /// </summary>
        /// <param name="portal">Wich portal to look for</param>
        /// <returns>returns the correspondent symbol 
        /// from enum Symbols</returns>
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
                    // Change text color
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"\nERROR\n " +
                        $"Portal Color: {portal} Doesn't exist.\n");
                    // Reset text color back to white
                    Console.ResetColor();
                    break;
            }
            return symbolToReturn;
        }

        public string GetRedPortal() => redPortalState;
        public string GetBluePortal() => bluePortalState;
        public string GetYellowPortal() => yellowPortalState;
    }
}
