using System;
using System.Text;

namespace _18GhostsGame
{
    /// <summary>
    /// Renders all the needed text and symbols
    /// </summary>
    class Render
    {
        // #########################
        // #### General Renders ####
        // #########################

        /// <summary>
        /// Sets the console encoding to support unicode
        /// </summary>
        public static void SetConsoleEncoding()
        {
            // Readying the console text for unicode
            Console.OutputEncoding = Encoding.UTF8;
        }

        /// <summary>
        /// Changes console text color
        /// </summary>
        /// <param name="color">Desired color number</param>
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

        /// <summary>
        /// Resets the console text color to white
        /// </summary>
        public static void ResetConsoleColor()
        {
            Console.ResetColor();
        }

        /// <summary>
        /// Clears all the previous printed text
        /// </summary>
        public static void Clear()
        {
            Console.Clear();
        }

        /// <summary>
        /// Prints a new line
        /// </summary>
        public static void Line()
        {
            Console.WriteLine("\n");
        }

        // #########################
        // ####  Board Renders #####
        // #########################

        /// <summary>
        /// Is used to print the given symbol from enum Symbols
        /// </summary>
        /// <param name="symbol">Desired symbol</param>
        public static void PrintSymbol(Symbols symbol)
        {
            Console.Write(((char)symbol).ToString());
        }


        /// <summary>
        /// Is used to print the desired ghost symbol with respective color
        /// </summary>
        /// <param name="ghostSymbols">Target player symbols</param>
        /// <param name="targetGhost">Target ghost position</param>
        /// <param name="allGhosts">Target player ghosts</param>
        public static void PrintSymbol
            (Symbols[] ghostSymbols, byte targetGhost, byte[,] allGhosts)
        {
            // Temporary variables
            BoardChecker checker = new BoardChecker();
            byte[] foundGhost = new byte[2] { 0, 0 };
            Symbols ghostSymbol = Symbols.blank;

            foundGhost = checker.FindGhost(targetGhost, allGhosts);

            // Check for the same target ghost number on player ghosts
            switch (foundGhost[0])
            {
                // Ghost a
                case 1:
                    ghostSymbol = ghostSymbols[0];
                    break;
                // Ghost b
                case 2:
                    ghostSymbol = ghostSymbols[1];
                    break;
                // Ghost c
                case 3:
                    ghostSymbol = ghostSymbols[2];
                    break;
            }
            // Change console text color
            switch (foundGhost[1])
            {
                // Red
                case 1:
                    SetConsoleColor('r'); ;
                    break;
                // Blue
                case 2:
                    SetConsoleColor('b');
                    break;
                // Yellow
                case 3:
                    SetConsoleColor('y');
                    break;
            }

            // Print result and reset color
            PrintSymbol(ghostSymbol);
            ResetConsoleColor();
        }

        /// <summary>
        /// Know which symbol from Symbols enum 
        /// represents the given portal position
        /// </summary>
        /// <param name="portal">Target Portal</param>
        public static void PrintPortalSymbol(string portal)
        {
            // Temporary variables
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
            // Print
            PrintSymbol(symbolToPrint);
        }

        /// <summary>
        /// Print dungeon vertical lines
        /// </summary>
        public static void PrintVerticalLines()
        {
            Console.Write("|     |     |     |     |     |\n");
        }

        /// <summary>
        /// Print dungeon horizontal lines
        /// </summary>
        public static void PrintHorizontalLines()
        {
            Console.Write("|_____ _____ _____ _____ _____|\n");
        }

        /// <summary>
        /// Print dungeon bottom lines 
        /// </summary>
        public static void PrintBottomLines()
        {
            Console.Write("\n|_____|_____|_____|_____|_____|\n");
        }

        /// <summary>
        /// Draws the entire dungeon
        /// </summary>
        /// <param name="p1Ghosts">Player 1 ghosts</param>
        /// <param name="ghostSymsP1">Player 1 Symbols</param>
        /// <param name="p2Ghosts">Player 2 ghosts</param>
        /// <param name="ghostSymsP2">Player 2 Symbols</param>
        public static void DrawDungeon
            (byte[,] p1Ghosts, Symbols[] ghostSymsP1,
            byte[,] p2Ghosts, Symbols[] ghostSymsP2)
        {
            // Print dungeon Top
            Console.Write("|        D U N G E O N        |\n" +
                    "|      ‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾      |\n" +
                    "|       P1. .|");
            // Print Player 1 ghosts
            PrintDungeonGhostSymbol(ghostSymsP1, p1Ghosts);
            // Print dungeon middle
            Console.Write("|      |\n" +
                    "|       P2. .|");
            //Print Player 2 ghosts
            PrintDungeonGhostSymbol(ghostSymsP2, p2Ghosts);
            // Print dungeon bottom
            Console.Write("|      |\n" +
                    " ‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾ ");
        }

