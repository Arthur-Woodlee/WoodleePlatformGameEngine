using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Woodlee_Platform_Game_Engine.Input
{
    public class Controls
    {
        private LinkedList<Vector2Command> _decimalCommands;
        private LinkedList<BoolCommand> _boolCommands;

        public Controls()
        {
            _boolCommands = new LinkedList<BoolCommand>();
            _decimalCommands = new LinkedList<Vector2Command>();
        }
        public void SetBoolSensor(string commandName, ReadBoolSensor readBoolSensor)
        {
            foreach (BoolCommand bc in _boolCommands)
            {
                if (bc.Name == commandName)
                {
                    bc.SetSensor(readBoolSensor);
                }
            }
        }
        public bool AddBoolCommand(BoolCommand command)
        {
            foreach (BoolCommand c in _boolCommands)
            {
                if (command.Name.Equals(c.Name))
                {
                    return false; // A command with that name already exists
                }
            }
            _boolCommands.AddLast(command);
            return true;
        }
        public bool AddDecimalCommand(Vector2Command command)
        {
            foreach (Vector2Command c in _decimalCommands)
            {
                if (command.Name.Equals(c.Name))
                {
                    return false; // A command with that name already exists
                }
            }
            _decimalCommands.AddLast(command);
            return true;
        }
        public void ClearCommands()
        {
            _boolCommands = new LinkedList<BoolCommand>();
            _decimalCommands = new LinkedList<Vector2Command>();

        }
        public void UpdateState()
        {
            foreach (BoolCommand c in _boolCommands)
            {
                c.UpdateState();
            }
            foreach (Vector2Command c in _decimalCommands)
            {
                c.UpdateState();
            }
        }
        public Vector2 GetDecimalCommand(string command)
        {
            foreach (Vector2Command c in _decimalCommands)
            {
                if (c.Name == command)
                {
                    return c.GetCommand();
                }
            }
            return new Vector2(0, 0);
        }
        public bool GetBoolCommand(string command)
        {
            foreach (BoolCommand c in _boolCommands)
            {
                if (c.Name == command)
                {
                    return c.GetCommand();
                }
            }
            return false;
        }
        public void PauseCommand(string command, ushort period)
        {
            foreach (Vector2Command dc in _decimalCommands)
            {
                if (command == dc.Name)
                {
                    dc.PauseCommand(period);
                }
            }
            foreach (BoolCommand bc in _boolCommands)
            {
                if (command == bc.Name)
                {
                    bc.PauseCommand(period);
                }
            }
        }
        public LinkedList<string> GetDecimalCommands()
        {
            LinkedList<string> commands = new LinkedList<string>();
            foreach (Vector2Command dc in _decimalCommands)
            {
                commands.AddLast(dc.Name);
            }
            return commands;
        }
        public LinkedList<string> GetBoolCommands()
        {
            LinkedList<string> commands = new LinkedList<string>();
            foreach (BoolCommand bc in _boolCommands)
            {
                commands.AddLast(bc.Name);
            }
            return commands;
        }

    }
}
