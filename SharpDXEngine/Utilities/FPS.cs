using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameClient.Utilities
{
    static class FPS
    {
        private static int frameRate = 0;
        private static int _FPS = 0;
        public static SpriteFont fontTexture = MainGame.engineContent.Load<SpriteFont>("Fonts/myFont");

        public static void Update(GameTime gameTime)
        {
            frameRate++;
            if (gameTime.TotalGameTime.Seconds > 0) {
                _FPS = frameRate / gameTime.TotalGameTime.Seconds;
            }
        }

        public static void Draw(GameTime gameTime)
        {
            MainGame.spriteBatch.DrawString(
                fontTexture,
                "FPS Draw: " + _FPS,
                new Vector2(10, 10),
                Color.Yellow
            );
        }
    }
}
