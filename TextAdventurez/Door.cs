using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAdventurez
{
    public enum Direction
    {
        none,
        north,
        east,
        south,
        west,
        back
    }
    public class Door
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Direction Orientation { get; set; }
        public Room NextRoom { get; set; }
        public int LockId { get; set; }
        public bool Locked { get; set; } = false;
    }
}
