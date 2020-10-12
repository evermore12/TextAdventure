using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using TextAdventurez.Classes;
using TextAdventurez.Resource_Files;
using TextAdventurez.Resource_Files.Items;

namespace TextAdventurez
{
    public class Item : Entity
    {
        public int Count { get; set; } = 1;
        public Item(string name, string description) : base(name, description)
        {

        }
    }
}
