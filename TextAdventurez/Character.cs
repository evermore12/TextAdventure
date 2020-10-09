using System;
using System.Collections.Generic;
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
                    string[] values = Interpret.Split(text, "on", 2);
                    break;
                case Command.look:
                    Look();
                    break;
                case Command.inspect:
                    break;
                default:
                    break;
            }
        }
        private void Go(Direction direction)
        {
            try
            {
                if (direction == Direction.back)
                {
                    Room = Visited.Last();
                    Visited.Remove(Visited.Last()); //To be able to go back multiple times
                }
                else
                {
                    if(Room.Doors.Single(door => door.Orientation == direction).Locked == true)
                    {
                        Console.WriteLine("The door is locked");
                    }
                    else
                    {
                        Visited.Add(Room); //Adds current room to the visited list right before going into another room
                    }
                }

                Console.WriteLine(Room.Description);
            }
            catch (Exception)
            {
                Console.WriteLine("Can't go there");
            }
        }
        private void Get(Item item)
        {
            try
            {
                Inventory.Add(Room.Items.Single(x => x.Name == item.Name));
                Room.Items.Remove(Room.Items.Single(x => x.Name == item.Name));
            }
            catch (Exception)
            {
                Console.WriteLine("Can't pick up \"{0}\"", item.Name);
                //Can't pick up item.name
            }
        }
        private void Drop(Item item)
        {
            try
            {
                Room.Items.Add(Inventory.Single(x => x.Name == item.Name));
                Inventory.Remove(Inventory.Single(x => x.Name == item.Name));
            }
            catch (Exception)
            {
                Console.WriteLine("Can't drop {0}", item.Name);
            }

            Console.WriteLine("Dropped {0} in {1}", item.Name, Room.Name);
        }
        private void Use(Item item, Item item2)
        {
            throw new NotImplementedException();
        }
        private void Use(Key key, Door door)
        {
            throw new NotImplementedException();
        }
        private void Look()
        {
            Console.WriteLine(Room.Description);
        }
        private void GoBack()
        {
            Room = Visited.Last();
            Console.WriteLine(Room.Description);
        }
    }
}
