using System;
using System.Collections.Generic;
using System.Text;

namespace _18GhostsGame
{
    class Player
    {
        private Ghosts ghosts;

        private byte playerNum;

        public byte[,] EnemyGhosts { set; get; }

        // Constructor
        public Player(byte playerNum)
        {
            ghosts = new Ghosts();

            this.playerNum = playerNum == 1 ? (byte)(1) : (byte)(2);
            EnemyGhosts =
            new byte[3, 3] { { 0, 2, 0 }, { 0, 0, 0 }, { 0, 0, 0 } };
        }

        public void ResetGhosts()
        {
            ghosts.ResetGhosts();
        }

        public void Action()
        {
            ConsoleKeyInfo input;
            bool chosen = false;

            while (!chosen)
            {
                Render.ActionMenu();

                input = Console.ReadKey();

                Render.Line();

                switch (input.Key)
                {
                    // Player wants to Move
                    case ConsoleKey.M:
                    case ConsoleKey.D1:
                        chosen = !chosen;
                        ghosts.Move(EnemyGhosts);
                        break;

                    // Player wants to Place
                    case ConsoleKey.P:
                    case ConsoleKey.D2:
                        chosen = !chosen;
                        ghosts.Place(EnemyGhosts);
                        //Render.HelpPlacing();
                        break;

                    // Player wants Help
                    case ConsoleKey.H:
                    case ConsoleKey.D3:
                        Render.HelpAction();
                        break;
                }
            }
        }

        public byte GetPlayerNum() => playerNum;

        public byte[,] GetGhosts() => ghosts.AllGhosts;


    }
}
