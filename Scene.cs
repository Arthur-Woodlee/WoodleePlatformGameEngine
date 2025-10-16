using System.Collections.Generic;

namespace Woodlee_Platform_Game_Engine
{
    public class Scene
    {
        
        private LinkedList<ISceneObject> _sceneObjects;
        private ushort _iterations { get; set; }
        public ushort Gravity { get; private set; } // TODO: Perhaps each SceneObject should have it's own gravity?

        public Scene(ushort interations, ushort gravity)
        {
            Gravity = gravity;
            _iterations = interations; // Iterations are the number of updates each scene object will have available to them when UpdateScene is called.
            _sceneObjects = new LinkedList<ISceneObject>();
        }
        public void UpdateScene()
        {
            for (ushort iteration = 1; iteration < _iterations + 1; iteration++)
            {
                foreach (ISceneObject sceneObject in _sceneObjects)
                {
                    sceneObject.Update(_iterations, iteration);
                }
            }
        }
        public void DrawScene()
        {
            foreach (ISceneObject sceneObject in _sceneObjects)
            {
                sceneObject.Draw();
            }
        }
        public void AddSceneObject(ISceneObject updateable)
        {
            _sceneObjects.AddFirst(updateable);
        }
        public Vector2 IsCollision(Vector2 vector2, ISceneObject inquirer)
        {
            // TODO: throw new System.Exception("Do we need to check for collisions that are very far away?");
            foreach (ISceneObject sceneObject in _sceneObjects)
            {
                if (inquirer != sceneObject)
                {
                    Vector2 intersection = sceneObject.Intersects(vector2);
                    if (intersection != null)
                    {
                        return intersection;
                    }
                }
            }
            return null;
        }
        public Rectangle IsCollision(Rectangle boundingBox, ISceneObject inquirer)
        {
            // TODO: throw new System.Exception("Do we need to check for collisions that are very far away?");
            foreach (ISceneObject sceneObject in _sceneObjects)
            {
                if (inquirer != sceneObject)
                {
                    Rectangle collision = sceneObject.Intersects(boundingBox);
                    if (collision != null)
                    {
                        return collision;
                    }
                }
            }
            return null;
        }
        public LinkedList<Contact> MakeContactWithSceneObjects(Rectangle boundingBox, ISceneObject inquirer, bool vacate)
        {
            throw new System.NotImplementedException();
            //LinkedList<Contact> contacts = new LinkedList<Contact>();
            //foreach (ISceneObject sceneObject in _sceneObjects)
            //{
            //    if (inquirer != sceneObject)
            //    {
            //        Rectangle collision = sceneObject.Intersects(boundingBox);
            //        if (collision != null)
            //        {
            //            Contact contact = sceneObject.VacateIntersection(inquirer.Id(), boundingBox, vacate)
            //                              ? contact = new Contact(true, sceneObject.Id())
            //                              : contact = new Contact(false, sceneObject.Id());
            //            contacts.AddLast(contact);
            //        }
            //    }
            //}
            //return contacts;
        }
    }
}
