using System;
using System.Collections.Generic;
using System.Text;

namespace _18GhostsGame
{
    class Board
    {
        public void Draw()
        {
            // Variables
            int line = 0;
            Symbols symbol = Symbols.blank;
            // Readying the console text for unicode
            Console.OutputEncoding = Encoding.UTF8;

            // Change text color
            Console.ForegroundColor = ConsoleColor.Blue;

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
                    // Not vertical line space
                    if (j % 6 != 0)

                        // Not middle space
                        if (j % 3 != 0)
                            symbol = Symbols.blank;

                        // Middle Spaces
                        // Mirror Space
                        else if ((j == 9 && line % 2 == 0) ||
                            (j == 21 && line % 2 == 0))
                            symbol = Symbols.mirrors;
                        // ?? Space
                        else
                            symbol = Symbols.blank;

                    // Vertical line space
                    else
                        symbol = Symbols.column;

                    Console.Write(Enum.GetValues(symbol);
                }

                // Print cell bottom lines
                Console.Write("\n|_____|_____|_____|_____|_____|     |\n");
            }

            // Print the dungeon bottom horizontal line
            Console.Write("                               ‾‾‾‾‾ \n\n\n");

            Console.WriteLine("Ghost1:Σ\nGhost2:Φ\nGhost3:Ψ\nMirror:¤");

            // Reset text color back to white
            Console.ResetColor();
        }

    }
}
