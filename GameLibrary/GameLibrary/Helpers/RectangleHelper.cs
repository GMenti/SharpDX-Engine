using Microsoft.Xna.Framework;

namespace GameLibrary.Helpers
{
    public static class RectangleHelper
    {
        public static Rectangle convertToRectangle(Vector2 position, int width, int height)
        {
            return new Rectangle(position.ToPoint(), new Point(width, height));
        }
    }
}
