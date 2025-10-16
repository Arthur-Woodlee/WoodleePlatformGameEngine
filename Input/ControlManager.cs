using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Woodlee_Platform_Game_Engine.Input
{
    public class ControlManager
    {
        private Controls _userControls;
        public ControlManager(Controls userControls)
        {
            _userControls = userControls;
        }
        public Vector2 GetDecimalCommand(string command)
        {
            return _userControls.GetDecimalCommand(command);
        }
        public bool GetBoolCommand(string command)
        {
            return _userControls.GetBoolCommand(command);
        }
        public void PauseCommand(string command, ushort period)
        {
            _userControls.PauseCommand(command, period);
        }
    }
}
