using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextAdventurez.Resource_Files;

namespace TextAdventurez
{
    public enum Direction
    {
        none,
        north,
        east,
        south,
        west,
        back
    }
    public class Exit
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Direction Orientation { get; set; }
        public int LockId { get; set; }
        public bool Locked { get; set; } = false;
        public Location NextLocation { get; set; }
        public Exit(Exit exit)
        {
            Name = exit.Name;
            Description = exit.Description;
            Orientation = exit.Orientation;
            LockId = exit.LockId;
            Locked = exit.Locked;
            NextLocation = exit.NextLocation;
        }
        public Exit()
        {

        }
        public string GetInfo()
        {
            return Description;
        }
        public string Unlock(Key key)
        {
            if(key.Id == LockId)
            {
                Locked = false;
                return string.Format(Messages.exit_unlock_successful, Name);
            }
            else
            {
                return string.Format(Messages.exit_unlock_successful);
            }
        }
    }
}