        /// <summary>
        /// Prints the color conflict chain order
        /// </summary>
        public static void ColorConflics()
        {
            Render.PrintColoredText("\n _____________________________\n" +
                    "        Y > R > B > Y \n" +
                    "     ‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾\n");
        }

        /// <summary>
        /// Prints ghosts in dungeon
        /// </summary>
        /// <param name="ghostSymbols">Target player ghost symbols</param>
        /// <param name="allGhosts">Target player ghosts</param>
        private static void PrintDungeonGhostSymbol
            (Symbols[] ghostSymbols, byte[,] allGhosts)
        {
            // Temporary variables
            byte counter = 0;
            Symbols[] ghostsToPrint = new Symbols[9];

            foreach (byte ghost in allGhosts)
            {
                counter++;
                // If ghost is in dungeon, store them
                if (ghost == 0)
                    switch (counter)
                    {
                        // ghosts a
                        case 1:
                        case 4:
                        case 7:
                            ghostsToPrint[counter - 1] = ghostSymbols[0];
                            break;
                        // ghosts b
                        case 2:
                        case 5:
                        case 8:
                            ghostsToPrint[counter - 1] = ghostSymbols[1];
                            break;
                        // ghosts c
                        case 3:
                        case 6:
                        case 9:
                            ghostsToPrint[counter - 1] = ghostSymbols[2];
                            break;
                    }
            }

            // Re-use counter for color
            counter = 0;

            // Check ghost color using counter
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
            // Reset color
            ResetConsoleColor();
        }

        /// <summary>
        /// Set the given carpet location color
        /// </summary>
        /// <param name="line"></param>
        /// <param name="j"></param>
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

        /// <summary>
        /// Will print score table of both players
        /// </summary>
        public static void PrintScoreTable()
        {
            // Print player 1 score
            Console.Write(" ________________ \n" +
                "| Player 1:      |\n" +
                "| ");
            PrintColoredText("R:");
            Console.Write(Portal.ghostsOut[0, 0]);
            PrintColoredText("  B:");
            Console.Write(Portal.ghostsOut[0, 1]);
            PrintColoredText("  Y:");
            Console.Write(Portal.ghostsOut[0, 2]);

            // Print player 2 score
            Console.Write("  |\n| -------------- |\n" +
                "| Player 2:      |\n" +
                "| ");
            PrintColoredText("R:");
            Console.Write(Portal.ghostsOut[1, 0]);
            PrintColoredText("  B:");
            Console.Write(Portal.ghostsOut[1, 1]);
            PrintColoredText("  Y:");
            Console.Write(Portal.ghostsOut[1, 2]);
            Console.Write("  |____________\n");                
        }

        /// <summary>
        /// Will show the main menu
        /// </summary>
        /// <param name="toWin">Ghosts of the same color to win</param>
        public static void MainMenu(byte toWin)
        {
            if (toWin > 1)
            {
                Console.WriteLine("You have started the game in:\n" +
                    "NORMAL MODE\n");
            }
            else
            {
                Console.WriteLine("You have started the game in:" +
                    "QUICK MODE\n\n");
            }
            Console.WriteLine("WELCOME TO 18 GHOSTS!\n" +
                "Player 1 ghosts are:" +
                " | a | b | c |\n" +
                "----------------------------------\n" +
                "Player 2 ghosts are:" +
                " | ɐ | q | ɔ |\n" +
                "----------------------------------\n" +
                "Portals are:" +
                " | ↑ | ↓ | ← | → |\n" +
                "------------------------------\n" +
                "Mirrors are:" +
                " | ¤ |\n\n" +
                "Input any key to continue...");

        }


        // #########################
        // #### Player Renders #####
        // #########################

        /// <summary>
        /// Print given text with while coloring the colors 
        /// Red, Blue and Green and setting the text to gray
        /// </summary>
        /// <param name="text">Text to print</param>
        public static void PrintColoredText(string text)
        {
            // Temporary variable
            bool color = false;

            foreach (char letter in text)
            {
                // Check for letter color
                if (letter == 'R')
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    color = !color;
                }
                else if (letter == 'B')
                {
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    color = !color;
                }
                else if (letter == 'Y')
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    color = !color;
                }
                // Check for endings
                if ((letter == ' ' || letter == '>') && color)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    color = !color;
                }
                if (letter == '?' || letter == '!')
                    color = !color;

