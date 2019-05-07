using System;
using System.Collections.Generic;
using System.Text;

namespace _18GhostsGame
{
    class PlayerRenderer
    {

        //Print given text
        public static void PrintColoredText(string text)
        {
            bool color = false;
            foreach (char letter in text)
            {
                // Check for color
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
                // Check for ending
                if ((letter == ' ' || letter == '>') && color)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    color = !color;
                }
                if (letter == '?')
                    color = !color;

                Console.Write(letter);
            }
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void PrintText(string text)
        {
            bool color = false;
            foreach (char letter in text)
            {
                // Check for ending
                if (color)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    color = !color;
                }
                if (letter == '?')
                    color = !color;

                Console.Write(letter);
            }
            Console.ForegroundColor = ConsoleColor.White;
        }

        // Just print a new line
        public static void PrintText()
        {
            Console.WriteLine("\n");
        }

    }
}
