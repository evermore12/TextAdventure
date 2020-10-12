using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAdventurez
{
    //https://crafting.thedestruc7i0n.ca/
    public class Recipe
    {
        public Item By { get; set; }
        public Item On { get; set; }
        public Item Result { get; set; }
        public string Effect { get; set; }

    }
}
