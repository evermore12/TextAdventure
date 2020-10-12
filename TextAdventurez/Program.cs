using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TextAdventurez.Classes;

namespace TextAdventurez
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Game game = new Game();

                game.Character = new Character
                {
                    Name = "Ezra"
                };

                while (game.Character.Location.EndPoint == false)
                {
                    try
                    {
                        string input = Console.ReadLine().ToLower();

                        try
                        {
                            game.UserCommand(input);
                            OutputHandler.DisplayMessage();
                        }
                        catch (Exception exception)
                        {
                            Console.WriteLine(exception.Message);
                        }
                    }
                    catch
                    {
                        Console.WriteLine("Invalid input");
                    }
                }

                Console.WriteLine("You have reached the end of the game");
                Console.ReadLine();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                throw;
            }


        }
    }
}


