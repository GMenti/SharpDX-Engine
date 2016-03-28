using System;

namespace SharpDXEngine.Utilities.Helpers
{
    static class NumberHelper
    {
        public static int getRandom(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }
        public static int getCenterX(int width, int size)
        {
            return (width / 2) - (size / 2);
        }
    }
}
