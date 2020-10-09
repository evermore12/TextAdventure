using System;
using System.Collections.Generic;
using System.Linq;
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
            Visited.Add(Room);
        }
        public void DoSomething(string text)
        {
            Command command = InputHandler.Translate(ref text);
            switch (command)
            {
                case Command.none:
                    break;
                case Command.go:
                    Go(InputHandler.TranslateDirection(text));
                    break;
                case Command.get:
                    Get(InputHandler.GetItem(text));
                    break;
                case Command.drop:
                    Drop(InputHandler.GetItem(text));
                    break;
                case Command.use:
                    break;
                case Command.look:
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
                Room = Room.Doors.Where(door => door.Orientation == direction).Select(door => door.NextRoom).FirstOrDefault();
            }
            catch (Exception)
            {
                //Can't go there...
                throw;
            }
        }
        public void Get(Item item)
        {
            try
            {
                Inventory.Add(Room.Items.Single(x => x.Name == item.Name));
            }
            catch (Exception)
            {
                //Can't pick up item.name
            }
        }
        public void Drop(Item item)
        {
            try
            {

            }
            catch (Exception)
            {

                throw;
            }
            //Dropped "text" in "room.name"
        }
        public void Use(Item item, Item item2)
        {
            throw new NotImplementedException();
        }
        public void Use(Key key, Door door)
        {

        }
        public void GoBack()
        {
            Room = Visited.ElementAt(Visited.Count - 2);
            Visited.RemoveAt(Visited.Count - 1);
            Console.WriteLine(Room.Description);
        }
    }
}
