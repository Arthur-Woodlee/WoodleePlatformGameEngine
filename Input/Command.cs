using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Woodlee_Platform_Game_Engine.Input
{ 
    public abstract class Command
    {
        protected string _name;
        public Command(string name)
        {
            _name = name;
        }
        public string Name
        {
            get
            {
                return String.Copy(_name);
            }
        }
        public abstract void UpdateState();
        public abstract void PauseCommand(ushort period);
    }
}
