using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TextAdventurez.Classes;
using TextAdventurez.Resource_Files.Exits;

namespace TextAdventurez
{
    public class Location : Entity
    {
        public List<Exit> Exits { get; set; }
        public List<Item> Items { get; set; }
        public bool EndPoint { get; set; } = false;
        public Location(string name, string description, bool endPoint = false) : base(name, description)
        {
            EndPoint = endPoint;
            Exits = new List<Exit>();
            Items = new List<Item>();
        }

        /// <param name="extendedInfo">True to return description, items and exits.</param>
        public string GetInfo(bool extendedInfo)
        {
            string message = base.GetInfo();

            if (extendedInfo)
            {
                if (Exits.Count > 0) message += "\nExits:\n-" + string.Join("\n-", Exits.Select(exit => exit.Name));

                if (Items.Count > 0) message += "\nItems:\n-" + string.Join("\n-", Items.Select(item => item.Name));
            }

            return message;
        }
    }
}

