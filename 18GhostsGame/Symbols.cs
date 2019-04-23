using System;
using System.Collections.Generic;
using System.Text;

namespace _18GhostsGame
{
    enum Symbols
    {
        blank = ' ',
        carpet = '·',
        column = '|',
        ghosts1 = 'Φ',
        ghosts2 = 'Ψ',
        ghosts3 = 'Σ',
        mirrors = '¤',
        portalUp = '↑',
        portalDown = '↓',
        portalLeft = '←',
        portalRight = '→'
    }
}

/*
mirrors: 7, 9, 17, 19
rPortal:3
yPortal:15
bPortal:23
 _____ _____ _____ _____ _____ _____ 
|1    |2    |3    |4    |5    |     |
|  b  |  r  | rP  |  b  |  r  |  D  |
|_____|_____|_____|_____|_____|     |
|6    |7    |8    |9    |10   |  U  |
|  y  |  M  |  y  |  M  |  y  |     |
|_____|_____|_____|_____|_____|  N  |
|11   |12   |13   |14   |15   |     |
|  r  |  b  |  r  |  b  | yP  |  G  |
|_____|_____|_____|_____|_____|     |
|16   |17   |18   |19   |20   |  E  |
|  b  |  M  |  y  |  M  |  r  |     |
|_____|_____|_____|_____|_____|  O  |
|21   |22   |23   |24   |25   |     |
|  y  |  r  | bP  |  b  |  y  |  N  |
|_____|_____|_____|_____|_____|_____|
*/
