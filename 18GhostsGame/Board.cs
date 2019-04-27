using System;
using System.Collections.Generic;
using System.Text;

namespace _18GhostsGame
{
    /// <summary>
    /// Will only print elements in the console, making the required math to 
    /// do so, and control the state and rotation of portals.
    /// </summary>
    class Board
    {
        // Class Variables
        private string redPortalState, bluePortalState, yellowPortalState;

        public Board()
        {
            // Portals default positions
            Console.OutputEncoding = Encoding.UTF8;

            redPortalState = "up";
            bluePortalState = "down";
            yellowPortalState = "right";
        }

        // DONT FORGET XML DOCUMENTATION!!!!!!!
        public void Draw(int[,] p1Ghosts, int[,] p2Ghosts)
        {
            // Method variables
            byte line = 0;
            int[] ghostPos;
            // used to not print carpets when a ghost is there
            bool ghostSpot = false;
            Symbols symbol = Symbols.blank;

            // Readying the console text for unicode

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

                        // Place carpets / ghosts (empty middle spaces)
                        // Keep in mind: Player 1 ghosts will allways be on top
                        else if (j % 3 == 0)
                        {
                            foreach (int ghost in p1Ghosts)
                            {
                                ghostPos = NormalizePositions(ghost);
                                if (ghostPos[0] == line && ghostPos[1] == j)
                                {
                                    PrintGhostSymbolP1(ghost, p1Ghosts);
                                    ghostSpot = true;
                                    j++;
                                }
                            }
                            foreach (int ghost in p2Ghosts)
                            {
                                symbol = Symbols.blank;

                                ghostPos = NormalizePositions(ghost);
                                if (ghostPos[0] == line && ghostPos[1] == j)
                                {
                                    PrintGhostSymbolP2(ghost, p2Ghosts);
                                    ghostSpot = true;
                                    j++;
                                }
                            }
                            // Print carpet if there is no ghost there
                            if (ghostSpot == false)
                            {
                                symbol = Symbols.carpet;
                                PrintCarpetColor(line, j);
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

            PrintDungeonGhostSymbol(1, p1Ghosts);
            Console.Write("|      |\n" +
                "|       P2. .|");

            PrintDungeonGhostSymbol(2, p2Ghosts);
            Console.Write("|      |\n" +
                " ‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾ ");

            // Debugging
            Console.WriteLine("\nGhost1:a\nGhost2:b\nGhost3:c\nMirror:¤ \nɔ q ɐ");
        }

        private void PrintGhostSymbolP1(int targetGhost, int[,] allGhosts)
        {
            Symbols ghostSymbol = Symbols.blank;
            byte counter = 0;

            foreach (int ghost in allGhosts)
            {
                counter++;
                if (ghost == targetGhost)
                    switch (counter)
                    {
                        // Red Ghosts
                        case 1:
                            ghostSymbol = Symbols.ghosts1P1;
                            Console.ForegroundColor = ConsoleColor.Red;
                            break;
                        case 2:
                            ghostSymbol = Symbols.ghosts2P1;
                            Console.ForegroundColor = ConsoleColor.Red;
                            break;
                        case 3:
                            ghostSymbol = Symbols.ghosts3P1;
                            Console.ForegroundColor = ConsoleColor.Red;
                            break;

                        // Blue Ghosts
                        case 4:
                            ghostSymbol = Symbols.ghosts1P1;
                            Console.ForegroundColor = ConsoleColor.Blue;
                            break;
                        case 5:
                            ghostSymbol = Symbols.ghosts2P1;
                            Console.ForegroundColor = ConsoleColor.Blue;
                            break;
                        case 6:
                            ghostSymbol = Symbols.ghosts3P1;
                            Console.ForegroundColor = ConsoleColor.Blue;
                            break;

                        // Yellow Ghosts
                        case 7:
                            ghostSymbol = Symbols.ghosts1P1;
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            break;
                        case 8:
                            ghostSymbol = Symbols.ghosts2P1;
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            break;
                        case 9:
                            ghostSymbol = Symbols.ghosts3P1;
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            break;
                    }

            }

            Console.Write(((char)ghostSymbol).ToString());
            Console.ResetColor();
        }
        private void PrintGhostSymbolP2(int targetGhost, int[,] allGhosts)
        {
            Symbols ghostSymbol = Symbols.blank;
            byte counter = 0;

            foreach (int ghost in allGhosts)
            {
                counter++;
                if (ghost == targetGhost)
                    switch (counter)
                    {
                        // Red Ghosts
                        case 1:
                            ghostSymbol = Symbols.ghosts1P2;
                            Console.ForegroundColor = ConsoleColor.Red;
                            break;
                        case 2:
                            ghostSymbol = Symbols.ghosts2P2;
                            Console.ForegroundColor = ConsoleColor.Red;
                            break;
                        case 3:
                            ghostSymbol = Symbols.ghosts3P2;
                            Console.ForegroundColor = ConsoleColor.Red;
                            break;

                        // Blue Ghosts
                        case 4:
                            ghostSymbol = Symbols.ghosts1P2;
                            Console.ForegroundColor = ConsoleColor.Blue;
                            break;
                        case 5:
                            ghostSymbol = Symbols.ghosts2P2;
                            Console.ForegroundColor = ConsoleColor.Blue;
                            break;
                        case 6:
                            ghostSymbol = Symbols.ghosts3P2;
                            Console.ForegroundColor = ConsoleColor.Blue;
                            break;

                        // Yellow Ghosts
                        case 7:
                            ghostSymbol = Symbols.ghosts1P2;
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            break;
                        case 8:
                            ghostSymbol = Symbols.ghosts2P2;
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            break;
                        case 9:
                            ghostSymbol = Symbols.ghosts3P2;
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            break;
                    }

            }

            Console.Write(((char)ghostSymbol).ToString());
            Console.ResetColor();
        }
        private void PrintDungeonGhostSymbol(byte playerNum, int[,] allGhosts)
        {
            byte counter = 0;
            Symbols[] ghostsToPrint = new Symbols[9];

            foreach (int ghost in allGhosts)
            {
                counter++;
                // Player 1 symbols
                if (ghost == 0 && playerNum == 1)
                    switch (counter)
                    {
                        case 1:
                        case 4:
                        case 7:
                            ghostsToPrint[counter - 1] = Symbols.ghosts1P1;
                            break;
                        case 2:
                        case 5:
                        case 8:
                            ghostsToPrint[counter - 1] = Symbols.ghosts2P1;
                            break;
                        case 3:
                        case 6:
                        case 9:
                            ghostsToPrint[counter - 1] = Symbols.ghosts3P1;
                            break;
                    }

                // Player 2 symbols
                else if (ghost == 0 && playerNum == 2)
                    switch (counter)
                    {
                        case 1:
                        case 4:
                        case 7:
                            ghostsToPrint[counter - 1] = Symbols.ghosts1P2;
                            break;
                        case 2:
                        case 5:
                        case 8:
                            ghostsToPrint[counter - 1] = Symbols.ghosts2P2;
                            break;
                        case 3:
                        case 6:
                        case 9:
                            ghostsToPrint[counter - 1] = Symbols.ghosts3P2;
                            break;
                    }

            }

            // Re-use counter to print 
            counter = 0;

            foreach (Symbols ghost in ghostsToPrint)
            {
                counter++;

                // Red Ghosts
                if (counter <= 3)
                    Console.ForegroundColor = ConsoleColor.Red;

                // Blue Ghosts
                else if (counter <= 6)
                    Console.ForegroundColor = ConsoleColor.Blue;

                // Yellow Ghosts
                else
                    Console.ForegroundColor = ConsoleColor.Yellow;

                Console.Write(((char)ghost).ToString());
            }
            Console.ResetColor();
        }
        private void PrintCarpetColor(byte line, byte j)
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

        private int[] NormalizePositions(int ghost)
        {
            //  normalizedPos = { line, character };
            int[] normalizedPos = new int[] { 0, 0 };

            // Is in the dungeon
            if (ghost <= 0)
            {
                normalizedPos[0] = 0;
                normalizedPos[1] = 0;
            }

            // Is in line 1
            else if (ghost <= 5)
            {
                normalizedPos[0] = 1;
                normalizedPos[1] = FindCharacterInLine(ghost);
            }

            // Is in line 2
            else if (ghost <= 10)
            {
                normalizedPos[0] = 2;
                normalizedPos[1] = FindCharacterInLine(ghost);
            }

            // Is in line 3
            else if (ghost <= 15)

            {
                normalizedPos[0] = 3;
                normalizedPos[1] = FindCharacterInLine(ghost);
            }

            // Is in line 4
            else if (ghost <= 20)
            {
                normalizedPos[0] = 4;
                normalizedPos[1] = FindCharacterInLine(ghost);
            }

            // Is in line 5
            else // if (ghost <= 25)
            {
                normalizedPos[0] = 5;
                normalizedPos[1] = FindCharacterInLine(ghost);
            }

            return normalizedPos;
        }

        private int FindCharacterInLine(int ghost)
        {
            int finalCharacter = 0;
            bool keepRunning = true;

            if (keepRunning)
                for (int k = 1; k <= 21; k += 5)
                    if (ghost == k)
                    {
                        finalCharacter = 3;
                        k = 22;
                        keepRunning = false;
                    }

            if (keepRunning)
                for (int k = 2; k <= 22; k += 5)
                    if (ghost == k)
                    {
                        finalCharacter = 9;
                        k = 23;
                        keepRunning = false;
                    }

            if (keepRunning)
                for (int k = 3; k <= 23; k += 5)
                    if (ghost == k)
                    {
                        finalCharacter = 15;
                        k = 24;
                        keepRunning = false;
                    }

            if (keepRunning)
                for (int k = 4; k <= 24; k += 5)
                    if (ghost == k)
                    {
                        finalCharacter = 21;
                        k = 25;
                        keepRunning = false;
                    }

            if (keepRunning)
                for (int k = 5; k <= 25; k += 5)
                    if (ghost == k)
                    {
                        finalCharacter = 27;
                        k = 26;
                    }

            return finalCharacter;
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
        public string GetRedPortalState() => redPortalState;
        public string GetBluePortalState() => bluePortalState;
        public string GetYellowPortalState() => yellowPortalState;
    }
}