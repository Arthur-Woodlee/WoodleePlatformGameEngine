using System;

namespace Woodlee_Platform_Game_Engine
{
    public class Rectangle
    {
        private Microsoft.Xna.Framework.Rectangle _xnaRectangle;
        public int X { get { return _xnaRectangle.X; } private set { } }
        public int Y { get { return _xnaRectangle.Y; } private set { } }
        public int Width { get { return _xnaRectangle.Width; } private set { } }
        public int Height { get { return _xnaRectangle.Height; } private set { } }
        public Rectangle(int x, int y, int width, int height)
        {
            if (x < 0 || y < 0 || width < 0 || height < 0)
                throw new ArgumentOutOfRangeException("The arguments 'x', 'y', 'width' and 'height' must be non-negative.");
            if (x > int.MaxValue || y > int.MaxValue || width > int.MaxValue || height > int.MaxValue)
                throw new ArgumentOutOfRangeException("The arguments 'x', 'y', 'width' and 'height' cannot be larger than int.MaxValue.");
            _xnaRectangle = new Microsoft.Xna.Framework.Rectangle(x, y, width, height);
        }
        public bool Contains(Rectangle rectangle)
        {
            Microsoft.Xna.Framework.Rectangle temp = new Microsoft.Xna.Framework.Rectangle(rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height);
            return _xnaRectangle.Contains(temp);
        }
        public bool Contains(int x, int y)
        {
            return _xnaRectangle.Contains(x, y);
        }
        public bool Intersects(Rectangle rectangle)
        {
            Microsoft.Xna.Framework.Rectangle temp = new Microsoft.Xna.Framework.Rectangle(rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height);
            return _xnaRectangle.Intersects(temp);
        }
    }
}
