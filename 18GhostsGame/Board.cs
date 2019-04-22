using System;
using System.Collections.Generic;
using System.Text;

namespace _18GhostsGame
{
    class Board
    {
        public void Draw()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.ForegroundColor = ConsoleColor.Blue;

            Console.Write(" _____ _____ _____ _____ _____ _____ \n");
            for (int i = 0; i < 5; i++)
            {
                Console.Write(
                       "|     |     |     |     |     |     |\n");

                for (int j = 0; j < 38; j++)
                {
                    if (j % 6 != 0)
                        Console.Write(" ");
                    else
                        Console.Write("|");
                }

                Console.Write("\n|_____|_____|_____|_____|_____|     |\n");
            }

            Console.Write("                               ‾‾‾‾‾ \n");

            Console.Write("\n\n");

            // 38 chars horizontally
            /* Console.WriteLine(
                " _____ _____ _____ _____ _____ _____ \n" +
                "|1    |2    |3    |4    |5    |     |\n" +
                "|     |     |     |     |     |  D  |\n" +
                "|_____|_____|_____|_____|_____|     |\n" +
                "|6    |7    |8    |9    |10   |  U  |\n" +
                "|     |     |     |     |     |     |\n" +
                "|_____|_____|_____|_____|_____|  N  |\n" +
                "|11   |12   |13   |14   |15   |     |\n" +
                "|     |     |     |     |     |  G  |\n" +
                "|_____|_____|_____|_____|_____|     |\n" +
                "|16   |17   |18   |19   |20   |  E  |\n" +
                "|     |     |     |     |     |     |\n" +
                "|_____|_____|_____|_____|_____|  O  |\n" +
                "|21   |22   |23   |24   |25   |     |\n" +
                "|     |     |     |     |     |  N  |\n" +
                "|_____|_____|_____|_____|_____|_____|");

            */

            Console.ResetColor();
        }

    }
}
