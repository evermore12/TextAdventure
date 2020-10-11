using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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

        public string Go(Direction direction)
        {
            try
            {
                if (direction == Direction.back)
                {
                    Location = Visited.Last();
                    Visited.Remove(Visited.Last()); //To be able to go back multiple times in succession
                    return Location.GetInfo();
                }
                else
                {
                    if (Location.Exits.Single(door => door.Orientation == direction).Locked == true)
                    {
                        return string.Format(Messages.character_go_door_locked);
                    }
                    else
                    {
                        Visited.Add(Location); //Adds current room to the visited list right before going into another room
                        Location = Location.Exits.Single(door => door.Orientation == direction).NextLocation;
                        return Location.GetInfo();
                    }
                }
            }
            catch (Exception)
            {
                return string.Format(Messages.character_go_unsuccessful);
            }
        }
        public string Get(string item)
        {
            try
            {
                Inventory.Add(Location.Items.Single(x => x.Name.ToLower() == item));
                Location.Items.Remove(Location.Items.Single(x => x.Name.ToLower() == item));
                return string.Format(Messages.character_get_successful, item);
            }
            catch (Exception)
            {
                return string.Format(Messages.character_get_unsuccesful, item);
            }
        }
        public string Drop(string item)
        {
            try
            {
                Location.Items.Add(Inventory.Single(x => x.Name.ToLower() == item));
                Inventory.Remove(Inventory.Single(x => x.Name.ToLower() == item));
                return string.Format(Messages.character_drop_successful, item, Location.Name);
            }
            catch (Exception)
            {
                return string.Format(Messages.character_drop_unsuccessful, item);
            }
        }

        public string Use(string byItem, string onItem)
        {
            try
            {
                Inventory.Add(Inventory.Single(x => x.Name.ToLower() == byItem).Use(onItem));
                Inventory.Remove(Inventory.Single(x => x.Name.ToLower() == onItem));
                return string.Format(Messages.character_use_successful);
            }
            catch (Exception)
            {
                return string.Format(Messages.character_use_unsuccesful, byItem);
            }
        }
    }
}
