using System;
using System.Collections.Generic;
using System.Text;


/* TO-DO
 * 1.Create method for error message (maybe not in this class?)
 * 2.Improve the overall performace of this class as well as organizing it
 * 2.1.Stop foreach loops when done with 'break;'!
 * 3.XML documentation
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

        /// <summary>
        /// 
        /// </summary>
        public string RedPortalState { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public string BluePortalState { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public string YellowPortalState { get; private set; }

        private readonly Symbols[] ghostSymsP1, ghostSymsP2;

        public Board()
        {
            // Readying the console text for unicode
            Console.OutputEncoding = Encoding.UTF8;

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
            bool ghostSpot = false;
            Symbols symbol = Symbols.blank;

            // Printing starts
            // Print the first horizontal lines
            Console.Write(" _____ _____ _____ _____ _____\n");

            // Print all the upcoming lines to make a 5x5 board
            for (byte i = 0; i < 5; i++)
            {
                // Increment current line
                line++;

                // Print vertical lines
                Console.Write(
                       "|     |     |     |     |     |\n");

                // Printing middle lines
                for (byte j = 0; j < 31; j++)
                {
                    ghostSpot = false;
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
                            symbol = GetPortalSymbol(RedPortalState);
                        }
                        // Yellow Portal place
                        else if (j == 27 && line == 3)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            symbol = GetPortalSymbol(YellowPortalState);
                        }
                        // Blue Portal place
                        else if (j == 15 && line == 5)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkCyan;
                            symbol = GetPortalSymbol(BluePortalState);
                        }

                        // Place carpets / ghosts (empty middle spaces)
                        // Keep in mind: Player 1 ghosts will allways be on top
                        else if (j % 3 == 0)
                        {
                            // Player 1 ghosts
                            foreach (byte ghost in p1Ghosts)
                            {
                                ghostPos = NormalizePositions(ghost);
                                if (ghostPos[0] == line && ghostPos[1] == j)
                                {
                                    PrintGhostSymbols(ghostSymsP1, ghost, p1Ghosts);
                                    ghostSpot = true;
                                    j++;
                                    break;
                                }
                            }
                            // Player 2 Ghosts
                            foreach (byte ghost in p2Ghosts)
                            {
                                symbol = Symbols.blank;

                                ghostPos = NormalizePositions(ghost);
                                if (ghostPos[0] == line && ghostPos[1] == j)
                                {
                                    PrintGhostSymbols(ghostSymsP2, ghost, p2Ghosts);
                                    ghostSpot = true;
                                    j++;
                                    break;
                                }
                            }
                            // Print carpet if there is no ghost there
                            if (ghostSpot == false)
                            {
                                symbol = Symbols.carpet;
                                SetCarpetColor(line, j);
                            }
                        }

                        // Fill blank Spaces in line
                        else
                            symbol = Symbols.blank;

                    // Vertical line space
                    else
                        symbol = Symbols.column;

                    Console.Write(((char)symbol).ToString());
                    Console.ResetColor();

                }

                // Print cell bottom lines
                Console.Write("\n|_____|_____|_____|_____|_____|\n");


            }
            // Print the Dungeon
            Console.Write("|        D U N G E O N        |\n" +
                "|      ‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾      |\n" +
                "|       P1. .|");

            PrintDungeonGhostSymbol(ghostSymsP1, p1Ghosts);
            Console.Write("|      |\n" +
                "|       P2. .|");

            PrintDungeonGhostSymbol(ghostSymsP2, p2Ghosts);
            Console.Write("|      |\n" +
                " ‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾ ");

            // Debugging
            Console.WriteLine("\nGhost1:a\nGhost2:b\nGhost3:c\nMirror:¤ \nɔ q ɐ");
        }

        private void PrintGhostSymbols
            (Symbols[] ghostSymbols, byte targetGhost, byte[,] allGhosts)
        {
            Symbols ghostSymbol = Symbols.blank;
            byte counter = 0;

            foreach (int ghost in allGhosts)
            {
                if (ghostSymbol == Symbols.blank)
                    counter++;
                else
                    break;

                // Check for the same target ghost number on player ghosts
                if (ghost == targetGhost)
                    switch (counter)
                    {
                        case 1:
                        case 4:
                        case 7:
                            ghostSymbol = ghostSymbols[0];
                            break;
                        case 2:
                        case 5:
                        case 8:
                            ghostSymbol = ghostSymbols[1];
                            break;
                        case 3:
                        case 6:
                        case 9:
                            ghostSymbol = ghostSymbols[2];
                            break;
                    }
            }
            // Check corresponding ghost color
            // Red ghosts
            if (counter <= 3)
                Console.ForegroundColor = ConsoleColor.Red;
            // Blue ghosts
            else if (counter <= 6)
                Console.ForegroundColor = ConsoleColor.Blue;
            // Yellow ghosts
            else
                Console.ForegroundColor = ConsoleColor.Yellow;

            // Print
            Console.Write(((char)ghostSymbol).ToString());
            Console.ResetColor();
        }

        private void PrintDungeonGhostSymbol
            (Symbols[] ghostSymbols, byte[,] allGhosts)
        {
            byte counter = 0;
            Symbols[] ghostsToPrint = new Symbols[9];

            foreach (byte ghost in allGhosts)
            {
                counter++;
                if (ghost == 0)
                    switch (counter)
                    {
                        case 1:
                        case 4:
                        case 7:
                            ghostsToPrint[counter - 1] = ghostSymbols[0];
                            break;
                        case 2:
                        case 5:
                        case 8:
                            ghostsToPrint[counter - 1] = ghostSymbols[1];
                            break;
                        case 3:
                        case 6:
                        case 9:
                            ghostsToPrint[counter - 1] = ghostSymbols[2];
                            break;
                    }
            }

            // Re-use counter to print 
            counter = 0;

            foreach (Symbols ghost in ghostsToPrint)
            {
                counter++;

                // Red Ghosts
                if (counter == 1)
                    Console.ForegroundColor = ConsoleColor.Red;

                // Blue Ghosts
                else if (counter == 4)
                    Console.ForegroundColor = ConsoleColor.Blue;

                // Yellow Ghosts
                else if (counter == 6)
                    Console.ForegroundColor = ConsoleColor.Yellow;

                Console.Write(((char)ghost).ToString());
            }
            Console.ResetColor();
        }

        private void SetCarpetColor(byte line, byte j)
        {
            // Red carpets
            if (line == 1 && (j == 9 || j == 27) ||
                line == 3 && (j == 3 || j == 15) ||
                line == 4 && j == 27 ||
                line == 5 && j == 9)
                Console.ForegroundColor =
                    ConsoleColor.DarkRed;
            // Blue carpets
            else if (line == 1 && (j == 3 || j == 21) ||
                line == 3 && (j == 9 || j == 21) ||
                line == 4 && j == 3 ||
                line == 5 && j == 21)
                Console.ForegroundColor =
                    ConsoleColor.Cyan;
            // Yellow carpets
            else if (line == 2 && (j == 3 || j == 15 ||
                j == 27) ||
                line == 4 && j == 15 ||
                line == 5 && (j == 3 || j == 27))
                Console.ForegroundColor =
                    ConsoleColor.DarkYellow;
        }

        private byte[] NormalizePositions(byte ghost)
        {
            //  normalizedPos = { line, character };
            byte[] normalizedPos = new byte[] { 0, 0 };
            byte line = 0;

            for (byte i = 0; i <= ghost; i += 1)
                if (ghost == i)
                {
                    normalizedPos[0] = line;
                    normalizedPos[1] = FindCharacterInLine(ghost);
                }
                else if (i % 5 == 0)
                    line++;

            return normalizedPos;
        }

        private byte FindCharacterInLine(byte ghost)
        {
            // ****************************
            // BETTER SOLUTION IN THE WORKS
            // ****************************

            byte finalCharacter = 0;

            switch (ghost)
            {
                case 0:
                    break;

                case 1:
                case 6:
                case 11:
                case 16:
                case 21:
                    finalCharacter = 3;
                    break;

                case 2:
                case 7:
                case 12:
                case 17:
                case 22:
                    finalCharacter = 9;
                    break;

                case 3:
                case 8:
                case 13:
                case 18:
                case 23:
                    finalCharacter = 15;
                    break;

                case 4:
                case 9:
                case 14:
                case 19:
                case 24:
                    finalCharacter = 21;
                    break;

                case 5:
                case 10:
                case 15:
                case 20:
                case 25:
                    finalCharacter = 27;
                    break;

            }
            return finalCharacter;

            /* 
             * Will be erased when a better solution is found
             * 
            //bool keepRunning = true;
            if (keepRunning)
                for (byte k = 1; k <= 21; k += 5)
                    if (ghost == k)
                    {
                        finalCharacter = 3;
                        k = 22;
                        keepRunning = false;
                    }
            if (keepRunning)
                for (byte k = 2; k <= 22; k += 5)
                    if (ghost == k)
                    {
                        finalCharacter = 9;
                        k = 23;
                        keepRunning = false;
                    }
            if (keepRunning)
                for (byte k = 3; k <= 23; k += 5)
                    if (ghost == k)
                    {
                        finalCharacter = 15;
                        k = 24;
                        keepRunning = false;
                    }
            if (keepRunning)
                for (byte k = 4; k <= 24; k += 5)
                    if (ghost == k)
                    {
                        finalCharacter = 21;
                        k = 25;
                        keepRunning = false;
                    }
            if (keepRunning)
                for (byte k = 5; k <= 25; k += 5)
                    if (ghost == k)
                    {
                        finalCharacter = 27;
                        k = 26;
                    }
            return finalCharacter;
            */
        }

        /// <summary>
        /// Returns the new rotation, clockwise, of the given portal
        /// </summary>
        /// <param name="portal">Target portal to rotate</param>
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
                    // Change text color
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"\nERROR\n " +
                        $"Position: {portal} Doesn't exist.\n");
                    // Reset text color back to white
                    Console.ResetColor();
                    break;
            }
            return newPosition;
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

        /// <summary>
        /// Used outside of class to know what ghost died
        /// </summary>
        /// <param name="color"></param>
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
                    // Change text color
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"\nERROR\n " +
                        $"Ghost color: {color} Doesn't exist.\n");
                    // Reset text color back to white
                    Console.ResetColor();
                    break;
            }
        }
    }
}