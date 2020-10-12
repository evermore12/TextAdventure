using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAdventurez.Classes
{
    public static class OutputHandler
    {
        private static string Message { get; set; }

        public static void SetMessage(string text)
        {
            Message = text;
        }
        public static void DisplayMessage()
        {
            Console.WriteLine(Message);
        }
    }
}
