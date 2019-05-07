using System;
using System.Collections.Generic;
using System.Text;

namespace _18GhostsGame
{
    static class Inputs
    {
        public static string PlayerInput(string message)
        {
            Console.WriteLine(message);
            string playerInput = Console.ReadLine();

            return playerInput;
        }
    }
}
