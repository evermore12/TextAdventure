using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAdventurez
{
    public class Key : Item
    {
        public int Id { get; set; }
        public Key(string name, string description, int id) : base(name, description)
        {
            Id = id;
        }
    }
}
