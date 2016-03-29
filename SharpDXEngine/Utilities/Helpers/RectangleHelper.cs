using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpDXEngine.Utilities.Helpers
{
    static class RectangleHelper
    {
        public static Rectangle convertToRectangle(Vector2 position, int width, int height)
        {
            return new Rectangle(position.ToPoint(), new Point(width, height));
        }
    }
}
