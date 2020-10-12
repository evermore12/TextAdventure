using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TextAdventurez.Classes;
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
    public class Exit : Entity
    {
        public Direction Orientation { get; set; }
        public int LockId { get; set; }
        public bool Locked { get; set; } = false;
        public Location NextLocation { get; set; }
        public Exit(string name, string description, Direction orientation, int lockId, bool locked = false) : base(name, description)
        {
            Orientation = orientation;
            LockId = lockId;
            Locked = locked;
        }
        public void Unlock(Key key)
        {
            if(key.Id == LockId)
            {
                Locked = false;
                OutputHandler.SetMessage(string.Format("Unlocked {0}", Name));
            }
            else
            {
                OutputHandler.SetMessage("Wrong key");
            }
        }
    }
}
