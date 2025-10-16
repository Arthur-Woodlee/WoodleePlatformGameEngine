using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Woodlee_Platform_Game_Engine.Input
{
    public class Vector2Command : Command
    {
        public Vector2Command(string name) : base(name) { }
        public Vector2 GetCommand()
        {
            throw new NotImplementedException();
        }

        public override void PauseCommand(ushort period)
        {
            throw new NotImplementedException();
        }

        public override void UpdateState()
        {
            throw new NotImplementedException();
        }
    }
}
