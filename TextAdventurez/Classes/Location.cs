using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TextAdventurez.Resource_Files.Exits;

namespace TextAdventurez
{
    public class Location
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Exit> Exits { get; set; }
        public List<Item> Items { get; set; }
        public bool EndPoint { get; set; } = false;
        public Location()
        {

        }
        public Location(Location location)
        {
            Name = location.Name;
            Description = location.Description;
            Exits = location.Exits;
            Items = location.Items;
            EndPoint = location.EndPoint;
        }

        /// <param name="extendedInfo">False by default, True for extended information</param>
        public string GetInfo(bool extendedInfo = false)
        {
            if (!extendedInfo)
            {
                return Description;
            }
            else
            {
                string message = "";
                if(Exits.Count > 0) message += string.Join("\n", Exits.Select(exit => exit.Name));

                if(Items.Count > 0) message += "\n" + string.Join("\n", Items.Select(items => items.Name));

                return message;
            }
        }
    }
}
