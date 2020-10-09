using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace TextAdventurez
{
    public class Item
    {
        public string Name { get; set; }
        public string Descrption { get; set; }
        public int Count { get; set; } = 1;
        public List<Recipe> Interactions { get; set; }

        public void Use()
        {

        }
    }
}
