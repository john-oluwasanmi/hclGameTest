using hcl.game.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace hcl.game.Model
{
    public class Player
    {
        public SelectionType CurrentSelection { get; set; }
        public List<SelectionType> Selections { get; set; } = new List<SelectionType>();
        public string Name { get; set; }
        public int Id { get; set; }
        public PlayerType PlayerType { get; set; }
    }
}
