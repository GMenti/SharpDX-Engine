using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameClient.Utilities
{
    static class FPS
    {
        private static int fpsUpdating;
        private static int countframesUpdating;
        private static int timerUpdate;

        private static int fpsDrawning;
        private static int countframesDrawning;
        private static int timerDraw;

        private static SpriteFont fontTexture = MainGame.engineContent.Load<SpriteFont>("Fonts/myFont");

        
        public static void Update()
        {
            countframesUpdating++;

            if (MainGame.totalTime.Seconds < timerUpdate) {
                return;
            }

            fpsUpdating = countframesUpdating;
            countframesUpdating = 0;
            timerUpdate = MainGame.totalTime.Seconds + 1;
        }

        public static void Draw()
        {
            MainGame.spriteBatch.DrawString(
                fontTexture,
                "FPS Drawing: " + fpsDrawning + "\nFPS Updating: " + fpsUpdating,
                new Vector2(10, 10),
                Color.Black
            );

            countframesDrawning++;

            if (MainGame.totalTime.Seconds < timerDraw) {
                return;
            }

            fpsDrawning = countframesDrawning;
            countframesDrawning = 0;
            timerDraw = MainGame.totalTime.Seconds + 1;
        }
    }
}
