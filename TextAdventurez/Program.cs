using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TextAdventurez
{
    class Program
    {
        static void Main(string[] args)
        {

            Character character = new Character
            {
                Name = "Ezra"
            };

            while (true)
            {
                try
                {
                    string input = Console.ReadLine().ToLower();

                    try
                    {
                       character.DoSomething(input);
                    }
                    catch (Exception exception)
                    {
                        Console.WriteLine(exception.Message);
                    }
                }
                catch
                {
                    //Wrong input format
                }
            }
        }
    }
}
