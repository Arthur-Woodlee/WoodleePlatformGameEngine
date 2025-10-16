using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Woodlee_Platform_Game_Engine
{
    public interface ISceneObject
    {
        void Update(ushort updateCycleLength, ushort cycleNumber);
        void Draw();
        Vector2 Intersects(Vector2 Vector2); // return null on no intersection
        Rectangle Intersects(Rectangle boundingBox); // return null on no intersection
        //bool VacateIntersection(LinkedList<string> sceneObjectId, Rectangle inquirer, bool vacate);
    }
}
