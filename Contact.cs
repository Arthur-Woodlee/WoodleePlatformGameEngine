using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Woodlee_Platform_Game_Engine
{
    public class Contact
    {
        public bool NewPositionAllowed;
        public LinkedList<string> SceneObjectID;
        public Contact(bool NewPositionAllowed, LinkedList<string> SceneObjectID)
        {
            this.NewPositionAllowed = NewPositionAllowed;
            this.SceneObjectID = SceneObjectID;
        }
    }
}
