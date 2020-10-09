using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAdventurez
{
    public class Room
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Door> Doors { get; set; }
        public List<Item> Items { get; set; }
        public bool EndPoint { get; set; }

        public void GetInfo()
        {
            Console.WriteLine(string.Join("\n", Items.Select(items => items.Name)));
        }
    }
}
