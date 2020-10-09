using System;

namespace TextAdventurez
{
    public enum Command
    {
        none,
        go,
        get,
        drop,
        use,
        look,
        inspect
    }
    public static class InputHandler
    {
        public static Command Translate(ref string text)
        {
            string commandStr = text.Substring(0, text.IndexOf(" "));
            text = text.Substring(commandStr.Length + 1);
            Command command = Command.none;
            try
            {
                command = (Command)Enum.Parse(typeof(Command), commandStr);
            }
            catch (Exception)
            {
                throw;
            }
            return command;
        }
        public static Direction TranslateDirection(string text)
        {
            Direction direction = Direction.none;
            try
            {
                direction = (Direction)Enum.Parse(typeof(Direction), text);
            }
            catch (Exception)
            {
                throw;
            }
            return direction;
        }
        public static Item GetItem(string text)
        {
            return new Item
            {
                Name = text
            };
        }
        public static string[] SplitInTwo(string text)
        {
            try
            {
                return text.Split(new string[] { "on" }, 2, StringSplitOptions.None);
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}