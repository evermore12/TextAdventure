using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace TextAdventurez
{
    public class Character
    {
        public string Name { get; set; }
        public Room Room { get; set; }
        public List<Room> Visited { get; set; }
        public List<Item> Inventory { get; set; }

        public Character()
        {
            Room = Repository.Start();
            Visited = new List<Room>();
            Inventory = new List<Item>();
        }

        public void DoSomething(string text)
        {
            Command command = Interpret.Command(ref text);
            switch (command)
            {
                case Command.go:
                    Go(Interpret.Direction(text));
                    break;
                case Command.get:
                    Get(Interpret.Item(text));
                    break;
                case Command.drop:
                    Drop(Interpret.Item(text));
                    break;
                case Command.use:
                    Inventory.Single(item => item.Name.ToLower() == "silver key").Use(new Item());
                    break;
                case Command.look:
                    Room.GetInfo();
                    break;
                case Command.inspect:
                    break;
                default:
                    break;
            }
        }

        public void Go(Direction direction)
        {
            try
            {
                if (direction == Direction.back)
                {
                    Room = Visited.Last();
                    Visited.Remove(Visited.Last()); //To be able to go back multiple times
                    Room.GetInfo();
                }
                else
                {
                    if (Room.Doors.Single(door => door.Orientation == direction).Locked == true)
                    {
                        Console.WriteLine("The door is locked");
                    }
                    else
                    {
                        Visited.Add(Room); //Adds current room to the visited list right before going into another room
                        Room = Room.Doors.Single(door => door.Orientation == direction).NextRoom;
                        Room.GetInfo();
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Can't go there");
            }
        }

        public void Get(Item item)
        {
            try
            {
                Inventory.Add(Room.Items.Single(x => x.Name.ToLower() == item.Name));
                Room.Items.Remove(Room.Items.Single(x => x.Name.ToLower() == item.Name));
            }
            catch (Exception)
            {
                Console.WriteLine("Can't pick up \"{0}\"", item.Name);
            }
        }

        public void Drop(Item item)
        {
            try
            {
                Room.Items.Add(Inventory.Single(x => x.Name.ToLower() == item.Name));
                Inventory.Remove(Inventory.Single(x => x.Name.ToLower() == item.Name));
            }
            catch (Exception)
            {
                Console.WriteLine("Can't drop {0}", item.Name);
            }

            Console.WriteLine("Dropped {0} in {1}", item.Name, Room.Name);
        }
    }
}
