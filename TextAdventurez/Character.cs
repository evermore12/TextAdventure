using System;
using System.Collections.Generic;
using System.Linq;
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
                    Get(text);
                    break;
                case Command.drop:
                    Drop(text);
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
            if (direction == Direction.back) GoBack();
            
            else if (Room.Doors.Any(door => door.Orientation == direction) == true)
            {
                //IF DOOR IS UNLOCKED /*if(Room.Doors.Select(door => door.Locked).Where(door => door.)*/
                Room = (Room.Doors.Where(door => door.Orientation == direction).Select(door => door.NextRoom).FirstOrDefault());
                Console.WriteLine(Room.Description);
                Visited.Add(Room);
                
            }
            else
            {
                Console.WriteLine("Cant go there");
            }
        }
        public void Get(string text)
        {
            Inventory.Add(Room.Items.Where(item => item.Name == text).FirstOrDefault());

            if (Inventory.Last().Name == text)
            {
                //Picked up "text"
            }
            else
            {
                //"Sorry, couldn't add that item
            }
        }
        public void Drop(string text)
        {
            try
            {
                Room.Items.Add(Inventory.Single(Item => Item.Name == text));
                Inventory.Remove(Inventory.Single(item => item.Name == text));
            }
            catch (Exception)
            {
                throw;
            }
            //Dropped "text" in "room.name"
        }
        public void Use(string text)
        {
            throw new NotImplementedException();
            string[] values = InputHandler.SplitInTwo(text);

            
                //Room.Doors.Where(door => door.Name == values[1]).Select(door => door.LockId)

            try
            {
                Room.Doors.Where(door => door.Name == values[1]);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void GoBack()
        {
            Room = Visited.ElementAt(Visited.Count - 2);
            Visited.RemoveAt(Visited.Count - 1);
            Console.WriteLine(Room.Description);
        }
    }
}
