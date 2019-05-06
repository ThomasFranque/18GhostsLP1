using System;
using System.Collections.Generic;
using System.Text;

// Change console color in Renderer ###########################################

namespace _18GhostsGame
{
    class BoardRenderer
    {
        // Not for Ghosts
        public static void PrintSymbol(Symbols symbol)
        {
            Console.Write(((char)symbol).ToString());
        }

        // For Ghosts
        public static void PrintSymbol
            (Symbols[] ghostSymbols, byte targetGhost, byte[,] allGhosts)
        {
            byte[] foundGhost = new byte[2] { 0, 0 };
            Symbols ghostSymbol = Symbols.blank;

            foundGhost = GhostChecker.FindGhost(targetGhost, allGhosts);

            // Check for the same target ghost number on player ghosts
            switch (foundGhost[0])
            {
                case 1:
                    ghostSymbol = ghostSymbols[0];
                    break;
                case 2:
                    ghostSymbol = ghostSymbols[1];
                    break;
                case 3:
                    ghostSymbol = ghostSymbols[2];
                    break;
            }
            switch (foundGhost[1])
            {
                case 1:
                    SetConsoleColor('r'); ;
                    break;
                case 2:
                    SetConsoleColor('b');
                    break;
                case 3:
                    SetConsoleColor('y');
                    break;
            }

            // Print
            PrintSymbol(ghostSymbol);
            ResetConsoleColor();
        }

        // Know which symbol represents up down left and right
        public static void PrintPortalSymbol(string portal)
        {
            Symbols symbolToPrint;
            symbolToPrint = Symbols.blank;

            switch (portal)
            {
                case "up":
                    symbolToPrint = Symbols.portalUp;
                    break;
                case "down":
                    symbolToPrint = Symbols.portalDown;
                    break;
                case "right":
                    symbolToPrint = Symbols.portalRight;
                    break;
                case "left":
                    symbolToPrint = Symbols.portalLeft;
                    break;
            }
            PrintSymbol(symbolToPrint);
        }

        //
        public static void PrintVerticalLines()
        {
            Console.Write("|     |     |     |     |     |\n");
        }

        //
        public static void PrintHorizontalLines()
        {
            Console.Write(" _____ _____ _____ _____ _____\n");
        }

        //
        public static void PrintBottomLines()
        {
            Console.Write("\n|_____|_____|_____|_____|_____|\n");
        }

        // Drawing the dungeon
        public static void DrawDungeon
            (byte[,] p1Ghosts, Symbols[] ghostSymsP1,
            byte[,] p2Ghosts, Symbols[] ghostSymsP2)
        {
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

        // For Ghosts in dungeon
        private static void PrintDungeonGhostSymbol
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
                    SetConsoleColor('r');

                // Blue Ghosts
                else if (counter == 4)
                    SetConsoleColor('b');

                // Yellow Ghosts
                else if (counter == 7)
                    SetConsoleColor('y');

                Console.Write(((char)ghost).ToString());
            }
            Console.ResetColor();
        }

        //
        public static void SetConsoleColor(char color)
        {
            switch (color)
            {
                // Set to Dark Red
                case 'R':
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    break;
                // Set to Dark Cyan
                case 'C':
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    break;
                // Set to Dark Yellow
                case 'Y':
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    break;
                // Set to Red
                case 'r':
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                // Set to blue
                case 'b':
                    Console.ForegroundColor = ConsoleColor.Blue;
                    break;
                // Set yo Yellow
                case 'y':
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
            }

        }

        //
        public static void ResetConsoleColor()
        {
            Console.ResetColor();
        }

        //
        public static void Error(string location, string message)
        {
            // Change text color
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\nERROR\n " +
                $"Location: {location}\n " +
                $"{message}.\n");
            // Reset text color back to white
            Console.ResetColor();
        }

        //
        public static void SetConsoleEncoding()
        {
            // Readying the console text for unicode
            Console.OutputEncoding = Encoding.UTF8;
        }

        public static void SetCarpetColor(byte line, byte j)
        {
            // Red carpets
            if (line == 1 && (j == 9 || j == 27) ||
                line == 3 && (j == 3 || j == 15) ||
                line == 4 && j == 27 ||
                line == 5 && j == 9)
                SetConsoleColor('R');
            // Blue carpets
            else if (line == 1 && (j == 3 || j == 21) ||
                line == 3 && (j == 9 || j == 21) ||
                line == 4 && j == 3 ||
                line == 5 && j == 21)
                SetConsoleColor('C');
            // Yellow carpets
            else if (line == 2 && (j == 3 || j == 15 ||
                j == 27) ||
                line == 4 && j == 15 ||
                line == 5 && (j == 3 || j == 27))
                SetConsoleColor('Y');
        }
    }
}