                // print
                Console.Write(letter);
            }
            // reset color
            ResetConsoleColor();
        }

        /// <summary>
        /// Print normal gray text
        /// </summary>
        /// <param name="text">Text to print</param>
        public static void PrintText(string text)
        {
            // Temporary variable
            bool color = false;

            foreach (char letter in text)
            {
                // Check for endings
                if (color)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    color = !color;
                }
                if (letter == '?')
                    color = !color;

                Console.Write(letter);
            }
            // Reset color
            ResetConsoleColor();
        }

        /// <summary>
        /// Menu shows possible player actions
        /// </summary>
        public static void ActionMenu()
        {
            //Ask what to do
            PrintText("What do you want to do?\n" +
                "Move / Attack ..... <M> or <1>\n" +
                "Place ............. <P> or <2>\n" +
                "Help .............. <H> or <3>\n");
        }

        /// <summary>
        /// Shows carpet and mirror spots to put ghosts
        /// </summary>
        /// <param name="color">Target spots</param>
        public static void ShowPlacingSpots(byte color)
        {
            //Ask what to do
            Console.WriteLine("To place, " +
                "insert the desired cell number.");
            switch (color)
            {
                // red spots
                case 0:
                    PrintColoredText(" It needs to be empty!\n" +
                        " _____ _____ _____ _____ _____ \n" +
                        "|     |2    |     |     |4    |\n" +
                        "|     |  R  |     |     |  R  |\n" +
                        "|_____|_____|_____|_____|_____|\n" +
                        "|     |     |     |     |     |\n" +
                        "|     |     |     |     |     |\n" +
                        "|_____|_____|_____|_____|_____|\n" +
                        "|8    |     |10   |     |     |\n" +
                        "|  R  |     |  R  |     |     |\n" +
                        "|_____|_____|_____|_____|_____|\n" +
                        "|     |     |     |     |14   |\n" +
                        "|     |     |     |     |  R  |\n" +
                        "|_____|_____|_____|_____|_____|\n" +
                        "|     |16   |     |     |     |\n" +
                        "|     |  R  |     |     |     |\n" +
                        "|_____|_____|_____|_____|_____|\n");
                    break;

                // blue spots
                case 1:
                    PrintColoredText(" It needs to be empty!\n" +
                        " _____ _____ _____ _____ _____ \n" +
                        "|1    |     |     |3    |     |\n" +
                        "|  B  |     |     |  B  |     |\n" +
                        "|_____|_____|_____|_____|_____|\n" +
                        "|     |     |     |     |     |\n" +
                        "|     |     |     |     |     |\n" +
                        "|_____|_____|_____|_____|_____|\n" +
                        "|     |9    |     |11   |     |\n" +
                        "|     |  B  |     |  B  |     |\n" +
                        "|_____|_____|_____|_____|_____|\n" +
                        "|12   |     |     |     |     |\n" +
                        "|  B  |     |     |     |     |\n" +
                        "|_____|_____|_____|_____|_____|\n" +
                        "|     |     |     |17   |     |\n" +
                        "|     |     |     |  B  |     |\n" +
                        "|_____|_____|_____|_____|_____|\n");
                    break;

                // yellow spots
                case 2:
                    PrintColoredText(" It needs to be empty!\n" +
                        " _____ _____ _____ _____ _____ \n" +
                        "|     |     |     |     |     |\n" +
                        "|     |     |     |     |     |\n" +
                        "|_____|_____|_____|_____|_____|\n" +
                        "| 5   |     |6    |     |7    |\n" +
                        "|  Y  |     |  Y  |     |  Y  |\n" +
                        "|_____|_____|_____|_____|_____|\n" +
                        "|     |     |     |     |     |\n" +
                        "|     |     |     |     |     |\n" +
                        "|_____|_____|_____|_____|_____|\n" +
                        "|     |     |13   |     |     |\n" +
                        "|     |     |  Y  |     |     |\n" +
                        "|_____|_____|_____|_____|_____|\n" +
                        "|15   |     |     |     |18   |\n" +
                        "|  Y  |     |     |     |  Y  |\n" +
                        "|_____|_____|_____|_____|_____|\n");
                    break;
                // mirror spots
                case 3:
                    PrintColoredText(" A ghost of the same color " +
                        "cannot be there!\n" +
                        " _____ _____ _____ _____ _____ \n" +
                        "|     |     |     |     |     |\n" +
                        "|     |     |     |     |     |\n" +
                        "|_____|_____|_____|_____|_____|\n" +
                        "|     |1    |     |2    |     |\n" +
                        "|     |  M  |     |  M  |     |\n" +
                        "|_____|_____|_____|_____|_____|\n" +
                        "|     |     |     |     |     |\n" +
                        "|     |     |     |     |     |\n" +
                        "|_____|_____|_____|_____|_____|\n" +
                        "|     |3    |     |4    |     |\n" +
                        "|     |  M  |     |  M  |     |\n" +
                        "|_____|_____|_____|_____|_____|\n" +
                        "|     |     |     |     |     |\n" +
                        "|     |     |     |     |     |\n" +
                        "|_____|_____|_____|_____|_____|\n");
                    break;

            }
        }

        // #########################
        // ####  Help Renders  #####
        // #########################

        /// <summary>
        /// Action help message
        /// </summary>
        public static void HelpAction()
        {
            // Describe options
            PrintText("MOVE / ATTACK\n" +
                "\tMove your ghost on the board, you can attack enemies by " +
                "choosing to move into their cell.\n" +
                "PLACE\n" +
                "\tPlace a ghost currently on the Dungeonon the board.\n" +
                "\tThe enemy chooses where.");
        }
    }
}
