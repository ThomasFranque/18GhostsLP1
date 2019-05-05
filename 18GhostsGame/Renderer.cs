using System;
using System.Collections.Generic;
using System.Text;

// Change console color in Renderer ###########################################

namespace _18GhostsGame
{
    class Renderer
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
                SetConsoleColor('r');
            // Blue ghosts
            else if (counter <= 6)
                SetConsoleColor('b');
            // Yellow ghosts
            else
                SetConsoleColor('y');

            // Print
            PrintSymbol(ghostSymbol);
            ResetConsoleColor();
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
    }
}
