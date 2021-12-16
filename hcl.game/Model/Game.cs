using hcl.game.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace hcl.game.Model
{
    public class Game
    {
        public Player Player1 { get; set; }
        public Player Player2 { get; set; }

        public Player GameWinnner { get; set; }

    }
}
