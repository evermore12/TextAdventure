using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using TextAdventurez;
using TextAdventurez.Classes;
using TextAdventurez.Resource_Files;
using TextAdventurez.Resource_Files.Items;

namespace TextAdventurez
{
    public class Game
    {
        public Character Character { get; set; }
        public List<Recipe> ItemInteractions { get; set; }

        public Game()
        {
            ItemInteractions = Repository.GetAllRecipes();
        }

        public void UserCommand(string text)
        {

            Command command = Interpret.Command(ref text);
            switch (command)
            {
                case Command.go:
                    Character.Go(Interpret.Direction(text));
                    break;
                case Command.get:
                    Character.Get(text);
                    break;
                case Command.drop:
                    Character.Drop(text);
                    break;
                case Command.use:
                    Use(text);
                    break;
                case Command.look:
                    OutputHandler.SetMessage(Character.Location.GetInfo(true));
                    break;
                case Command.inspect:
                    Character.Inspect(text);
                    break;
            }

        }
        public void Use(string text)
        {
            string[] values = Interpret.Split(text, " on ", 2);

            try
            {
                if (ItemInteractions.Any(x => x.By.Name.ToLower() == values[0] && x.On.Name.ToLower() == values[1]))
                {
                    Character.Inventory.Remove(Character.Inventory.Single(x => x.Name.ToLower() == values[1]));
                    Character.Inventory.Add(ItemInteractions.Single(x => x.By.Name.ToLower() == values[0] && x.On.Name.ToLower() == values[1]).Result);
                    OutputHandler.SetMessage(String.Format("You used {0} on {1} and received {2}", values[0], values[1], Character.Inventory.Last().Name));
                }
                else if (Character.Inventory.Any(x => x.Name.ToLower() == values[0]) && Character.Location.Exits.Any(x => x.Name.ToLower() == values[1]))
                {
                    Character.Location.Exits.Single(x => x.Name.ToLower() == values[1]).Unlock((Key)Character.Inventory.Single(x => x.Name.ToLower() == values[0]));
                }
                else
                {
                    OutputHandler.SetMessage(string.Format("Can't use {0} on {1}", values[0], values[1]));
                }
            }
            catch (Exception)
            {
                OutputHandler.SetMessage("Invalid arguments");
            }

        }
    }
}

