using GameClient;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SharpDXEngine.Frames.Components
{
    class Picture
    {
        private Texture2D texture;
        private Vector2 position;

        public Picture(Vector2 position)
        {
            this.position = position;
        }

        public void Load()
        {
            this.texture = MainGame.engineContent.Load<Texture2D>("GUI/Menu/background");
        }

        public void Draw()
        {
            MainGame.spriteBatch.Draw(
                this.texture,
                this.position,
                Color.White
            );
        }
    }
}
