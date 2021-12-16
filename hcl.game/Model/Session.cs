using System;
using System.Collections.Generic;
using System.Text;

namespace hcl.game.Model
{
    public class Session
    {

        public Player SessionOverallWinner { get; set; }
        public List<Game> Games { get; set; } = new List<Game>();
    }
}
