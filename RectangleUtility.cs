
namespace Woodlee_Platform_Game_Engine
{
    public static class RectangleUtility
    {
        public static Vector2 GetBottomRight(Rectangle rectangle)
        {
            return new Vector2(rectangle.X + rectangle.Width - 1, rectangle.Y + rectangle.Height - 1);
        }
        public static Vector2 GetBottomLeft(Rectangle rectangle)
        {
            return new Vector2(rectangle.X, rectangle.Y + rectangle.Height - 1);
        }
        public static Vector2 GetTopRight(Rectangle rectangle)
        {
            return new Vector2((rectangle.X + rectangle.Width), rectangle.Y);
        }
        public static bool Equal(Rectangle a, Rectangle b)
        {
            if (a.X == b.X && a.Y == b.Y && a.Width == b.Width && a.Height == b.Height)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
