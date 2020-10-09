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
    public static class Interpret
    {
        public static Command Command(ref string text)
        {
            try
            {
                if (text.IndexOf(" ") == -1)
                {
                    return (Command)Enum.Parse(typeof(Command), text);
                }
                else
                {
                    string commandStr = text.Substring(0, text.IndexOf(" "));
                    text = text.Substring(commandStr.Length + 1);
                    return (Command)Enum.Parse(typeof(Command), commandStr);
                }
            }
            catch (Exception)
            {
                throw new Exception("Could not recognize command");
            }
        }
        public static Direction Direction(string text)
        {
            try
            {
                return (Direction)Enum.Parse(typeof(Direction), text);
            }
            catch (Exception)
            {
                throw new Exception("Could not recognize direction");
            }
        }
        public static Item Item(string text)
        {
            return new Item
            {
                Name = text
            };
        }
        public static Key Key(string text)
        {
            return new Key
            {
                Name = text
            };
        }
        public static string[] Split(string text, string separator, int count)
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
        public static string Word(string text, int sentenceRank) //Where in  the sentence
        {
            return (string)text.Split(' ').GetValue(sentenceRank);
        }

    }
}