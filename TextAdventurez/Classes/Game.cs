using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using TextAdventurez.Resource_Files;

namespace TextAdventurez
{
    public class Game
    {
        public Character Character { get; set; }

        public string UserCommand(string text)
        {
            Command command = Interpret.Command(ref text);
            switch (command)
            {
                case Command.go:
                    return Character.Go(Interpret.Direction(text));
                case Command.get:
                    return Character.Get(text);
                case Command.drop:
                    return Character.Drop(text);
                case Command.use:
                    return Use(text);
                case Command.look:
                    return Character.Location.GetInfo(true);
                case Command.inspect:
                    return Inspect(text);
            }
            return null;
        }
        public string Inspect(string text)
        {
            try
            {
                if (Character.Location.Exits.Any(x => x.Name.ToLower() == text))
                {
                    return Character.Location.Exits.Single(x => x.Name.ToLower() == text).GetInfo();
                }
                else if (Character.Inventory.Any(x => x.Name.ToLower() == text))
                {
                    return Character.Inventory.Single(x => x.Name.ToLower() == text).GetInfo();
                }
                else if (Character.Location.Items.Any(x => x.Name.ToLower() == text))
                {
                    return Character.Location.Items.Single(x => x.Name.ToLower() == text).GetInfo();
                }
                {
                    //NOT FINISHED
                    return "";
                }
            }
            catch (Exception)
            {
                //NOT FINISHED
                return "";
            }
        }
        public string Use(string text)
        {
            string[] values = Interpret.Split(text, " on ", 2);

            try
            {
                if (Character.Location.Exits.Any(x => x.Name.ToLower() == values[1]))
                {
                    return Character.Location.Exits.Single(x => x.Name.ToLower() == values[1])
                    .Unlock
                    ((Key)Character.Inventory.Single(x => x.Name.ToLower() == values[0]));
                }
                else if (Character.Inventory.Any(x => x.Name.ToLower() == values[1]))
                {
                    return Character.Use(values[0], values[1]);
                }
                else
                {
                    return string.Format(Messages.game_use_unsuccessful, values[1]);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
