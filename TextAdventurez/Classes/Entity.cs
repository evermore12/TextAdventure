using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAdventurez.Classes
{
    public abstract class Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Entity(string name, string description)
        {
            Name = name;
            Description = description;
        }
        public virtual string GetInfo()
        {
            return Description;
        }
    }
}
