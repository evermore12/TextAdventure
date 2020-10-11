using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using TextAdventurez.Resource_Files;
using TextAdventurez.Resource_Files.Items;

namespace TextAdventurez
{
    public class Item
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Count { get; set; } = 1;
        public List<Recipe> Interactions { get; set; }

        public Item()
        {

        }

        public string GetInfo()
        {
            return Description;
        }
        public Item Use(string onItem)
        {
            try
            {
                return Interactions.Single(x => x.On.ToLower() == onItem).Result;
            }
            catch (Exception)
            {
                Console.WriteLine(Messages.item_use_unsuccessful, Name, onItem);
                return null;
            }
        }
    }
}
