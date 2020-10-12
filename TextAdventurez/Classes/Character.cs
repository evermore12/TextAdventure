using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TextAdventurez.Classes;
using TextAdventurez.Resource_Files;

namespace TextAdventurez
{
    public class Character
    {
        public string Name { get; set; }
        public Location Location { get; set; }
        public List<Location> Visited { get; set; }
        public List<Item> Inventory { get; set; }

        public Character()
        {
            Location = Repository.Start();
            Inventory = new List<Item>();
            Visited = new List<Location>();
        }

        public void Go(Direction direction)
        {
            try
            {
                if (direction == Direction.back)
                {
                    Location = Visited.Last();
                    Visited.Remove(Visited.Last()); //To be able to go back multiple times in succession
                    OutputHandler.SetMessage(Location.GetInfo());
                }
                else
                {
                    if (Location.Exits.Single(door => door.Orientation == direction).Locked == true)
                    {
                        OutputHandler.SetMessage("The door is locked");
                    }
                    else
                    {
                        Visited.Add(Location); //Adds current room to the visited list right before going into another room
                        Location = Location.Exits.Single(door => door.Orientation == direction).NextLocation;
                        OutputHandler.SetMessage(Location.GetInfo());
                    }
                }
            }
            catch (Exception)
            {
                OutputHandler.SetMessage("You can't go there");
            }
        }
        public void Get(string item)
        {
            try
            {
                Inventory.Add(Location.Items.Single(x => x.Name.ToLower() == item));
                Location.Items.Remove(Location.Items.Single(x => x.Name.ToLower() == item));
                OutputHandler.SetMessage(string.Format("Picked up {0}", item));
            }
            catch (Exception)
            {
                OutputHandler.SetMessage(string.Format("Can't pick up {0}", item));
            }
        }
        public void Drop(string item)
        {
            try
            {
                Location.Items.Add(Inventory.Single(x => x.Name.ToLower() == item));
                Inventory.Remove(Inventory.Single(x => x.Name.ToLower() == item));
                OutputHandler.SetMessage(string.Format("Dropped {0} in {1}", item, Location));
            }
            catch (Exception)
            {
                OutputHandler.SetMessage(string.Format("Couldn't drop {0}", item));
            }
        }
        public void Inspect(string text)
        {
            if (Location.Exits.Any(x => x.Name.ToLower() == text))
            {
                OutputHandler.SetMessage(Location.Exits.Single(x => x.Name.ToLower() == text).GetInfo());
            }
            else if (Inventory.Any(x => x.Name.ToLower() == text))
            {
                OutputHandler.SetMessage(Inventory.Single(x => x.Name.ToLower() == text).GetInfo());
            }
            else if (Location.Items.Any(x => x.Name.ToLower() == text))
            {
                OutputHandler.SetMessage(Location.Items.Single(x => x.Name.ToLower() == text).GetInfo());
            }
            else
            {
                OutputHandler.SetMessage(string.Format("Can't find {0}", text));
            }

        }
    }
}
