using System;
using System.Collections.Generic;
using System.Text;

namespace _18GhostsGame
{
    // Esta classe vai ter 2 metodos
    // 1. que so verifica, em caso de conflito qual o fantasma que ganha
    // 2. que retorna true ou false caso o fantasma se possa mover ou nao 

    // color = Color of the ghost:  0 red > 1 blue > 2 yellow
    class GhostInteractions
    {
        // victim 1
        // attacker 0
        public bool Conflict(byte[] attacker, byte[] victim)
        {
            bool attackerWins = false;
            byte attackerColor = attacker[0];
            byte victimColor = victim[0];

            attackerColor++;

            if (attackerColor > victimColor || (attackerColor == 1 && victimColor == 2))
                attackerWins = false;
            else
                attackerWins = true;

            Console.WriteLine("WINS: " + attackerWins);
            return attackerWins;
        }
    }                                                                          
}
